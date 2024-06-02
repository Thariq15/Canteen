using CanteenApp.Forms;
using CanteenApp.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanteenApp.Controllers
{
    internal class DBTransaction
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

        public void AddTransaction(TransactionModel transaction)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection connection = GetConnection();
            string query = "INSERT INTO transactions(transaction_code, admin_id, customer_name, total_price, total_payment, change, transaction_date) VALUES(@code, @adminId, @name, @totalPrice, @totalPayment, @change, @date)";
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.AddWithValue("code", transaction.TransactionCode);
            command.Parameters.AddWithValue("adminId", transaction.AdminId);
            command.Parameters.AddWithValue("name", transaction.CustomerName);
            command.Parameters.AddWithValue("totalPrice", transaction.TotalPrice);
            command.Parameters.AddWithValue("totalPayment", transaction.TotalPayment);
            command.Parameters.AddWithValue("change", transaction.Change);
            command.Parameters.AddWithValue("date", transaction.TransactionDate);
            command.Prepare();
            try
            {
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                MessageBox.Show("Transaksi berhasil ditambahkan", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
