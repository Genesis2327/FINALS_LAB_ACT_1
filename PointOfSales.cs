using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FINALS_LAB_ACT_1
{
    public partial class PointOfSales : Form
    {
        private MySqlConnection conn;
        private List<CartItem> cartItems;

        public PointOfSales()
        {
            InitializeComponent();
            cartItems = new List<CartItem>();
            ConnectToDatabase();
        }

        // Establish connection to the database
        private void ConnectToDatabase()
        {
            string connString = "Server=127.0.0.1;Database=SalesInventory;Uid=root;Pwd=Password123;";
            conn = new MySqlConnection(connString);
        }

        private void PointOfSales_Load(object sender, EventArgs e)
        {
            // Add any initialization code if necessary
        }

        // Event for Quantity TextBox change - Auto calculate total amount
        private void tbQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int itemId = int.Parse(tbItemId.Text);
                int quantity = int.Parse(tbQuantity.Text);

                decimal unitPrice = GetItemPrice(itemId);
                decimal totalAmount = unitPrice * quantity;

                tbTotalAmount.Text = totalAmount.ToString("C");
            }
            catch (Exception)
            {
                tbTotalAmount.Text = "Invalid Input";
            }
        }

        // Get item price from the database using Item ID
        private decimal GetItemPrice(int itemId)
        {
            decimal unitPrice = 0;
            try
            {
                conn.Open();
                string query = "SELECT BasePrice FROM Items WHERE ItemId = @ItemId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ItemId", itemId);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    unitPrice = reader.GetDecimal("BasePrice");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching item price: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return unitPrice;
        }

        // Add item to the cart
        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
            try
            {
                int itemId = int.Parse(tbItemId.Text);
                int quantity = int.Parse(tbQuantity.Text);
                decimal totalAmount = decimal.Parse(tbTotalAmount.Text);

                CartItem newItem = new CartItem(itemId, quantity, totalAmount);
                cartItems.Add(newItem);

                UpdateCartListView();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Update item in the cart (change quantity)
        private void btnUpdateTheCart_Click(object sender, EventArgs e)
        {
            try
            {
                int itemId = int.Parse(tbItemId.Text);
                int quantity = int.Parse(tbQuantity.Text);
                decimal totalAmount = decimal.Parse(tbTotalAmount.Text);

                var item = cartItems.FirstOrDefault(c => c.ItemId == itemId);
                if (item != null)
                {
                    item.Quantity = quantity;
                    item.TotalAmount = totalAmount;

                    UpdateCartListView();
                }
                else
                {
                    MessageBox.Show("Item not found in the cart.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Delete item from the cart
        private void btnDeleteInTheCart_Click(object sender, EventArgs e)
        {
            try
            {
                int itemId = int.Parse(tbItemId.Text);

                var item = cartItems.FirstOrDefault(c => c.ItemId == itemId);
                if (item != null)
                {
                    cartItems.Remove(item);
                    UpdateCartListView();
                }
                else
                {
                    MessageBox.Show("Item not found in the cart.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // View the cart (display all cart items from the database in the ListView)
        private void btnViewTheCart_Click(object sender, EventArgs e)
        {
            try
            {
                // Fetch sales data from the database
                List<SalesData> salesData = GetSalesDataFromDatabase();

                // Clear existing items in the ListView
                listView3.Items.Clear();

                // Populate ListView with data from the database
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

        // Fetch sales data from the database
        private List<SalesData> GetSalesDataFromDatabase()
        {
            List<SalesData> salesDataList = new List<SalesData>();

            try
            {
                conn.Open();

                // SQL query to get sales data
                string query = "SELECT ReceiptId, ReceiptDate, ItemId, Quantity, TotalAmount FROM PointofSales";
                MySqlCommand cmd = new MySqlCommand(query, conn);
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
                MessageBox.Show("Error fetching data: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return salesDataList;
        }

        // Update the ListView with cart items
        private void UpdateCartListView()
        {
            listView3.Items.Clear();

            foreach (var item in cartItems)
            {
                ListViewItem listItem = new ListViewItem(item.ItemId.ToString());
                listItem.SubItems.Add(item.Quantity.ToString());
                listItem.SubItems.Add(item.TotalAmount.ToString("C"));
                listView3.Items.Add(listItem);
            }
        }

        // Clear input fields after adding or updating items
        private void ClearInputFields()
        {
            tbItemId.Clear();
            tbQuantity.Clear();
            tbTotalAmount.Clear();
        }

        // CartItem class
        public class CartItem
        {
            public int ItemId { get; set; }
            public int Quantity { get; set; }
            public decimal TotalAmount { get; set; }

            public CartItem(int itemId, int quantity, decimal totalAmount)
            {
                ItemId = itemId;
                Quantity = quantity;
                TotalAmount = totalAmount;
            }
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
    }
}
