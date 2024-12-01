using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FINALS_LAB_ACT_1
{
    public partial class LOGIN : Form
    {
        // MySQL Connection string
        string connectionString = "Server=127.0.0.1;Database=salesinventory;Uid=root;Pwd=Password123;";

        public LOGIN()
        {
            InitializeComponent();
        }

        // Form load event to ensure password is hidden by default with asterisks
        private void LOGIN_Load(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = '*';
        }

        // Checkbox event to toggle password visibility
        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // If the checkbox is checked, show the password
            if (cbShowPassword.Checked)
            {
                tbPassword.PasswordChar = '\0'; // Show password as plain text
            }
            else
            {
                tbPassword.PasswordChar = '*'; // Hide password with asterisks
            }
        }

        // Login Button event to handle user login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if the user exists with the entered credentials
                    string loginQuery = "SELECT COUNT(*) FROM Users WHERE username = @username AND password = @password";
                    MySqlCommand cmdLogin = new MySqlCommand(loginQuery, conn);
                    cmdLogin.Parameters.AddWithValue("@username", username);
                    cmdLogin.Parameters.AddWithValue("@password", password); // Do NOT store passwords in plain text, use hashing in production.

                    int userExists = Convert.ToInt32(cmdLogin.ExecuteScalar());

                    if (userExists > 0)
                    {
                        // Login successful, navigate to the HomePage
                        MessageBox.Show("Login successful!");

                        // Instantiate and show the HomePage form
                        HomePage homePage = new HomePage();
                        homePage.Show();  // Show HomePage

                        // Hide the Login form
                        this.Hide();  // Hide the Login form
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password. Please try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Redirect to the SignUp form when user clicks the "Register Here" label
        private void lblRegisterHere_Click(object sender, EventArgs e)
        {
            SIGNUP signupForm = new SIGNUP();
            signupForm.Show();
            this.Hide();  // Hide Login form and show SignUp form
        }
    }
}
