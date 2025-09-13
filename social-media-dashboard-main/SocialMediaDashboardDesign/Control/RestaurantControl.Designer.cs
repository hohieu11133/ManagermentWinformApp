namespace SocialMediaDashboardDesign
{
    partial class RestaurantControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            SATAUiFramework.BorderRadius borderRadius1 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius2 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius3 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius4 = new SATAUiFramework.BorderRadius();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new SATAUiFramework.SATAPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRefresh = new FrameworkTest.SATAButton();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.statusPanel = new SATAUiFramework.SATAPanel();
            this.pnlAvailable = new System.Windows.Forms.Panel();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.pnlOccupied = new System.Windows.Forms.Panel();
            this.lblOccupied = new System.Windows.Forms.Label();
            this.pnlCleaning = new System.Windows.Forms.Panel();
            this.lblCleaning = new System.Windows.Forms.Label();
            this.tablesPanel = new SATAUiFramework.SATAPanel();
            this.lblTablesTitle = new System.Windows.Forms.Label();
            this.tablesFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.actionPanel = new SATAUiFramework.SATAPanel();
            this.lblActionTitle = new System.Windows.Forms.Label();
            this.lblSelectedTable = new System.Windows.Forms.Label();
            this.btnViewOrder = new FrameworkTest.SATAButton();
            this.btnTakeOrder = new FrameworkTest.SATAButton();
            this.btnBillPayment = new FrameworkTest.SATAButton();
            this.btnCleanTable = new FrameworkTest.SATAButton();
            this.btnReserveTable = new FrameworkTest.SATAButton();
            this.lblRevenueValue = new System.Windows.Forms.Label();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.statusPanel.SuspendLayout();
            this.pnlCleaning.SuspendLayout();
            this.tablesPanel.SuspendLayout();
            this.actionPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.mainPanel.Controls.Add(this.headerPanel);
            this.mainPanel.Controls.Add(this.statusPanel);
            this.mainPanel.Controls.Add(this.tablesPanel);
            this.mainPanel.Controls.Add(this.actionPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.Size = new System.Drawing.Size(1133, 660);
            this.mainPanel.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.BackColor2 = System.Drawing.Color.White;
            this.headerPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            borderRadius1.BottomLeft = 15;
            borderRadius1.BottomRight = 15;
            borderRadius1.TopLeft = 15;
            borderRadius1.TopRight = 15;
            this.headerPanel.BorderRadius = borderRadius1;
            this.headerPanel.BorderThickness = 1;
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.btnRefresh);
            this.headerPanel.Controls.Add(this.lblDateTime);
            this.headerPanel.Location = new System.Drawing.Point(23, 20);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1076, 70);
            this.headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(302, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Table Management";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnRefresh.Location = new System.Drawing.Point(936, 20);
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
            // lblDateTime
            // 
            this.lblDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblDateTime.Location = new System.Drawing.Point(766, 28);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(140, 21);
            this.lblDateTime.TabIndex = 2;
            this.lblDateTime.Text = "2024-12-28 14:30";
            // 
            // statusPanel
            // 
            this.statusPanel.BackColor = System.Drawing.Color.White;
            this.statusPanel.BackColor2 = System.Drawing.Color.White;
            this.statusPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            borderRadius2.BottomLeft = 15;
            borderRadius2.BottomRight = 15;
            borderRadius2.TopLeft = 15;
            borderRadius2.TopRight = 15;
            this.statusPanel.BorderRadius = borderRadius2;
            this.statusPanel.BorderThickness = 1;
            this.statusPanel.Controls.Add(this.panel2);
            this.statusPanel.Controls.Add(this.label1);
            this.statusPanel.Controls.Add(this.pnlAvailable);
            this.statusPanel.Controls.Add(this.lblAvailable);
            this.statusPanel.Controls.Add(this.pnlOccupied);
            this.statusPanel.Controls.Add(this.lblOccupied);
            this.statusPanel.Controls.Add(this.pnlCleaning);
            this.statusPanel.Controls.Add(this.lblCleaning);
            this.statusPanel.Location = new System.Drawing.Point(819, 96);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(280, 120);
            this.statusPanel.TabIndex = 1;
            // 
            // pnlAvailable
            // 
            this.pnlAvailable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.pnlAvailable.Location = new System.Drawing.Point(25, 50);
            this.pnlAvailable.Name = "pnlAvailable";
            this.pnlAvailable.Size = new System.Drawing.Size(15, 15);
            this.pnlAvailable.TabIndex = 1;
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblAvailable.Location = new System.Drawing.Point(50, 48);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(79, 20);
            this.lblAvailable.TabIndex = 2;
            this.lblAvailable.Text = "Available";
            // 
            // pnlOccupied
            // 
            this.pnlOccupied.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.pnlOccupied.Location = new System.Drawing.Point(140, 50);
            this.pnlOccupied.Name = "pnlOccupied";
            this.pnlOccupied.Size = new System.Drawing.Size(15, 15);
            this.pnlOccupied.TabIndex = 3;
            // 
            // lblOccupied
            // 
            this.lblOccupied.AutoSize = true;
            this.lblOccupied.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblOccupied.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblOccupied.Location = new System.Drawing.Point(165, 48);
            this.lblOccupied.Name = "lblOccupied";
            this.lblOccupied.Size = new System.Drawing.Size(84, 20);
            this.lblOccupied.TabIndex = 4;
            this.lblOccupied.Text = "Occupied";
            // 
            // pnlCleaning
            // 
            this.pnlCleaning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.pnlCleaning.Controls.Add(this.panel1);
            this.pnlCleaning.Location = new System.Drawing.Point(25, 78);
            this.pnlCleaning.Name = "pnlCleaning";
            this.pnlCleaning.Size = new System.Drawing.Size(15, 15);
            this.pnlCleaning.TabIndex = 7;
            // 
            // lblCleaning
            // 
            this.lblCleaning.AutoSize = true;
            this.lblCleaning.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblCleaning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblCleaning.Location = new System.Drawing.Point(50, 76);
            this.lblCleaning.Name = "lblCleaning";
            this.lblCleaning.Size = new System.Drawing.Size(75, 20);
            this.lblCleaning.TabIndex = 8;
            this.lblCleaning.Text = "Cleaning";
            // 
            // tablesPanel
            // 
            this.tablesPanel.BackColor = System.Drawing.Color.White;
            this.tablesPanel.BackColor2 = System.Drawing.Color.White;
            this.tablesPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            borderRadius3.BottomLeft = 15;
            borderRadius3.BottomRight = 15;
            borderRadius3.TopLeft = 15;
            borderRadius3.TopRight = 15;
            this.tablesPanel.BorderRadius = borderRadius3;
            this.tablesPanel.BorderThickness = 1;
            this.tablesPanel.Controls.Add(this.lblTablesTitle);
            this.tablesPanel.Controls.Add(this.tablesFlowPanel);
            this.tablesPanel.Location = new System.Drawing.Point(23, 96);
            this.tablesPanel.Name = "tablesPanel";
            this.tablesPanel.Size = new System.Drawing.Size(790, 561);
            this.tablesPanel.TabIndex = 3;
            this.tablesPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tablesPanel_Paint);
            // 
            // lblTablesTitle
            // 
            this.lblTablesTitle.AutoSize = true;
            this.lblTablesTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblTablesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.lblTablesTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTablesTitle.Name = "lblTablesTitle";
            this.lblTablesTitle.Size = new System.Drawing.Size(71, 23);
            this.lblTablesTitle.TabIndex = 0;
            this.lblTablesTitle.Text = "Tables";
            // 
            // tablesFlowPanel
            // 
            this.tablesFlowPanel.AutoScroll = true;
            this.tablesFlowPanel.Location = new System.Drawing.Point(20, 50);
            this.tablesFlowPanel.Name = "tablesFlowPanel";
            this.tablesFlowPanel.Size = new System.Drawing.Size(754, 508);
            this.tablesFlowPanel.TabIndex = 1;
            this.tablesFlowPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tablesFlowPanel_Paint);
            // 
            // actionPanel
            // 
            this.actionPanel.BackColor = System.Drawing.Color.White;
            this.actionPanel.BackColor2 = System.Drawing.Color.White;
            this.actionPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            borderRadius4.BottomLeft = 15;
            borderRadius4.BottomRight = 15;
            borderRadius4.TopLeft = 15;
            borderRadius4.TopRight = 15;
            this.actionPanel.BorderRadius = borderRadius4;
            this.actionPanel.BorderThickness = 1;
            this.actionPanel.Controls.Add(this.lblActionTitle);
            this.actionPanel.Controls.Add(this.lblSelectedTable);
            this.actionPanel.Controls.Add(this.btnViewOrder);
            this.actionPanel.Controls.Add(this.btnTakeOrder);
            this.actionPanel.Controls.Add(this.btnBillPayment);
            this.actionPanel.Controls.Add(this.btnCleanTable);
            this.actionPanel.Controls.Add(this.btnReserveTable);
            this.actionPanel.Location = new System.Drawing.Point(819, 229);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(280, 425);
            this.actionPanel.TabIndex = 4;
            // 
            // lblActionTitle
            // 
            this.lblActionTitle.AutoSize = true;
            this.lblActionTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblActionTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.lblActionTitle.Location = new System.Drawing.Point(20, 15);
            this.lblActionTitle.Name = "lblActionTitle";
            this.lblActionTitle.Size = new System.Drawing.Size(141, 23);
            this.lblActionTitle.TabIndex = 0;
            this.lblActionTitle.Text = "Table Actions";
            // 
            // lblSelectedTable
            // 
            this.lblSelectedTable.AutoSize = true;
            this.lblSelectedTable.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblSelectedTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblSelectedTable.Location = new System.Drawing.Point(20, 50);
            this.lblSelectedTable.Name = "lblSelectedTable";
            this.lblSelectedTable.Size = new System.Drawing.Size(139, 21);
            this.lblSelectedTable.TabIndex = 1;
            this.lblSelectedTable.Text = "Selected: None";
            this.lblSelectedTable.Click += new System.EventHandler(this.lblSelectedTable_Click);
            // 
            // btnViewOrder
            // 
            this.btnViewOrder.ButtonText = "📋 View Order";
            this.btnViewOrder.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnViewOrder.CheckedForeColor = System.Drawing.Color.White;
            this.btnViewOrder.CheckedImageTint = System.Drawing.Color.White;
            this.btnViewOrder.CheckedOutline = System.Drawing.Color.Transparent;
            this.btnViewOrder.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnViewOrder.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewOrder.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnViewOrder.HoverForeColor = System.Drawing.Color.White;
            this.btnViewOrder.HoverImage = null;
            this.btnViewOrder.HoverImageTint = System.Drawing.Color.White;
            this.btnViewOrder.HoverOutline = System.Drawing.Color.Transparent;
            this.btnViewOrder.Image = null;
            this.btnViewOrder.ImageAutoCenter = true;
            this.btnViewOrder.ImageExpand = new System.Drawing.Point(3, 3);
            this.btnViewOrder.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnViewOrder.ImageTint = System.Drawing.Color.White;
            this.btnViewOrder.IsToggleButton = false;
            this.btnViewOrder.IsToggled = false;
            this.btnViewOrder.Location = new System.Drawing.Point(20, 90);
            this.btnViewOrder.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnViewOrder.Name = "btnViewOrder";
            this.btnViewOrder.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnViewOrder.NormalForeColor = System.Drawing.Color.White;
            this.btnViewOrder.NormalOutline = System.Drawing.Color.Transparent;
            this.btnViewOrder.OutlineThickness = 0F;
            this.btnViewOrder.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnViewOrder.PressedForeColor = System.Drawing.Color.White;
            this.btnViewOrder.PressedImageTint = System.Drawing.Color.White;
            this.btnViewOrder.PressedOutline = System.Drawing.Color.Transparent;
            this.btnViewOrder.Rounding = new System.Windows.Forms.Padding(10);
            this.btnViewOrder.Size = new System.Drawing.Size(240, 40);
            this.btnViewOrder.TabIndex = 2;
            this.btnViewOrder.TextAutoCenter = true;
            this.btnViewOrder.TextOffset = new System.Drawing.Point(0, 0);
            this.btnViewOrder.Click += new System.EventHandler(this.btnViewOrder_Click);
            // 
            // btnTakeOrder
            // 
            this.btnTakeOrder.ButtonText = "➕ Take Order";
            this.btnTakeOrder.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnTakeOrder.CheckedForeColor = System.Drawing.Color.White;
            this.btnTakeOrder.CheckedImageTint = System.Drawing.Color.White;
            this.btnTakeOrder.CheckedOutline = System.Drawing.Color.Transparent;
            this.btnTakeOrder.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnTakeOrder.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnTakeOrder.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnTakeOrder.HoverForeColor = System.Drawing.Color.White;
            this.btnTakeOrder.HoverImage = null;
            this.btnTakeOrder.HoverImageTint = System.Drawing.Color.White;
            this.btnTakeOrder.HoverOutline = System.Drawing.Color.Transparent;
            this.btnTakeOrder.Image = null;
            this.btnTakeOrder.ImageAutoCenter = true;
            this.btnTakeOrder.ImageExpand = new System.Drawing.Point(3, 3);
            this.btnTakeOrder.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnTakeOrder.ImageTint = System.Drawing.Color.White;
            this.btnTakeOrder.IsToggleButton = false;
            this.btnTakeOrder.IsToggled = false;
            this.btnTakeOrder.Location = new System.Drawing.Point(20, 140);
            this.btnTakeOrder.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnTakeOrder.Name = "btnTakeOrder";
            this.btnTakeOrder.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnTakeOrder.NormalForeColor = System.Drawing.Color.White;
            this.btnTakeOrder.NormalOutline = System.Drawing.Color.Transparent;
            this.btnTakeOrder.OutlineThickness = 0F;
            this.btnTakeOrder.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnTakeOrder.PressedForeColor = System.Drawing.Color.White;
            this.btnTakeOrder.PressedImageTint = System.Drawing.Color.White;
            this.btnTakeOrder.PressedOutline = System.Drawing.Color.Transparent;
            this.btnTakeOrder.Rounding = new System.Windows.Forms.Padding(10);
            this.btnTakeOrder.Size = new System.Drawing.Size(240, 40);
            this.btnTakeOrder.TabIndex = 3;
            this.btnTakeOrder.TextAutoCenter = true;
            this.btnTakeOrder.TextOffset = new System.Drawing.Point(0, 0);
            this.btnTakeOrder.Click += new System.EventHandler(this.btnTakeOrder_Click);
            // 
            // btnBillPayment
            // 
            this.btnBillPayment.ButtonText = "💳 Bill & Payment";
            this.btnBillPayment.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnBillPayment.CheckedForeColor = System.Drawing.Color.White;
            this.btnBillPayment.CheckedImageTint = System.Drawing.Color.White;
            this.btnBillPayment.CheckedOutline = System.Drawing.Color.Transparent;
            this.btnBillPayment.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBillPayment.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnBillPayment.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnBillPayment.HoverForeColor = System.Drawing.Color.White;
            this.btnBillPayment.HoverImage = null;
            this.btnBillPayment.HoverImageTint = System.Drawing.Color.White;
            this.btnBillPayment.HoverOutline = System.Drawing.Color.Transparent;
            this.btnBillPayment.Image = null;
            this.btnBillPayment.ImageAutoCenter = true;
            this.btnBillPayment.ImageExpand = new System.Drawing.Point(3, 3);
            this.btnBillPayment.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnBillPayment.ImageTint = System.Drawing.Color.White;
            this.btnBillPayment.IsToggleButton = false;
            this.btnBillPayment.IsToggled = false;
            this.btnBillPayment.Location = new System.Drawing.Point(20, 190);
            this.btnBillPayment.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnBillPayment.Name = "btnBillPayment";
            this.btnBillPayment.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnBillPayment.NormalForeColor = System.Drawing.Color.White;
            this.btnBillPayment.NormalOutline = System.Drawing.Color.Transparent;
            this.btnBillPayment.OutlineThickness = 0F;
            this.btnBillPayment.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnBillPayment.PressedForeColor = System.Drawing.Color.White;
            this.btnBillPayment.PressedImageTint = System.Drawing.Color.White;
            this.btnBillPayment.PressedOutline = System.Drawing.Color.Transparent;
            this.btnBillPayment.Rounding = new System.Windows.Forms.Padding(10);
            this.btnBillPayment.Size = new System.Drawing.Size(240, 40);
            this.btnBillPayment.TabIndex = 4;
            this.btnBillPayment.TextAutoCenter = true;
            this.btnBillPayment.TextOffset = new System.Drawing.Point(0, 0);
            this.btnBillPayment.Click += new System.EventHandler(this.btnBillPayment_Click);
            // 
            // btnCleanTable
            // 
            this.btnCleanTable.ButtonText = "🧹 Clean Table";
            this.btnCleanTable.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.btnCleanTable.CheckedForeColor = System.Drawing.Color.White;
            this.btnCleanTable.CheckedImageTint = System.Drawing.Color.White;
            this.btnCleanTable.CheckedOutline = System.Drawing.Color.Transparent;
            this.btnCleanTable.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCleanTable.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnCleanTable.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.btnCleanTable.HoverForeColor = System.Drawing.Color.White;
            this.btnCleanTable.HoverImage = null;
            this.btnCleanTable.HoverImageTint = System.Drawing.Color.White;
            this.btnCleanTable.HoverOutline = System.Drawing.Color.Transparent;
            this.btnCleanTable.Image = null;
            this.btnCleanTable.ImageAutoCenter = true;
            this.btnCleanTable.ImageExpand = new System.Drawing.Point(3, 3);
            this.btnCleanTable.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnCleanTable.ImageTint = System.Drawing.Color.White;
            this.btnCleanTable.IsToggleButton = false;
            this.btnCleanTable.IsToggled = false;
            this.btnCleanTable.Location = new System.Drawing.Point(20, 240);
            this.btnCleanTable.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnCleanTable.Name = "btnCleanTable";
            this.btnCleanTable.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCleanTable.NormalForeColor = System.Drawing.Color.White;
            this.btnCleanTable.NormalOutline = System.Drawing.Color.Transparent;
            this.btnCleanTable.OutlineThickness = 0F;
            this.btnCleanTable.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.btnCleanTable.PressedForeColor = System.Drawing.Color.White;
            this.btnCleanTable.PressedImageTint = System.Drawing.Color.White;
            this.btnCleanTable.PressedOutline = System.Drawing.Color.Transparent;
            this.btnCleanTable.Rounding = new System.Windows.Forms.Padding(10);
            this.btnCleanTable.Size = new System.Drawing.Size(240, 40);
            this.btnCleanTable.TabIndex = 5;
            this.btnCleanTable.TextAutoCenter = true;
            this.btnCleanTable.TextOffset = new System.Drawing.Point(0, 0);
            this.btnCleanTable.Click += new System.EventHandler(this.btnCleanTable_Click);
            // 
            // btnReserveTable
            // 
            this.btnReserveTable.ButtonText = "📅 Reserve Table";
            this.btnReserveTable.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnReserveTable.CheckedForeColor = System.Drawing.Color.White;
            this.btnReserveTable.CheckedImageTint = System.Drawing.Color.White;
            this.btnReserveTable.CheckedOutline = System.Drawing.Color.Transparent;
            this.btnReserveTable.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReserveTable.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnReserveTable.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnReserveTable.HoverForeColor = System.Drawing.Color.White;
            this.btnReserveTable.HoverImage = null;
            this.btnReserveTable.HoverImageTint = System.Drawing.Color.White;
            this.btnReserveTable.HoverOutline = System.Drawing.Color.Transparent;
            this.btnReserveTable.Image = null;
            this.btnReserveTable.ImageAutoCenter = true;
            this.btnReserveTable.ImageExpand = new System.Drawing.Point(3, 3);
            this.btnReserveTable.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnReserveTable.ImageTint = System.Drawing.Color.White;
            this.btnReserveTable.IsToggleButton = false;
            this.btnReserveTable.IsToggled = false;
            this.btnReserveTable.Location = new System.Drawing.Point(20, 290);
            this.btnReserveTable.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnReserveTable.Name = "btnReserveTable";
            this.btnReserveTable.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnReserveTable.NormalForeColor = System.Drawing.Color.White;
            this.btnReserveTable.NormalOutline = System.Drawing.Color.Transparent;
            this.btnReserveTable.OutlineThickness = 0F;
            this.btnReserveTable.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnReserveTable.PressedForeColor = System.Drawing.Color.White;
            this.btnReserveTable.PressedImageTint = System.Drawing.Color.White;
            this.btnReserveTable.PressedOutline = System.Drawing.Color.Transparent;
            this.btnReserveTable.Rounding = new System.Windows.Forms.Padding(10);
            this.btnReserveTable.Size = new System.Drawing.Size(240, 40);
            this.btnReserveTable.TabIndex = 6;
            this.btnReserveTable.TextAutoCenter = true;
            this.btnReserveTable.TextOffset = new System.Drawing.Point(0, 0);
            this.btnReserveTable.Click += new System.EventHandler(this.btnReserveTable_Click);
            // 
            // lblRevenueValue
            // 
            this.lblRevenueValue.AutoSize = true;
            this.lblRevenueValue.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold);
            this.lblRevenueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblRevenueValue.Location = new System.Drawing.Point(630, 50);
            this.lblRevenueValue.Name = "lblRevenueValue";
            this.lblRevenueValue.Size = new System.Drawing.Size(139, 37);
            this.lblRevenueValue.TabIndex = 7;
            this.lblRevenueValue.Text = "$2,450.00";
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 60000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(15, 15);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(140, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 15);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(15, 15);
            this.panel3.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.label1.Location = new System.Drawing.Point(165, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Reserved";
            // 
            // RestaurantControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "RestaurantControl";
            this.Size = new System.Drawing.Size(1133, 660);
            this.Load += new System.EventHandler(this.RestaurantControl_Load);
            this.mainPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.statusPanel.ResumeLayout(false);
            this.statusPanel.PerformLayout();
            this.pnlCleaning.ResumeLayout(false);
            this.tablesPanel.ResumeLayout(false);
            this.tablesPanel.PerformLayout();
            this.actionPanel.ResumeLayout(false);
            this.actionPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private SATAUiFramework.SATAPanel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private FrameworkTest.SATAButton btnRefresh;
        private System.Windows.Forms.Label lblDateTime;
        private SATAUiFramework.SATAPanel statusPanel;
        private System.Windows.Forms.Panel pnlAvailable;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Panel pnlOccupied;
        private System.Windows.Forms.Label lblOccupied;
        private System.Windows.Forms.Panel pnlCleaning;
        private System.Windows.Forms.Label lblCleaning;
        private System.Windows.Forms.Label lblRevenueValue;
        private SATAUiFramework.SATAPanel tablesPanel;
        private System.Windows.Forms.Label lblTablesTitle;
        private System.Windows.Forms.FlowLayoutPanel tablesFlowPanel;
        private SATAUiFramework.SATAPanel actionPanel;
        private System.Windows.Forms.Label lblActionTitle;
        private FrameworkTest.SATAButton btnViewOrder;
        private FrameworkTest.SATAButton btnTakeOrder;
        private FrameworkTest.SATAButton btnBillPayment;
        private FrameworkTest.SATAButton btnCleanTable;
        private FrameworkTest.SATAButton btnReserveTable;
        private System.Windows.Forms.Label lblSelectedTable;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}