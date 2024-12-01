using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FINALS_LAB_ACT_1
{
    public partial class SalesMonitoring : Form
    {
        private MySqlConnection conn;

        public SalesMonitoring()
        {
            InitializeComponent();
            ConnectToDatabase(); // Initialize the database connection
        }

        // Establish connection to the database
        private void ConnectToDatabase()
        {
            string connString = "Server=127.0.0.1;Database=SalesInventory;Uid=root;Pwd=Password123;";
            conn = new MySqlConnection(connString);
        }

        // Handle form load event (currently not needed, but can be used for any initialization)
        private void SalesMonitoring_Load(object sender, EventArgs e)
        {
            // Optionally populate the ListView or perform other tasks when the form loads
        }

        // Event handler for DateTimePicker value change
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // When the user selects a date, fetch the sales for that date
            DateTime selectedDate = dateTimePicker1.Value.Date;
            ViewSalesByDate(selectedDate);
        }

        // Fetch and display sales data based on the selected date
        private void ViewSalesByDate(DateTime selectedDate)
        {
            try
            {
                // Fetch sales data from the database based on the selected date
                List<SalesData> salesData = GetSalesDataByDate(selectedDate);

                // Clear existing items in the ListView
                listView3.Items.Clear();

                // Populate the ListView with the sales data
                foreach (var data in salesData)
                {
                    ListViewItem listItem = new ListViewItem(data.ReceiptId.ToString());
                    listItem.SubItems.Add(data.ReceiptDate.ToString("yyyy-MM-dd"));
                    listItem.SubItems.Add(data.ItemId.ToString());
                    listItem.SubItems.Add(data.Quantity.ToString());
                    listItem.SubItems.Add(data.TotalAmount.ToString("C"));
                    listView3.Items.Add(listItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching sales data: " + ex.Message);
            }
        }

        // Get sales data from the database by the selected date
        private List<SalesData> GetSalesDataByDate(DateTime selectedDate)
        {
            List<SalesData> salesDataList = new List<SalesData>();

            try
            {
                conn.Open();

                // SQL query to get sales data based on the selected date
                string query = "SELECT ReceiptId, ReceiptDate, ItemId, Quantity, TotalAmount FROM PointofSales WHERE DATE(ReceiptDate) = @SelectedDate";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SelectedDate", selectedDate);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SalesData data = new SalesData
                    {
                        ReceiptId = reader.GetInt32("ReceiptId"),
                        ReceiptDate = reader.GetDateTime("ReceiptDate"),
                        ItemId = reader.GetInt32("ItemId"),
                        Quantity = reader.GetInt32("Quantity"),
                        TotalAmount = reader.GetDecimal("TotalAmount")
                    };

                    salesDataList.Add(data);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching sales data: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return salesDataList;
        }

        // SalesData class for representing sales data
        public class SalesData
        {
            public int ReceiptId { get; set; }
            public DateTime ReceiptDate { get; set; }
            public int ItemId { get; set; }
            public int Quantity { get; set; }
            public decimal TotalAmount { get; set; }
        }

        // Event handler for View Sales button click (optional if you want a separate button for viewing sales)
        private void btnViewTheCart_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date;
            ViewSalesByDate(selectedDate);
        }
    }
}
