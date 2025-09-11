namespace SocialMediaDashboardDesign
{
    partial class MenuControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            SATAUiFramework.BorderRadius borderRadius5 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius6 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius7 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius8 = new SATAUiFramework.BorderRadius();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new SATAUiFramework.SATAPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRefresh = new FrameworkTest.SATAButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new FrameworkTest.SATAButton();
            this.categoryPanel = new SATAUiFramework.SATAPanel();
            this.lblCategoryTitle = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.actionPanel = new SATAUiFramework.SATAPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnAddItem = new FrameworkTest.SATAButton();
            this.btnEditItem = new FrameworkTest.SATAButton();
            this.btnDeleteItem = new FrameworkTest.SATAButton();
            this.btnToggleAvailability = new FrameworkTest.SATAButton();
            this.menuItemsPanel = new SATAUiFramework.SATAPanel();
            this.lblMenuItemsTitle = new System.Windows.Forms.Label();
            this.menuItemsListView = new System.Windows.Forms.ListView();
            this.columnItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAvailability = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.kryptonContextMenu1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAvailability = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.categoryPanel.SuspendLayout();
            this.actionPanel.SuspendLayout();
            this.menuItemsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.mainPanel.Controls.Add(this.headerPanel);
            this.mainPanel.Controls.Add(this.categoryPanel);
            this.mainPanel.Controls.Add(this.actionPanel);
            this.mainPanel.Controls.Add(this.menuItemsPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.Size = new System.Drawing.Size(1133, 660);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.BackColor2 = System.Drawing.Color.White;
            this.headerPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            borderRadius5.BottomLeft = 15;
            borderRadius5.BottomRight = 15;
            borderRadius5.TopLeft = 15;
            borderRadius5.TopRight = 15;
            this.headerPanel.BorderRadius = borderRadius5;
            this.headerPanel.BorderThickness = 1;
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.btnRefresh);
            this.headerPanel.Controls.Add(this.txtSearch);
            this.headerPanel.Controls.Add(this.btnSearch);
            this.headerPanel.Location = new System.Drawing.Point(20, 20);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1083, 70);
            this.headerPanel.TabIndex = 0;
            this.headerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.headerPanel_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(305, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Menu Management";
            // 
            // btnRefresh
            // 
            this.btnRefresh.ButtonText = "🔄 Refresh";
            this.btnRefresh.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnRefresh.CheckedForeColor = System.Drawing.Color.White;
            this.btnRefresh.CheckedImageTint = System.Drawing.Color.White;
            this.btnRefresh.CheckedOutline = System.Drawing.Color.Transparent;
            this.btnRefresh.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRefresh.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnRefresh.HoverForeColor = System.Drawing.Color.White;
            this.btnRefresh.HoverImage = null;
            this.btnRefresh.HoverImageTint = System.Drawing.Color.White;
            this.btnRefresh.HoverOutline = System.Drawing.Color.Transparent;
            this.btnRefresh.Image = null;
            this.btnRefresh.ImageAutoCenter = true;
            this.btnRefresh.ImageExpand = new System.Drawing.Point(3, 3);
            this.btnRefresh.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnRefresh.ImageTint = System.Drawing.Color.White;
            this.btnRefresh.IsToggleButton = false;
            this.btnRefresh.IsToggled = false;
            this.btnRefresh.Location = new System.Drawing.Point(951, 22);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefresh.NormalForeColor = System.Drawing.Color.White;
            this.btnRefresh.NormalOutline = System.Drawing.Color.Transparent;
            this.btnRefresh.OutlineThickness = 0F;
            this.btnRefresh.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnRefresh.PressedForeColor = System.Drawing.Color.White;
            this.btnRefresh.PressedImageTint = System.Drawing.Color.White;
            this.btnRefresh.PressedOutline = System.Drawing.Color.Transparent;
            this.btnRefresh.Rounding = new System.Windows.Forms.Padding(10);
            this.btnRefresh.Size = new System.Drawing.Size(120, 35);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.TextAutoCenter = true;
            this.btnRefresh.TextOffset = new System.Drawing.Point(0, 0);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtSearch.Location = new System.Drawing.Point(581, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 28);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.Text = "Search items...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.ButtonText = "🔍 Search";
            this.btnSearch.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnSearch.CheckedForeColor = System.Drawing.Color.White;
            this.btnSearch.CheckedImageTint = System.Drawing.Color.White;
            this.btnSearch.CheckedOutline = System.Drawing.Color.Transparent;
            this.btnSearch.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnSearch.HoverForeColor = System.Drawing.Color.White;
            this.btnSearch.HoverImage = null;
            this.btnSearch.HoverImageTint = System.Drawing.Color.White;
            this.btnSearch.HoverOutline = System.Drawing.Color.Transparent;
            this.btnSearch.Image = null;
            this.btnSearch.ImageAutoCenter = true;
            this.btnSearch.ImageExpand = new System.Drawing.Point(3, 3);
            this.btnSearch.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnSearch.ImageTint = System.Drawing.Color.White;
            this.btnSearch.IsToggleButton = false;
            this.btnSearch.IsToggled = false;
            this.btnSearch.Location = new System.Drawing.Point(841, 22);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSearch.NormalForeColor = System.Drawing.Color.White;
            this.btnSearch.NormalOutline = System.Drawing.Color.Transparent;
            this.btnSearch.OutlineThickness = 0F;
            this.btnSearch.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnSearch.PressedForeColor = System.Drawing.Color.White;
            this.btnSearch.PressedImageTint = System.Drawing.Color.White;
            this.btnSearch.PressedOutline = System.Drawing.Color.Transparent;
            this.btnSearch.Rounding = new System.Windows.Forms.Padding(10);
            this.btnSearch.Size = new System.Drawing.Size(100, 35);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.TextAutoCenter = true;
            this.btnSearch.TextOffset = new System.Drawing.Point(0, 0);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // categoryPanel
            // 
            this.categoryPanel.BackColor = System.Drawing.Color.White;
            this.categoryPanel.BackColor2 = System.Drawing.Color.White;
            this.categoryPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            borderRadius6.BottomLeft = 15;
            borderRadius6.BottomRight = 15;
            borderRadius6.TopLeft = 15;
            borderRadius6.TopRight = 15;
            this.categoryPanel.BorderRadius = borderRadius6;
            this.categoryPanel.BorderThickness = 1;
            this.categoryPanel.Controls.Add(this.lblCategoryTitle);
            this.categoryPanel.Controls.Add(this.categoryComboBox);
            this.categoryPanel.Location = new System.Drawing.Point(865, 97);
            this.categoryPanel.Name = "categoryPanel";
            this.categoryPanel.Size = new System.Drawing.Size(238, 104);
            this.categoryPanel.TabIndex = 1;
            // 
            // lblCategoryTitle
            // 
            this.lblCategoryTitle.AutoSize = true;
            this.lblCategoryTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblCategoryTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.lblCategoryTitle.Location = new System.Drawing.Point(20, 15);
            this.lblCategoryTitle.Name = "lblCategoryTitle";
            this.lblCategoryTitle.Size = new System.Drawing.Size(117, 23);
            this.lblCategoryTitle.TabIndex = 0;
            this.lblCategoryTitle.Text = "Categories";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Items.AddRange(new object[] {
            "All",
            "Appetizers",
            "Main Courses",
            "Desserts",
            "Beverages"});
            this.categoryComboBox.Location = new System.Drawing.Point(20, 50);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(203, 29);
            this.categoryComboBox.TabIndex = 1;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // actionPanel
            // 
            this.actionPanel.BackColor = System.Drawing.Color.White;
            this.actionPanel.BackColor2 = System.Drawing.Color.White;
            this.actionPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            borderRadius7.BottomLeft = 15;
            borderRadius7.BottomRight = 15;
            borderRadius7.TopLeft = 15;
            borderRadius7.TopRight = 15;
            this.actionPanel.BorderRadius = borderRadius7;
            this.actionPanel.BorderThickness = 1;
            this.actionPanel.Controls.Add(this.comboBox1);
            this.actionPanel.Controls.Add(this.label4);
            this.actionPanel.Controls.Add(this.label3);
            this.actionPanel.Controls.Add(this.txtAvailability);
            this.actionPanel.Controls.Add(this.label2);
            this.actionPanel.Controls.Add(this.txtPrice);
            this.actionPanel.Controls.Add(this.label1);
            this.actionPanel.Controls.Add(this.txtName);
            this.actionPanel.Controls.Add(this.pictureBox1);
            this.actionPanel.Controls.Add(this.btnAddItem);
            this.actionPanel.Controls.Add(this.btnEditItem);
            this.actionPanel.Controls.Add(this.btnDeleteItem);
            this.actionPanel.Controls.Add(this.btnToggleAvailability);
            this.actionPanel.Location = new System.Drawing.Point(868, 207);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(238, 450);
            this.actionPanel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "price";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(105, 116);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(117, 22);
            this.txtPrice.TabIndex = 8;
            this.txtPrice.Text = "ass";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(105, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(117, 22);
            this.txtName.TabIndex = 6;
            this.txtName.Text = "ass";
            // 
            // btnAddItem
            // 
            this.btnAddItem.ButtonText = "➕ Add Item";
            this.btnAddItem.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnAddItem.CheckedForeColor = System.Drawing.Color.White;
            this.btnAddItem.CheckedImageTint = System.Drawing.Color.White;
            this.btnAddItem.CheckedOutline = System.Drawing.Color.Transparent;
            this.btnAddItem.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddItem.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddItem.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnAddItem.HoverForeColor = System.Drawing.Color.White;
            this.btnAddItem.HoverImage = null;
            this.btnAddItem.HoverImageTint = System.Drawing.Color.White;
            this.btnAddItem.HoverOutline = System.Drawing.Color.Transparent;
            this.btnAddItem.Image = null;
            this.btnAddItem.ImageAutoCenter = true;
            this.btnAddItem.ImageExpand = new System.Drawing.Point(3, 3);
            this.btnAddItem.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnAddItem.ImageTint = System.Drawing.Color.White;
            this.btnAddItem.IsToggleButton = false;
            this.btnAddItem.IsToggled = false;
            this.btnAddItem.Location = new System.Drawing.Point(7, 248);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddItem.NormalForeColor = System.Drawing.Color.White;
            this.btnAddItem.NormalOutline = System.Drawing.Color.Transparent;
            this.btnAddItem.OutlineThickness = 0F;
            this.btnAddItem.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnAddItem.PressedForeColor = System.Drawing.Color.White;
            this.btnAddItem.PressedImageTint = System.Drawing.Color.White;
            this.btnAddItem.PressedOutline = System.Drawing.Color.Transparent;
            this.btnAddItem.Rounding = new System.Windows.Forms.Padding(10);
            this.btnAddItem.Size = new System.Drawing.Size(228, 40);
            this.btnAddItem.TabIndex = 0;
            this.btnAddItem.TextAutoCenter = true;
            this.btnAddItem.TextOffset = new System.Drawing.Point(0, 0);
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.ButtonText = "✏️ Edit Item";
            this.btnEditItem.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnEditItem.CheckedForeColor = System.Drawing.Color.White;
            this.btnEditItem.CheckedImageTint = System.Drawing.Color.White;
            this.btnEditItem.CheckedOutline = System.Drawing.Color.Transparent;
            this.btnEditItem.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEditItem.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditItem.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnEditItem.HoverForeColor = System.Drawing.Color.White;
            this.btnEditItem.HoverImage = null;
            this.btnEditItem.HoverImageTint = System.Drawing.Color.White;
            this.btnEditItem.HoverOutline = System.Drawing.Color.Transparent;
            this.btnEditItem.Image = null;
            this.btnEditItem.ImageAutoCenter = true;
            this.btnEditItem.ImageExpand = new System.Drawing.Point(3, 3);
            this.btnEditItem.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnEditItem.ImageTint = System.Drawing.Color.White;
            this.btnEditItem.IsToggleButton = false;
            this.btnEditItem.IsToggled = false;
            this.btnEditItem.Location = new System.Drawing.Point(7, 298);
            this.btnEditItem.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnEditItem.NormalForeColor = System.Drawing.Color.White;
            this.btnEditItem.NormalOutline = System.Drawing.Color.Transparent;
            this.btnEditItem.OutlineThickness = 0F;
            this.btnEditItem.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnEditItem.PressedForeColor = System.Drawing.Color.White;
            this.btnEditItem.PressedImageTint = System.Drawing.Color.White;
            this.btnEditItem.PressedOutline = System.Drawing.Color.Transparent;
            this.btnEditItem.Rounding = new System.Windows.Forms.Padding(10);
            this.btnEditItem.Size = new System.Drawing.Size(228, 40);
            this.btnEditItem.TabIndex = 1;
            this.btnEditItem.TextAutoCenter = true;
            this.btnEditItem.TextOffset = new System.Drawing.Point(0, 0);
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.ButtonText = "🗑️ Delete Item";
            this.btnDeleteItem.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnDeleteItem.CheckedForeColor = System.Drawing.Color.White;
            this.btnDeleteItem.CheckedImageTint = System.Drawing.Color.White;
            this.btnDeleteItem.CheckedOutline = System.Drawing.Color.Transparent;
            this.btnDeleteItem.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDeleteItem.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteItem.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnDeleteItem.HoverForeColor = System.Drawing.Color.White;
            this.btnDeleteItem.HoverImage = null;
            this.btnDeleteItem.HoverImageTint = System.Drawing.Color.White;
            this.btnDeleteItem.HoverOutline = System.Drawing.Color.Transparent;
            this.btnDeleteItem.Image = null;
            this.btnDeleteItem.ImageAutoCenter = true;
            this.btnDeleteItem.ImageExpand = new System.Drawing.Point(3, 3);
            this.btnDeleteItem.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnDeleteItem.ImageTint = System.Drawing.Color.White;
            this.btnDeleteItem.IsToggleButton = false;
            this.btnDeleteItem.IsToggled = false;
            this.btnDeleteItem.Location = new System.Drawing.Point(7, 348);
            this.btnDeleteItem.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDeleteItem.NormalForeColor = System.Drawing.Color.White;
            this.btnDeleteItem.NormalOutline = System.Drawing.Color.Transparent;
            this.btnDeleteItem.OutlineThickness = 0F;
            this.btnDeleteItem.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnDeleteItem.PressedForeColor = System.Drawing.Color.White;
            this.btnDeleteItem.PressedImageTint = System.Drawing.Color.White;
            this.btnDeleteItem.PressedOutline = System.Drawing.Color.Transparent;
            this.btnDeleteItem.Rounding = new System.Windows.Forms.Padding(10);
            this.btnDeleteItem.Size = new System.Drawing.Size(228, 40);
            this.btnDeleteItem.TabIndex = 2;
            this.btnDeleteItem.TextAutoCenter = true;
            this.btnDeleteItem.TextOffset = new System.Drawing.Point(0, 0);
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnToggleAvailability
            // 
            this.btnToggleAvailability.ButtonText = "🔄 Toggle Availability";
            this.btnToggleAvailability.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnToggleAvailability.CheckedForeColor = System.Drawing.Color.White;
            this.btnToggleAvailability.CheckedImageTint = System.Drawing.Color.White;
            this.btnToggleAvailability.CheckedOutline = System.Drawing.Color.Transparent;
            this.btnToggleAvailability.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnToggleAvailability.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnToggleAvailability.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnToggleAvailability.HoverForeColor = System.Drawing.Color.White;
            this.btnToggleAvailability.HoverImage = null;
            this.btnToggleAvailability.HoverImageTint = System.Drawing.Color.White;
            this.btnToggleAvailability.HoverOutline = System.Drawing.Color.Transparent;
            this.btnToggleAvailability.Image = null;
            this.btnToggleAvailability.ImageAutoCenter = true;
            this.btnToggleAvailability.ImageExpand = new System.Drawing.Point(3, 3);
            this.btnToggleAvailability.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnToggleAvailability.ImageTint = System.Drawing.Color.White;
            this.btnToggleAvailability.IsToggleButton = false;
            this.btnToggleAvailability.IsToggled = false;
            this.btnToggleAvailability.Location = new System.Drawing.Point(7, 398);
            this.btnToggleAvailability.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnToggleAvailability.Name = "btnToggleAvailability";
            this.btnToggleAvailability.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnToggleAvailability.NormalForeColor = System.Drawing.Color.White;
            this.btnToggleAvailability.NormalOutline = System.Drawing.Color.Transparent;
            this.btnToggleAvailability.OutlineThickness = 0F;
            this.btnToggleAvailability.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnToggleAvailability.PressedForeColor = System.Drawing.Color.White;
            this.btnToggleAvailability.PressedImageTint = System.Drawing.Color.White;
            this.btnToggleAvailability.PressedOutline = System.Drawing.Color.Transparent;
            this.btnToggleAvailability.Rounding = new System.Windows.Forms.Padding(10);
            this.btnToggleAvailability.Size = new System.Drawing.Size(228, 40);
            this.btnToggleAvailability.TabIndex = 3;
            this.btnToggleAvailability.TextAutoCenter = true;
            this.btnToggleAvailability.TextOffset = new System.Drawing.Point(0, 0);
            this.btnToggleAvailability.Click += new System.EventHandler(this.btnToggleAvailability_Click);
            // 
            // menuItemsPanel
            // 
            this.menuItemsPanel.BackColor = System.Drawing.Color.White;
            this.menuItemsPanel.BackColor2 = System.Drawing.Color.White;
            this.menuItemsPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            borderRadius8.BottomLeft = 15;
            borderRadius8.BottomRight = 15;
            borderRadius8.TopLeft = 15;
            borderRadius8.TopRight = 15;
            this.menuItemsPanel.BorderRadius = borderRadius8;
            this.menuItemsPanel.BorderThickness = 1;
            this.menuItemsPanel.Controls.Add(this.lblMenuItemsTitle);
            this.menuItemsPanel.Controls.Add(this.menuItemsListView);
            this.menuItemsPanel.Location = new System.Drawing.Point(23, 97);
            this.menuItemsPanel.Name = "menuItemsPanel";
            this.menuItemsPanel.Size = new System.Drawing.Size(836, 560);
            this.menuItemsPanel.TabIndex = 2;
            // 
            // lblMenuItemsTitle
            // 
            this.lblMenuItemsTitle.AutoSize = true;
            this.lblMenuItemsTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblMenuItemsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.lblMenuItemsTitle.Location = new System.Drawing.Point(20, 15);
            this.lblMenuItemsTitle.Name = "lblMenuItemsTitle";
            this.lblMenuItemsTitle.Size = new System.Drawing.Size(124, 23);
            this.lblMenuItemsTitle.TabIndex = 0;
            this.lblMenuItemsTitle.Text = "Menu Items";
            // 
            // menuItemsListView
            // 
            this.menuItemsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnItemName,
            this.columnCategory,
            this.columnPrice,
            this.columnAvailability});
            this.menuItemsListView.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.menuItemsListView.FullRowSelect = true;
            this.menuItemsListView.GridLines = true;
            this.menuItemsListView.HideSelection = false;
            this.menuItemsListView.Location = new System.Drawing.Point(20, 50);
            this.menuItemsListView.Name = "menuItemsListView";
            this.menuItemsListView.Size = new System.Drawing.Size(808, 499);
            this.menuItemsListView.TabIndex = 1;
            this.menuItemsListView.UseCompatibleStateImageBehavior = false;
            this.menuItemsListView.View = System.Windows.Forms.View.Details;
            this.menuItemsListView.SelectedIndexChanged += new System.EventHandler(this.menuItemsListView_SelectedIndexChanged);
            // 
            // columnItemName
            // 
            this.columnItemName.Text = "Item Name";
            this.columnItemName.Width = 300;
            // 
            // columnCategory
            // 
            this.columnCategory.Text = "Category";
            this.columnCategory.Width = 200;
            // 
            // columnPrice
            // 
            this.columnPrice.Text = "Price";
            this.columnPrice.Width = 150;
            // 
            // columnAvailability
            // 
            this.columnAvailability.Text = "Availability";
            this.columnAvailability.Width = 150;
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 60000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "All",
            "Appetizers",
            "Main Courses",
            "Desserts",
            "Beverages"});
            this.comboBox1.Location = new System.Drawing.Point(100, 75);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(120, 29);
            this.comboBox1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "availability";
            // 
            // txtAvailability
            // 
            this.txtAvailability.Location = new System.Drawing.Point(105, 155);
            this.txtAvailability.Name = "txtAvailability";
            this.txtAvailability.Size = new System.Drawing.Size(117, 22);
            this.txtAvailability.TabIndex = 10;
            this.txtAvailability.Text = "ass";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "category";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SocialMediaDashboardDesign.Properties.Resources.holderpic;
            this.pictureBox1.Location = new System.Drawing.Point(7, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 147);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "MenuControl";
            this.Size = new System.Drawing.Size(1133, 660);
            this.Load += new System.EventHandler(this.MenuControl_Load);
            this.mainPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.categoryPanel.ResumeLayout(false);
            this.categoryPanel.PerformLayout();
            this.actionPanel.ResumeLayout(false);
            this.actionPanel.PerformLayout();
            this.menuItemsPanel.ResumeLayout(false);
            this.menuItemsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private SATAUiFramework.SATAPanel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private FrameworkTest.SATAButton btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private FrameworkTest.SATAButton btnSearch;
        private SATAUiFramework.SATAPanel categoryPanel;
        private System.Windows.Forms.Label lblCategoryTitle;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private SATAUiFramework.SATAPanel menuItemsPanel;
        private System.Windows.Forms.Label lblMenuItemsTitle;
        private System.Windows.Forms.ListView menuItemsListView;
        private System.Windows.Forms.ColumnHeader columnItemName;
        private System.Windows.Forms.ColumnHeader columnCategory;
        private System.Windows.Forms.ColumnHeader columnPrice;
        private System.Windows.Forms.ColumnHeader columnAvailability;
        private SATAUiFramework.SATAPanel actionPanel;
        private FrameworkTest.SATAButton btnAddItem;
        private FrameworkTest.SATAButton btnEditItem;
        private FrameworkTest.SATAButton btnDeleteItem;
        private FrameworkTest.SATAButton btnToggleAvailability;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtName;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu kryptonContextMenu1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAvailability;
    }
}