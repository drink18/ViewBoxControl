namespace MultiViewTest
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelTabView = new System.Windows.Forms.TableLayoutPanel();
            this.vb1 = new ViewBoxContorl.ViewBoxForm();
            this.vb2 = new ViewBoxContorl.ViewBoxForm();
            this.vb3 = new ViewBoxContorl.ViewBoxForm();
            this.vb4 = new ViewBoxContorl.ViewBoxForm();
            this.Load = new System.Windows.Forms.Button();
            this.panelTabView.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTabView
            // 
            this.panelTabView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTabView.ColumnCount = 2;
            this.panelTabView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.93288F));
            this.panelTabView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.06712F));
            this.panelTabView.Controls.Add(this.vb1, 0, 0);
            this.panelTabView.Controls.Add(this.vb2, 1, 0);
            this.panelTabView.Controls.Add(this.vb3, 0, 1);
            this.panelTabView.Controls.Add(this.vb4, 1, 1);
            this.panelTabView.Location = new System.Drawing.Point(0, 0);
            this.panelTabView.Name = "panelTabView";
            this.panelTabView.RowCount = 2;
            this.panelTabView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelTabView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelTabView.Size = new System.Drawing.Size(898, 518);
            this.panelTabView.TabIndex = 0;
            // 
            // vb1
            // 
            this.vb1.AccelModeScale = 3;
            this.vb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vb1.FovCol = 0D;
            this.vb1.FovRow = 0D;
            this.vb1.GrayLevelData = null;
            this.vb1.Image = ((System.Drawing.Image)(resources.GetObject("vb1.Image")));
            this.vb1.Lev = ((short)(0));
            this.vb1.Location = new System.Drawing.Point(3, 3);
            this.vb1.Name = "vb1";
            this.vb1.NoCol = 100;
            this.vb1.NoRow = 100;
            this.vb1.Pannable = false;
            this.vb1.PixelData = null;
            this.vb1.SampleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.vb1.ShowPixelValue = false;
            this.vb1.ShowStatistics = false;
            this.vb1.Size = new System.Drawing.Size(442, 253);
            this.vb1.ZoomFactor = 1F;
            this.vb1.TabIndex = 0;
            this.vb1.Win = ((short)(0));
            this.vb1.Zoomable = false;
            // 
            // vb2
            // 
            this.vb2.AccelModeScale = 3;
            this.vb2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vb2.FovCol = 0D;
            this.vb2.FovRow = 0D;
            this.vb2.GrayLevelData = null;
            this.vb2.Image = ((System.Drawing.Image)(resources.GetObject("vb2.Image")));
            this.vb2.Lev = ((short)(0));
            this.vb2.Location = new System.Drawing.Point(451, 3);
            this.vb2.Name = "vb2";
            this.vb2.NoCol = 100;
            this.vb2.NoRow = 100;
            this.vb2.Pannable = false;
            this.vb2.PixelData = null;
            this.vb2.SampleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.vb2.ShowPixelValue = false;
            this.vb2.ShowStatistics = false;
            this.vb2.Size = new System.Drawing.Size(444, 253);
            this.vb2.ZoomFactor = 1F;
            this.vb2.TabIndex = 1;
            this.vb2.Win = ((short)(0));
            this.vb2.Zoomable = false;
            // 
            // vb3
            // 
            this.vb3.AccelModeScale = 3;
            this.vb3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vb3.FovCol = 0D;
            this.vb3.FovRow = 0D;
            this.vb3.GrayLevelData = null;
            this.vb3.Image = ((System.Drawing.Image)(resources.GetObject("vb3.Image")));
            this.vb3.Lev = ((short)(0));
            this.vb3.Location = new System.Drawing.Point(3, 262);
            this.vb3.Name = "vb3";
            this.vb3.NoCol = 100;
            this.vb3.NoRow = 100;
            this.vb3.Pannable = false;
            this.vb3.PixelData = null;
            this.vb3.SampleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.vb3.ShowPixelValue = false;
            this.vb3.ShowStatistics = false;
            this.vb3.Size = new System.Drawing.Size(442, 253);
            this.vb3.ZoomFactor = 1F;
            this.vb3.TabIndex = 2;
            this.vb3.Win = ((short)(0));
            this.vb3.Zoomable = false;
            // 
            // vb4
            // 
            this.vb4.AccelModeScale = 3;
            this.vb4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vb4.FovCol = 0D;
            this.vb4.FovRow = 0D;
            this.vb4.GrayLevelData = null;
            this.vb4.Image = ((System.Drawing.Image)(resources.GetObject("vb4.Image")));
            this.vb4.Lev = ((short)(0));
            this.vb4.Location = new System.Drawing.Point(451, 262);
            this.vb4.Name = "vb4";
            this.vb4.NoCol = 100;
            this.vb4.NoRow = 100;
            this.vb4.Pannable = false;
            this.vb4.PixelData = null;
            this.vb4.SampleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.vb4.ShowPixelValue = false;
            this.vb4.ShowStatistics = false;
            this.vb4.Size = new System.Drawing.Size(444, 253);
            this.vb4.ZoomFactor = 1F;
            this.vb4.TabIndex = 3;
            this.vb4.Win = ((short)(0));
            this.vb4.Zoomable = false;
            // 
            // Load
            // 
            this.Load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Load.Location = new System.Drawing.Point(13, 540);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(75, 23);
            this.Load.TabIndex = 1;
            this.Load.Text = "btnLoad";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 575);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.panelTabView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelTabView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelTabView;
        private ViewBoxContorl.ViewBoxForm vb1;
        private ViewBoxContorl.ViewBoxForm vb2;
        private ViewBoxContorl.ViewBoxForm vb3;
        private ViewBoxContorl.ViewBoxForm vb4;
        private System.Windows.Forms.Button Load;
    }
}

