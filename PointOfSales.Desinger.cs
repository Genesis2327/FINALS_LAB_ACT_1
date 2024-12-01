namespace FINALS_LAB_ACT_1
{
    partial class PointOfSales
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
            this.btnViewTheCart = new System.Windows.Forms.Button();
            this.tbTotalAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbItemId = new System.Windows.Forms.TextBox();
            this.lblItemId = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddtoCart = new System.Windows.Forms.Button();
            this.btnDeleteInTheCart = new System.Windows.Forms.Button();
            this.btnUpdateTheCart = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnViewTheCart
            // 
            this.btnViewTheCart.BackColor = System.Drawing.Color.Green;
            this.btnViewTheCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewTheCart.ForeColor = System.Drawing.Color.White;
            this.btnViewTheCart.Location = new System.Drawing.Point(644, 243);
            this.btnViewTheCart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewTheCart.Name = "btnViewTheCart";
            this.btnViewTheCart.Size = new System.Drawing.Size(103, 30);
            this.btnViewTheCart.TabIndex = 56;
            this.btnViewTheCart.Text = "View";
            this.btnViewTheCart.UseVisualStyleBackColor = false;
            this.btnViewTheCart.Click += new System.EventHandler(this.btnViewTheCart_Click);
            // 
            // tbTotalAmount
            // 
            this.tbTotalAmount.Location = new System.Drawing.Point(140, 333);
            this.tbTotalAmount.Multiline = true;
            this.tbTotalAmount.Name = "tbTotalAmount";
            this.tbTotalAmount.Size = new System.Drawing.Size(260, 34);
            this.tbTotalAmount.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 333);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 19);
            this.label3.TabIndex = 54;
            this.label3.Text = "Total Amount:";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(114, 288);
            this.tbQuantity.Multiline = true;
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(260, 34);
            this.tbQuantity.TabIndex = 53;
            this.tbQuantity.TextChanged += new System.EventHandler(this.tbQuantity_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 19);
            this.label2.TabIndex = 52;
            this.label2.Text = "Quantity:";
            // 
            // tbItemId
            // 
            this.tbItemId.Location = new System.Drawing.Point(114, 248);
            this.tbItemId.Multiline = true;
            this.tbItemId.Name = "tbItemId";
            this.tbItemId.Size = new System.Drawing.Size(260, 34);
            this.tbItemId.TabIndex = 51;
            // 
            // lblItemId
            // 
            this.lblItemId.AutoSize = true;
            this.lblItemId.BackColor = System.Drawing.Color.Transparent;
            this.lblItemId.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemId.ForeColor = System.Drawing.Color.Black;
            this.lblItemId.Location = new System.Drawing.Point(14, 253);
            this.lblItemId.Name = "lblItemId";
            this.lblItemId.Size = new System.Drawing.Size(72, 19);
            this.lblItemId.TabIndex = 50;
            this.lblItemId.Text = "Item ID:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel3.Controls.Add(this.listView3);
            this.panel3.Location = new System.Drawing.Point(12, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(735, 209);
            this.panel3.TabIndex = 49;
            // 
            // listView3
            // 
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader1});
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(23, 19);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(701, 171);
            this.listView3.TabIndex = 0;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Receipt ID";
            this.columnHeader8.Width = 77;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Receipt Date";
            this.columnHeader9.Width = 170;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "ItemID";
            this.columnHeader10.Width = 68;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Quantity";
            this.columnHeader11.Width = 68;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "TotaAmount";
            this.columnHeader1.Width = 134;
            // 
            // btnAddtoCart
            // 
            this.btnAddtoCart.BackColor = System.Drawing.Color.Green;
            this.btnAddtoCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddtoCart.ForeColor = System.Drawing.Color.White;
            this.btnAddtoCart.Location = new System.Drawing.Point(18, 391);
            this.btnAddtoCart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddtoCart.Name = "btnAddtoCart";
            this.btnAddtoCart.Size = new System.Drawing.Size(106, 29);
            this.btnAddtoCart.TabIndex = 48;
            this.btnAddtoCart.Text = "Add";
            this.btnAddtoCart.UseVisualStyleBackColor = false;
            this.btnAddtoCart.Click += new System.EventHandler(this.btnAddtoCart_Click);
            // 
            // btnDeleteInTheCart
            // 
            this.btnDeleteInTheCart.BackColor = System.Drawing.Color.Red;
            this.btnDeleteInTheCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteInTheCart.ForeColor = System.Drawing.Color.White;
            this.btnDeleteInTheCart.Location = new System.Drawing.Point(334, 390);
            this.btnDeleteInTheCart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteInTheCart.Name = "btnDeleteInTheCart";
            this.btnDeleteInTheCart.Size = new System.Drawing.Size(106, 30);
            this.btnDeleteInTheCart.TabIndex = 47;
            this.btnDeleteInTheCart.Text = "Delete";
            this.btnDeleteInTheCart.UseVisualStyleBackColor = false;
            this.btnDeleteInTheCart.Click += new System.EventHandler(this.btnDeleteInTheCart_Click);
            // 
            // btnUpdateTheCart
            // 
            this.btnUpdateTheCart.BackColor = System.Drawing.Color.Teal;
            this.btnUpdateTheCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateTheCart.ForeColor = System.Drawing.Color.White;
            this.btnUpdateTheCart.Location = new System.Drawing.Point(180, 391);
            this.btnUpdateTheCart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateTheCart.Name = "btnUpdateTheCart";
            this.btnUpdateTheCart.Size = new System.Drawing.Size(103, 29);
            this.btnUpdateTheCart.TabIndex = 46;
            this.btnUpdateTheCart.Text = "Update";
            this.btnUpdateTheCart.UseVisualStyleBackColor = false;
            this.btnUpdateTheCart.Click += new System.EventHandler(this.btnUpdateTheCart_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(451, 278);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(447, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 19);
            this.label1.TabIndex = 58;
            this.label1.Text = "Receipt Date:";
            // 
            // PointOfSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 440);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnViewTheCart);
            this.Controls.Add(this.tbTotalAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbItemId);
            this.Controls.Add(this.lblItemId);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnAddtoCart);
            this.Controls.Add(this.btnDeleteInTheCart);
            this.Controls.Add(this.btnUpdateTheCart);
            this.Name = "PointOfSales";
            this.Text = "PointOfSales";
            this.Load += new System.EventHandler(this.PointOfSales_Load);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnViewTheCart;
        private System.Windows.Forms.TextBox tbTotalAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbItemId;
        private System.Windows.Forms.Label lblItemId;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button btnAddtoCart;
        private System.Windows.Forms.Button btnDeleteInTheCart;
        private System.Windows.Forms.Button btnUpdateTheCart;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
    }
}
