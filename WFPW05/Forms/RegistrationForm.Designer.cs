namespace WFPW05.Forms
{
    partial class RegistrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param Login="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            PasswordConfirm = new TextBox();
            UserLogin = new TextBox();
            UserPassword = new TextBox();
            UserEmail = new TextBox();
            CAPTCHALayout = new TableLayoutPanel();
            CaptchaBox = new PictureBox();
            ButtonAccept = new Button();
            CAPTCHAInput = new TextBox();
            ButtonGenerate = new Button();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            CAPTCHALayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CaptchaBox).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(PasswordConfirm, 0, 3);
            tableLayoutPanel1.Controls.Add(UserLogin, 0, 0);
            tableLayoutPanel1.Controls.Add(UserPassword, 0, 1);
            tableLayoutPanel1.Controls.Add(UserEmail, 0, 2);
            tableLayoutPanel1.Controls.Add(CAPTCHALayout, 0, 4);
            tableLayoutPanel1.Controls.Add(label1, 0, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(442, 373);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // PasswordConfirm
            // 
            PasswordConfirm.Dock = DockStyle.Fill;
            PasswordConfirm.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            PasswordConfirm.Location = new Point(3, 183);
            PasswordConfirm.Name = "PasswordConfirm";
            PasswordConfirm.PlaceholderText = "Repeat Password";
            PasswordConfirm.Size = new Size(436, 51);
            PasswordConfirm.TabIndex = 5;
            // 
            // UserLogin
            // 
            UserLogin.Dock = DockStyle.Fill;
            UserLogin.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            UserLogin.Location = new Point(3, 3);
            UserLogin.Name = "UserLogin";
            UserLogin.PlaceholderText = "Login";
            UserLogin.Size = new Size(436, 51);
            UserLogin.TabIndex = 0;
            // 
            // UserPassword
            // 
            UserPassword.Dock = DockStyle.Fill;
            UserPassword.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            UserPassword.Location = new Point(3, 63);
            UserPassword.Name = "UserPassword";
            UserPassword.PlaceholderText = "Password";
            UserPassword.Size = new Size(436, 51);
            UserPassword.TabIndex = 1;
            // 
            // UserEmail
            // 
            UserEmail.Dock = DockStyle.Fill;
            UserEmail.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            UserEmail.Location = new Point(3, 123);
            UserEmail.Name = "UserEmail";
            UserEmail.PlaceholderText = "Email";
            UserEmail.Size = new Size(436, 51);
            UserEmail.TabIndex = 2;
            // 
            // CAPTCHALayout
            // 
            CAPTCHALayout.ColumnCount = 4;
            CAPTCHALayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 210F));
            CAPTCHALayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            CAPTCHALayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            CAPTCHALayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            CAPTCHALayout.Controls.Add(CaptchaBox, 0, 0);
            CAPTCHALayout.Controls.Add(ButtonAccept, 3, 0);
            CAPTCHALayout.Controls.Add(CAPTCHAInput, 1, 0);
            CAPTCHALayout.Controls.Add(ButtonGenerate, 2, 0);
            CAPTCHALayout.Dock = DockStyle.Fill;
            CAPTCHALayout.Location = new Point(3, 243);
            CAPTCHALayout.Name = "CAPTCHALayout";
            CAPTCHALayout.RowCount = 1;
            CAPTCHALayout.RowStyles.Add(new RowStyle());
            CAPTCHALayout.Size = new Size(436, 104);
            CAPTCHALayout.TabIndex = 4;
            // 
            // CaptchaBox
            // 
            CaptchaBox.Dock = DockStyle.Fill;
            CaptchaBox.Location = new Point(3, 3);
            CaptchaBox.Name = "CaptchaBox";
            CaptchaBox.Size = new Size(204, 100);
            CaptchaBox.TabIndex = 0;
            CaptchaBox.TabStop = false;
            // 
            // ButtonAccept
            // 
            ButtonAccept.Dock = DockStyle.Fill;
            ButtonAccept.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonAccept.Location = new Point(382, 3);
            ButtonAccept.Name = "ButtonAccept";
            ButtonAccept.Size = new Size(51, 100);
            ButtonAccept.TabIndex = 2;
            ButtonAccept.Text = "✓";
            ButtonAccept.UseVisualStyleBackColor = true;
            ButtonAccept.Click += ButtonAccept_Click;
            // 
            // CAPTCHAInput
            // 
            CAPTCHAInput.Dock = DockStyle.Bottom;
            CAPTCHAInput.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            CAPTCHAInput.Location = new Point(213, 65);
            CAPTCHAInput.Name = "CAPTCHAInput";
            CAPTCHAInput.PlaceholderText = "CAPTCHA";
            CAPTCHAInput.Size = new Size(107, 38);
            CAPTCHAInput.TabIndex = 3;
            // 
            // ButtonGenerate
            // 
            ButtonGenerate.Cursor = Cursors.Hand;
            ButtonGenerate.Dock = DockStyle.Fill;
            ButtonGenerate.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonGenerate.Location = new Point(326, 3);
            ButtonGenerate.Name = "ButtonGenerate";
            ButtonGenerate.Size = new Size(50, 100);
            ButtonGenerate.TabIndex = 1;
            ButtonGenerate.Text = "↻";
            ButtonGenerate.UseVisualStyleBackColor = true;
            ButtonGenerate.Click += ButtonGenerate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 350);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(436, 23);
            label1.TabIndex = 3;
            label1.Text = "Already Have an Account? Login";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Click += label1_Click;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 373);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "RegistrationForm";
            Load += RegistrationForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            CAPTCHALayout.ResumeLayout(false);
            CAPTCHALayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CaptchaBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox UserLogin;
        private TextBox UserPassword;
        private TextBox UserEmail;
        private Label label1;
        private TableLayoutPanel CAPTCHALayout;
        private PictureBox CaptchaBox;
        private Button ButtonAccept;
        private TextBox CAPTCHAInput;
        private Button ButtonGenerate;
        private TextBox PasswordConfirm;
    }
}