using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using CanteenApp.Models;
using System.Data;
using System.Windows.Forms;

namespace CanteenApp.Controllers
{
    internal class DBCategory
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
                MessageBox.Show(ex.Message,"Connection Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return connection;
        }

        public void AddCategory(CategoryModel category)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection connection = GetConnection();
            string query = "INSERT INTO categories(name) VALUES(@name)";
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.AddWithValue("name", category.Name);
            command.Prepare();
            try
            {
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                MessageBox.Show("Kategori berhasil ditambahkan", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        public void UpdateCategory(CategoryModel category, string Id)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection connection = GetConnection();
            string query = "UPDATE categories SET name = @name WHERE id = @id";
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.AddWithValue("name", category.Name);
            command.Parameters.AddWithValue("id", Int32.Parse(Id));
            command.Prepare();
            try
            {
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                MessageBox.Show("Kategori berhasil diupdate", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        public void DeleteCategory(string Id)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection connection = GetConnection();
            string query = "DELETE FROM categories WHERE id = @id";
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.AddWithValue("id", Int32.Parse(Id));
            command.Prepare();
            try
            {
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                MessageBox.Show("Kategori berhasil dihapus", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        public void DisplayAndSearch(string query, DataGridView dgv)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection connection = GetConnection();
            command.CommandText = query;
            command.Connection = connection;
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dgv.DataSource = dataTable;
            connection.Close();
        }

        public void LoadCategory(string query, ComboBox comboBox)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection connection = GetConnection();
            command.CommandText = query;
            command.Connection = connection;
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            comboBox.Items.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                comboBox.Items.Add(row["name"].ToString());
            }
            connection.Close();
        }
    }
}
