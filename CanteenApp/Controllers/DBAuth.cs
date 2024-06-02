using CanteenApp.Models;
using CanteenApp.Pages;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanteenApp.Controllers
{
    internal class DBAuth
    {
        public NpgsqlConnection GetConnection()
        {
            string connectionString = "Host=localhost;Username=postgres;Password=12345678;Database=canteen";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return connection;
        }

        public void Register(UserModel user)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection connection = GetConnection();
            string query = "INSERT INTO users(name, email, phone, password) VALUES(@name, @email, @phone, @password)";
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.AddWithValue("name", user.Name);
            command.Parameters.AddWithValue("email", user.Email);
            command.Parameters.AddWithValue("phone", user.Phone);
            command.Parameters.AddWithValue("password", user.Password);
            command.Prepare();
            try
            {
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                MessageBox.Show("Registrasi berhasil", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        public void Login(string email, string password, LoginForm loginForm)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection connection = GetConnection();
            command.CommandText = "SELECT * FROM users WHERE email = @email";
            command.Connection = connection;
            command.Parameters.AddWithValue("@email", email);
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string storedPassword = reader["password"].ToString();
                if (storedPassword == password)
                {
                    MessageBox.Show("Berhasil login");
                    UserSession.Id = Convert.ToInt32(reader["id"]);
                    UserSession.Name = reader["name"].ToString();
                    UserSession.Phone = reader["phone"].ToString();
                    UserSession.Email = reader["email"].ToString();
                    connection.Close();
                    loginForm.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    return;
                }
            }
            connection.Close();
            MessageBox.Show("Email atau Password Anda Salah");
        }

        private bool VerifyPassword(string password, string storedPasswordHash)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString() == storedPasswordHash;
            }
        }

        public int CheckEmail(string email)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection connection = GetConnection();
            command.CommandText = "SELECT COUNT(*) FROM users WHERE email = @email";
            command.Connection = connection;
            command.Parameters.AddWithValue("@email", email);
            int count = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return count;
        }
    }
}
