namespace SocialMediaDashboardDesign.Control
{
    partial class InventoryManagementControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // -------------------------------------------------------------------
        // KHAI BÁO CÁC CỘT THỦ CÔNG (CHỈ CẦN THIẾT CHO CÁC CỘT KHÔNG CÓ TRONG BẢNG Ingredients GỐC)
        // -------------------------------------------------------------------
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitName;     // Cột thủ công cho TÊN ĐƠN VỊ (Alias UnitName)
        private System.Windows.Forms.DataGridViewButtonColumn colActions;   // Cột thủ công cho Nút bấm

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.colActions = new System.Windows.Forms.DataGridViewButtonColumn();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.dgvIngredient = new System.Windows.Forms.DataGridView();
            this.ingredientIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costPerUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minStockLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingredientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.restaurantManagementDBDataSet = new SocialMediaDashboardDesign.RestaurantManagementDBDataSet();
            this.filtersPanel = new System.Windows.Forms.Panel();
            this.btnAddInventory = new FrameworkTest.SATAButton();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.unitIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingredientsTableAdapter = new SocialMediaDashboardDesign.RestaurantManagementDBDataSetTableAdapters.IngredientsTableAdapter();
            this.deletebtn = new FrameworkTest.SATAButton();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restaurantManagementDBDataSet)).BeginInit();
            this.filtersPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // colActions
            // 
            this.colActions.FillWeight = 80F;
            this.colActions.HeaderText = "Hành động";
            this.colActions.MinimumWidth = 6;
            this.colActions.Name = "colActions";
            this.colActions.ReadOnly = true;
            this.colActions.Text = "Sửa/Nhập";
            this.colActions.UseColumnTextForButtonValue = true;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.mainPanel.Controls.Add(this.dgvIngredient);
            this.mainPanel.Controls.Add(this.filtersPanel);
            this.mainPanel.Controls.Add(this.headerPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.Size = new System.Drawing.Size(1134, 668);
            this.mainPanel.TabIndex = 1;
            // 
            // dgvIngredient
            // 
            this.dgvIngredient.AllowUserToAddRows = false;
            this.dgvIngredient.AllowUserToDeleteRows = false;
            this.dgvIngredient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIngredient.AutoGenerateColumns = false;
            this.dgvIngredient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIngredient.BackgroundColor = System.Drawing.Color.White;
            this.dgvIngredient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvIngredient.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvIngredient.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIngredient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIngredient.ColumnHeadersHeight = 40;
            this.dgvIngredient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ingredientIDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.currentStockDataGridViewTextBoxColumn,
            this.costPerUnitDataGridViewTextBoxColumn,
            this.minStockLevelDataGridViewTextBoxColumn,
            this.colActions});
            this.dgvIngredient.DataSource = this.ingredientsBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIngredient.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvIngredient.EnableHeadersVisualStyles = false;
            this.dgvIngredient.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dgvIngredient.Location = new System.Drawing.Point(23, 160);
            this.dgvIngredient.Name = "dgvIngredient";
            this.dgvIngredient.ReadOnly = true;
            this.dgvIngredient.RowHeadersVisible = false;
            this.dgvIngredient.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.dgvIngredient.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvIngredient.RowTemplate.Height = 50;
            this.dgvIngredient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngredient.Size = new System.Drawing.Size(1088, 485);
            this.dgvIngredient.TabIndex = 2;
            this.dgvIngredient.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIngredient_CellContentClick_1);
            // 
            // ingredientIDDataGridViewTextBoxColumn
            // 
            this.ingredientIDDataGridViewTextBoxColumn.DataPropertyName = "IngredientID";
            this.ingredientIDDataGridViewTextBoxColumn.FillWeight = 50F;
            this.ingredientIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.ingredientIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ingredientIDDataGridViewTextBoxColumn.Name = "ingredientIDDataGridViewTextBoxColumn";
            this.ingredientIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.FillWeight = 150F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Tên Nguyên liệu";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // currentStockDataGridViewTextBoxColumn
            // 
            this.currentStockDataGridViewTextBoxColumn.DataPropertyName = "CurrentStock";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.currentStockDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.currentStockDataGridViewTextBoxColumn.FillWeight = 80F;
            this.currentStockDataGridViewTextBoxColumn.HeaderText = "Tồn kho";
            this.currentStockDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.currentStockDataGridViewTextBoxColumn.Name = "currentStockDataGridViewTextBoxColumn";
            this.currentStockDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costPerUnitDataGridViewTextBoxColumn
            // 
            this.costPerUnitDataGridViewTextBoxColumn.DataPropertyName = "CostPerUnit";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.costPerUnitDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.costPerUnitDataGridViewTextBoxColumn.HeaderText = "Giá vốn/ĐV";
            this.costPerUnitDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.costPerUnitDataGridViewTextBoxColumn.Name = "costPerUnitDataGridViewTextBoxColumn";
            this.costPerUnitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // minStockLevelDataGridViewTextBoxColumn
            // 
            this.minStockLevelDataGridViewTextBoxColumn.DataPropertyName = "MinStockLevel";
            this.minStockLevelDataGridViewTextBoxColumn.FillWeight = 80F;
            this.minStockLevelDataGridViewTextBoxColumn.HeaderText = "Tồn tối thiểu";
            this.minStockLevelDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.minStockLevelDataGridViewTextBoxColumn.Name = "minStockLevelDataGridViewTextBoxColumn";
            this.minStockLevelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ingredientsBindingSource
            // 
            this.ingredientsBindingSource.DataMember = "Ingredients";
            this.ingredientsBindingSource.DataSource = this.restaurantManagementDBDataSet;
            // 
            // restaurantManagementDBDataSet
            // 
            this.restaurantManagementDBDataSet.DataSetName = "RestaurantManagementDBDataSet";
            this.restaurantManagementDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // filtersPanel
            // 
            this.filtersPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filtersPanel.BackColor = System.Drawing.Color.White;
            this.filtersPanel.Controls.Add(this.deletebtn);
            this.filtersPanel.Controls.Add(this.btnAddInventory);
            this.filtersPanel.Location = new System.Drawing.Point(23, 85);
            this.filtersPanel.Name = "filtersPanel";
            this.filtersPanel.Size = new System.Drawing.Size(1088, 60);
            this.filtersPanel.TabIndex = 1;
            // 
            // btnAddInventory
            // 
            this.btnAddInventory.ButtonText = "Thêm NVL";
            this.btnAddInventory.CheckedBackground = System.Drawing.Color.Cyan;
            this.btnAddInventory.CheckedForeColor = System.Drawing.Color.White;
            this.btnAddInventory.CheckedImageTint = System.Drawing.Color.White;
            this.btnAddInventory.CheckedOutline = System.Drawing.Color.Transparent;
            this.btnAddInventory.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddInventory.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddInventory.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnAddInventory.HoverForeColor = System.Drawing.Color.White;
            this.btnAddInventory.HoverImage = null;
            this.btnAddInventory.HoverImageTint = System.Drawing.Color.White;
            this.btnAddInventory.HoverOutline = System.Drawing.Color.Transparent;
            this.btnAddInventory.Image = null;
            this.btnAddInventory.ImageAutoCenter = true;
            this.btnAddInventory.ImageExpand = new System.Drawing.Point(3, 3);
            this.btnAddInventory.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnAddInventory.ImageTint = System.Drawing.Color.White;
            this.btnAddInventory.IsToggleButton = false;
            this.btnAddInventory.IsToggled = false;
            this.btnAddInventory.Location = new System.Drawing.Point(777, 15);
            this.btnAddInventory.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnAddInventory.Name = "btnAddInventory";
            this.btnAddInventory.NormalBackground = System.Drawing.Color.MediumTurquoise;
            this.btnAddInventory.NormalForeColor = System.Drawing.Color.White;
            this.btnAddInventory.NormalOutline = System.Drawing.Color.Transparent;
            this.btnAddInventory.OutlineThickness = 0F;
            this.btnAddInventory.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnAddInventory.PressedForeColor = System.Drawing.Color.White;
            this.btnAddInventory.PressedImageTint = System.Drawing.Color.White;
            this.btnAddInventory.PressedOutline = System.Drawing.Color.Transparent;
            this.btnAddInventory.Rounding = new System.Windows.Forms.Padding(10);
            this.btnAddInventory.Size = new System.Drawing.Size(99, 32);
            this.btnAddInventory.TabIndex = 3;
            this.btnAddInventory.TextAutoCenter = true;
            this.btnAddInventory.TextOffset = new System.Drawing.Point(0, 0);
            this.btnAddInventory.Click += new System.EventHandler(this.btnAddInventory_Click);
            // 
            // headerPanel
            // 
            this.headerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Location = new System.Drawing.Point(23, 23);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1088, 50);
            this.headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(409, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản Lý Kho Nguyên Vật Liệu";
            // 
            // unitIDDataGridViewTextBoxColumn
            // 
            this.unitIDDataGridViewTextBoxColumn.DataPropertyName = "UnitID";
            this.unitIDDataGridViewTextBoxColumn.FillWeight = 1F;
            this.unitIDDataGridViewTextBoxColumn.HeaderText = "UnitID";
            this.unitIDDataGridViewTextBoxColumn.MinimumWidth = 2;
            this.unitIDDataGridViewTextBoxColumn.Name = "unitIDDataGridViewTextBoxColumn";
            this.unitIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitIDDataGridViewTextBoxColumn.Visible = false;
            this.unitIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // ingredientsTableAdapter
            // 
            this.ingredientsTableAdapter.ClearBeforeFill = true;
            // 
            // deletebtn
            // 
            this.deletebtn.ButtonText = "Xóa NVL";
            this.deletebtn.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.deletebtn.CheckedForeColor = System.Drawing.Color.White;
            this.deletebtn.CheckedImageTint = System.Drawing.Color.White;
            this.deletebtn.CheckedOutline = System.Drawing.Color.Transparent;
            this.deletebtn.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.deletebtn.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.deletebtn.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.deletebtn.HoverForeColor = System.Drawing.Color.White;
            this.deletebtn.HoverImage = null;
            this.deletebtn.HoverImageTint = System.Drawing.Color.White;
            this.deletebtn.HoverOutline = System.Drawing.Color.Transparent;
            this.deletebtn.Image = null;
            this.deletebtn.ImageAutoCenter = true;
            this.deletebtn.ImageExpand = new System.Drawing.Point(3, 3);
            this.deletebtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.deletebtn.ImageTint = System.Drawing.Color.White;
            this.deletebtn.IsToggleButton = false;
            this.deletebtn.IsToggled = false;
            this.deletebtn.Location = new System.Drawing.Point(886, 15);
            this.deletebtn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.deletebtn.NormalForeColor = System.Drawing.Color.White;
            this.deletebtn.NormalOutline = System.Drawing.Color.Transparent;
            this.deletebtn.OutlineThickness = 0F;
            this.deletebtn.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.deletebtn.PressedForeColor = System.Drawing.Color.White;
            this.deletebtn.PressedImageTint = System.Drawing.Color.White;
            this.deletebtn.PressedOutline = System.Drawing.Color.Transparent;
            this.deletebtn.Rounding = new System.Windows.Forms.Padding(10);
            this.deletebtn.Size = new System.Drawing.Size(99, 32);
            this.deletebtn.TabIndex = 4;
            this.deletebtn.TextAutoCenter = true;
            this.deletebtn.TextOffset = new System.Drawing.Point(0, 0);
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // InventoryManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "InventoryManagementControl";
            this.Size = new System.Drawing.Size(1134, 668);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restaurantManagementDBDataSet)).EndInit();
            this.filtersPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // -------------------------------------------------------------------
        // KHAI BÁO BIẾN CUỐI FILE DESIGNER.CS
        // -------------------------------------------------------------------
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.DataGridView dgvIngredient;
        private System.Windows.Forms.Panel filtersPanel;
        private FrameworkTest.SATAButton btnAddInventory;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;

        //// CỘT THỦ CÔNG MỚI
        //private System.Windows.Forms.DataGridViewTextBoxColumn colUnitName;
        //private System.Windows.Forms.DataGridViewButtonColumn colActions;

        // CỘT TỰ ĐỘNG SINH RA (GIỮ LẠI)
        private System.Windows.Forms.DataGridViewTextBoxColumn ingredientIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitIDDataGridViewTextBoxColumn;
        // Remove one of the duplicate declarations for colActions.
        // The following duplicate should be removed from the end of the file:

        // private System.Windows.Forms.DataGridViewButtonColumn colActions;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costPerUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minStockLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource ingredientsBindingSource;
        private RestaurantManagementDBDataSet restaurantManagementDBDataSet;
        private RestaurantManagementDBDataSetTableAdapters.IngredientsTableAdapter ingredientsTableAdapter;
        private FrameworkTest.SATAButton deletebtn;
    }
}