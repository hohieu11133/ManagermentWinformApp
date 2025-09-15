namespace SocialMediaDashboardDesign
{
    partial class OrderControl
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
            SATAUiFramework.BorderRadius borderRadius1 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius2 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius3 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius4 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius5 = new SATAUiFramework.BorderRadius();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.orderSummaryPanel = new SATAUiFramework.SATAPanel();
            this.lblOrderSummaryTitle = new System.Windows.Forms.Label();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lblOrderIdValue = new System.Windows.Forms.Label();
            this.lblTableNumber = new System.Windows.Forms.Label();
            this.lblTableNumberValue = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalAmountValue = new System.Windows.Forms.Label();
            this.lblOrderStatus = new System.Windows.Forms.Label();
            this.lblOrderStatusValue = new System.Windows.Forms.Label();
            this.actionPanel = new SATAUiFramework.SATAPanel();
            this.btnAddItem = new FrameworkTest.SATAButton();
            this.btnEditItem = new FrameworkTest.SATAButton();
            this.btnRemoveItem = new FrameworkTest.SATAButton();
            this.btnConfirmOrder = new FrameworkTest.SATAButton();
            this.btnCancelOrder = new FrameworkTest.SATAButton();
            this.headerPanel = new SATAUiFramework.SATAPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRefresh = new FrameworkTest.SATAButton();
            this.lblSelectedTable = new System.Windows.Forms.Label();
            this.orderItemsPanel = new SATAUiFramework.SATAPanel();
            this.OrderGridView = new System.Windows.Forms.DataGridView();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editbtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblOrderItemsTitle = new System.Windows.Forms.Label();
            this.menuSelectionPanel = new SATAUiFramework.SATAPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.menuListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblMenuTitle = new System.Windows.Forms.Label();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.mainPanel.SuspendLayout();
            this.orderSummaryPanel.SuspendLayout();
            this.actionPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.orderItemsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderGridView)).BeginInit();
            this.menuSelectionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.mainPanel.Controls.Add(this.orderSummaryPanel);
            this.mainPanel.Controls.Add(this.actionPanel);
            this.mainPanel.Controls.Add(this.headerPanel);
            this.mainPanel.Controls.Add(this.orderItemsPanel);
            this.mainPanel.Controls.Add(this.menuSelectionPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.Size = new System.Drawing.Size(1134, 668);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // orderSummaryPanel
            // 
            this.orderSummaryPanel.BackColor = System.Drawing.Color.White;
            this.orderSummaryPanel.BackColor2 = System.Drawing.Color.White;
            this.orderSummaryPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            borderRadius1.BottomLeft = 15;
            borderRadius1.BottomRight = 15;
            borderRadius1.TopLeft = 15;
            borderRadius1.TopRight = 15;
            this.orderSummaryPanel.BorderRadius = borderRadius1;
            this.orderSummaryPanel.BorderThickness = 1;
            this.orderSummaryPanel.Controls.Add(this.lblOrderSummaryTitle);
            this.orderSummaryPanel.Controls.Add(this.lblOrderId);
            this.orderSummaryPanel.Controls.Add(this.lblOrderIdValue);
            this.orderSummaryPanel.Controls.Add(this.lblTableNumber);
            this.orderSummaryPanel.Controls.Add(this.lblTableNumberValue);
            this.orderSummaryPanel.Controls.Add(this.lblTotalAmount);
            this.orderSummaryPanel.Controls.Add(this.lblTotalAmountValue);
            this.orderSummaryPanel.Controls.Add(this.lblOrderStatus);
            this.orderSummaryPanel.Controls.Add(this.lblOrderStatusValue);
            this.orderSummaryPanel.Location = new System.Drawing.Point(817, 79);
            this.orderSummaryPanel.Name = "orderSummaryPanel";
            this.orderSummaryPanel.Size = new System.Drawing.Size(280, 176);
            this.orderSummaryPanel.TabIndex = 5;
            this.orderSummaryPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.orderSummaryPanel_Paint);
            // 
            // lblOrderSummaryTitle
            // 
            this.lblOrderSummaryTitle.AutoSize = true;
            this.lblOrderSummaryTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblOrderSummaryTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.lblOrderSummaryTitle.Location = new System.Drawing.Point(20, 15);
            this.lblOrderSummaryTitle.Name = "lblOrderSummaryTitle";
            this.lblOrderSummaryTitle.Size = new System.Drawing.Size(162, 23);
            this.lblOrderSummaryTitle.TabIndex = 0;
            this.lblOrderSummaryTitle.Text = "Order Summary";
            // 
            // lblOrderId
            // 
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblOrderId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblOrderId.Location = new System.Drawing.Point(20, 50);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(81, 21);
            this.lblOrderId.TabIndex = 1;
            this.lblOrderId.Text = "Order ID";
            // 
            // lblOrderIdValue
            // 
            this.lblOrderIdValue.AutoSize = true;
            this.lblOrderIdValue.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblOrderIdValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.lblOrderIdValue.Location = new System.Drawing.Point(120, 50);
            this.lblOrderIdValue.Name = "lblOrderIdValue";
            this.lblOrderIdValue.Size = new System.Drawing.Size(69, 19);
            this.lblOrderIdValue.TabIndex = 2;
            this.lblOrderIdValue.Text = "#12345";
            // 
            // lblTableNumber
            // 
            this.lblTableNumber.AutoSize = true;
            this.lblTableNumber.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblTableNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblTableNumber.Location = new System.Drawing.Point(20, 80);
            this.lblTableNumber.Name = "lblTableNumber";
            this.lblTableNumber.Size = new System.Drawing.Size(127, 21);
            this.lblTableNumber.TabIndex = 3;
            this.lblTableNumber.Text = "Table Number";
            // 
            // lblTableNumberValue
            // 
            this.lblTableNumberValue.AutoSize = true;
            this.lblTableNumberValue.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblTableNumberValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.lblTableNumberValue.Location = new System.Drawing.Point(150, 80);
            this.lblTableNumberValue.Name = "lblTableNumberValue";
            this.lblTableNumberValue.Size = new System.Drawing.Size(68, 19);
            this.lblTableNumberValue.TabIndex = 4;
            this.lblTableNumberValue.Text = "Table 2";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 110);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(122, 21);
            this.lblTotalAmount.TabIndex = 5;
            this.lblTotalAmount.Text = "Total Amount";
            // 
            // lblTotalAmountValue
            // 
            this.lblTotalAmountValue.AutoSize = true;
            this.lblTotalAmountValue.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmountValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotalAmountValue.Location = new System.Drawing.Point(120, 110);
            this.lblTotalAmountValue.Name = "lblTotalAmountValue";
            this.lblTotalAmountValue.Size = new System.Drawing.Size(74, 19);
            this.lblTotalAmountValue.TabIndex = 6;
            this.lblTotalAmountValue.Text = "$150.00";
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.AutoSize = true;
            this.lblOrderStatus.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblOrderStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblOrderStatus.Location = new System.Drawing.Point(20, 140);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(61, 21);
            this.lblOrderStatus.TabIndex = 7;
            this.lblOrderStatus.Text = "Status";
            // 
            // lblOrderStatusValue
            // 
            this.lblOrderStatusValue.AutoSize = true;
            this.lblOrderStatusValue.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblOrderStatusValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblOrderStatusValue.Location = new System.Drawing.Point(120, 140);
            this.lblOrderStatusValue.Name = "lblOrderStatusValue";
            this.lblOrderStatusValue.Size = new System.Drawing.Size(98, 19);
            this.lblOrderStatusValue.TabIndex = 8;
            this.lblOrderStatusValue.Text = "In Progress";
            // 
            // actionPanel
            // 
            this.actionPanel.BackColor = System.Drawing.Color.White;
            this.actionPanel.BackColor2 = System.Drawing.Color.White;
            this.actionPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            borderRadius2.BottomLeft = 15;
            borderRadius2.BottomRight = 15;
            borderRadius2.TopLeft = 15;
            borderRadius2.TopRight = 15;
            this.actionPanel.BorderRadius = borderRadius2;
            this.actionPanel.BorderThickness = 1;
            this.actionPanel.Controls.Add(this.btnAddItem);
            this.actionPanel.Controls.Add(this.btnEditItem);
            this.actionPanel.Controls.Add(this.btnRemoveItem);
            this.actionPanel.Controls.Add(this.btnConfirmOrder);
            this.actionPanel.Controls.Add(this.btnCancelOrder);
            this.actionPanel.Location = new System.Drawing.Point(817, 261);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(280, 382);
            this.actionPanel.TabIndex = 6;
            this.actionPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.actionPanel_Paint);
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
            this.btnAddItem.Location = new System.Drawing.Point(20, 20);
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
            this.btnAddItem.Size = new System.Drawing.Size(240, 40);
            this.btnAddItem.TabIndex = 0;
            this.btnAddItem.TextAutoCenter = true;
            this.btnAddItem.TextOffset = new System.Drawing.Point(0, 0);
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.ButtonText = "Edit Item";
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
            this.btnEditItem.Location = new System.Drawing.Point(20, 70);
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
            this.btnEditItem.Size = new System.Drawing.Size(240, 40);
            this.btnEditItem.TabIndex = 1;
            this.btnEditItem.TextAutoCenter = true;
            this.btnEditItem.TextOffset = new System.Drawing.Point(0, 0);
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click_1);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.ButtonText = " Remove Item";
            this.btnRemoveItem.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnRemoveItem.CheckedForeColor = System.Drawing.Color.White;
            this.btnRemoveItem.CheckedImageTint = System.Drawing.Color.White;
            this.btnRemoveItem.CheckedOutline = System.Drawing.Color.Transparent;
            this.btnRemoveItem.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRemoveItem.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnRemoveItem.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnRemoveItem.HoverForeColor = System.Drawing.Color.White;
            this.btnRemoveItem.HoverImage = null;
            this.btnRemoveItem.HoverImageTint = System.Drawing.Color.White;
            this.btnRemoveItem.HoverOutline = System.Drawing.Color.Transparent;
            this.btnRemoveItem.Image = null;
            this.btnRemoveItem.ImageAutoCenter = true;
            this.btnRemoveItem.ImageExpand = new System.Drawing.Point(3, 3);
            this.btnRemoveItem.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnRemoveItem.ImageTint = System.Drawing.Color.White;
            this.btnRemoveItem.IsToggleButton = false;
            this.btnRemoveItem.IsToggled = false;
            this.btnRemoveItem.Location = new System.Drawing.Point(20, 120);
            this.btnRemoveItem.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnRemoveItem.NormalForeColor = System.Drawing.Color.White;
            this.btnRemoveItem.NormalOutline = System.Drawing.Color.Transparent;
            this.btnRemoveItem.OutlineThickness = 0F;
            this.btnRemoveItem.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnRemoveItem.PressedForeColor = System.Drawing.Color.White;
            this.btnRemoveItem.PressedImageTint = System.Drawing.Color.White;
            this.btnRemoveItem.PressedOutline = System.Drawing.Color.Transparent;
            this.btnRemoveItem.Rounding = new System.Windows.Forms.Padding(10);
            this.btnRemoveItem.Size = new System.Drawing.Size(240, 40);
            this.btnRemoveItem.TabIndex = 2;
            this.btnRemoveItem.TextAutoCenter = true;
            this.btnRemoveItem.TextOffset = new System.Drawing.Point(0, 0);
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click_1);
            // 
            // btnConfirmOrder
            // 
            this.btnConfirmOrder.ButtonText = "✅ Confirm Order";
            this.btnConfirmOrder.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnConfirmOrder.CheckedForeColor = System.Drawing.Color.White;
            this.btnConfirmOrder.CheckedImageTint = System.Drawing.Color.White;
            this.btnConfirmOrder.CheckedOutline = System.Drawing.Color.Transparent;
            this.btnConfirmOrder.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnConfirmOrder.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirmOrder.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnConfirmOrder.HoverForeColor = System.Drawing.Color.White;
            this.btnConfirmOrder.HoverImage = null;
            this.btnConfirmOrder.HoverImageTint = System.Drawing.Color.White;
            this.btnConfirmOrder.HoverOutline = System.Drawing.Color.Transparent;
            this.btnConfirmOrder.Image = null;
            this.btnConfirmOrder.ImageAutoCenter = true;
            this.btnConfirmOrder.ImageExpand = new System.Drawing.Point(3, 3);
            this.btnConfirmOrder.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnConfirmOrder.ImageTint = System.Drawing.Color.White;
            this.btnConfirmOrder.IsToggleButton = false;
            this.btnConfirmOrder.IsToggled = false;
            this.btnConfirmOrder.Location = new System.Drawing.Point(20, 170);
            this.btnConfirmOrder.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnConfirmOrder.Name = "btnConfirmOrder";
            this.btnConfirmOrder.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnConfirmOrder.NormalForeColor = System.Drawing.Color.White;
            this.btnConfirmOrder.NormalOutline = System.Drawing.Color.Transparent;
            this.btnConfirmOrder.OutlineThickness = 0F;
            this.btnConfirmOrder.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnConfirmOrder.PressedForeColor = System.Drawing.Color.White;
            this.btnConfirmOrder.PressedImageTint = System.Drawing.Color.White;
            this.btnConfirmOrder.PressedOutline = System.Drawing.Color.Transparent;
            this.btnConfirmOrder.Rounding = new System.Windows.Forms.Padding(10);
            this.btnConfirmOrder.Size = new System.Drawing.Size(240, 40);
            this.btnConfirmOrder.TabIndex = 3;
            this.btnConfirmOrder.TextAutoCenter = true;
            this.btnConfirmOrder.TextOffset = new System.Drawing.Point(0, 0);
            this.btnConfirmOrder.Click += new System.EventHandler(this.btnConfirmOrder_Click_1);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.ButtonText = "❌ Cancel Order";
            this.btnCancelOrder.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnCancelOrder.CheckedForeColor = System.Drawing.Color.White;
            this.btnCancelOrder.CheckedImageTint = System.Drawing.Color.White;
            this.btnCancelOrder.CheckedOutline = System.Drawing.Color.Transparent;
            this.btnCancelOrder.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancelOrder.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelOrder.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnCancelOrder.HoverForeColor = System.Drawing.Color.White;
            this.btnCancelOrder.HoverImage = null;
            this.btnCancelOrder.HoverImageTint = System.Drawing.Color.White;
            this.btnCancelOrder.HoverOutline = System.Drawing.Color.Transparent;
            this.btnCancelOrder.Image = null;
            this.btnCancelOrder.ImageAutoCenter = true;
            this.btnCancelOrder.ImageExpand = new System.Drawing.Point(3, 3);
            this.btnCancelOrder.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnCancelOrder.ImageTint = System.Drawing.Color.White;
            this.btnCancelOrder.IsToggleButton = false;
            this.btnCancelOrder.IsToggled = false;
            this.btnCancelOrder.Location = new System.Drawing.Point(20, 220);
            this.btnCancelOrder.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancelOrder.NormalForeColor = System.Drawing.Color.White;
            this.btnCancelOrder.NormalOutline = System.Drawing.Color.Transparent;
            this.btnCancelOrder.OutlineThickness = 0F;
            this.btnCancelOrder.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnCancelOrder.PressedForeColor = System.Drawing.Color.White;
            this.btnCancelOrder.PressedImageTint = System.Drawing.Color.White;
            this.btnCancelOrder.PressedOutline = System.Drawing.Color.Transparent;
            this.btnCancelOrder.Rounding = new System.Windows.Forms.Padding(10);
            this.btnCancelOrder.Size = new System.Drawing.Size(240, 40);
            this.btnCancelOrder.TabIndex = 4;
            this.btnCancelOrder.TextAutoCenter = true;
            this.btnCancelOrder.TextOffset = new System.Drawing.Point(0, 0);
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click_1);
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.BackColor2 = System.Drawing.Color.White;
            this.headerPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            borderRadius3.BottomLeft = 15;
            borderRadius3.BottomRight = 15;
            borderRadius3.TopLeft = 15;
            borderRadius3.TopRight = 15;
            this.headerPanel.BorderRadius = borderRadius3;
            this.headerPanel.BorderThickness = 1;
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.btnRefresh);
            this.headerPanel.Controls.Add(this.lblSelectedTable);
            this.headerPanel.Location = new System.Drawing.Point(3, 3);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1094, 70);
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
            this.lblTitle.Size = new System.Drawing.Size(307, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Order Management";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
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
            this.btnRefresh.Location = new System.Drawing.Point(965, 12);
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
            // lblSelectedTable
            // 
            this.lblSelectedTable.AutoSize = true;
            this.lblSelectedTable.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblSelectedTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblSelectedTable.Location = new System.Drawing.Point(795, 20);
            this.lblSelectedTable.Name = "lblSelectedTable";
            this.lblSelectedTable.Size = new System.Drawing.Size(111, 21);
            this.lblSelectedTable.TabIndex = 2;
            this.lblSelectedTable.Text = "Table: None";
            // 
            // orderItemsPanel
            // 
            this.orderItemsPanel.BackColor = System.Drawing.Color.White;
            this.orderItemsPanel.BackColor2 = System.Drawing.Color.White;
            this.orderItemsPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            borderRadius4.BottomLeft = 15;
            borderRadius4.BottomRight = 15;
            borderRadius4.TopLeft = 15;
            borderRadius4.TopRight = 15;
            this.orderItemsPanel.BorderRadius = borderRadius4;
            this.orderItemsPanel.BorderThickness = 1;
            this.orderItemsPanel.Controls.Add(this.OrderGridView);
            this.orderItemsPanel.Controls.Add(this.lblOrderItemsTitle);
            this.orderItemsPanel.Location = new System.Drawing.Point(3, 79);
            this.orderItemsPanel.Name = "orderItemsPanel";
            this.orderItemsPanel.Size = new System.Drawing.Size(808, 276);
            this.orderItemsPanel.TabIndex = 2;
            this.orderItemsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.orderItemsPanel_Paint);
            // 
            // OrderGridView
            // 
            this.OrderGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.Quantity,
            this.Price,
            this.Total,
            this.Editbtn});
            this.OrderGridView.Location = new System.Drawing.Point(24, 50);
            this.OrderGridView.Name = "OrderGridView";
            this.OrderGridView.ReadOnly = true;
            this.OrderGridView.RowHeadersWidth = 51;
            this.OrderGridView.RowTemplate.Height = 24;
            this.OrderGridView.Size = new System.Drawing.Size(772, 213);
            this.OrderGridView.TabIndex = 1;
            this.OrderGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrderGridView_CellClick);
            this.OrderGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Name";
            this.ItemName.MinimumWidth = 6;
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 300;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 125;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 125;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 125;
            // 
            // Editbtn
            // 
            this.Editbtn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Editbtn.HeaderText = "";
            this.Editbtn.MinimumWidth = 6;
            this.Editbtn.Name = "Editbtn";
            this.Editbtn.ReadOnly = true;
            // 
            // lblOrderItemsTitle
            // 
            this.lblOrderItemsTitle.AutoSize = true;
            this.lblOrderItemsTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblOrderItemsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.lblOrderItemsTitle.Location = new System.Drawing.Point(20, 15);
            this.lblOrderItemsTitle.Name = "lblOrderItemsTitle";
            this.lblOrderItemsTitle.Size = new System.Drawing.Size(124, 23);
            this.lblOrderItemsTitle.TabIndex = 0;
            this.lblOrderItemsTitle.Text = "Order Items";
            // 
            // menuSelectionPanel
            // 
            this.menuSelectionPanel.BackColor = System.Drawing.Color.White;
            this.menuSelectionPanel.BackColor2 = System.Drawing.Color.White;
            this.menuSelectionPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            borderRadius5.BottomLeft = 15;
            borderRadius5.BottomRight = 15;
            borderRadius5.TopLeft = 15;
            borderRadius5.TopRight = 15;
            this.menuSelectionPanel.BorderRadius = borderRadius5;
            this.menuSelectionPanel.BorderThickness = 1;
            this.menuSelectionPanel.Controls.Add(this.txtSearch);
            this.menuSelectionPanel.Controls.Add(this.categoryComboBox);
            this.menuSelectionPanel.Controls.Add(this.menuListView);
            this.menuSelectionPanel.Controls.Add(this.lblMenuTitle);
            this.menuSelectionPanel.Location = new System.Drawing.Point(3, 361);
            this.menuSelectionPanel.Name = "menuSelectionPanel";
            this.menuSelectionPanel.Size = new System.Drawing.Size(808, 287);
            this.menuSelectionPanel.TabIndex = 3;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtSearch.Location = new System.Drawing.Point(635, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(161, 28);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.Text = "Search items...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(387, 7);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(105, 24);
            this.categoryComboBox.TabIndex = 3;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // menuListView
            // 
            this.menuListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.menuListView.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.menuListView.FullRowSelect = true;
            this.menuListView.GridLines = true;
            this.menuListView.HideSelection = false;
            this.menuListView.Location = new System.Drawing.Point(24, 41);
            this.menuListView.Name = "menuListView";
            this.menuListView.Size = new System.Drawing.Size(772, 224);
            this.menuListView.TabIndex = 2;
            this.menuListView.UseCompatibleStateImageBehavior = false;
            this.menuListView.View = System.Windows.Forms.View.Details;
            this.menuListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 365;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Category";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Price";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Quantity";
            this.columnHeader4.Width = 159;
            // 
            // lblMenuTitle
            // 
            this.lblMenuTitle.AutoSize = true;
            this.lblMenuTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblMenuTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.lblMenuTitle.Location = new System.Drawing.Point(20, 15);
            this.lblMenuTitle.Name = "lblMenuTitle";
            this.lblMenuTitle.Size = new System.Drawing.Size(65, 23);
            this.lblMenuTitle.TabIndex = 0;
            this.lblMenuTitle.Text = "Menu";
            this.lblMenuTitle.Click += new System.EventHandler(this.lblMenuTitle_Click);
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 60000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // OrderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "OrderControl";
            this.Size = new System.Drawing.Size(1134, 668);
            this.Load += new System.EventHandler(this.OrderControl_Load);
            this.mainPanel.ResumeLayout(false);
            this.orderSummaryPanel.ResumeLayout(false);
            this.orderSummaryPanel.PerformLayout();
            this.actionPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.orderItemsPanel.ResumeLayout(false);
            this.orderItemsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderGridView)).EndInit();
            this.menuSelectionPanel.ResumeLayout(false);
            this.menuSelectionPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private SATAUiFramework.SATAPanel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private FrameworkTest.SATAButton btnRefresh;
        private System.Windows.Forms.Label lblSelectedTable;
        private SATAUiFramework.SATAPanel orderItemsPanel;
        private System.Windows.Forms.Label lblOrderItemsTitle;
        private SATAUiFramework.SATAPanel menuSelectionPanel;
        private System.Windows.Forms.Label lblMenuTitle;
        private System.Windows.Forms.Timer updateTimer;
        private SATAUiFramework.SATAPanel orderSummaryPanel;
        private System.Windows.Forms.Label lblOrderSummaryTitle;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label lblOrderIdValue;
        private System.Windows.Forms.Label lblTableNumber;
        private System.Windows.Forms.Label lblTableNumberValue;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalAmountValue;
        private System.Windows.Forms.Label lblOrderStatus;
        private System.Windows.Forms.Label lblOrderStatusValue;
        private SATAUiFramework.SATAPanel actionPanel;
        private FrameworkTest.SATAButton btnAddItem;
        private FrameworkTest.SATAButton btnEditItem;
        private FrameworkTest.SATAButton btnRemoveItem;
        private FrameworkTest.SATAButton btnConfirmOrder;
        private FrameworkTest.SATAButton btnCancelOrder;
        private System.Windows.Forms.ListView menuListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView OrderGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewButtonColumn Editbtn;
    }
}