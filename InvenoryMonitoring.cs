using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FINALS_LAB_ACT_1
{
    public partial class InventoryMonitoring : Form
    {
        // Database connection string
        private string connectionString = "Server=127.0.0.1;Database=SalesInventory;Uid=root;Pwd=Password123;";

        public InventoryMonitoring()
        {
            InitializeComponent();
        }

        // Form load event - loads inventory data when the form is loaded
        private void InventoryMonitoring_Load(object sender, EventArgs e)
        {
            // Initialize the ListView columns
            InitializeListViewColumns();

            // Load inventory data into ListView
            LoadInventory();
        }

        // Initialize ListView columns
        private void InitializeListViewColumns()
        {
            // Add columns for ItemId, ItemName, and Quantity
            listView4.Columns.Clear();
            listView4.Columns.Add("ItemId", 100);
            listView4.Columns.Add("ItemName", 200);
            listView4.Columns.Add("Quantity", 100);
        }

        // Method to load inventory data into ListView
        private void LoadInventory()
        {
            try
            {
                // Clear the ListView before reloading data
                listView4.Items.Clear();

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT Inventory.ItemId, Items.ItemName, Inventory.Quantity
                                     FROM Inventory
                                     INNER JOIN Items ON Inventory.ItemId = Items.ItemId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // Create a new ListViewItem for each row in the result set
                        ListViewItem item = new ListViewItem(reader["ItemId"].ToString());
                        item.SubItems.Add(reader["ItemName"].ToString());
                        item.SubItems.Add(reader["Quantity"].ToString());

                        // Add the item to the ListView
                        listView4.Items.Add(item);
                    }
                }

                // Check if no records are found
                if (listView4.Items.Count == 0)
                {
                    MessageBox.Show("No inventory records found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory: " + ex.Message);
            }
        }

        // Event handler for the "Refresh Inventory" button click
        private void btnRefreshInventory_Click(object sender, EventArgs e)
        {
            // Refresh the inventory data
            LoadInventory();
        }
    }
}
