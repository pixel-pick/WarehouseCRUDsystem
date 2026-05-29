namespace WFPW05.Forms
{
    public partial class MainForm : Form
    {
        string Role;
        string Login;
        private LoginForm _loginForm;

        public MainForm(string role, string name, LoginForm loginForm)
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(MainForm_Closed);
            _loginForm = loginForm;
            Role = role;
            Login = name;
            this.Text = "Hello, " + name + "!";
            RoleLabel.Text = "Access level - " + role;
            /*if (!(role == "Admin"))
             * {
             * 
             * } изначально задумывалось что будет больше форм и кнопки будут скрыты для не Admin */
        }

        private void MainForm_Closed(object sender, EventArgs e) //закрытие
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e) //выход
        {
            _loginForm.Show();
            this.Close();
        }

        private void btnCRUD_Click(object sender, EventArgs e)
        {
            EntityForm EF = new EntityForm(Role, Login, this);
            EF.Show();
            this.Hide();
        }
    }
}
