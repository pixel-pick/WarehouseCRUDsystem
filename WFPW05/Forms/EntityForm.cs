using Microsoft.Data.Sqlite;
using System.Data;
using System.Xml.Linq;
using WFPW05.Services;

namespace WFPW05.Forms
{
    public partial class EntityForm : Form
    {
        private readonly DBService _db;
        string Role;
        string Login;
        private string currentTable = "";
        private MainForm _mainForm;
        private int _currentOffset = 0;
        private const int _pageSize = 10;

        private Dictionary<string, TextBox> _dynamicInputs = new Dictionary<string, TextBox>();
        private BindingSource _bindingSource = new BindingSource();

        public EntityForm(string role, string name, MainForm mainForm)
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(EntityForm_Closed);
            _mainForm = mainForm;
            Role = role;
            Login = name;
            _db = new DBService();

            //Скрытие кнопок в зависимости от роли
            if (!(Role == "Admin"))
            {
                btnShowUsers.Visible = false;
                btnShowRoles.Visible = false;
                btnGenerateTestData.Visible = false;
            }
            this.Load += EntityForm_Load;
        }

        private void EntityForm_Load(object sender, EventArgs e)
        {
            try
            {
                btnShowOrders_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критическая ошибка при загрузке формы: " + ex.Message);
            }
        }

        private void LoadTable(string sql, SqliteParameter[] parameters = null)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    using (var cmd = new SqliteCommand(sql, conn))
                    {
                        if (parameters != null) cmd.Parameters.AddRange(parameters);

                        DataTable dt = new DataTable();
                        using (var reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                        _bindingSource.DataSource = dt;
                        dataGridViewMain.DataSource = _bindingSource;
                        dataGridViewMain.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
        }

        private void SetupDynamicFields(string tableName)
        {
            currentTable = tableName;
            _dynamicInputs.Clear();
            pnlFields.Controls.Clear();
            cmbForeignKey.Items.Clear();
            btnCalculate.Visible = false;

            bool isAdmin = (Role == "Admin"); //элементы активны если Admin

            List<string> fields = new List<string>();
            switch (tableName)
            {
                case "Users":
                    fields.AddRange(new[] { "Login", "Email", "RegistrationDate", "RID" });
                    PopulateCombo("Roles", "RID", "RoleName");
                    break;
                case "Goods":
                    fields.AddRange(new[] { "Name", "Amount", "Price", "SupplierID" });
                    PopulateCombo("Suppliers", "SupplierID", "Name");
                    break;
                case "Orders":
                    fields.AddRange(new[] { "GID", "UID", "Amount" });
                    PopulateCombo("Goods", "GID", "Name");
                    PopulateCombo("Users", "UID", "Login");
                    btnCalculate.Visible = true;
                    break;
                case "Logins":
                    fields.AddRange(new[] { "UID", "DateTime", "Success" });
                    PopulateCombo("Users", "UID", "Login");
                    break;
                case "Suppliers":
                    fields.AddRange(new[] { "Name", "Email" });
                    break;
                case "Roles":
                    fields.Add("RoleName");
                    break;
            }

            if (tableName == "Users")
            {
                Label lblPass = new Label { Text = "Password", AutoSize = true, Margin = new Padding(0, 5, 0, 0) };
                TextBox txtPass = new TextBox { Name = "txt_Password", Width = 180, PasswordChar = '*', Enabled = isAdmin };
                pnlFields.Controls.Add(lblPass);
                pnlFields.Controls.Add(txtPass);
                _dynamicInputs.Add("Password", txtPass);
            }

            foreach (var field in fields)
            {
                Label lbl = new Label { Text = field, AutoSize = true, Margin = new Padding(0, 5, 0, 0) };
                TextBox txt = new TextBox { Name = "txt_" + field, Width = 180, Enabled = isAdmin };

                pnlFields.Controls.Add(lbl);
                pnlFields.Controls.Add(txt);
                _dynamicInputs.Add(field, txt);
            }

            btnSave.Enabled = isAdmin;
            btnDelete.Enabled = isAdmin;

            if (cmbForeignKey.Visible && cmbForeignKey.Items.Count > 0)
            {
                cmbForeignKey.Enabled = isAdmin;
                pnlFields.Controls.Add(cmbForeignKey);
            }

            pnlFields.ResumeLayout(true);
            this.PerformLayout();
        }

        private void PopulateCombo(string tableName, string idField, string nameField)
        {
            string sql = $"SELECT {idField}, {nameField} FROM {tableName}";
            try
            {
                using (var conn = _db.GetConnection())
                {
                    var cmd = new SqliteCommand(sql, conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbForeignKey.Items.Add(new
                            {
                                ID = reader[idField],
                                Display = reader[nameField].ToString()
                            });
                        }
                    }
                }
            }
            catch { }
        }

