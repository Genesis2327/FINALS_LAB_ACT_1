using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FINALS_LAB_ACT_1
{
    public partial class Delivery : Form
    {
        // Database connection string
        private string connectionString = "Server=127.0.0.1;Database=SalesInventory;Uid=root;Pwd=Password123;";

        public Delivery()
        {
            InitializeComponent();
        }

        // Load event handler for the form
        private void Delivery_Load(object sender, EventArgs e)
        {
            // Load items into ComboBox (cbItemName)
            LoadItems();
            // Load deliveries into ListView
            LoadDeliveries();
        }

        // Method to load items into the ComboBox
        private void LoadItems()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ItemId, ItemName FROM Items";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable itemsTable = new DataTable();
                    adapter.Fill(itemsTable);

                    // Bind ComboBox to the DataTable
                    cbItemName.DataSource = itemsTable;
                    cbItemName.DisplayMember = "ItemName"; // Display ItemName in ComboBox
                    cbItemName.ValueMember = "ItemId";    // Use ItemId as the value
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message);
            }
        }

        // Method to load deliveries into the ListView
        private void LoadDeliveries()
        {
            try
            {
                listView4.Items.Clear();

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT DeliveryId, DeliveryDate, Delivery.ItemId, Items.ItemName, Quantity
                                     FROM Delivery
                                     INNER JOIN Items ON Delivery.ItemId = Items.ItemId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["DeliveryId"].ToString());
                        item.SubItems.Add(reader["DeliveryDate"].ToString());
                        item.SubItems.Add(reader["ItemId"].ToString());
                        item.SubItems.Add(reader["ItemName"].ToString());
                        item.SubItems.Add(reader["Quantity"].ToString());

                        listView4.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading deliveries: " + ex.Message);
            }
        }

        // Event handler for ComboBox selection change
        private void cbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbItemName.SelectedValue != null)
            {
                // Get the selected item (it will be a DataRowView due to DataBinding)
                DataRowView selectedItem = (DataRowView)cbItemName.SelectedItem;

                // Get the ItemId and ItemName from the selected item
                string itemId = selectedItem["ItemId"].ToString();
                string itemName = selectedItem["ItemName"].ToString();

                // Set the ItemName in the TextBox
                cbItemName.Text = itemName;
            }
        }

        // Event handler for Add Delivery button
        private void btnAddAddDelivery_Click(object sender, EventArgs e)
        {
            if (cbItemName.SelectedItem == null || string.IsNullOrEmpty(tbQuantity.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string itemId = cbItemName.SelectedValue.ToString();
            string deliveryDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string quantity = tbQuantity.Text.Trim();

            if (!int.TryParse(quantity, out int quantityValue) || quantityValue <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string insertQuery = "INSERT INTO Delivery (DeliveryDate, ItemId, Quantity) VALUES (@deliveryDate, @itemId, @quantity)";
                    MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@deliveryDate", deliveryDate);
                    cmd.Parameters.AddWithValue("@itemId", itemId);
                    cmd.Parameters.AddWithValue("@quantity", quantityValue);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Delivery added successfully!");
                        LoadDeliveries();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add delivery.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
