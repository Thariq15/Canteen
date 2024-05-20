using CanteenApp.Models;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanteenApp.Controllers
{
    internal class DBProducts
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

        public void AddProduct(ProductModel product)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection connection = GetConnection();
            string query = "INSERT INTO products(category_id, name, price, stock, description, image) VALUES(@categoryId, @name, @price, @stock, @description, @image)";
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.AddWithValue("categoryId", Int32.Parse(product.CategoryId));
            command.Parameters.AddWithValue("name", product.Name);
            command.Parameters.AddWithValue("price", product.Price);
            command.Parameters.AddWithValue("stock", product.Stock);
            command.Parameters.AddWithValue("description", product.Description);
            command.Parameters.AddWithValue("image", product.Image);
            command.Prepare();
            try
            {
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                MessageBox.Show("Produk berhasil ditambahkan", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        public void UpdateCategory(ProductModel product, string Id)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection connection = GetConnection();
            string query = "UPDATE products SET category_id = @categoryId, name = @name, price = @price, stock = @stock, description = @description WHERE id = @id";
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.AddWithValue("categoryId", product.CategoryId);
            command.Parameters.AddWithValue("name", product.Name);
            command.Parameters.AddWithValue("price", product.Price);
            command.Parameters.AddWithValue("stock", product.Stock);
            command.Parameters.AddWithValue("description", product.Description);
            command.Parameters.AddWithValue("id", Int32.Parse(Id));
            command.Prepare();
            try
            {
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                MessageBox.Show("Product berhasil diupdate", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string query = "DELETE FROM products WHERE id = @id";
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.AddWithValue("id", Int32.Parse(Id));
            command.Prepare();
            try
            {
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                MessageBox.Show("Product berhasil dihapus", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public int GetCategoryId(string name)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection connection = GetConnection();
            command.CommandText = "SELECT * FROM categories WHERE name = '"+name+"'";
            command.Connection = connection;
            NpgsqlDataReader reader;
            reader = command.ExecuteReader();
            reader.Read();
            int id = reader.GetInt32(0);
            connection.Close();
            return id;
        }
    }
}
