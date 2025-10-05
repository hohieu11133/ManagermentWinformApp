using SATAUiFramework.Helpers;

namespace SocialMediaDashboardDesign
{
    partial class DashboardControl
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
            SATAUiFramework.BorderRadius borderRadius1 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius2 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius3 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius4 = new SATAUiFramework.BorderRadius();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardControl));
            SATAUiFramework.BorderRadius borderRadius5 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius6 = new SATAUiFramework.BorderRadius();
            this.panel4 = new System.Windows.Forms.Panel();
            this.sataPanel4 = new SATAUiFramework.SATAPanel();
            this.lblmonthprofit = new System.Windows.Forms.Label();
            this.lblnumbermonthprofit = new System.Windows.Forms.Label();
            this.sataPanel3 = new SATAUiFramework.SATAPanel();
            this.lblnumberyearprofit = new System.Windows.Forms.Label();
            this.lblyearprofit = new System.Windows.Forms.Label();
            this.btnExportPdf = new FrameworkTest.SATAButton();
            this.sataPanel2 = new SATAUiFramework.SATAPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sataPanel5 = new SATAUiFramework.SATAPanel();
            this.YearcomboBox = new System.Windows.Forms.ComboBox();
            this.sataBarChart1 = new SATAUi.Controls.Charts.SATABarChart();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.sataPanel7 = new SATAUiFramework.SATAPanel();
            this.MonthcomboBox = new System.Windows.Forms.ComboBox();
            this.sataLineChart1 = new FrameworkTest.Charts.SATALineChart();
            this.label28 = new System.Windows.Forms.Label();
            this.sataPanel1 = new SATAUiFramework.SATAPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.sataPanel4.SuspendLayout();
            this.sataPanel3.SuspendLayout();
            this.sataPanel2.SuspendLayout();
            this.sataPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.sataPanel7.SuspendLayout();
            this.sataPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.sataPanel4);
            this.panel4.Controls.Add(this.sataPanel3);
            this.panel4.Controls.Add(this.btnExportPdf);
            this.panel4.Controls.Add(this.sataPanel2);
            this.panel4.Controls.Add(this.sataPanel5);
            this.panel4.Controls.Add(this.sataPanel7);
            this.panel4.Controls.Add(this.sataPanel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1155, 660);
            this.panel4.TabIndex = 5;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // sataPanel4
            // 
            this.sataPanel4.BackColor = System.Drawing.Color.White;
            this.sataPanel4.BackColor2 = System.Drawing.Color.White;
            this.sataPanel4.BorderColor = System.Drawing.Color.Black;
            borderRadius1.BottomLeft = 10;
            borderRadius1.BottomRight = 10;
            borderRadius1.TopLeft = 10;
            borderRadius1.TopRight = 10;
            this.sataPanel4.BorderRadius = borderRadius1;
            this.sataPanel4.BorderThickness = 0;
            this.sataPanel4.Controls.Add(this.lblmonthprofit);
            this.sataPanel4.Controls.Add(this.lblnumbermonthprofit);
            this.sataPanel4.Location = new System.Drawing.Point(857, 535);
            this.sataPanel4.Name = "sataPanel4";
            this.sataPanel4.Size = new System.Drawing.Size(241, 81);
            this.sataPanel4.TabIndex = 4;
            // 
            // lblmonthprofit
            // 
            this.lblmonthprofit.AutoSize = true;
            this.lblmonthprofit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblmonthprofit.Location = new System.Drawing.Point(3, 21);
            this.lblmonthprofit.Name = "lblmonthprofit";
            this.lblmonthprofit.Size = new System.Drawing.Size(103, 16);
            this.lblmonthprofit.TabIndex = 1;
            this.lblmonthprofit.Text = "Lợi nhuận tháng ";
            // 
            // lblnumbermonthprofit
            // 
            this.lblnumbermonthprofit.AutoSize = true;
            this.lblnumbermonthprofit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnumbermonthprofit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblnumbermonthprofit.Location = new System.Drawing.Point(3, 37);
            this.lblnumbermonthprofit.Name = "lblnumbermonthprofit";
            this.lblnumbermonthprofit.Size = new System.Drawing.Size(59, 23);
            this.lblnumbermonthprofit.TabIndex = 1;
            this.lblnumbermonthprofit.Text = "4.35k";
            // 
            // sataPanel3
            // 
            this.sataPanel3.BackColor = System.Drawing.Color.White;
            this.sataPanel3.BackColor2 = System.Drawing.Color.White;
            this.sataPanel3.BorderColor = System.Drawing.Color.Black;
            borderRadius2.BottomLeft = 10;
            borderRadius2.BottomRight = 10;
            borderRadius2.TopLeft = 10;
            borderRadius2.TopRight = 10;
            this.sataPanel3.BorderRadius = borderRadius2;
            this.sataPanel3.BorderThickness = 0;
            this.sataPanel3.Controls.Add(this.lblnumberyearprofit);
            this.sataPanel3.Controls.Add(this.lblyearprofit);
            this.sataPanel3.Location = new System.Drawing.Point(857, 211);
            this.sataPanel3.Name = "sataPanel3";
            this.sataPanel3.Size = new System.Drawing.Size(241, 81);
            this.sataPanel3.TabIndex = 2;
            // 
            // lblnumberyearprofit
            // 
            this.lblnumberyearprofit.AutoSize = true;
            this.lblnumberyearprofit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnumberyearprofit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblnumberyearprofit.Location = new System.Drawing.Point(3, 32);
            this.lblnumberyearprofit.Name = "lblnumberyearprofit";
            this.lblnumberyearprofit.Size = new System.Drawing.Size(81, 23);
            this.lblnumberyearprofit.TabIndex = 3;
            this.lblnumberyearprofit.Text = "123.65k";
            // 
            // lblyearprofit
            // 
            this.lblyearprofit.AutoSize = true;
            this.lblyearprofit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblyearprofit.Location = new System.Drawing.Point(4, 11);
            this.lblyearprofit.Name = "lblyearprofit";
            this.lblyearprofit.Size = new System.Drawing.Size(96, 16);
            this.lblyearprofit.TabIndex = 2;
            this.lblyearprofit.Text = "Lợi nhuận năm ";
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.ButtonText = "Export Pdf";
            this.btnExportPdf.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnExportPdf.CheckedForeColor = System.Drawing.Color.White;
            this.btnExportPdf.CheckedImageTint = System.Drawing.Color.White;
            this.btnExportPdf.CheckedOutline = System.Drawing.Color.Transparent;
            this.btnExportPdf.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExportPdf.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportPdf.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnExportPdf.HoverForeColor = System.Drawing.Color.White;
            this.btnExportPdf.HoverImage = null;
            this.btnExportPdf.HoverImageTint = System.Drawing.Color.White;
            this.btnExportPdf.HoverOutline = System.Drawing.Color.Transparent;
            this.btnExportPdf.Image = null;
            this.btnExportPdf.ImageAutoCenter = true;
            this.btnExportPdf.ImageExpand = new System.Drawing.Point(3, 3);
            this.btnExportPdf.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnExportPdf.ImageTint = System.Drawing.Color.White;
            this.btnExportPdf.IsToggleButton = false;
            this.btnExportPdf.IsToggled = false;
            this.btnExportPdf.Location = new System.Drawing.Point(735, 48);
            this.btnExportPdf.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnExportPdf.NormalForeColor = System.Drawing.Color.White;
            this.btnExportPdf.NormalOutline = System.Drawing.Color.Transparent;
            this.btnExportPdf.OutlineThickness = 0F;
            this.btnExportPdf.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnExportPdf.PressedForeColor = System.Drawing.Color.White;
            this.btnExportPdf.PressedImageTint = System.Drawing.Color.White;
            this.btnExportPdf.PressedOutline = System.Drawing.Color.Transparent;
            this.btnExportPdf.Rounding = new System.Windows.Forms.Padding(10);
            this.btnExportPdf.Size = new System.Drawing.Size(116, 49);
            this.btnExportPdf.TabIndex = 3;
            this.btnExportPdf.TextAutoCenter = true;
            this.btnExportPdf.TextOffset = new System.Drawing.Point(0, 0);
            this.btnExportPdf.Click += new System.EventHandler(this.btnExportPdf_Click);
            // 
            // sataPanel2
            // 
            this.sataPanel2.BackColor = System.Drawing.Color.White;
            this.sataPanel2.BackColor2 = System.Drawing.Color.White;
            this.sataPanel2.BorderColor = System.Drawing.Color.Black;
            borderRadius3.BottomLeft = 10;
            borderRadius3.BottomRight = 10;
            borderRadius3.TopLeft = 10;
            borderRadius3.TopRight = 10;
            this.sataPanel2.BorderRadius = borderRadius3;
            this.sataPanel2.BorderThickness = 0;
            this.sataPanel2.Controls.Add(this.label9);
            this.sataPanel2.Controls.Add(this.label4);
            this.sataPanel2.Location = new System.Drawing.Point(857, 448);
            this.sataPanel2.Name = "sataPanel2";
            this.sataPanel2.Size = new System.Drawing.Size(241, 81);
            this.sataPanel2.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(12, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 23);
            this.label9.TabIndex = 2;
            this.label9.Text = "4.35k";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(11, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Doanh thu tháng ";
            // 
            // sataPanel5
            // 
            this.sataPanel5.BackColor = System.Drawing.Color.White;
            this.sataPanel5.BackColor2 = System.Drawing.Color.White;
            this.sataPanel5.BorderColor = System.Drawing.Color.Black;
            borderRadius4.BottomLeft = 10;
            borderRadius4.BottomRight = 10;
            borderRadius4.TopLeft = 10;
            borderRadius4.TopRight = 10;
            this.sataPanel5.BorderRadius = borderRadius4;
            this.sataPanel5.BorderThickness = 0;
            this.sataPanel5.Controls.Add(this.YearcomboBox);
            this.sataPanel5.Controls.Add(this.sataBarChart1);
            this.sataPanel5.Controls.Add(this.label15);
            this.sataPanel5.Controls.Add(this.pictureBox6);
            this.sataPanel5.Location = new System.Drawing.Point(28, 124);
            this.sataPanel5.Name = "sataPanel5";
            this.sataPanel5.Size = new System.Drawing.Size(823, 318);
            this.sataPanel5.TabIndex = 0;
            this.sataPanel5.Paint += new System.Windows.Forms.PaintEventHandler(this.sataPanel5_Paint);
            // 
            // YearcomboBox
            // 
            this.YearcomboBox.FormattingEnabled = true;
            this.YearcomboBox.Items.AddRange(new object[] {
            "2020\t",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.YearcomboBox.Location = new System.Drawing.Point(627, 20);
            this.YearcomboBox.Name = "YearcomboBox";
            this.YearcomboBox.Size = new System.Drawing.Size(121, 24);
            this.YearcomboBox.TabIndex = 3;
            this.YearcomboBox.Text = "Chọn năm";
            this.YearcomboBox.SelectedIndexChanged += new System.EventHandler(this.YearcomboBox_SelectedIndexChanged);
            // 
            // sataBarChart1
            // 
            this.sataBarChart1.AutoMaxValue = false;
            this.sataBarChart1.AxisColor = System.Drawing.Color.Gray;
            this.sataBarChart1.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.sataBarChart1.BarColors = new System.Drawing.Color[0];
            this.sataBarChart1.BarSpacing = 10;
            this.sataBarChart1.BarWidth = 0;
            this.sataBarChart1.ChartPadding = 60;
            this.sataBarChart1.CustomXAxis = new string[] {
        "jan",
        "feb",
        "mar",
        "apr",
        "may",
        "jun",
        "jul",
        "aug",
        "sep",
        "oct",
        "nov",
        "dec"};
            this.sataBarChart1.DataPoints = new float[] {
        15F,
        35F,
        38F,
        28F,
        14F,
        32F,
        60F,
        45F,
        31F,
        58F,
        75F,
        55F};
            this.sataBarChart1.DayColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sataBarChart1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sataBarChart1.Location = new System.Drawing.Point(11, 46);
            this.sataBarChart1.MaxValue = 75F;
            this.sataBarChart1.Name = "sataBarChart1";
            this.sataBarChart1.Padding = new System.Windows.Forms.Padding(40, 40, 40, 80);
            this.sataBarChart1.RoundedBars = true;
            this.sataBarChart1.Size = new System.Drawing.Size(737, 262);
            this.sataBarChart1.TabIndex = 2;
            this.sataBarChart1.UsePercent = false;
            this.sataBarChart1.Load += new System.EventHandler(this.sataBarChart1_Load);
            this.sataBarChart1.Click += new System.EventHandler(this.sataBarChart1_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label15.Location = new System.Drawing.Point(48, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(103, 23);
            this.label15.TabIndex = 1;
            this.label15.Text = "Doanh thu";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(12, 16);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(26, 23);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 0;
            this.pictureBox6.TabStop = false;
            // 
            // sataPanel7
            // 
            this.sataPanel7.BackColor = System.Drawing.Color.White;
            this.sataPanel7.BackColor2 = System.Drawing.Color.White;
            this.sataPanel7.BorderColor = System.Drawing.Color.Black;
            borderRadius5.BottomLeft = 10;
            borderRadius5.BottomRight = 10;
            borderRadius5.TopLeft = 10;
            borderRadius5.TopRight = 10;
            this.sataPanel7.BorderRadius = borderRadius5;
            this.sataPanel7.BorderThickness = 0;
            this.sataPanel7.Controls.Add(this.MonthcomboBox);
            this.sataPanel7.Controls.Add(this.sataLineChart1);
            this.sataPanel7.Controls.Add(this.label28);
            this.sataPanel7.Location = new System.Drawing.Point(28, 448);
            this.sataPanel7.Name = "sataPanel7";
            this.sataPanel7.Size = new System.Drawing.Size(823, 198);
            this.sataPanel7.TabIndex = 0;
            // 
            // MonthcomboBox
            // 
            this.MonthcomboBox.FormattingEnabled = true;
            this.MonthcomboBox.Items.AddRange(new object[] {
            "Jan",
            "Feb",
            "Mar ",
            "Apr",
            "May",
            "June ",
            "July",
            "Aug",
            "Sep",
            "Oct",
            "Nov",
            "Dec"});
            this.MonthcomboBox.Location = new System.Drawing.Point(627, 14);
            this.MonthcomboBox.Name = "MonthcomboBox";
            this.MonthcomboBox.Size = new System.Drawing.Size(121, 24);
            this.MonthcomboBox.TabIndex = 4;
            this.MonthcomboBox.Text = "Chọn tháng";
            this.MonthcomboBox.SelectedIndexChanged += new System.EventHandler(this.MonthcomboBox_SelectedIndexChanged);
            // 
            // sataLineChart1
            // 
            this.sataLineChart1.AutoMaxValue = false;
            this.sataLineChart1.AxisColor = System.Drawing.Color.Gray;
            this.sataLineChart1.ChartLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.sataLineChart1.ChartPadding = 60;
            this.sataLineChart1.CustomXAxis = new string[0];
            this.sataLineChart1.DataPoints = new float[] {
        105F,
        65F,
        80F,
        120F,
        135F,
        65F,
        30F};
            this.sataLineChart1.DayColor = System.Drawing.Color.DarkGray;
            this.sataLineChart1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sataLineChart1.GradientBackground = true;
            this.sataLineChart1.Location = new System.Drawing.Point(13, 29);
            this.sataLineChart1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sataLineChart1.MaxValue = 150F;
            this.sataLineChart1.Name = "sataLineChart1";
            this.sataLineChart1.PointColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.sataLineChart1.ShortDates = true;
            this.sataLineChart1.Size = new System.Drawing.Size(751, 166);
            this.sataLineChart1.TabIndex = 2;
            this.sataLineChart1.UseBezier = true;
            this.sataLineChart1.UsePercent = false;
            this.sataLineChart1.Load += new System.EventHandler(this.sataLineChart1_Load);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label28.Location = new System.Drawing.Point(11, 11);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(102, 23);
            this.label28.TabIndex = 1;
            this.label28.Text = "Line Chart";
            // 
            // sataPanel1
            // 
            this.sataPanel1.BackColor = System.Drawing.Color.White;
            this.sataPanel1.BackColor2 = System.Drawing.Color.White;
            this.sataPanel1.BorderColor = System.Drawing.Color.Black;
            borderRadius6.BottomLeft = 10;
            borderRadius6.BottomRight = 10;
            borderRadius6.TopLeft = 10;
            borderRadius6.TopRight = 10;
            this.sataPanel1.BorderRadius = borderRadius6;
            this.sataPanel1.BorderThickness = 0;
            this.sataPanel1.Controls.Add(this.label8);
            this.sataPanel1.Controls.Add(this.label7);
            this.sataPanel1.Location = new System.Drawing.Point(857, 124);
            this.sataPanel1.Name = "sataPanel1";
            this.sataPanel1.Size = new System.Drawing.Size(241, 81);
            this.sataPanel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(9, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 23);
            this.label8.TabIndex = 1;
            this.label8.Text = "123.65k";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(4, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Doanh thu năm ";
            // 
            // DashboardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Name = "DashboardControl";
            this.Size = new System.Drawing.Size(1155, 660);
            this.panel4.ResumeLayout(false);
            this.sataPanel4.ResumeLayout(false);
            this.sataPanel4.PerformLayout();
            this.sataPanel3.ResumeLayout(false);
            this.sataPanel3.PerformLayout();
            this.sataPanel2.ResumeLayout(false);
            this.sataPanel2.PerformLayout();
            this.sataPanel5.ResumeLayout(false);
            this.sataPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.sataPanel7.ResumeLayout(false);
            this.sataPanel7.PerformLayout();
            this.sataPanel1.ResumeLayout(false);
            this.sataPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private SATAUiFramework.SATAPanel sataPanel2;
        private System.Windows.Forms.Label lblnumbermonthprofit;
        private System.Windows.Forms.Label lblmonthprofit;
        private SATAUiFramework.SATAPanel sataPanel5;
        private SATAUi.Controls.Charts.SATABarChart sataBarChart1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictureBox6;
        private SATAUiFramework.SATAPanel sataPanel7;
        private FrameworkTest.Charts.SATALineChart sataLineChart1;
        private System.Windows.Forms.Label label28;
        private SATAUiFramework.SATAPanel sataPanel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox YearcomboBox;
        private System.Windows.Forms.ComboBox MonthcomboBox;
        private FrameworkTest.SATAButton btnExportPdf;
        private System.Windows.Forms.Label lblnumberyearprofit;
        private System.Windows.Forms.Label lblyearprofit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private SATAUiFramework.SATAPanel sataPanel4;
        private SATAUiFramework.SATAPanel sataPanel3;
    }
}
