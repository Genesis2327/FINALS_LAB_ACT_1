using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FINALS_LAB_ACT_1
{
    public partial class SIGNUP : Form
    {
        // MySQL Connection string
        string connectionString = "Server=127.0.0.1;Database=salesinventory;Uid=root;Pwd=Password123;";

        public SIGNUP()
        {
            InitializeComponent();
        }

        // Form load event to ensure password is hidden by default with asterisks
        private void SIGNUP_Load(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = '*';
            tbConfirmPassword.PasswordChar = '*';
        }

        // Checkbox event to toggle password visibility
        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                tbPassword.PasswordChar = '\0';
                tbConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                tbPassword.PasswordChar = '*';
                tbConfirmPassword.PasswordChar = '*';
            }
        }

        // Sign Up Button event to handle user registration
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            string confirmPassword = tbConfirmPassword.Text;

            // Check if passwords match
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if the username already exists
                    string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE username = @username";
                    MySqlCommand cmdCheck = new MySqlCommand(checkUserQuery, conn);
                    cmdCheck.Parameters.AddWithValue("@username", username);
                    int userExists = Convert.ToInt32(cmdCheck.ExecuteScalar());

                    if (userExists > 0)
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.");
                        return;
                    }

                    // Insert new user into the database
                    string insertQuery = "INSERT INTO Users (username, password) VALUES (@username, @password)";
                    MySqlCommand cmdInsert = new MySqlCommand(insertQuery, conn);
                    cmdInsert.Parameters.AddWithValue("@username", username);
                    cmdInsert.Parameters.AddWithValue("@password", password);

                    int result = cmdInsert.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Sign up successful!");

                        // Clear the text fields after successful sign-up
                        tbUsername.Clear();
                        tbPassword.Clear();
                        tbConfirmPassword.Clear();

                        // Automatically proceed to the Login page
                        LOGIN loginForm = new LOGIN();
                        loginForm.Show();
                        this.Hide();  // Hide SignUp form and show Login form
                    }
                    else
                    {
                        MessageBox.Show("Error: Sign up failed. Please try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Link to go back to login page
        private void lblLoginHere_Click(object sender, EventArgs e)
        {
            LOGIN loginForm = new LOGIN();
            loginForm.Show();
            this.Hide();  // Hide SignUp form and show Login form
        }
    }
}
