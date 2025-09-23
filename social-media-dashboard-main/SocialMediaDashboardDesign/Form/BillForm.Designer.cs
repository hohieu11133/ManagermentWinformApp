namespace SocialMediaDashboardDesign
{
    partial class BillForm
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
            this.btnConfirmPayment = new FrameworkTest.SATAButton();
            this.billListView = new System.Windows.Forms.ListView();
            this.ItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Subtotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblOrderIdValue = new System.Windows.Forms.Label();
            this.lblTableNumberValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConfirmPayment
            // 
            this.btnConfirmPayment.ButtonText = "Thanh toán";
            this.btnConfirmPayment.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnConfirmPayment.CheckedForeColor = System.Drawing.Color.White;
            this.btnConfirmPayment.CheckedImageTint = System.Drawing.Color.White;
            this.btnConfirmPayment.CheckedOutline = System.Drawing.Color.Transparent;
            this.btnConfirmPayment.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnConfirmPayment.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirmPayment.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnConfirmPayment.HoverForeColor = System.Drawing.Color.White;
            this.btnConfirmPayment.HoverImage = null;
            this.btnConfirmPayment.HoverImageTint = System.Drawing.Color.White;
            this.btnConfirmPayment.HoverOutline = System.Drawing.Color.Transparent;
            this.btnConfirmPayment.Image = null;
            this.btnConfirmPayment.ImageAutoCenter = true;
            this.btnConfirmPayment.ImageExpand = new System.Drawing.Point(3, 3);
            this.btnConfirmPayment.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnConfirmPayment.ImageTint = System.Drawing.Color.White;
            this.btnConfirmPayment.IsToggleButton = false;
            this.btnConfirmPayment.IsToggled = false;
            this.btnConfirmPayment.Location = new System.Drawing.Point(314, 557);
            this.btnConfirmPayment.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnConfirmPayment.Name = "btnConfirmPayment";
            this.btnConfirmPayment.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnConfirmPayment.NormalForeColor = System.Drawing.Color.White;
            this.btnConfirmPayment.NormalOutline = System.Drawing.Color.Transparent;
            this.btnConfirmPayment.OutlineThickness = 0F;
            this.btnConfirmPayment.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnConfirmPayment.PressedForeColor = System.Drawing.Color.White;
            this.btnConfirmPayment.PressedImageTint = System.Drawing.Color.White;
            this.btnConfirmPayment.PressedOutline = System.Drawing.Color.Transparent;
            this.btnConfirmPayment.Rounding = new System.Windows.Forms.Padding(10);
            this.btnConfirmPayment.Size = new System.Drawing.Size(127, 40);
            this.btnConfirmPayment.TabIndex = 7;
            this.btnConfirmPayment.TextAutoCenter = true;
            this.btnConfirmPayment.TextOffset = new System.Drawing.Point(0, 0);
            this.btnConfirmPayment.Click += new System.EventHandler(this.btnConfirmPayment_Click);
            // 
            // billListView
            // 
            this.billListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemName,
            this.Quantity,
            this.Price,
            this.Subtotal});
            this.billListView.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.billListView.FullRowSelect = true;
            this.billListView.GridLines = true;
            this.billListView.HideSelection = false;
            this.billListView.Location = new System.Drawing.Point(-3, 54);
            this.billListView.Name = "billListView";
            this.billListView.Size = new System.Drawing.Size(458, 396);
            this.billListView.TabIndex = 8;
            this.billListView.UseCompatibleStateImageBehavior = false;
            this.billListView.View = System.Windows.Forms.View.Details;
            this.billListView.SelectedIndexChanged += new System.EventHandler(this.billListView_SelectedIndexChanged);
            // 
            // ItemName
            // 
            this.ItemName.Text = "ItemName";
            this.ItemName.Width = 150;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 100;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 100;
            // 
            // Subtotal
            // 
            this.Subtotal.Text = "Subtotal";
            this.Subtotal.Width = 100;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(212, 468);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(70, 25);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "label1";
            // 
            // lblOrderIdValue
            // 
            this.lblOrderIdValue.AutoSize = true;
            this.lblOrderIdValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderIdValue.Location = new System.Drawing.Point(12, 9);
            this.lblOrderIdValue.Name = "lblOrderIdValue";
            this.lblOrderIdValue.Size = new System.Drawing.Size(85, 25);
            this.lblOrderIdValue.TabIndex = 10;
            this.lblOrderIdValue.Text = "OrderId";
            // 
            // lblTableNumberValue
            // 
            this.lblTableNumberValue.AutoSize = true;
            this.lblTableNumberValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableNumberValue.Location = new System.Drawing.Point(335, 9);
            this.lblTableNumberValue.Name = "lblTableNumberValue";
            this.lblTableNumberValue.Size = new System.Drawing.Size(67, 25);
            this.lblTableNumberValue.TabIndex = 11;
            this.lblTableNumberValue.Text = "Table";
            // 
            // BillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 600);
            this.Controls.Add(this.lblTableNumberValue);
            this.Controls.Add(this.lblOrderIdValue);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.billListView);
            this.Controls.Add(this.btnConfirmPayment);
            this.Name = "BillForm";
            this.Text = "BillForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FrameworkTest.SATAButton btnConfirmPayment;
        private System.Windows.Forms.ListView billListView;
        private System.Windows.Forms.ColumnHeader ItemName;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader Subtotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblOrderIdValue;
        private System.Windows.Forms.Label lblTableNumberValue;
    }
}