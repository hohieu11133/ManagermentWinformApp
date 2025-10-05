namespace SocialMediaDashboardDesign
{
    partial class AddInventoryForm
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

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.nudCurrentStock = new System.Windows.Forms.NumericUpDown();
            this.lblCost = new System.Windows.Forms.Label();
            this.nudCostPerUnit = new System.Windows.Forms.NumericUpDown();
            this.lblMinStock = new System.Windows.Forms.Label();
            this.nudMinStockLevel = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCostPerUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinStockLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(287, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "NHẬP NGUYÊN LIỆU";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(33, 80);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(118, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Tên Nguyên liệu:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(36, 103);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(280, 27);
            this.txtName.TabIndex = 2;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(330, 80);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(84, 20);
            this.lblUnit.TabIndex = 3;
            this.lblUnit.Text = "Đơn vị tính:";
            // 
            // cmbUnit
            // 
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(333, 103);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(150, 28);
            this.cmbUnit.TabIndex = 4;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(33, 150);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(65, 20);
            this.lblStock.TabIndex = 5;
            this.lblStock.Text = "Tồn kho:";
            // 
            // nudCurrentStock
            // 
            this.nudCurrentStock.DecimalPlaces = 2;
            this.nudCurrentStock.Location = new System.Drawing.Point(36, 173);
            this.nudCurrentStock.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudCurrentStock.Name = "nudCurrentStock";
            this.nudCurrentStock.Size = new System.Drawing.Size(150, 27);
            this.nudCurrentStock.TabIndex = 6;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(203, 150);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(107, 20);
            this.lblCost.TabIndex = 7;
            this.lblCost.Text = "Chi phí/Đơn vị:";
            // 
            // nudCostPerUnit
            // 
            this.nudCostPerUnit.DecimalPlaces = 2;
            this.nudCostPerUnit.Location = new System.Drawing.Point(206, 173);
            this.nudCostPerUnit.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudCostPerUnit.Name = "nudCostPerUnit";
            this.nudCostPerUnit.Size = new System.Drawing.Size(150, 27);
            this.nudCostPerUnit.TabIndex = 8;
            // 
            // lblMinStock
            // 
            this.lblMinStock.AutoSize = true;
            this.lblMinStock.Location = new System.Drawing.Point(373, 150);
            this.lblMinStock.Name = "lblMinStock";
            this.lblMinStock.Size = new System.Drawing.Size(124, 20);
            this.lblMinStock.TabIndex = 9;
            this.lblMinStock.Text = "Tồn kho tối thiểu:";
            // 
            // nudMinStockLevel
            // 
            this.nudMinStockLevel.DecimalPlaces = 2;
            this.nudMinStockLevel.Location = new System.Drawing.Point(376, 173);
            this.nudMinStockLevel.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudMinStockLevel.Name = "nudMinStockLevel";
            this.nudMinStockLevel.Size = new System.Drawing.Size(150, 27);
            this.nudMinStockLevel.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(36, 250);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(170, 250);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.Lime;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(406, 23);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(120, 40);
            this.btnImport.TabIndex = 13;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // AddInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 320);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.nudMinStockLevel);
            this.Controls.Add(this.lblMinStock);
            this.Controls.Add(this.nudCostPerUnit);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.nudCurrentStock);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddInventoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập Nguyên Vật Liệu";
            ((System.ComponentModel.ISupportInitialize)(this.nudCurrentStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCostPerUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinStockLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.NumericUpDown nudCurrentStock;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.NumericUpDown nudCostPerUnit;
        private System.Windows.Forms.Label lblMinStock;
        private System.Windows.Forms.NumericUpDown nudMinStockLevel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnImport;
    }
}