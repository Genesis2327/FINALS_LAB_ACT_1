using System;
using System.Windows.Forms;

namespace FINALS_LAB_ACT_1
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        // To load the Maintenance form inside Panel3
        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            // Clear Panel3 and load the Maintenance form
            panel3.Controls.Clear();
            Maintenance maintenanceForm = new Maintenance();
            maintenanceForm.TopLevel = false; // Allow this form to be inside Panel3
            maintenanceForm.Dock = DockStyle.Fill; // Fill Panel3
            panel3.Controls.Add(maintenanceForm);
            maintenanceForm.Show();
        }

        // To load the Delivery form inside Panel3
        private void btnDelivery_Click(object sender, EventArgs e)
        {
            // Clear Panel3 and load the Delivery form
            panel3.Controls.Clear();
            Delivery deliveryForm = new Delivery();
            deliveryForm.TopLevel = false; // Allow this form to be inside Panel3
            deliveryForm.Dock = DockStyle.Fill; // Fill Panel3
            panel3.Controls.Add(deliveryForm);
            deliveryForm.Show();
        }

        // To load the Inventory Monitoring form inside Panel3
        private void btnInventoryMonitoring_Click(object sender, EventArgs e)
        {
            // Clear Panel3 and load the Inventory Monitoring form
            panel3.Controls.Clear();
            InventoryMonitoring inventoryMonitoringForm = new InventoryMonitoring();
            inventoryMonitoringForm.TopLevel = false; // Allow this form to be inside Panel3
            inventoryMonitoringForm.Dock = DockStyle.Fill; // Fill Panel3
            panel3.Controls.Add(inventoryMonitoringForm);
            inventoryMonitoringForm.Show();
        }

        // To load the Point of Sales form inside Panel3
        private void btnPointOfSales_Click(object sender, EventArgs e)
        {
            // Clear Panel3 and load the Point of Sales form
            panel3.Controls.Clear();
            PointOfSales pointOfSalesForm = new PointOfSales();
            pointOfSalesForm.TopLevel = false; // Allow this form to be inside Panel3
            pointOfSalesForm.Dock = DockStyle.Fill; // Fill Panel3
            panel3.Controls.Add(pointOfSalesForm);
            pointOfSalesForm.Show();
        }

        // To load the Sales Monitoring form inside Panel3
        private void btnSalesMonitoring_Click(object sender, EventArgs e)
        {
            // Clear Panel3 and load the Sales Monitoring form
            panel3.Controls.Clear();
            SalesMonitoring salesMonitoringForm = new SalesMonitoring();
            salesMonitoringForm.TopLevel = false; // Allow this form to be inside Panel3
            salesMonitoringForm.Dock = DockStyle.Fill; // Fill Panel3
            panel3.Controls.Add(salesMonitoringForm);
            salesMonitoringForm.Show();
        }

        // Logout Button click event
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // Show the Login form and hide the current HomePage form
            LOGIN loginForm = new LOGIN();
            loginForm.Show();
            this.Hide();  // Hide the HomePage form
        }

        // Optional: If you want to reset the panel or do additional work when needed.
        private void panel7_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
