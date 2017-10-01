namespace testViewBox
{
    partial class testViewBox
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(testViewBox));
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.tbxInfo = new System.Windows.Forms.TextBox();
            this.btnLoadRawImage = new System.Windows.Forms.Button();
            this.lblMaxPixel = new System.Windows.Forms.Label();
            this.tbxMaxPixel = new System.Windows.Forms.TextBox();
            this.lblMinPixel = new System.Windows.Forms.Label();
            this.tbxMinPixel = new System.Windows.Forms.TextBox();
            this.lblWin = new System.Windows.Forms.Label();
            this.tbxWin = new System.Windows.Forms.TextBox();
            this.lblLev = new System.Windows.Forms.Label();
            this.tbxLev = new System.Windows.Forms.TextBox();
            this.hsbWin = new System.Windows.Forms.HScrollBar();
            this.hsbLev = new System.Windows.Forms.HScrollBar();
            this.cbAnnotation = new System.Windows.Forms.CheckBox();
            this.dbNewShape = new System.Windows.Forms.ComboBox();
            this.cbShowPixelMeasure = new System.Windows.Forms.CheckBox();
            this.cbShowStatistics = new System.Windows.Forms.CheckBox();
            this.btnPrintROI = new System.Windows.Forms.Button();
            this.btnTestCompound = new System.Windows.Forms.Button();
            this.vbxImage = new ViewBoxContorl.ViewBoxForm();
            this.hsbAngle = new System.Windows.Forms.HScrollBar();
            this.SuspendLayout();
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadImage.Location = new System.Drawing.Point(548, 12);
            this.btnLoadImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(135, 22);
            this.btnLoadImage.TabIndex = 1;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // tbxInfo
            // 
            this.tbxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxInfo.Location = new System.Drawing.Point(531, 258);
            this.tbxInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxInfo.Multiline = true;
            this.tbxInfo.Name = "tbxInfo";
            this.tbxInfo.Size = new System.Drawing.Size(656, 278);
            this.tbxInfo.TabIndex = 2;
            // 
            // btnLoadRawImage
            // 
            this.btnLoadRawImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadRawImage.Location = new System.Drawing.Point(689, 12);
            this.btnLoadRawImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadRawImage.Name = "btnLoadRawImage";
            this.btnLoadRawImage.Size = new System.Drawing.Size(152, 22);
            this.btnLoadRawImage.TabIndex = 1;
            this.btnLoadRawImage.Text = "Load Raw Image";
            this.btnLoadRawImage.UseVisualStyleBackColor = true;
            this.btnLoadRawImage.Click += new System.EventHandler(this.btnLoadRawImage_Click);
            // 
            // lblMaxPixel
            // 
            this.lblMaxPixel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaxPixel.AutoSize = true;
            this.lblMaxPixel.Location = new System.Drawing.Point(849, 12);
            this.lblMaxPixel.Name = "lblMaxPixel";
            this.lblMaxPixel.Size = new System.Drawing.Size(79, 15);
            this.lblMaxPixel.TabIndex = 3;
            this.lblMaxPixel.Text = "maxPixel:";
            // 
            // tbxMaxPixel
            // 
            this.tbxMaxPixel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxMaxPixel.Location = new System.Drawing.Point(933, 10);
            this.tbxMaxPixel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxMaxPixel.Name = "tbxMaxPixel";
            this.tbxMaxPixel.Size = new System.Drawing.Size(77, 25);
            this.tbxMaxPixel.TabIndex = 4;
            // 
            // lblMinPixel
            // 
            this.lblMinPixel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinPixel.AutoSize = true;
            this.lblMinPixel.Location = new System.Drawing.Point(1027, 12);
            this.lblMinPixel.Name = "lblMinPixel";
            this.lblMinPixel.Size = new System.Drawing.Size(79, 15);
            this.lblMinPixel.TabIndex = 3;
            this.lblMinPixel.Text = "minPixel:";
            // 
            // tbxMinPixel
            // 
            this.tbxMinPixel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxMinPixel.Location = new System.Drawing.Point(1111, 10);
            this.tbxMinPixel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxMinPixel.Name = "tbxMinPixel";
            this.tbxMinPixel.Size = new System.Drawing.Size(77, 25);
            this.tbxMinPixel.TabIndex = 4;
            // 
            // lblWin
            // 
            this.lblWin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWin.AutoSize = true;
            this.lblWin.Location = new System.Drawing.Point(549, 62);
            this.lblWin.Name = "lblWin";
            this.lblWin.Size = new System.Drawing.Size(39, 15);
            this.lblWin.TabIndex = 3;
            this.lblWin.Text = "Win:";
            // 
            // tbxWin
            // 
            this.tbxWin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxWin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbxWin.Location = new System.Drawing.Point(595, 60);
            this.tbxWin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxWin.Name = "tbxWin";
            this.tbxWin.ReadOnly = true;
            this.tbxWin.Size = new System.Drawing.Size(77, 25);
            this.tbxWin.TabIndex = 4;
            this.tbxWin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_KeyPress);
            // 
            // lblLev
            // 
            this.lblLev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLev.AutoSize = true;
            this.lblLev.Location = new System.Drawing.Point(677, 62);
            this.lblLev.Name = "lblLev";
            this.lblLev.Size = new System.Drawing.Size(39, 15);
            this.lblLev.TabIndex = 3;
            this.lblLev.Text = "Lev:";
            // 
            // tbxLev
            // 
            this.tbxLev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxLev.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbxLev.Location = new System.Drawing.Point(713, 60);
            this.tbxLev.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxLev.Name = "tbxLev";
            this.tbxLev.ReadOnly = true;
            this.tbxLev.Size = new System.Drawing.Size(77, 25);
            this.tbxLev.TabIndex = 4;
            this.tbxLev.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_KeyPress);
            // 
            // hsbWin
            // 
            this.hsbWin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hsbWin.Location = new System.Drawing.Point(595, 108);
            this.hsbWin.Name = "hsbWin";
            this.hsbWin.Size = new System.Drawing.Size(579, 21);
            this.hsbWin.TabIndex = 5;
            this.hsbWin.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbWin_Scroll);
            // 
            // hsbLev
            // 
            this.hsbLev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hsbLev.Location = new System.Drawing.Point(595, 140);
            this.hsbLev.Name = "hsbLev";
            this.hsbLev.Size = new System.Drawing.Size(579, 21);
            this.hsbLev.TabIndex = 5;
            this.hsbLev.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbLev_Scroll);
            // 
            // cbAnnotation
            // 
            this.cbAnnotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAnnotation.AutoSize = true;
            this.cbAnnotation.Location = new System.Drawing.Point(775, 184);
            this.cbAnnotation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbAnnotation.Name = "cbAnnotation";
            this.cbAnnotation.Size = new System.Drawing.Size(109, 19);
            this.cbAnnotation.TabIndex = 6;
            this.cbAnnotation.Text = "Annotation";
            this.cbAnnotation.UseVisualStyleBackColor = true;
            this.cbAnnotation.CheckedChanged += new System.EventHandler(this.cbAnnotation_CheckedChanged);
            // 
            // dbNewShape
            // 
            this.dbNewShape.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dbNewShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbNewShape.FormattingEnabled = true;
            this.dbNewShape.Items.AddRange(new object[] {
            "None",
            "Ellipse",
            "Box",
            "Line"});
            this.dbNewShape.Location = new System.Drawing.Point(1020, 180);
            this.dbNewShape.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dbNewShape.Name = "dbNewShape";
            this.dbNewShape.Size = new System.Drawing.Size(160, 23);
            this.dbNewShape.TabIndex = 7;
            this.dbNewShape.SelectedIndexChanged += new System.EventHandler(this.dbNewShape_SelectedIndexChanged);
            // 
            // cbShowPixelMeasure
            // 
            this.cbShowPixelMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbShowPixelMeasure.AutoSize = true;
            this.cbShowPixelMeasure.Location = new System.Drawing.Point(895, 184);
            this.cbShowPixelMeasure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbShowPixelMeasure.Name = "cbShowPixelMeasure";
            this.cbShowPixelMeasure.Size = new System.Drawing.Size(117, 19);
            this.cbShowPixelMeasure.TabIndex = 8;
            this.cbShowPixelMeasure.Text = "Pixel Value";
            this.cbShowPixelMeasure.UseVisualStyleBackColor = true;
            this.cbShowPixelMeasure.CheckedChanged += new System.EventHandler(this.ShowPixelMeasure_CheckedChanged);
            // 
            // cbShowStatistics
            // 
            this.cbShowStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbShowStatistics.AutoSize = true;
            this.cbShowStatistics.Location = new System.Drawing.Point(895, 211);
            this.cbShowStatistics.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbShowStatistics.Name = "cbShowStatistics";
            this.cbShowStatistics.Size = new System.Drawing.Size(109, 19);
            this.cbShowStatistics.TabIndex = 9;
            this.cbShowStatistics.Text = "Statistics";
            this.cbShowStatistics.UseVisualStyleBackColor = true;
            this.cbShowStatistics.CheckedChanged += new System.EventHandler(this.cbShowStatistics_CheckedChanged);
            // 
            // btnPrintROI
            // 
            this.btnPrintROI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintROI.Location = new System.Drawing.Point(784, 212);
            this.btnPrintROI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrintROI.Name = "btnPrintROI";
            this.btnPrintROI.Size = new System.Drawing.Size(100, 29);
            this.btnPrintROI.TabIndex = 10;
            this.btnPrintROI.Text = "Print ROI";
            this.btnPrintROI.UseVisualStyleBackColor = true;
            this.btnPrintROI.Click += new System.EventHandler(this.btnPrintROI_Click);
            // 
            // btnTestCompound
            // 
            this.btnTestCompound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestCompound.Location = new System.Drawing.Point(676, 211);
            this.btnTestCompound.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTestCompound.Name = "btnTestCompound";
            this.btnTestCompound.Size = new System.Drawing.Size(100, 29);
            this.btnTestCompound.TabIndex = 11;
            this.btnTestCompound.Text = "CompoundShape";
            this.btnTestCompound.UseVisualStyleBackColor = true;
            this.btnTestCompound.Click += new System.EventHandler(this.btnTestCompound_Click);
            // 
            // vbxImage
            // 
            this.vbxImage.AccelModeScale = 3;
            this.vbxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vbxImage.FovCol = 0D;
            this.vbxImage.FovRow = 0D;
            this.vbxImage.GrayLevelData = null;
            this.vbxImage.Image = ((System.Drawing.Image)(resources.GetObject("vbxImage.Image")));
            this.vbxImage.InterationMode = ViewBoxContorl.ViewBoxForm.Interaction.Browse;
            this.vbxImage.Lev = ((short)(0));
            this.vbxImage.Location = new System.Drawing.Point(12, 12);
            this.vbxImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vbxImage.MouseOpMode = ViewBoxContorl.ViewBoxForm.MouseOps.PosLvl;
            this.vbxImage.Name = "vbxImage";
            this.vbxImage.NoCol = 0;
            this.vbxImage.NoRow = 0;
            this.vbxImage.Pannable = false;
            this.vbxImage.PixelData = null;
            this.vbxImage.SampleRect = new System.Drawing.Rectangle(-161, -205, 322, 410);
            this.vbxImage.ShowPixelValue = false;
            this.vbxImage.ShowStatistics = false;
            this.vbxImage.Size = new System.Drawing.Size(429, 512);
            this.vbxImage.SizeScale = 1F;
            this.vbxImage.TabIndex = 0;
            this.vbxImage.TabStop = false;
            this.vbxImage.Win = ((short)(1));
            this.vbxImage.Zoomable = true;
            this.vbxImage.SizeChanged += new System.EventHandler(this.vbxImage_SizeChanged);
            this.vbxImage.VisibleChanged += new System.EventHandler(this.vbxImage_VisibleChanged);
            this.vbxImage.Click += new System.EventHandler(this.vbxImage_Click);
            this.vbxImage.Paint += new System.Windows.Forms.PaintEventHandler(this.vbxImage_Paint);
            this.vbxImage.Resize += new System.EventHandler(this.vbxImage_Resize);
            // 
            // hsbAngle
            // 
            this.hsbAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hsbAngle.Location = new System.Drawing.Point(868, 62);
            this.hsbAngle.Maximum = 90;
            this.hsbAngle.Minimum = -90;
            this.hsbAngle.Name = "hsbAngle";
            this.hsbAngle.Size = new System.Drawing.Size(219, 21);
            this.hsbAngle.TabIndex = 12;
            this.hsbAngle.ValueChanged += new System.EventHandler(this.hsbAngle_ValueChanged);
            // 
            // testViewBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 548);
            this.Controls.Add(this.hsbAngle);
            this.Controls.Add(this.btnTestCompound);
            this.Controls.Add(this.btnPrintROI);
            this.Controls.Add(this.cbShowStatistics);
            this.Controls.Add(this.cbShowPixelMeasure);
            this.Controls.Add(this.dbNewShape);
            this.Controls.Add(this.cbAnnotation);
            this.Controls.Add(this.hsbLev);
            this.Controls.Add(this.hsbWin);
            this.Controls.Add(this.tbxLev);
            this.Controls.Add(this.lblLev);
            this.Controls.Add(this.tbxMinPixel);
            this.Controls.Add(this.tbxWin);
            this.Controls.Add(this.lblMinPixel);
            this.Controls.Add(this.lblWin);
            this.Controls.Add(this.tbxMaxPixel);
            this.Controls.Add(this.lblMaxPixel);
            this.Controls.Add(this.tbxInfo);
            this.Controls.Add(this.btnLoadRawImage);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.vbxImage);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "testViewBox";
            this.Text = "Test ViewBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ViewBoxContorl.ViewBoxForm vbxImage;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.TextBox tbxInfo;
        private System.Windows.Forms.Button btnLoadRawImage;
        private System.Windows.Forms.Label lblMaxPixel;
        private System.Windows.Forms.TextBox tbxMaxPixel;
        private System.Windows.Forms.Label lblMinPixel;
        private System.Windows.Forms.TextBox tbxMinPixel;
        private System.Windows.Forms.Label lblWin;
        private System.Windows.Forms.TextBox tbxWin;
        private System.Windows.Forms.Label lblLev;
        private System.Windows.Forms.TextBox tbxLev;
        private System.Windows.Forms.HScrollBar hsbWin;
        private System.Windows.Forms.HScrollBar hsbLev;
        private System.Windows.Forms.CheckBox cbAnnotation;
        private System.Windows.Forms.ComboBox dbNewShape;
        private System.Windows.Forms.CheckBox cbShowPixelMeasure;
        private System.Windows.Forms.CheckBox cbShowStatistics;
        private System.Windows.Forms.Button btnPrintROI;
        private System.Windows.Forms.Button btnTestCompound;
        private System.Windows.Forms.HScrollBar hsbAngle;
    }
}

