using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FINALS_LAB_ACT_1
{
    public partial class BackupAndRestore : Form
    {
        // Database Configuration
        private const string Server = "127.0.0.1";
        private const string User = "root";
        private const string Password = "Password123";
        private const string Database = "SalesInventory";
        private const int Port = 3306; // Default MySQL port

        public BackupAndRestore()
        {
            InitializeComponent();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                // Open SaveFileDialog for the user to choose a backup file location
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    Filter = "SQL Files (*.sql)|*.sql",
                    FileName = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.sql"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupFilePath = saveFileDialog.FileName;
                    string arguments = $"-h {Server} -P {Port} -u {User} --password={Password} --databases {Database} -r \"{backupFilePath}\" 2>nul";

                    ExecuteCommand("mysqldump", arguments);

                    MessageBox.Show($"Backup completed successfully.\nFile saved at: {backupFilePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                // Open OpenFileDialog for the user to select a backup file
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    Filter = "SQL Files (*.sql)|*.sql",
                    RestoreDirectory = true
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string restoreFilePath = openFileDialog.FileName;
                    string arguments = $"-h {Server} -P {Port} -u {User} --password={Password} {Database}";

                    ExecuteCommand("mysql", arguments, restoreFilePath);

                    MessageBox.Show("Database restore completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during restore: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecuteCommand(string fileName, string arguments, string inputFile = null)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                RedirectStandardInput = !string.IsNullOrEmpty(inputFile),
                RedirectStandardError = true, // Capture warnings or errors
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();

                // If restoring, send the SQL file content to the process
                if (!string.IsNullOrEmpty(inputFile))
                {
                    using (StreamReader sr = new StreamReader(inputFile))
                    {
                        using (StreamWriter sw = process.StandardInput)
                        {
                            sw.Write(sr.ReadToEnd());
                        }
                    }
                }

                process.WaitForExit();

                // Handle errors
                string error = process.StandardError.ReadToEnd();
                if (!string.IsNullOrEmpty(error) && !error.Contains("Using a password on the command line interface can be insecure"))
                {
                    throw new Exception($"Error during execution: {error}");
                }
            }
        }

        
    }
}
