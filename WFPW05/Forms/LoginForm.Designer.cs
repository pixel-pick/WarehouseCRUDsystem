namespace WFPW05
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LayoutLogin = new TableLayoutPanel();
            CAPTCHALayout = new TableLayoutPanel();
            CaptchaBox = new PictureBox();
            ButtonAccept = new Button();
            CAPTCHAInput = new TextBox();
            ButtonGenerate = new Button();
            UserLogin = new TextBox();
            UserPassword = new TextBox();
            CrtAccLabel = new Label();
            LayoutLogin.SuspendLayout();
            CAPTCHALayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CaptchaBox).BeginInit();
            SuspendLayout();
            // 
            // LayoutLogin
            // 
            LayoutLogin.ColumnCount = 1;
            LayoutLogin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            LayoutLogin.Controls.Add(CAPTCHALayout, 0, 2);
            LayoutLogin.Controls.Add(UserLogin, 0, 0);
            LayoutLogin.Controls.Add(UserPassword, 0, 1);
            LayoutLogin.Controls.Add(CrtAccLabel, 0, 3);
            LayoutLogin.Dock = DockStyle.Fill;
            LayoutLogin.Location = new Point(0, 0);
            LayoutLogin.Name = "LayoutLogin";
            LayoutLogin.RowCount = 4;
            LayoutLogin.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            LayoutLogin.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            LayoutLogin.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            LayoutLogin.RowStyles.Add(new RowStyle());
            LayoutLogin.Size = new Size(442, 253);
            LayoutLogin.TabIndex = 0;
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
            CAPTCHALayout.Location = new Point(3, 123);
            CAPTCHALayout.Name = "CAPTCHALayout";
            CAPTCHALayout.RowCount = 1;
            CAPTCHALayout.RowStyles.Add(new RowStyle());
            CAPTCHALayout.Size = new Size(436, 104);
            CAPTCHALayout.TabIndex = 2;
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
            // UserLogin
            // 
            UserLogin.Dock = DockStyle.Top;
            UserLogin.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            UserLogin.Location = new Point(3, 3);
            UserLogin.Name = "UserLogin";
            UserLogin.PlaceholderText = "Login";
            UserLogin.Size = new Size(436, 51);
            UserLogin.TabIndex = 3;
            // 
            // UserPassword
            // 
            UserPassword.Dock = DockStyle.Top;
            UserPassword.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            UserPassword.Location = new Point(3, 63);
            UserPassword.Name = "UserPassword";
            UserPassword.PlaceholderText = "Password";
            UserPassword.Size = new Size(436, 51);
            UserPassword.TabIndex = 4;
            // 
            // CrtAccLabel
            // 
            CrtAccLabel.AutoSize = true;
            CrtAccLabel.Dock = DockStyle.Fill;
            CrtAccLabel.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 204);
            CrtAccLabel.Location = new Point(3, 230);
            CrtAccLabel.Name = "CrtAccLabel";
            CrtAccLabel.Size = new Size(436, 23);
            CrtAccLabel.TabIndex = 5;
            CrtAccLabel.Text = "Don't have an Account? Sign up";
            CrtAccLabel.TextAlign = ContentAlignment.MiddleLeft;
            CrtAccLabel.Click += CrtAccLabel_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 253);
            Controls.Add(LayoutLogin);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "LoginForm";
            Tag = "Login";
            Text = "Login";
            Load += LoginForm_Load;
            LayoutLogin.ResumeLayout(false);
            LayoutLogin.PerformLayout();
            CAPTCHALayout.ResumeLayout(false);
            CAPTCHALayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CaptchaBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel LayoutLogin;
        private PictureBox CaptchaBox;
        private Button ButtonGenerate;
        private TableLayoutPanel CAPTCHALayout;
        private Button ButtonAccept;
        private TextBox CAPTCHAInput;
        private TextBox UserLogin;
        private TextBox UserPassword;
        private Label CrtAccLabel;
    }
}
