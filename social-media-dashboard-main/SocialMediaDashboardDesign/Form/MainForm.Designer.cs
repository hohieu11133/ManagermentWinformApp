namespace SocialMediaDashboardDesign
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sataEllipseControl1 = new SATAUiFramework.Controls.SATAEllipseControl();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.sataDragControl1 = new SATAUiFramework.Controls.SATADragControl();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Inventorybtn = new FrameworkTest.SATAButton();
            this.sataButton21 = new FrameworkTest.SATAButton();
            this.logoutbtn = new FrameworkTest.SATAButton();
            this.menuOrder = new FrameworkTest.SATAButton();
            this.menuRestaurant = new FrameworkTest.SATAButton();
            this.sataButton12 = new FrameworkTest.SATAButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sataEllipseControl1
            // 
            this.sataEllipseControl1.CornerRadius = 35;
            this.sataEllipseControl1.TargetControl = this;
            // 
            // panelHeader
            // 
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(257, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1112, 77);
            this.panelHeader.TabIndex = 2;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // sataDragControl1
            // 
            this.sataDragControl1.SelectControl = this.panelHeader;
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(257, 77);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1112, 783);
            this.mainPanel.TabIndex = 3;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.label2.Location = new System.Drawing.Point(80, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Order App";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(21, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Menu";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Inventorybtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.sataButton21);
            this.panel1.Controls.Add(this.logoutbtn);
            this.panel1.Controls.Add(this.menuOrder);
            this.panel1.Controls.Add(this.menuRestaurant);
            this.panel1.Controls.Add(this.sataButton12);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 860);
            this.panel1.TabIndex = 0;
            // 
            // Inventorybtn
            // 
            this.Inventorybtn.ButtonText = "Inventory";
            this.Inventorybtn.CheckedBackground = System.Drawing.Color.White;
            this.Inventorybtn.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.Inventorybtn.CheckedImageTint = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.Inventorybtn.CheckedOutline = System.Drawing.Color.White;
            this.Inventorybtn.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.Inventorybtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Inventorybtn.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.Inventorybtn.HoverForeColor = System.Drawing.Color.White;
            this.Inventorybtn.HoverImage = ((System.Drawing.Image)(resources.GetObject("Inventorybtn.HoverImage")));
            this.Inventorybtn.HoverImageTint = System.Drawing.Color.White;
            this.Inventorybtn.HoverOutline = System.Drawing.Color.Empty;
            this.Inventorybtn.Image = ((System.Drawing.Image)(resources.GetObject("Inventorybtn.Image")));
            this.Inventorybtn.ImageAutoCenter = false;
            this.Inventorybtn.ImageExpand = new System.Drawing.Point(3, 3);
            this.Inventorybtn.ImageOffset = new System.Drawing.Point(20, 0);
            this.Inventorybtn.ImageTint = System.Drawing.Color.White;
            this.Inventorybtn.IsToggleButton = false;
            this.Inventorybtn.IsToggled = false;
            this.Inventorybtn.Location = new System.Drawing.Point(4, 380);
            this.Inventorybtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Inventorybtn.Name = "Inventorybtn";
            this.Inventorybtn.NormalBackground = System.Drawing.Color.White;
            this.Inventorybtn.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Inventorybtn.NormalOutline = System.Drawing.Color.Empty;
            this.Inventorybtn.OutlineThickness = 2F;
            this.Inventorybtn.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.Inventorybtn.PressedForeColor = System.Drawing.Color.White;
            this.Inventorybtn.PressedImageTint = System.Drawing.Color.White;
            this.Inventorybtn.PressedOutline = System.Drawing.Color.Empty;
            this.Inventorybtn.Rounding = new System.Windows.Forms.Padding(5);
            this.Inventorybtn.Size = new System.Drawing.Size(250, 51);
            this.Inventorybtn.TabIndex = 3;
            this.Inventorybtn.TextAutoCenter = false;
            this.Inventorybtn.TextOffset = new System.Drawing.Point(15, 0);
            this.Inventorybtn.Click += new System.EventHandler(this.Inventory_Click);
            // 
            // sataButton21
            // 
            this.sataButton21.ButtonText = "Menu ";
            this.sataButton21.CheckedBackground = System.Drawing.Color.White;
            this.sataButton21.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.sataButton21.CheckedImageTint = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.sataButton21.CheckedOutline = System.Drawing.Color.White;
            this.sataButton21.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.sataButton21.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sataButton21.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.sataButton21.HoverForeColor = System.Drawing.Color.White;
            this.sataButton21.HoverImage = ((System.Drawing.Image)(resources.GetObject("sataButton21.HoverImage")));
            this.sataButton21.HoverImageTint = System.Drawing.Color.White;
            this.sataButton21.HoverOutline = System.Drawing.Color.Empty;
            this.sataButton21.Image = ((System.Drawing.Image)(resources.GetObject("sataButton21.Image")));
            this.sataButton21.ImageAutoCenter = false;
            this.sataButton21.ImageExpand = new System.Drawing.Point(3, 3);
            this.sataButton21.ImageOffset = new System.Drawing.Point(20, 0);
            this.sataButton21.ImageTint = System.Drawing.Color.White;
            this.sataButton21.IsToggleButton = false;
            this.sataButton21.IsToggled = false;
            this.sataButton21.Location = new System.Drawing.Point(4, 323);
            this.sataButton21.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sataButton21.Name = "sataButton21";
            this.sataButton21.NormalBackground = System.Drawing.Color.White;
            this.sataButton21.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sataButton21.NormalOutline = System.Drawing.Color.Empty;
            this.sataButton21.OutlineThickness = 2F;
            this.sataButton21.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.sataButton21.PressedForeColor = System.Drawing.Color.White;
            this.sataButton21.PressedImageTint = System.Drawing.Color.White;
            this.sataButton21.PressedOutline = System.Drawing.Color.Empty;
            this.sataButton21.Rounding = new System.Windows.Forms.Padding(5);
            this.sataButton21.Size = new System.Drawing.Size(250, 51);
            this.sataButton21.TabIndex = 2;
            this.sataButton21.TextAutoCenter = false;
            this.sataButton21.TextOffset = new System.Drawing.Point(15, 0);
            this.sataButton21.Click += new System.EventHandler(this.menuMenu_Click);
            // 
            // logoutbtn
            // 
            this.logoutbtn.ButtonText = "Logout";
            this.logoutbtn.CheckedBackground = System.Drawing.Color.White;
            this.logoutbtn.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.logoutbtn.CheckedImageTint = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.logoutbtn.CheckedOutline = System.Drawing.Color.White;
            this.logoutbtn.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.logoutbtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutbtn.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.logoutbtn.HoverForeColor = System.Drawing.Color.White;
            this.logoutbtn.HoverImage = ((System.Drawing.Image)(resources.GetObject("logoutbtn.HoverImage")));
            this.logoutbtn.HoverImageTint = System.Drawing.Color.White;
            this.logoutbtn.HoverOutline = System.Drawing.Color.Empty;
            this.logoutbtn.Image = ((System.Drawing.Image)(resources.GetObject("logoutbtn.Image")));
            this.logoutbtn.ImageAutoCenter = false;
            this.logoutbtn.ImageExpand = new System.Drawing.Point(3, 3);
            this.logoutbtn.ImageOffset = new System.Drawing.Point(20, 0);
            this.logoutbtn.ImageTint = System.Drawing.Color.White;
            this.logoutbtn.IsToggleButton = false;
            this.logoutbtn.IsToggled = false;
            this.logoutbtn.Location = new System.Drawing.Point(7, 785);
            this.logoutbtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.logoutbtn.Name = "logoutbtn";
            this.logoutbtn.NormalBackground = System.Drawing.Color.White;
            this.logoutbtn.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.logoutbtn.NormalOutline = System.Drawing.Color.Empty;
            this.logoutbtn.OutlineThickness = 2F;
            this.logoutbtn.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.logoutbtn.PressedForeColor = System.Drawing.Color.White;
            this.logoutbtn.PressedImageTint = System.Drawing.Color.White;
            this.logoutbtn.PressedOutline = System.Drawing.Color.Empty;
            this.logoutbtn.Rounding = new System.Windows.Forms.Padding(5);
            this.logoutbtn.Size = new System.Drawing.Size(250, 51);
            this.logoutbtn.TabIndex = 2;
            this.logoutbtn.TextAutoCenter = false;
            this.logoutbtn.TextOffset = new System.Drawing.Point(15, 0);
            this.logoutbtn.Click += new System.EventHandler(this.logoutbtn_Click);
            // 
            // menuOrder
            // 
            this.menuOrder.ButtonText = "Order";
            this.menuOrder.CheckedBackground = System.Drawing.Color.White;
            this.menuOrder.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.menuOrder.CheckedImageTint = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.menuOrder.CheckedOutline = System.Drawing.Color.White;
            this.menuOrder.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.menuOrder.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuOrder.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.menuOrder.HoverForeColor = System.Drawing.Color.White;
            this.menuOrder.HoverImage = ((System.Drawing.Image)(resources.GetObject("menuOrder.HoverImage")));
            this.menuOrder.HoverImageTint = System.Drawing.Color.White;
            this.menuOrder.HoverOutline = System.Drawing.Color.Empty;
            this.menuOrder.Image = ((System.Drawing.Image)(resources.GetObject("menuOrder.Image")));
            this.menuOrder.ImageAutoCenter = false;
            this.menuOrder.ImageExpand = new System.Drawing.Point(3, 3);
            this.menuOrder.ImageOffset = new System.Drawing.Point(20, 0);
            this.menuOrder.ImageTint = System.Drawing.Color.White;
            this.menuOrder.IsToggleButton = false;
            this.menuOrder.IsToggled = false;
            this.menuOrder.Location = new System.Drawing.Point(4, 266);
            this.menuOrder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.menuOrder.Name = "menuOrder";
            this.menuOrder.NormalBackground = System.Drawing.Color.White;
            this.menuOrder.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuOrder.NormalOutline = System.Drawing.Color.Empty;
            this.menuOrder.OutlineThickness = 2F;
            this.menuOrder.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.menuOrder.PressedForeColor = System.Drawing.Color.White;
            this.menuOrder.PressedImageTint = System.Drawing.Color.White;
            this.menuOrder.PressedOutline = System.Drawing.Color.Empty;
            this.menuOrder.Rounding = new System.Windows.Forms.Padding(5);
            this.menuOrder.Size = new System.Drawing.Size(250, 51);
            this.menuOrder.TabIndex = 2;
            this.menuOrder.TextAutoCenter = false;
            this.menuOrder.TextOffset = new System.Drawing.Point(15, 0);
            this.menuOrder.Click += new System.EventHandler(this.menuOrder_Click);
            // 
            // menuRestaurant
            // 
            this.menuRestaurant.ButtonText = "Restaurant";
            this.menuRestaurant.CheckedBackground = System.Drawing.Color.White;
            this.menuRestaurant.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.menuRestaurant.CheckedImageTint = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.menuRestaurant.CheckedOutline = System.Drawing.Color.White;
            this.menuRestaurant.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.menuRestaurant.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuRestaurant.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.menuRestaurant.HoverForeColor = System.Drawing.Color.White;
            this.menuRestaurant.HoverImage = ((System.Drawing.Image)(resources.GetObject("menuRestaurant.HoverImage")));
            this.menuRestaurant.HoverImageTint = System.Drawing.Color.White;
            this.menuRestaurant.HoverOutline = System.Drawing.Color.Empty;
            this.menuRestaurant.Image = ((System.Drawing.Image)(resources.GetObject("menuRestaurant.Image")));
            this.menuRestaurant.ImageAutoCenter = false;
            this.menuRestaurant.ImageExpand = new System.Drawing.Point(3, 3);
            this.menuRestaurant.ImageOffset = new System.Drawing.Point(20, 0);
            this.menuRestaurant.ImageTint = System.Drawing.Color.White;
            this.menuRestaurant.IsToggleButton = false;
            this.menuRestaurant.IsToggled = false;
            this.menuRestaurant.Location = new System.Drawing.Point(4, 209);
            this.menuRestaurant.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.menuRestaurant.Name = "menuRestaurant";
            this.menuRestaurant.NormalBackground = System.Drawing.Color.White;
            this.menuRestaurant.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuRestaurant.NormalOutline = System.Drawing.Color.Empty;
            this.menuRestaurant.OutlineThickness = 2F;
            this.menuRestaurant.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.menuRestaurant.PressedForeColor = System.Drawing.Color.White;
            this.menuRestaurant.PressedImageTint = System.Drawing.Color.White;
            this.menuRestaurant.PressedOutline = System.Drawing.Color.Empty;
            this.menuRestaurant.Rounding = new System.Windows.Forms.Padding(5);
            this.menuRestaurant.Size = new System.Drawing.Size(250, 51);
            this.menuRestaurant.TabIndex = 2;
            this.menuRestaurant.TextAutoCenter = false;
            this.menuRestaurant.TextOffset = new System.Drawing.Point(15, 0);
            this.menuRestaurant.Click += new System.EventHandler(this.menuRestaurant_Click);
            // 
            // sataButton12
            // 
            this.sataButton12.ButtonText = "Dashboard";
            this.sataButton12.CheckedBackground = System.Drawing.Color.White;
            this.sataButton12.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.sataButton12.CheckedImageTint = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.sataButton12.CheckedOutline = System.Drawing.Color.White;
            this.sataButton12.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.sataButton12.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sataButton12.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.sataButton12.HoverForeColor = System.Drawing.Color.White;
            this.sataButton12.HoverImage = ((System.Drawing.Image)(resources.GetObject("sataButton12.HoverImage")));
            this.sataButton12.HoverImageTint = System.Drawing.Color.White;
            this.sataButton12.HoverOutline = System.Drawing.Color.Empty;
            this.sataButton12.Image = ((System.Drawing.Image)(resources.GetObject("sataButton12.Image")));
            this.sataButton12.ImageAutoCenter = false;
            this.sataButton12.ImageExpand = new System.Drawing.Point(3, 3);
            this.sataButton12.ImageOffset = new System.Drawing.Point(20, 0);
            this.sataButton12.ImageTint = System.Drawing.Color.White;
            this.sataButton12.IsToggleButton = false;
            this.sataButton12.IsToggled = false;
            this.sataButton12.Location = new System.Drawing.Point(4, 152);
            this.sataButton12.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sataButton12.Name = "sataButton12";
            this.sataButton12.NormalBackground = System.Drawing.Color.White;
            this.sataButton12.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sataButton12.NormalOutline = System.Drawing.Color.Empty;
            this.sataButton12.OutlineThickness = 2F;
            this.sataButton12.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.sataButton12.PressedForeColor = System.Drawing.Color.White;
            this.sataButton12.PressedImageTint = System.Drawing.Color.White;
            this.sataButton12.PressedOutline = System.Drawing.Color.Empty;
            this.sataButton12.Rounding = new System.Windows.Forms.Padding(5);
            this.sataButton12.Size = new System.Drawing.Size(250, 51);
            this.sataButton12.TabIndex = 2;
            this.sataButton12.TextAutoCenter = false;
            this.sataButton12.TextOffset = new System.Drawing.Point(15, 0);
            this.sataButton12.Click += new System.EventHandler(this.menuDashboard_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(31, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1369, 860);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SATAUiFramework.Controls.SATAEllipseControl sataEllipseControl1;
        private System.Windows.Forms.Panel panelHeader;
        private SATAUiFramework.Controls.SATADragControl sataDragControl1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private FrameworkTest.SATAButton sataButton21;
        private FrameworkTest.SATAButton logoutbtn;
        private FrameworkTest.SATAButton menuOrder;
        private FrameworkTest.SATAButton menuRestaurant;
        private FrameworkTest.SATAButton sataButton12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FrameworkTest.SATAButton Inventorybtn;
    }
}

