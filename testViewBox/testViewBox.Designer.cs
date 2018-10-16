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
            this.dbNewShape = new System.Windows.Forms.ComboBox();
            this.cbShowPixelMeasure = new System.Windows.Forms.CheckBox();
            this.cbShowStatistics = new System.Windows.Forms.CheckBox();
            this.btnPrintROI = new System.Windows.Forms.Button();
            this.btnTestCompound = new System.Windows.Forms.Button();
            this.hsbAngle = new System.Windows.Forms.HScrollBar();
            this.numRowSpacing = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numColSpacing = new System.Windows.Forms.NumericUpDown();
            this.btnUnload = new System.Windows.Forms.Button();
            this.cbPannable = new System.Windows.Forms.CheckBox();
            this.cbZoomable = new System.Windows.Forms.CheckBox();
            this.btnRemoveSub = new System.Windows.Forms.Button();
            this.btnLineText = new System.Windows.Forms.Button();
            this.vbxImage = new ViewBoxContorl.ViewBoxForm();
            ((System.ComponentModel.ISupportInitialize)(this.numRowSpacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColSpacing)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadImage.Location = new System.Drawing.Point(611, 22);
            this.btnLoadImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(202, 37);
            this.btnLoadImage.TabIndex = 1;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // tbxInfo
            // 
            this.tbxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxInfo.Location = new System.Drawing.Point(584, 698);
            this.tbxInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbxInfo.Multiline = true;
            this.tbxInfo.Name = "tbxInfo";
            this.tbxInfo.Size = new System.Drawing.Size(982, 334);
            this.tbxInfo.TabIndex = 2;
            // 
            // btnLoadRawImage
            // 
            this.btnLoadRawImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadRawImage.Location = new System.Drawing.Point(824, 22);
            this.btnLoadRawImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLoadRawImage.Name = "btnLoadRawImage";
            this.btnLoadRawImage.Size = new System.Drawing.Size(228, 37);
            this.btnLoadRawImage.TabIndex = 1;
            this.btnLoadRawImage.Text = "Load Raw Image";
            this.btnLoadRawImage.UseVisualStyleBackColor = true;
            this.btnLoadRawImage.Click += new System.EventHandler(this.btnLoadRawImage_Click);
            // 
            // lblMaxPixel
            // 
            this.lblMaxPixel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaxPixel.AutoSize = true;
            this.lblMaxPixel.Location = new System.Drawing.Point(1064, 22);
            this.lblMaxPixel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxPixel.Name = "lblMaxPixel";
            this.lblMaxPixel.Size = new System.Drawing.Size(105, 25);
            this.lblMaxPixel.TabIndex = 3;
            this.lblMaxPixel.Text = "maxPixel:";
            // 
            // tbxMaxPixel
            // 
            this.tbxMaxPixel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxMaxPixel.Location = new System.Drawing.Point(1188, 17);
            this.tbxMaxPixel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbxMaxPixel.Name = "tbxMaxPixel";
            this.tbxMaxPixel.Size = new System.Drawing.Size(114, 31);
            this.tbxMaxPixel.TabIndex = 4;
            // 
            // lblMinPixel
            // 
            this.lblMinPixel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinPixel.AutoSize = true;
            this.lblMinPixel.Location = new System.Drawing.Point(1328, 22);
            this.lblMinPixel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinPixel.Name = "lblMinPixel";
            this.lblMinPixel.Size = new System.Drawing.Size(99, 25);
            this.lblMinPixel.TabIndex = 3;
            this.lblMinPixel.Text = "minPixel:";
            // 
            // tbxMinPixel
            // 
            this.tbxMinPixel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxMinPixel.Location = new System.Drawing.Point(1456, 17);
            this.tbxMinPixel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbxMinPixel.Name = "tbxMinPixel";
            this.tbxMinPixel.Size = new System.Drawing.Size(114, 31);
            this.tbxMinPixel.TabIndex = 4;
            // 
            // lblWin
            // 
            this.lblWin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWin.AutoSize = true;
            this.lblWin.Location = new System.Drawing.Point(612, 177);
            this.lblWin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWin.Name = "lblWin";
            this.lblWin.Size = new System.Drawing.Size(55, 25);
            this.lblWin.TabIndex = 3;
            this.lblWin.Text = "Win:";
            // 
            // tbxWin
            // 
            this.tbxWin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxWin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbxWin.Location = new System.Drawing.Point(680, 173);
            this.tbxWin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbxWin.Name = "tbxWin";
            this.tbxWin.ReadOnly = true;
            this.tbxWin.Size = new System.Drawing.Size(114, 31);
            this.tbxWin.TabIndex = 4;
            this.tbxWin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_KeyPress);
            // 
            // lblLev
            // 
            this.lblLev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLev.AutoSize = true;
            this.lblLev.Location = new System.Drawing.Point(804, 177);
            this.lblLev.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLev.Name = "lblLev";
            this.lblLev.Size = new System.Drawing.Size(53, 25);
            this.lblLev.TabIndex = 3;
            this.lblLev.Text = "Lev:";
            // 
            // tbxLev
            // 
            this.tbxLev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxLev.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbxLev.Location = new System.Drawing.Point(860, 173);
            this.tbxLev.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbxLev.Name = "tbxLev";
            this.tbxLev.ReadOnly = true;
            this.tbxLev.Size = new System.Drawing.Size(114, 31);
            this.tbxLev.TabIndex = 4;
            this.tbxLev.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_KeyPress);
            // 
            // hsbWin
            // 
            this.hsbWin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hsbWin.Location = new System.Drawing.Point(680, 253);
            this.hsbWin.Name = "hsbWin";
            this.hsbWin.Size = new System.Drawing.Size(868, 21);
            this.hsbWin.TabIndex = 5;
            this.hsbWin.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbWin_Scroll);
            // 
            // hsbLev
            // 
            this.hsbLev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hsbLev.Location = new System.Drawing.Point(680, 307);
            this.hsbLev.Name = "hsbLev";
            this.hsbLev.Size = new System.Drawing.Size(868, 21);
            this.hsbLev.TabIndex = 5;
            this.hsbLev.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbLev_Scroll);
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
            this.dbNewShape.Location = new System.Drawing.Point(1319, 477);
            this.dbNewShape.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.dbNewShape.Name = "dbNewShape";
            this.dbNewShape.Size = new System.Drawing.Size(238, 33);
            this.dbNewShape.TabIndex = 7;
            this.dbNewShape.SelectedIndexChanged += new System.EventHandler(this.dbNewShape_SelectedIndexChanged);
            // 
            // cbShowPixelMeasure
            // 
            this.cbShowPixelMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbShowPixelMeasure.AutoSize = true;
            this.cbShowPixelMeasure.Location = new System.Drawing.Point(1157, 483);
            this.cbShowPixelMeasure.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbShowPixelMeasure.Name = "cbShowPixelMeasure";
            this.cbShowPixelMeasure.Size = new System.Drawing.Size(152, 29);
            this.cbShowPixelMeasure.TabIndex = 8;
            this.cbShowPixelMeasure.Text = "Pixel Value";
            this.cbShowPixelMeasure.UseVisualStyleBackColor = true;
            this.cbShowPixelMeasure.CheckedChanged += new System.EventHandler(this.ShowPixelMeasure_CheckedChanged);
            // 
            // cbShowStatistics
            // 
            this.cbShowStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbShowStatistics.AutoSize = true;
            this.cbShowStatistics.Location = new System.Drawing.Point(1165, 528);
            this.cbShowStatistics.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbShowStatistics.Name = "cbShowStatistics";
            this.cbShowStatistics.Size = new System.Drawing.Size(131, 29);
            this.cbShowStatistics.TabIndex = 9;
            this.cbShowStatistics.Text = "Statistics";
            this.cbShowStatistics.UseVisualStyleBackColor = true;
            this.cbShowStatistics.CheckedChanged += new System.EventHandler(this.cbShowStatistics_CheckedChanged);
            // 
            // btnPrintROI
            // 
            this.btnPrintROI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintROI.Location = new System.Drawing.Point(953, 528);
            this.btnPrintROI.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnPrintROI.Name = "btnPrintROI";
            this.btnPrintROI.Size = new System.Drawing.Size(150, 47);
            this.btnPrintROI.TabIndex = 10;
            this.btnPrintROI.Text = "Print ROI";
            this.btnPrintROI.UseVisualStyleBackColor = true;
            this.btnPrintROI.Click += new System.EventHandler(this.btnPrintROI_Click);
            // 
            // btnTestCompound
            // 
            this.btnTestCompound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestCompound.Location = new System.Drawing.Point(618, 528);
            this.btnTestCompound.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnTestCompound.Name = "btnTestCompound";
            this.btnTestCompound.Size = new System.Drawing.Size(150, 47);
            this.btnTestCompound.TabIndex = 11;
            this.btnTestCompound.Text = "CompoundShape";
            this.btnTestCompound.UseVisualStyleBackColor = true;
            this.btnTestCompound.Click += new System.EventHandler(this.btnTestCompound_Click);
            // 
            // hsbAngle
            // 
            this.hsbAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hsbAngle.Location = new System.Drawing.Point(1091, 177);
            this.hsbAngle.Maximum = 90;
            this.hsbAngle.Minimum = -90;
            this.hsbAngle.Name = "hsbAngle";
            this.hsbAngle.Size = new System.Drawing.Size(328, 21);
            this.hsbAngle.TabIndex = 12;
            this.hsbAngle.ValueChanged += new System.EventHandler(this.hsbAngle_ValueChanged);
            // 
            // numRowSpacing
            // 
            this.numRowSpacing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numRowSpacing.Location = new System.Drawing.Point(1103, 387);
            this.numRowSpacing.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.numRowSpacing.Name = "numRowSpacing";
            this.numRowSpacing.Size = new System.Drawing.Size(126, 31);
            this.numRowSpacing.TabIndex = 13;
            this.numRowSpacing.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numRowSpacing.ValueChanged += new System.EventHandler(this.numRowSpacing_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(948, 393);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Row Spacing";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(656, 393);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Col Spacing";
            // 
            // numColSpacing
            // 
            this.numColSpacing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numColSpacing.Location = new System.Drawing.Point(812, 387);
            this.numColSpacing.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.numColSpacing.Name = "numColSpacing";
            this.numColSpacing.Size = new System.Drawing.Size(126, 31);
            this.numColSpacing.TabIndex = 15;
            this.numColSpacing.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numColSpacing.ValueChanged += new System.EventHandler(this.numColSpacing_ValueChanged);
            // 
            // btnUnload
            // 
            this.btnUnload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnload.Location = new System.Drawing.Point(611, 67);
            this.btnUnload.Name = "btnUnload";
            this.btnUnload.Size = new System.Drawing.Size(202, 43);
            this.btnUnload.TabIndex = 17;
            this.btnUnload.Text = "Unload";
            this.btnUnload.UseVisualStyleBackColor = true;
            this.btnUnload.Click += new System.EventHandler(this.btnUnload_Click);
            // 
            // cbPannable
            // 
            this.cbPannable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPannable.AutoSize = true;
            this.cbPannable.Location = new System.Drawing.Point(663, 477);
            this.cbPannable.Name = "cbPannable";
            this.cbPannable.Size = new System.Drawing.Size(135, 29);
            this.cbPannable.TabIndex = 18;
            this.cbPannable.Text = "Pannable";
            this.cbPannable.UseVisualStyleBackColor = true;
            this.cbPannable.CheckedChanged += new System.EventHandler(this.cbPannable_CheckedChanged);
            // 
            // cbZoomable
            // 
            this.cbZoomable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbZoomable.AutoSize = true;
            this.cbZoomable.Location = new System.Drawing.Point(825, 477);
            this.cbZoomable.Name = "cbZoomable";
            this.cbZoomable.Size = new System.Drawing.Size(139, 29);
            this.cbZoomable.TabIndex = 19;
            this.cbZoomable.Text = "Zoomable";
            this.cbZoomable.UseVisualStyleBackColor = true;
            this.cbZoomable.CheckedChanged += new System.EventHandler(this.cbZoomable_CheckedChanged);
            // 
            // btnRemoveSub
            // 
            this.btnRemoveSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveSub.Location = new System.Drawing.Point(788, 528);
            this.btnRemoveSub.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnRemoveSub.Name = "btnRemoveSub";
            this.btnRemoveSub.Size = new System.Drawing.Size(150, 47);
            this.btnRemoveSub.TabIndex = 20;
            this.btnRemoveSub.Text = "Remove Sub";
            this.btnRemoveSub.UseVisualStyleBackColor = true;
            this.btnRemoveSub.Click += new System.EventHandler(this.btnRemoveSub_Click);
            // 
            // btnLineText
            // 
            this.btnLineText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLineText.Location = new System.Drawing.Point(618, 602);
            this.btnLineText.Name = "btnLineText";
            this.btnLineText.Size = new System.Drawing.Size(150, 51);
            this.btnLineText.TabIndex = 21;
            this.btnLineText.Text = "LineText";
            this.btnLineText.UseVisualStyleBackColor = true;
            this.btnLineText.Click += new System.EventHandler(this.btnLineText_Click);
            // 
            // vbxImage
            // 
            this.vbxImage.AccelModeScale = 3;
            this.vbxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vbxImage.ColSpacing = 1F;
            this.vbxImage.FovCol = 0D;
            this.vbxImage.FovRow = 0D;
            this.vbxImage.GrayLevelData = null;
            this.vbxImage.Image = ((System.Drawing.Image)(resources.GetObject("vbxImage.Image")));
            this.vbxImage.Lev = ((short)(0));
            this.vbxImage.Location = new System.Drawing.Point(18, 22);
            this.vbxImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.vbxImage.MouseOpMode = ViewBoxContorl.ViewBoxForm.MouseOps.None;
            this.vbxImage.Name = "vbxImage";
            this.vbxImage.NoCol = 0;
            this.vbxImage.NoRow = 0;
            this.vbxImage.Pannable = false;
            this.vbxImage.PanPosition = ((System.Drawing.PointF)(resources.GetObject("vbxImage.PanPosition")));
            this.vbxImage.PixelData = null;
            this.vbxImage.RowSpacing = 1F;
            this.vbxImage.SampleRect = new System.Drawing.Rectangle(-161, -205, 322, 410);
            this.vbxImage.ShowPixelValue = false;
            this.vbxImage.ShowStatistics = false;
            this.vbxImage.Size = new System.Drawing.Size(520, 1011);
            this.vbxImage.TabIndex = 0;
            this.vbxImage.TabStop = false;
            this.vbxImage.Win = ((short)(1));
            this.vbxImage.Zoomable = true;
            this.vbxImage.ZoomFactor = 1F;
            this.vbxImage.SizeChanged += new System.EventHandler(this.vbxImage_SizeChanged);
            this.vbxImage.VisibleChanged += new System.EventHandler(this.vbxImage_VisibleChanged);
            this.vbxImage.Click += new System.EventHandler(this.vbxImage_Click);
            this.vbxImage.Paint += new System.Windows.Forms.PaintEventHandler(this.vbxImage_Paint);
            this.vbxImage.Resize += new System.EventHandler(this.vbxImage_Resize);
            // 
            // testViewBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 1056);
            this.Controls.Add(this.btnLineText);
            this.Controls.Add(this.btnRemoveSub);
            this.Controls.Add(this.cbZoomable);
            this.Controls.Add(this.cbPannable);
            this.Controls.Add(this.btnUnload);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numColSpacing);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numRowSpacing);
            this.Controls.Add(this.hsbAngle);
            this.Controls.Add(this.btnTestCompound);
            this.Controls.Add(this.btnPrintROI);
            this.Controls.Add(this.cbShowStatistics);
            this.Controls.Add(this.cbShowPixelMeasure);
            this.Controls.Add(this.dbNewShape);
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
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "testViewBox";
            this.Text = "Test ViewBox";
            this.Load += new System.EventHandler(this.testViewBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRowSpacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColSpacing)).EndInit();
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
        private System.Windows.Forms.ComboBox dbNewShape;
        private System.Windows.Forms.CheckBox cbShowPixelMeasure;
        private System.Windows.Forms.CheckBox cbShowStatistics;
        private System.Windows.Forms.Button btnPrintROI;
        private System.Windows.Forms.Button btnTestCompound;
        private System.Windows.Forms.HScrollBar hsbAngle;
        private System.Windows.Forms.NumericUpDown numRowSpacing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numColSpacing;
        private System.Windows.Forms.Button btnUnload;
        private System.Windows.Forms.CheckBox cbPannable;
        private System.Windows.Forms.CheckBox cbZoomable;
        private System.Windows.Forms.Button btnRemoveSub;
        private System.Windows.Forms.Button btnLineText;
    }
}

