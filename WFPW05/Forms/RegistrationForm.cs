using Microsoft.Data.Sqlite;
using WFPW05.Services;

namespace WFPW05.Forms
{
    public partial class RegistrationForm : Form
    {
        CAPTCHA captcha = new CAPTCHA();
        string text;
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            if (CAPTCHAInput.Text == text)
            {
                if (UserPassword.Text == PasswordConfirm.Text)
                {
                    string login = UserLogin.Text.Trim();
                    string email = UserEmail.Text.Trim();
                    string password = UserPassword.Text;
                    int RoleId = 1; //user по стандарту

                    var validation = PasswordHasher.ValidatePasswordStrength(password);

                    if (!validation.IsValid)
                    {
                        // Если проверка не прошла, выводим ошибку и прерываем выполнение
                        MessageBox.Show($"Слишком слабый пароль: {validation.ErrorMessage}",
                            "Ошибка безопасности", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(login))
                    {
                        MessageBox.Show("Пожалуйста, заполните все поля!");
                        return;
                    }

                    var dbService = new DBService();
                    if (dbService.IsLoginExists(login))
                    {
                        MessageBox.Show("Пользователь уже зарегистрирован!", "Ошибка регистрации",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string passwordHash = PasswordHasher.HashPassword(password);
                    try
                    {
                        using (var connection = dbService.GetConnection())
                        {
                            string sql = @"INSERT INTO Users (Login, Email, PasswordHash, RegistrationDate, RID) 
                           VALUES (@login, @email, @hash, @date, @rid)";

                            using (var command = new SqliteCommand(sql, connection))
                            {
                                command.Parameters.AddWithValue("@login", login);
                                command.Parameters.AddWithValue("@email", email);
                                command.Parameters.AddWithValue("@hash", passwordHash);
                                command.Parameters.AddWithValue("@date", DateTime.Now);
                                command.Parameters.AddWithValue("@rid", RoleId);

                                command.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Регистрация завершена успешно!");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при регистрации: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                ButtonGenerate.PerformClick();
                MessageBox.Show("CAPTCHA введена неверно", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButtonGenerate_Click(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
