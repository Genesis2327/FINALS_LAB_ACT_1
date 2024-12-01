using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace FINALS_LAB_ACT_1
{
    public partial class Maintenance : Form
    {
        // MySQL connection string
        string connectionString = "Server=127.0.0.1;Database=SalesInventory;Uid=root;Pwd=Password123;";

        // Placeholder for the logged-in username (replace this with actual logged-in username logic)
        private string loggedInUsername = "admin"; // Replace this with actual logged-in username

        public Maintenance()
        {
            InitializeComponent();
        }

        // Event for the Show Password checkbox to toggle password visibility
        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                tbCurrentPassword.PasswordChar = '\0';  // Show current password as plain text
                tbPassword.PasswordChar = '\0';        // Show new password as plain text
                tbConfirmPassword.PasswordChar = '\0'; // Show confirm password as plain text
            }
            else
            {
                tbCurrentPassword.PasswordChar = '*';  // Hide current password as asterisks
                tbPassword.PasswordChar = '*';         // Hide new password as asterisks
                tbConfirmPassword.PasswordChar = '*';  // Hide confirm password as asterisks
            }
        }

        // Event for the Change Password button click
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string currentPassword = tbCurrentPassword.Text.Trim();  // Trim any leading/trailing whitespace
            string newPassword = tbPassword.Text.Trim();  // Trim any leading/trailing whitespace
            string confirmPassword = tbConfirmPassword.Text.Trim();  // Trim any leading/trailing whitespace

            // Validate if the new password and confirm password match
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirm password do not match. Please try again.");
                return;
            }

            // Validate the new password strength (for example, at least 6 characters)
            if (newPassword.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if the current password is correct for the logged-in user
                    string checkCurrentPasswordQuery = "SELECT password FROM Users WHERE username = @username";
                    MySqlCommand cmdCheckPassword = new MySqlCommand(checkCurrentPasswordQuery, conn);
                    cmdCheckPassword.Parameters.AddWithValue("@username", loggedInUsername); // Ensure username matches exactly

                    // Get the stored password from the database
                    object result = cmdCheckPassword.ExecuteScalar();

                    // If no result, the user does not exist
                    if (result == null)
                    {
                        MessageBox.Show("User not found in the database.");
                        return;
                    }

                    string storedPassword = result.ToString();

                    // Now we compare the current password entered with the stored password
                    if (storedPassword.Trim() != currentPassword)
                    {
                        MessageBox.Show("Current password is incorrect. Please try again.");
                        return;
                    }

                    // Update the password in the database if the current password is correct
                    string updatePasswordQuery = "UPDATE Users SET password = @newPassword WHERE username = @username";
                    MySqlCommand cmdUpdatePassword = new MySqlCommand(updatePasswordQuery, conn);
                    cmdUpdatePassword.Parameters.AddWithValue("@newPassword", newPassword);
                    cmdUpdatePassword.Parameters.AddWithValue("@username", loggedInUsername); // Ensure username matches exactly

                    int resultUpdate = cmdUpdatePassword.ExecuteNonQuery();
                    if (resultUpdate > 0)
                    {
                        MessageBox.Show("Password changed successfully!");

                        // Clear the text fields after successful password change
                        tbCurrentPassword.Clear();
                        tbPassword.Clear();
                        tbConfirmPassword.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error: Failed to change password. Please try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Load event for the form
        private void Maintenance_Load(object sender, EventArgs e)
        {
            LoadCategories();  // Load categories into ListView when form is loaded
            LoadSuppliers();  // Load suppliers into ListView when form is loaded
            LoadItems(); // Load Items into ListView when form is loaded
        }

        // Method to load categories into ListView
        private void LoadCategories()
        {
            try
            {
                listView4.Items.Clear();  // Clear existing items in the ListView

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string selectQuery = "SELECT CategoryId, CategoryName FROM ItemCategory";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, conn);
                    DataTable categoryTable = new DataTable();
                    adapter.Fill(categoryTable);

                    // If there are data rows, add them to the ListView
                    if (categoryTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in categoryTable.Rows)
                        {
                            ListViewItem item = new ListViewItem(row["CategoryId"].ToString());
                            item.SubItems.Add(row["CategoryName"].ToString());
                            listView4.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }


        // Add Category Button Click Event
        private void btnAddCategoryName_Click(object sender, EventArgs e)
        {
            string categoryName = tbCategoryName.Text.Trim();  // Get the category name from the text box

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string insertQuery = "INSERT INTO ItemCategory (CategoryName) VALUES (@categoryName)";
                    MySqlCommand cmdInsertCategory = new MySqlCommand(insertQuery, conn);
                    cmdInsertCategory.Parameters.AddWithValue("@categoryName", categoryName);

                    int result = cmdInsertCategory.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Category added successfully!");
                        LoadCategories();  // Reload categories after addition
                        tbCategoryName.Clear();  // Clear the input field
                    }
                    else
                    {
                        MessageBox.Show("Error: Failed to add category.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Delete Category Button Click Event
        private void btnDeleteCategoryName_Click(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a category to delete.");
                return;
            }

            int categoryId = Convert.ToInt32(listView4.SelectedItems[0].Text);  // Get the selected CategoryId from the first column

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM ItemCategory WHERE CategoryId = @categoryId";
                    MySqlCommand cmdDeleteCategory = new MySqlCommand(deleteQuery, conn);
                    cmdDeleteCategory.Parameters.AddWithValue("@categoryId", categoryId);

                    int result = cmdDeleteCategory.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Category deleted successfully!");
                        LoadCategories();  // Reload categories after deletion
                    }
                    else
                    {
                        MessageBox.Show("Error: Failed to delete category.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Update Category Button Click Event
        private void btnUpdateCategoryName_Click(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a category to update.");
                return;
            }

            string categoryName = tbCategoryName.Text.Trim();  // Get the new category name from the text box
            int categoryId = Convert.ToInt32(listView4.SelectedItems[0].Text);  // Get the selected CategoryId from the first column

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string updateQuery = "UPDATE ItemCategory SET CategoryName = @categoryName WHERE CategoryId = @categoryId";
                    MySqlCommand cmdUpdateCategory = new MySqlCommand(updateQuery, conn);
                    cmdUpdateCategory.Parameters.AddWithValue("@categoryName", categoryName);
                    cmdUpdateCategory.Parameters.AddWithValue("@categoryId", categoryId);

                    int result = cmdUpdateCategory.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Category updated successfully!");
                        LoadCategories();  // Reload categories after update
                        tbCategoryName.Clear();  // Clear the input field
                    }
                    else
                    {
                        MessageBox.Show("Error: Failed to update category.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ListView Item Selection Changed Event
        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count > 0)
            {
                // When a category is selected in the ListView, display the category name in the TextBox
                tbCategoryName.Text = listView4.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void btnViewDataItemCategory_Click(object sender, EventArgs e)
        {
            // Reload the categories into the ListView
            LoadCategories();  // Reload categories to ensure the ListView is always updated with current data
        }

        // Method to load suppliers into ListView
        private void LoadSuppliers()
        {
            try
            {
                listView3.Items.Clear();  // Clear existing items in the ListView

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string selectQuery = "SELECT SupplierId, SupplierName, Address, ContactNumber FROM Supplier";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, conn);
                    DataTable supplierTable = new DataTable();
                    adapter.Fill(supplierTable);

                    // If there are data rows, add them to the ListView
                    if (supplierTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in supplierTable.Rows)
                        {
                            ListViewItem item = new ListViewItem(row["SupplierId"].ToString());
                            item.SubItems.Add(row["SupplierName"].ToString());
                            item.SubItems.Add(row["Address"].ToString());
                            item.SubItems.Add(row["ContactNumber"].ToString());
                            listView3.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading suppliers: " + ex.Message);
            }
        }

        // Add Supplier Button Click Event
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            string supplierName = tbSupplierName.Text.Trim();  // Get the supplier name from the text box
            string address = tbAddress.Text.Trim();           // Get the address
            string contactNumber = tbContactNumber.Text.Trim(); // Get the contact number

            if (string.IsNullOrEmpty(supplierName) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(contactNumber))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string insertQuery = "INSERT INTO Supplier (SupplierName, Address, ContactNumber) VALUES (@supplierName, @address, @contactNumber)";
                    MySqlCommand cmdInsertSupplier = new MySqlCommand(insertQuery, conn);
                    cmdInsertSupplier.Parameters.AddWithValue("@supplierName", supplierName);
                    cmdInsertSupplier.Parameters.AddWithValue("@address", address);
                    cmdInsertSupplier.Parameters.AddWithValue("@contactNumber", contactNumber);

                    int result = cmdInsertSupplier.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Supplier added successfully!");
                        LoadSuppliers();  // Reload suppliers after addition
                        tbSupplierName.Clear();
                        tbAddress.Clear();
                        tbContactNumber.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error: Failed to add supplier.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Delete Supplier Button Click Event
        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a supplier to delete.");
                return;
            }

            int supplierId = Convert.ToInt32(listView3.SelectedItems[0].Text);  // Get the selected SupplierId from the first column

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM Supplier WHERE SupplierId = @supplierId";
                    MySqlCommand cmdDeleteSupplier = new MySqlCommand(deleteQuery, conn);
                    cmdDeleteSupplier.Parameters.AddWithValue("@supplierId", supplierId);

                    int result = cmdDeleteSupplier.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Supplier deleted successfully!");
                        LoadSuppliers();  // Reload suppliers after deletion
                    }
                    else
                    {
                        MessageBox.Show("Error: Failed to delete supplier.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Update Supplier Button Click Event
        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a supplier to update.");
                return;
            }

            int supplierId = Convert.ToInt32(listView3.SelectedItems[0].Text);  // Get the selected SupplierId from the first column
            string supplierName = tbSupplierName.Text.Trim();
            string address = tbAddress.Text.Trim();
            string contactNumber = tbContactNumber.Text.Trim();

            if (string.IsNullOrEmpty(supplierName) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(contactNumber))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string updateQuery = "UPDATE Supplier SET SupplierName = @supplierName, Address = @address, ContactNumber = @contactNumber WHERE SupplierId = @supplierId";
                    MySqlCommand cmdUpdateSupplier = new MySqlCommand(updateQuery, conn);
                    cmdUpdateSupplier.Parameters.AddWithValue("@supplierId", supplierId);
                    cmdUpdateSupplier.Parameters.AddWithValue("@supplierName", supplierName);
                    cmdUpdateSupplier.Parameters.AddWithValue("@address", address);
                    cmdUpdateSupplier.Parameters.AddWithValue("@contactNumber", contactNumber);

                    int result = cmdUpdateSupplier.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Supplier updated successfully!");
                        LoadSuppliers();  // Reload suppliers after update
                        tbSupplierName.Clear();
                        tbAddress.Clear();
                        tbContactNumber.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error: Failed to update supplier.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Method to load items into ListView
        private void LoadItems()
        {
            listView2.Items.Clear();  // Clear existing items in the ListView

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ItemId, ItemName, BasePrice, CategoryId FROM Items";  // BasePrice used to represent amount here
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // If there are data rows, add them to the ListView
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["ItemId"].ToString());
                        item.SubItems.Add(reader["ItemName"].ToString());
                        item.SubItems.Add(reader["BasePrice"].ToString());  // Display BasePrice (Amount)
                        item.SubItems.Add(reader["CategoryId"].ToString());
                        listView2.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message);
            }
        }

        // Reset TextBoxes if no item is selected
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                tbItemName.Text = listView2.SelectedItems[0].SubItems[1].Text;
                tbBasedPrice.Text = listView2.SelectedItems[0].SubItems[2].Text;  // Continue to show BasePrice here (as amount/quantity)
                tbCategoryID.Text = listView2.SelectedItems[0].SubItems[3].Text;
            }
            else
            {
                tbItemName.Clear();
                tbBasedPrice.Clear();  // Clear the amount field
                tbCategoryID.Clear();
            }
        }

        // View Data Button for Suppliers - Reload suppliers into ListView
        private void btnViewDataSuppliers_Click(object sender, EventArgs e)
        {
            // Reload the suppliers into the ListView
            LoadSuppliers();  // This will refresh the ListView to show current data
        }

        // Add Item Button Click Event
        private void btnAddItemNameBasedPrice_Click(object sender, EventArgs e)
        {
            string itemName = tbItemName.Text.Trim();
            string amount = tbBasedPrice.Text.Trim();  // Treat tbBasedPrice as "amount"
            string categoryId = tbCategoryID.Text.Trim();

            if (string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(amount) || string.IsNullOrEmpty(categoryId))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string insertQuery = "INSERT INTO Items (ItemName, BasePrice, CategoryId) VALUES (@itemName, @amount, @categoryId)";
                    MySqlCommand cmdInsertItem = new MySqlCommand(insertQuery, conn);
                    cmdInsertItem.Parameters.AddWithValue("@itemName", itemName);
                    cmdInsertItem.Parameters.AddWithValue("@amount", amount);  // Use amount here for BasePrice
                    cmdInsertItem.Parameters.AddWithValue("@categoryId", categoryId);

                    int result = cmdInsertItem.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Item added successfully!");
                        LoadItems();  // Reload items after addition
                        tbItemName.Clear();
                        tbBasedPrice.Clear();  // Clear amount field
                        tbCategoryID.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error: Failed to add item.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Delete Item Button Click Event
        private void btnDeleteItemNameBasedPrice_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item to delete.");
                return;
            }

            int itemId = Convert.ToInt32(listView2.SelectedItems[0].Text);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM Items WHERE ItemId = @itemId";
                    MySqlCommand cmdDeleteItem = new MySqlCommand(deleteQuery, conn);
                    cmdDeleteItem.Parameters.AddWithValue("@itemId", itemId);

                    int result = cmdDeleteItem.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Item deleted successfully!");
                        LoadItems();  // Reload items after deletion
                    }
                    else
                    {
                        MessageBox.Show("Error: Failed to delete item.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Update Item Button Click Event
        private void btnUpdateItemNameBasedPrice_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item to update.");
                return;
            }

            int itemId = Convert.ToInt32(listView2.SelectedItems[0].Text);
            string itemName = tbItemName.Text.Trim();
            string amount = tbBasedPrice.Text.Trim();  // Treat tbBasedPrice as "amount"
            string categoryId = tbCategoryID.Text.Trim();

            if (string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(amount) || string.IsNullOrEmpty(categoryId))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string updateQuery = "UPDATE Items SET ItemName = @itemName, BasePrice = @amount, CategoryId = @categoryId WHERE ItemId = @itemId";
                    MySqlCommand cmdUpdateItem = new MySqlCommand(updateQuery, conn);
                    cmdUpdateItem.Parameters.AddWithValue("@itemId", itemId);
                    cmdUpdateItem.Parameters.AddWithValue("@itemName", itemName);
                    cmdUpdateItem.Parameters.AddWithValue("@amount", amount);  // Use amount here for BasePrice
                    cmdUpdateItem.Parameters.AddWithValue("@categoryId", categoryId);

                    int result = cmdUpdateItem.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Item updated successfully!");
                        LoadItems();  // Reload items after update
                        tbItemName.Clear();
                        tbBasedPrice.Clear();  // Clear amount field
                        tbCategoryID.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error: Failed to update item.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // View Data Button for Items - Reload items into ListView
        private void btnViewDataItems_Click(object sender, EventArgs e)
        {
            // Reload the items into the ListView
            LoadItems();  // This will refresh the ListView to show current data
        }
    }
}
