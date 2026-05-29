namespace WFPW05.Forms
{
    partial class EntityForm
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
            btnShowUsers = new Button();
            btnShowRoles = new Button();
            btnShowGoods = new Button();
            btnShowOrders = new Button();
            btnShowSuppliers = new Button();
            dataGridViewMain = new DataGridView();
            txtID = new TextBox();
            cmbForeignKey = new ComboBox();
            btnSave = new Button();
            btnDelete = new Button();
            btnCalculate = new Button();
            lblContextInfo = new Label();
            pnlFields = new FlowLayoutPanel();
            btnGenerateTestData = new Button();
            btnLogins = new Button();
            btnUp = new Button();
            btnDown = new Button();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMain).BeginInit();
            pnlFields.SuspendLayout();
            SuspendLayout();
            // 
            // btnShowUsers
            // 
            btnShowUsers.Location = new Point(146, 700);
            btnShowUsers.Name = "btnShowUsers";
            btnShowUsers.Size = new Size(88, 29);
            btnShowUsers.TabIndex = 0;
            btnShowUsers.Text = "Users";
            btnShowUsers.UseVisualStyleBackColor = true;
            btnShowUsers.Click += btnShowUsers_Click;
            // 
            // btnShowRoles
            // 
            btnShowRoles.Location = new Point(240, 700);
            btnShowRoles.Name = "btnShowRoles";
            btnShowRoles.Size = new Size(94, 29);
            btnShowRoles.TabIndex = 1;
            btnShowRoles.Text = "Roles";
            btnShowRoles.UseVisualStyleBackColor = true;
            btnShowRoles.Click += btnShowRoles_Click;
            // 
            // btnShowGoods
            // 
            btnShowGoods.Location = new Point(340, 700);
            btnShowGoods.Name = "btnShowGoods";
            btnShowGoods.Size = new Size(94, 29);
            btnShowGoods.TabIndex = 2;
            btnShowGoods.Text = "Goods";
            btnShowGoods.UseVisualStyleBackColor = true;
            btnShowGoods.Click += btnShowGoods_Click;
            // 
            // btnShowOrders
            // 
            btnShowOrders.Location = new Point(440, 700);
            btnShowOrders.Name = "btnShowOrders";
            btnShowOrders.Size = new Size(94, 29);
            btnShowOrders.TabIndex = 3;
            btnShowOrders.Text = "Orders";
            btnShowOrders.UseVisualStyleBackColor = true;
            btnShowOrders.Click += btnShowOrders_Click;
            // 
            // btnShowSuppliers
            // 
            btnShowSuppliers.Location = new Point(540, 700);
            btnShowSuppliers.Name = "btnShowSuppliers";
            btnShowSuppliers.Size = new Size(94, 29);
            btnShowSuppliers.TabIndex = 4;
            btnShowSuppliers.Text = "Suppliers";
            btnShowSuppliers.UseVisualStyleBackColor = true;
            btnShowSuppliers.Click += btnShowSuppliers_Click;
            // 
            // dataGridViewMain
            // 
            dataGridViewMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMain.Location = new Point(11, 32);
            dataGridViewMain.Name = "dataGridViewMain";
            dataGridViewMain.RowHeadersWidth = 51;
            dataGridViewMain.Size = new Size(1042, 661);
            dataGridViewMain.TabIndex = 5;
            // 
            // txtID
            // 
            txtID.Location = new Point(11, 699);
            txtID.Name = "txtID";
            txtID.PlaceholderText = "ID";
            txtID.Size = new Size(129, 27);
            txtID.TabIndex = 6;
            // 
            // cmbForeignKey
            // 
            cmbForeignKey.Anchor = AnchorStyles.None;
            cmbForeignKey.FormattingEnabled = true;
            cmbForeignKey.Location = new Point(3, 3);
            cmbForeignKey.Name = "cmbForeignKey";
            cmbForeignKey.Size = new Size(338, 28);
            cmbForeignKey.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(759, 700);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(859, 700);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(959, 700);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(94, 29);
            btnCalculate.TabIndex = 11;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // lblContextInfo
            // 
            lblContextInfo.AutoSize = true;
            lblContextInfo.Location = new Point(12, 9);
            lblContextInfo.Name = "lblContextInfo";
            lblContextInfo.Size = new Size(50, 20);
            lblContextInfo.TabIndex = 14;
            lblContextInfo.Text = "label1";
            // 
            // pnlFields
            // 
            pnlFields.AutoScroll = true;
            pnlFields.Controls.Add(cmbForeignKey);
            pnlFields.Location = new Point(12, 732);
            pnlFields.Name = "pnlFields";
            pnlFields.Size = new Size(1041, 125);
            pnlFields.TabIndex = 15;
            // 
            // btnGenerateTestData
            // 
            btnGenerateTestData.Location = new Point(759, 863);
            btnGenerateTestData.Name = "btnGenerateTestData";
            btnGenerateTestData.Size = new Size(194, 29);
            btnGenerateTestData.TabIndex = 16;
            btnGenerateTestData.Text = "Add test data";
            btnGenerateTestData.UseVisualStyleBackColor = true;
            btnGenerateTestData.Click += btnGenerateTestData_Click_1;
            // 
            // btnLogins
            // 
            btnLogins.Location = new Point(640, 700);
            btnLogins.Name = "btnLogins";
            btnLogins.Size = new Size(94, 29);
            btnLogins.TabIndex = 17;
            btnLogins.Text = "Logins";
            btnLogins.UseVisualStyleBackColor = true;
            btnLogins.Click += btnLogins_Click;
            // 
            // btnUp
            // 
            btnUp.Location = new Point(11, 863);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(94, 29);
            btnUp.TabIndex = 18;
            btnUp.Text = "Up";
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += btnUp_Click;
            // 
            // btnDown
            // 
            btnDown.Location = new Point(111, 863);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(94, 29);
            btnDown.TabIndex = 19;
            btnDown.Text = "Down";
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += btnDown_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(959, 863);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 20;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // EntityForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1065, 902);
            Controls.Add(btnExit);
            Controls.Add(btnDown);
            Controls.Add(btnUp);
            Controls.Add(btnLogins);
            Controls.Add(btnGenerateTestData);
            Controls.Add(pnlFields);
            Controls.Add(lblContextInfo);
            Controls.Add(btnCalculate);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(txtID);
            Controls.Add(dataGridViewMain);
            Controls.Add(btnShowSuppliers);
            Controls.Add(btnShowOrders);
            Controls.Add(btnShowGoods);
            Controls.Add(btnShowRoles);
            Controls.Add(btnShowUsers);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "EntityForm";
            Load += EntityForm_Load;
            Shown += EntityForm_Shown;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMain).EndInit();
            pnlFields.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnShowUsers;
        private Button btnShowRoles;
        private Button btnShowGoods;
        private Button btnShowOrders;
        private Button btnShowSuppliers;
        private DataGridView dataGridViewMain;
        private TextBox txtID;
        private ComboBox cmbForeignKey;
        private Button btnSave;
        private Button btnDelete;
        private Button btnCalculate;
        private Label lblContextInfo;
        private FlowLayoutPanel pnlFields;
        private Button btnGenerateTestData;
        private Button btnLogins;
        private Button btnUp;
        private Button btnDown;
        private Button btnExit;
    }
}