        //Обработчики кнопок

        private void btnShowUsers_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT U.UID, U.Login, U.Email, U.RID, U.RegistrationDate, U.PasswordHash FROM Users U ORDER BY U.UID DESC LIMIT {_pageSize} OFFSET {_currentOffset}";
            LoadTable(sql);
            SetupDynamicFields("Users");
            lblContextInfo.Text = "Mode: Users";
        }

        private void btnLogins_Click(object sender, EventArgs e)
        {
            string sql = "SELECT L.LoginAttemptID, U.Login, L.DateTime, L.Success FROM Logins L JOIN Users U ON L.UID = U.UID";
            SqliteParameter[] ps = null;

            if (Role == "User")
            {
                sql += " WHERE U.Login = @login";
                ps = new[] { new SqliteParameter("@login", Login) };
                lblContextInfo.Text = $"My logins: {Login}";
            }
            else
            {
                lblContextInfo.Text = "All login attempts";
            }

            sql += $" ORDER BY L.LoginAttemptID DESC LIMIT {_pageSize} OFFSET {_currentOffset}";

            LoadTable(sql, ps);
            SetupDynamicFields("Logins");
        }

        private void btnShowOrders_Click(object sender, EventArgs e)
        {
            string sql = "SELECT o.OrderID, o.UID, g.Name, o.Amount FROM Orders o JOIN Goods g ON o.GID = g.GID";
            SqliteParameter[] ps = null;

            //Если пользователь — "User", добавляем фильтр
            if (Role == "User")
            {
                sql += " WHERE EXISTS (SELECT 1 FROM Users u WHERE u.UID = o.UID AND u.Login = @login)";
                ps = new[] { new SqliteParameter("@login", Login) };
                lblContextInfo.Text = $"Заказы: {Login}";
            }
            else
            {
                lblContextInfo.Text = "All orders";
            }

            // 3. В САМОМ КОНЦЕ добавляем сортировку и пагинацию
            sql += $" ORDER BY o.OrderID DESC LIMIT {_pageSize} OFFSET {_currentOffset}";

            LoadTable(sql, ps);

            SetupDynamicFields("Orders");
            btnCalculate.Visible = true;
        }

        private void btnShowGoods_Click(object sender, EventArgs e)
        {
            LoadTable($"SELECT GID, Name, Amount, Price, SupplierID FROM Goods ORDER BY GID DESC LIMIT {_pageSize} OFFSET {_currentOffset}");
            SetupDynamicFields("Goods");
            lblContextInfo.Text = "Goods";
            btnCalculate.Visible = false;
        }

        private void btnShowSuppliers_Click(object sender, EventArgs e)
        {
            SetupDynamicFields("Suppliers");
            LoadTable($"SELECT SupplierID, Name, Email FROM Suppliers ORDER BY SupplierID DESC LIMIT {_pageSize} OFFSET {_currentOffset}");
            lblContextInfo.Text = "Suppliers";
        }

        // --- РАСЧЕТ И CRUD ---

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string sql = "";
            List<SqliteParameter> parameters = new List<SqliteParameter>();

            if (!string.IsNullOrWhiteSpace(txtID.Text))
            {
                // Режим 1: Расчет по ID из TextBox
                sql = "SELECT (g.Price * o.Amount) FROM Orders o JOIN Goods g ON o.GID = g.GID WHERE o.OrderID = @id";
                parameters.Add(new SqliteParameter("@id", txtID.Text));
            }
            else if (Role == "User")
            {
                // Режим 2: Расчет всех заказов текущего пользователя
                sql = @"
                    SELECT SUM(g.Price * o.Amount) 
                    FROM Orders o 
                    JOIN Goods g ON o.GID = g.GID 
                    WHERE o.UID = (SELECT UID FROM Users WHERE Login = @login)";
                parameters.Add(new SqliteParameter("@login", Login));
            }
            else
            {
                // Режим 3: По текущей строке в сетке
                if (dataGridViewMain.CurrentRow == null) return;
                int orderId = Convert.ToInt32(dataGridViewMain.CurrentRow.Cells["OrderID"].Value);
                sql = "SELECT (g.Price * o.Amount) FROM Orders o JOIN Goods g ON o.GID = g.GID WHERE o.OrderID = @id";
                parameters.Add(new SqliteParameter("@id", orderId));
            }

            try
            {
                using (var conn = _db.GetConnection())
                {
                    var cmd = new SqliteCommand(sql, conn);
                    cmd.Parameters.AddRange(parameters.ToArray());
                    var res = cmd.ExecuteScalar();

                    decimal total = res == DBNull.Value ? 0 : Convert.ToDecimal(res);
                    MessageBox.Show($"Итоговая стоимость: {total:C2}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка расчета: {ex.Message}");
            }
        }

        private void btnGenerateTestData_Click_1(object sender, EventArgs e)
        {
            using (var conn = _db.GetConnection())
            {
                string sql = @"
                    INSERT OR IGNORE INTO Suppliers VALUES (1, 'exampleSupplier', 'supplier@suppliermail.com');
                    INSERT OR IGNORE INTO Goods (Name, Amount, Price, SupplierID) VALUES ('Test Item', 10, 500, 1);
                    INSERT OR IGNORE INTO Orders (GID, UID, Amount) VALUES (1, 0, 2);";
                var cmd = new SqliteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Тестовые данные добавлены!");
                btnShowUsers_Click(null, null);
            }
        }

        private void btnShowRoles_Click(object sender, EventArgs e)
        {
            LoadTable($"SELECT RID, RoleName FROM Roles ORDER BY RID DESC LIMIT {_pageSize} OFFSET {_currentOffset}");
            SetupDynamicFields("Roles");
            lblContextInfo.Text = "Режим: Роли";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_dynamicInputs.Count == 0) return;
            string currentTable = GetCurrentTableName();

            string passwordHash = null;
            string columns = "";
            string values = "";
            string updates = "";
            var parameters = new List<SqliteParameter>();

            if (_dynamicInputs.ContainsKey("Password"))
            {
                string rawPassword = _dynamicInputs["Password"].Text;
                if (!string.IsNullOrWhiteSpace(rawPassword))
                {
                    var validation = PasswordHasher.ValidatePasswordStrength(rawPassword);
                    if (!validation.IsValid)
                    {
                        MessageBox.Show(validation.ErrorMessage);
                        return;
                    }
                    passwordHash = PasswordHasher.HashPassword(rawPassword);
                }
            }

            int i = 0;
            string pk = "ID";
            if (currentTable == "Users") pk = "UID";
            else if (currentTable == "Roles") pk = "RID";
            else if (currentTable == "Goods") pk = "GID";
            else if (currentTable == "Orders") pk = "OrderID";
            else if (currentTable == "Suppliers") pk = "SupplierID";
            else if (currentTable == "Logins") pk = "LoginAttemptID";
            bool isUpdate = !string.IsNullOrWhiteSpace(txtID.Text);

            foreach (var entry in _dynamicInputs)
            {
                string colName = entry.Key;
                string val = entry.Value.Text;

                // Пропускаем Password, так как мы обрабатываем его отдельно (через PasswordHash)
                if (colName == "Password") continue;

                if (isUpdate)
                {
                    updates += (updates == "" ? "" : ", ") + $"{colName} = @p{i}";
                }
                else
                {
                    columns += (columns == "" ? "" : ", ") + colName;
                    values += (values == "" ? "" : ", ") + "@p" + i;
                }
                parameters.Add(new SqliteParameter("@p" + i, val));
                i++;
            }

            if (passwordHash != null)
            {
                string pName = "@p" + i;
                if (isUpdate) updates += $", PasswordHash = {pName}";
                else { columns += ", PasswordHash"; values += ", " + pName; }
                parameters.Add(new SqliteParameter(pName, passwordHash));
            }

            string sql = "";
            switch (currentTable)
            {
                case "Users":
                    pk = "UID";
                    break;
                case "Roles":
                    pk = "RID";
                    break;
                case "Goods":
                    pk = "GID";
                    break;
                case "Orders":
                    pk = "OrderID";
                    break;
                case "Suppliers":
                    pk = "SupplierID";
                    break;
                case "Logins":
                    pk = "LoginAttemptID";
                    break;
                default:
                    MessageBox.Show($"Ошибка: Не определен первичный ключ для таблицы {currentTable}", "Ошибка БД");
                    return;
            }

            try
            {
                if (isUpdate)
                {
                    sql = $"UPDATE {currentTable} SET {updates} WHERE {pk} = @pkVal";
                    parameters.Add(new SqliteParameter("@pkVal", txtID.Text));
                }
                else
                {
                    sql = $"INSERT INTO {currentTable} ({columns}) VALUES ({values})";
                }

                using (var conn = _db.GetConnection())
                {
                    using (var cmd = new SqliteCommand(sql, conn))
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(isUpdate ? "Обновлено!" : "Создано!");
                        RefreshCurrentTable();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Сначала выберите запись в таблице!");
                return;
            }

            string currentTable = GetCurrentTableName();
            string pk = "ID";
            if (currentTable == "Users") pk = "UID";
            else if (currentTable == "Roles") pk = "RID";
            else if (currentTable == "Goods") pk = "GID";
            else if (currentTable == "Orders") pk = "OrderID";
            else if (currentTable == "Suppliers") pk = "SupplierID";
            else if (currentTable == "Logins") pk = "LoginAttemptID";

            var confirm = MessageBox.Show($"Удалить запись из {currentTable}?", "Подтверждение", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string sql = $"DELETE FROM {currentTable} WHERE {pk} = @id";
                try
                {
                    using (var conn = _db.GetConnection())
                    {
                        var cmd = new SqliteCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", txtID.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Удалено!");
                        RefreshCurrentTable();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Ошибка удаления: " + ex.Message); }
            }
        }

        private string GetCurrentTableName() => currentTable;

        private void RefreshCurrentTable()
        {
            if (currentTable == "Users") btnShowUsers_Click(null, null);
            else if (currentTable == "Roles") btnShowRoles_Click(null, null);
            else if (currentTable == "Goods") btnShowGoods_Click(null, null);
            else if (currentTable == "Orders") btnShowOrders_Click(null, null);
            else if (currentTable == "Logins") btnLogins_Click(null, null);
            else if (currentTable == "Suppliers") btnShowSuppliers_Click(null, null);
        }

        private void EntityForm_Shown(object sender, EventArgs e)
        {
            // Применяем начальные ограничения прав при запуске
            bool isAdmin = (Role == "Admin");
            btnSave.Enabled = isAdmin;
            btnDelete.Enabled = isAdmin;

            if (string.IsNullOrEmpty(currentTable))
            {
                btnShowUsers_Click(null, null);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (_currentOffset <= 0)
            {
                _currentOffset = 0;
                MessageBox.Show("Вы на первой странице");
                RefreshCurrentTableData();
                return;
            }

            //Уменьшаем смещение
            _currentOffset = Math.Max(0, _currentOffset - _pageSize);

            //обновляем данные
            RefreshCurrentTableData();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            _currentOffset += _pageSize;
            RefreshCurrentTableData();

            if (dataGridViewMain.Rows.Count == 0)
            {
                _currentOffset -= _pageSize;
                if (_currentOffset < 0) _currentOffset = 0;
                RefreshCurrentTableData();
            }
        }

        private void RefreshCurrentTableData() //чтобы не дублировать логику вызова таблицы
        {
            if (string.IsNullOrEmpty(currentTable)) return;

            switch (currentTable)
            {
                case "Users": btnShowUsers_Click(null, null); break;
                case "Roles": btnShowRoles_Click(null, null); break;
                case "Goods": btnShowGoods_Click(null, null); break;
                case "Orders": btnShowOrders_Click(null, null); break;
                case "Logins": btnLogins_Click(null, null); break;
                case "Suppliers": btnShowSuppliers_Click(null, null); break;
            }
        }
        private void EntityForm_Closed(object sender, EventArgs e) //закрытие
        {
            Application.Exit();
        }
        private void btnExit_Click(object sender, EventArgs e) //выход
        {
            _mainForm.Show();
            this.Close();
        }

    }
}