namespace WFPW05.Forms
{
    partial class MainForm
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
            RoleLabel = new Label();
            ExitButton = new Button();
            btnCRUD = new Button();
            SuspendLayout();
            // 
            // RoleLabel
            // 
            RoleLabel.AutoSize = true;
            RoleLabel.Location = new Point(2, 1);
            RoleLabel.Name = "RoleLabel";
            RoleLabel.Size = new Size(39, 20);
            RoleLabel.TabIndex = 0;
            RoleLabel.Text = "Role";
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(12, 133);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(241, 29);
            ExitButton.TabIndex = 1;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += button1_Click;
            // 
            // btnCRUD
            // 
            btnCRUD.Location = new Point(12, 31);
            btnCRUD.Name = "btnCRUD";
            btnCRUD.Size = new Size(241, 29);
            btnCRUD.TabIndex = 2;
            btnCRUD.Text = "Tables";
            btnCRUD.UseVisualStyleBackColor = true;
            btnCRUD.Click += btnCRUD_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(265, 171);
            Controls.Add(btnCRUD);
            Controls.Add(ExitButton);
            Controls.Add(RoleLabel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainForm";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label RoleLabel;
        private Button ExitButton;
        private Button btnCRUD;
    }
}