using Microsoft.Data.Sqlite;
using System.Windows.Forms;
using WFPW05.Forms;
using WFPW05.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace WFPW05
{
    public partial class LoginForm : Form
    {
        CAPTCHA captcha = new CAPTCHA();
        string text;
        int error = 0;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void ButtonGenerate_Click(object sender, EventArgs e) //генерация капчи
        {
            byte[] captchaBytes = captcha.CreateCaptchaBytes(200, 100, out text);

            using (MemoryStream ms = new MemoryStream(captchaBytes))
            {
                Image tempImage = Image.FromStream(ms);
                if (CaptchaBox.Image != null)
                {
                    CaptchaBox.Image.Dispose();
                }
                CaptchaBox.Image = tempImage;
            }
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            if (CAPTCHAInput.Text == text) //проверка капчи
            {
                string login = UserLogin.Text.Trim();
                string password = UserPassword.Text;

                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)) //Проверка пустоты
                {
                    MessageBox.Show("Логин или пароль не введены!");
                    ErrorBlock(error);
                    return;
                }

                try
                {
                    var dbService = new DBService();
                    bool isAuthenticated = false;

                    using (var connection = dbService.GetConnection())
                    {
                        //Получаем хеш пользователя по Login
                        string sql = "SELECT PasswordHash FROM Users WHERE Login = @login";
                        using (var command = new SqliteCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@login", login);

                            var result = command.ExecuteScalar();
                            if (result != null)
                            {
                                string storedHash = result.ToString();

                                //Проверяем пароль
                                if (PasswordHasher.VerifyPassword(password, storedHash))
                                {
                                    isAuthenticated = true;
                                }
                            }
                        }

                        //Логируем попытку входа
                        LogAttemptToDb(connection, login, isAuthenticated);

                        //Обработка результата
                        if (isAuthenticated)
                        {
                            string role;
                            sql = "SELECT RID FROM Users WHERE LOGIN = @login";
                            using (var command = new SqliteCommand(sql, connection))
                            {
                                command.Parameters.AddWithValue("@login", login);
                                var result = command.ExecuteScalar();
                                role = result.ToString();
                            }

                            sql = "SELECT RoleName FROM Roles WHERE RID = @Role";
                            using (var command = new SqliteCommand(sql, connection))
                            {
                                command.Parameters.AddWithValue("@Role", role);
                                var result = command.ExecuteScalar();
                                role = result.ToString();
                            }
                            MainForm MF = new MainForm(role, login, this);
                            MF.Show();
                            //Очистка значений полей
                            UserLogin.Text = "";
                            UserPassword.Text = "";
                            CAPTCHAInput.Text = "";
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль!");
                            ErrorBlock(error++);
                            CAPTCHAInput.Text = "";
                            ButtonGenerate.PerformClick(); //Обновление капчи если неверно
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при входе: {ex.Message}");
                }
            }

            else //Обновление капчи если неверно
            {
                ButtonGenerate.PerformClick();
                MessageBox.Show("CAPTCHA введена неверно", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ErrorBlock(error++);
                CAPTCHAInput.Text = "";
            }
        }

        private async Task ErrorBlock(int error)
        {
            if (error > 2)
            {
                MessageBox.Show("Слишком много попыток, подождите", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ButtonAccept.Enabled = false; //Блокируем кнопку
                await Task.Delay(5000); //Асинхронное ожидание чтобы интерфейс не вис
                ButtonAccept.Enabled = true;
                error = 0;
            }
        }

        private void LogAttemptToDb(SqliteConnection connection, string login, bool isSuccess) //Логирование попыток входа
        {
            string formattedDate = DateTime.Now.ToString("HH:mm_dd.MM.yy");

            string sqlLog = @"
                INSERT INTO Logins (UID, DateTime, Success) 
                SELECT UID, @date, @success FROM Users WHERE Login = @login";

            using (var command = new SqliteCommand(sqlLog, connection))
            {
                command.Parameters.AddWithValue("@date", formattedDate);
                command.Parameters.AddWithValue("@success", isSuccess ? "Да" : "Нет");
                command.Parameters.AddWithValue("@login", login);
                command.ExecuteNonQuery();
            }
        }

        private void CrtAccLabel_Click(object sender, EventArgs e)
        {
            RegistrationForm rf = new RegistrationForm(); //диалог вместо закрытия тк нужно будет вернутся
            rf.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}