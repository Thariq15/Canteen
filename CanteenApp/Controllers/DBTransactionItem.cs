using CanteenApp.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanteenApp.Controllers
{
    internal class DBTransactionItem
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

        public void AddItem(TransactionItemModel item)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            NpgsqlConnection connection = GetConnection();
            string query = "INSERT INTO transaction_items(transaction_code, product_id, quantity, sub_total) VALUES(@code, @productId, @qty, @subTotal)";
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.AddWithValue("code", item.TransactionCode);
            command.Parameters.AddWithValue("productId", item.ProductId);
            command.Parameters.AddWithValue("qty", item.Quantity);
            command.Parameters.AddWithValue("subTotal", item.SubTotal);
            command.Prepare();
            try
            {
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                //MessageBox.Show("Transaksi berhasil ditambahkan", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }
    }
}
