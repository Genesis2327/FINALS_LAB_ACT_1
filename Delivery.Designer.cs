namespace FINALS_LAB_ACT_1
{
    partial class Delivery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblQuantity = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView4 = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddAddDelivery = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cbItemName = new System.Windows.Forms.ComboBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.BackColor = System.Drawing.Color.Transparent;
            this.lblQuantity.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.ForeColor = System.Drawing.Color.Black;
            this.lblQuantity.Location = new System.Drawing.Point(26, 284);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(81, 19);
            this.lblQuantity.TabIndex = 47;
            this.lblQuantity.Text = "Quantity:";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(129, 284);
            this.tbQuantity.Multiline = true;
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(82, 34);
            this.tbQuantity.TabIndex = 46;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.listView4);
            this.panel1.Location = new System.Drawing.Point(12, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(735, 180);
            this.panel1.TabIndex = 44;
            // 
            // listView4
            // 
            this.listView4.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2});
            this.listView4.HideSelection = false;
            this.listView4.Location = new System.Drawing.Point(29, 18);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(680, 145);
            this.listView4.TabIndex = 1;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "DeliveryID";
            this.columnHeader12.Width = 88;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Delivery Date";
            this.columnHeader13.Width = 154;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item ID";
            this.columnHeader1.Width = 82;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Item Name";
            this.columnHeader3.Width = 119;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Quantity";
            this.columnHeader2.Width = 84;
            // 
            // btnAddAddDelivery
            // 
            this.btnAddAddDelivery.BackColor = System.Drawing.Color.Green;
            this.btnAddAddDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAddDelivery.ForeColor = System.Drawing.Color.White;
            this.btnAddAddDelivery.Location = new System.Drawing.Point(108, 375);
            this.btnAddAddDelivery.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddAddDelivery.Name = "btnAddAddDelivery";
            this.btnAddAddDelivery.Size = new System.Drawing.Size(180, 54);
            this.btnAddAddDelivery.TabIndex = 43;
            this.btnAddAddDelivery.Text = "Add Delivery";
            this.btnAddAddDelivery.UseVisualStyleBackColor = false;
            this.btnAddAddDelivery.Click += new System.EventHandler(this.btnAddAddDelivery_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(454, 227);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(267, 22);
            this.dateTimePicker1.TabIndex = 48;
            // 
            // cbItemName
            // 
            this.cbItemName.FormattingEnabled = true;
            this.cbItemName.Location = new System.Drawing.Point(164, 242);
            this.cbItemName.Name = "cbItemName";
            this.cbItemName.Size = new System.Drawing.Size(121, 24);
            this.cbItemName.TabIndex = 49;
            this.cbItemName.SelectedIndexChanged += new System.EventHandler(this.cbItemName_SelectedIndexChanged);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.BackColor = System.Drawing.Color.Transparent;
            this.lblItemName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.Black;
            this.lblItemName.Location = new System.Drawing.Point(21, 242);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(101, 19);
            this.lblItemName.TabIndex = 51;
            this.lblItemName.Text = "ItemName:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(160, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 19);
            this.label2.TabIndex = 52;
            // 
            // Delivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 440);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.cbItemName);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAddAddDelivery);
            this.Name = "Delivery";
            this.Text = "Delivery";
            this.Load += new System.EventHandler(this.Delivery_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Button btnAddAddDelivery;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cbItemName;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label2;
    }
}
