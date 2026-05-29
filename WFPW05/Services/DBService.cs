using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace WFPW05.Services
{
    public class DBService
    {
        private readonly string _connectionString;
        private readonly string _dbPath;
        public DBService()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Directory.GetParent(baseDir).Parent.Parent.Parent.FullName;

            string dataDirectory = Path.Combine(projectRoot, "Data");
            _dbPath = Path.Combine(dataDirectory, "warehouse.db");

            if (!Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }

            var builder = new SqliteConnectionStringBuilder
            {
                DataSource = _dbPath
            };
            _connectionString = builder.ConnectionString;
        }

        //Метод для получения открытого соединения с включенными Foreign Keys
        public SqliteConnection GetConnection()
        {
            var connection = new SqliteConnection(_connectionString);
            connection.Open();

            //поддержка внешних ключей для SQLite
            using (var cmd = new SqliteCommand("PRAGMA foreign_keys = ON;", connection))
            {
                cmd.ExecuteNonQuery();
            }
            return connection;
        }

        public bool IsLoginExists(string login)
        {
            bool exists = false;
            try
            {
                using (var connection = GetConnection())
                {
                    string sql = "SELECT COUNT(1) FROM Users WHERE Login = @login";
                    using (var command = new SqliteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        long count = (long)command.ExecuteScalar();
                        exists = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при проверке уникальности: {ex.Message}");
            }
            return exists;
        }

        // Инициализация таблиц
        public void InitializeTables()
        {

            const string createTablesSql = @"
                CREATE TABLE IF NOT EXISTS Roles (RID INTEGER PRIMARY KEY AUTOINCREMENT, RoleName TEXT NOT NULL);
                CREATE TABLE IF NOT EXISTS Users (UID INTEGER PRIMARY KEY AUTOINCREMENT, Login TEXT NOT NULL, Email TEXT NOT NULL, PasswordHash TEXT NOT NULL, RegistrationDate DATETIME NOT NULL, RID INTEGER, FOREIGN KEY (RID) REFERENCES Roles(RID));
                CREATE TABLE IF NOT EXISTS Logins (LoginAttemptID INTEGER PRIMARY KEY AUTOINCREMENT, UID INTEGER, DateTime DATETIME NOT NULL, Success TEXT NOT NULL, FOREIGN KEY (UID) REFERENCES Users(UID));
                CREATE TABLE IF NOT EXISTS Goods (GID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL, Amount REAL NOT NULL, Price DECIMAL(18, 2) NOT NULL, SupplierID INTEGER, FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID));
                CREATE TABLE IF NOT EXISTS Suppliers (SupplierID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL, Email TEXT NOT NULL);
                CREATE TABLE IF NOT EXISTS Supply (SupplyID INTEGER PRIMARY KEY AUTOINCREMENT, SupplierID INTEGER, GID INTEGER, DateTime DATETIME NOT NULL, Amount REAL NOT NULL, FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID), FOREIGN KEY (GID) REFERENCES Goods(GID));
                CREATE TABLE IF NOT EXISTS Orders (OrderID INTEGER PRIMARY KEY AUTOINCREMENT, GID INTEGER, UID INTEGER, Amount REAL NOT NULL, FOREIGN KEY (GID) REFERENCES Goods(GID), FOREIGN KEY (UID) REFERENCES Users(UID));
                INSERT OR IGNORE INTO Roles
                VALUES (0, 'Admin'),
                (1, 'User');
                INSERT OR IGNORE INTO Users
                VALUES (0, 'Admin', 'admin@adminmail.com', '$2a$12$7zR7rYVmU15G2wYHUYK6R.I3q4zjBGa/RbyLhR31whgc0bUqgASY2', '18.05.2026', 0),
                (1, 'User', 'user@usermail.com', '$2a$12$7zR7rYVmU15G2wYHUYK6R.I3q4zjBGa/RbyLhR31whgc0bUqgASY2', '18.05.2026', 1);
            ";



            using (var connection = GetConnection())
            using (var command = new SqliteCommand(createTablesSql, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public string GetDatabasePath() => _dbPath;
    }

    public static class DBInitialize
    {
        public static void DBInit()
        {
            new DBService().InitializeTables();
        }
    }
}