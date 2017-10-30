namespace multiViewBox
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlToolsUp = new System.Windows.Forms.Panel();
            this.cbxShowPixelValue = new System.Windows.Forms.CheckBox();
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLev = new System.Windows.Forms.Label();
            this.lblWin = new System.Windows.Forms.Label();
            this.tbxLev = new System.Windows.Forms.TextBox();
            this.tbxWin = new System.Windows.Forms.TextBox();
            this.tbxMinPixel = new System.Windows.Forms.TextBox();
            this.lblMinPixel = new System.Windows.Forms.Label();
            this.tbxMaxPixel = new System.Windows.Forms.TextBox();
            this.lblMaxPixel = new System.Windows.Forms.Label();
            this.vsbWin = new System.Windows.Forms.VScrollBar();
            this.vsbLev = new System.Windows.Forms.VScrollBar();
            this.gbxMouseFunc = new System.Windows.Forms.GroupBox();
            this.rbtMouseFuncLine = new System.Windows.Forms.RadioButton();
            this.rbtMouseFuncRect = new System.Windows.Forms.RadioButton();
            this.rbtMouseFuncEllipse = new System.Windows.Forms.RadioButton();
            this.rbtMouseFuncNone = new System.Windows.Forms.RadioButton();
            this.btnOpenTest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlImages = new System.Windows.Forms.Panel();
            this.tplImages = new System.Windows.Forms.TableLayoutPanel();
            this.btn1X1 = new System.Windows.Forms.Button();
            this.btn2X2 = new System.Windows.Forms.Button();
            this.btn3X3 = new System.Windows.Forms.Button();
            this.btnSaveDicom = new System.Windows.Forms.Button();
            this.tplImageIcon = new System.Windows.Forms.TableLayoutPanel();
            this.pnlToolsUp.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbxMouseFunc.SuspendLayout();
            this.pnlImages.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlToolsUp
            // 
            this.pnlToolsUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlToolsUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlToolsUp.Controls.Add(this.cbxShowPixelValue);
            this.pnlToolsUp.Location = new System.Drawing.Point(858, 4);
            this.pnlToolsUp.Name = "pnlToolsUp";
            this.pnlToolsUp.Size = new System.Drawing.Size(182, 93);
            this.pnlToolsUp.TabIndex = 1;
            // 
            // cbxShowPixelValue
            // 
            this.cbxShowPixelValue.AutoSize = true;
            this.cbxShowPixelValue.Location = new System.Drawing.Point(14, 10);
            this.cbxShowPixelValue.Name = "cbxShowPixelValue";
            this.cbxShowPixelValue.Size = new System.Drawing.Size(157, 19);
            this.cbxShowPixelValue.TabIndex = 0;
            this.cbxShowPixelValue.Text = "Show Pixel Value";
            this.cbxShowPixelValue.UseVisualStyleBackColor = true;
            this.cbxShowPixelValue.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Location = new System.Drawing.Point(12, 12);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(121, 23);
            this.btnOpenImage.TabIndex = 3;
            this.btnOpenImage.Text = "Open Image";
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblLev);
            this.panel1.Controls.Add(this.lblWin);
            this.panel1.Controls.Add(this.tbxLev);
            this.panel1.Controls.Add(this.tbxWin);
            this.panel1.Controls.Add(this.tbxMinPixel);
            this.panel1.Controls.Add(this.lblMinPixel);
            this.panel1.Controls.Add(this.tbxMaxPixel);
            this.panel1.Controls.Add(this.lblMaxPixel);
            this.panel1.Controls.Add(this.vsbWin);
            this.panel1.Controls.Add(this.vsbLev);
            this.panel1.Controls.Add(this.gbxMouseFunc);
            this.panel1.Location = new System.Drawing.Point(858, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 595);
            this.panel1.TabIndex = 1;
            // 
            // lblLev
            // 
            this.lblLev.AutoSize = true;
            this.lblLev.Location = new System.Drawing.Point(51, 324);
            this.lblLev.Name = "lblLev";
            this.lblLev.Size = new System.Drawing.Size(39, 15);
            this.lblLev.TabIndex = 6;
            this.lblLev.Text = "Lev:";
            this.lblLev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWin
            // 
            this.lblWin.AutoSize = true;
            this.lblWin.Location = new System.Drawing.Point(51, 295);
            this.lblWin.Name = "lblWin";
            this.lblWin.Size = new System.Drawing.Size(39, 15);
            this.lblWin.TabIndex = 5;
            this.lblWin.Text = "Win:";
            this.lblWin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxLev
            // 
            this.tbxLev.Location = new System.Drawing.Point(91, 321);
            this.tbxLev.Name = "tbxLev";
            this.tbxLev.Size = new System.Drawing.Size(80, 25);
            this.tbxLev.TabIndex = 3;
            // 
            // tbxWin
            // 
            this.tbxWin.Location = new System.Drawing.Point(91, 290);
            this.tbxWin.Name = "tbxWin";
            this.tbxWin.Size = new System.Drawing.Size(80, 25);
            this.tbxWin.TabIndex = 3;
            // 
            // tbxMinPixel
            // 
            this.tbxMinPixel.Location = new System.Drawing.Point(91, 259);
            this.tbxMinPixel.Name = "tbxMinPixel";
            this.tbxMinPixel.Size = new System.Drawing.Size(80, 25);
            this.tbxMinPixel.TabIndex = 3;
            // 
            // lblMinPixel
            // 
            this.lblMinPixel.AutoSize = true;
            this.lblMinPixel.Location = new System.Drawing.Point(3, 262);
            this.lblMinPixel.Name = "lblMinPixel";
            this.lblMinPixel.Size = new System.Drawing.Size(87, 15);
            this.lblMinPixel.TabIndex = 4;
            this.lblMinPixel.Text = "Min Pixel:";
            // 
            // tbxMaxPixel
            // 
            this.tbxMaxPixel.Location = new System.Drawing.Point(91, 224);
            this.tbxMaxPixel.Name = "tbxMaxPixel";
            this.tbxMaxPixel.Size = new System.Drawing.Size(80, 25);
            this.tbxMaxPixel.TabIndex = 3;
            // 
            // lblMaxPixel
            // 
            this.lblMaxPixel.AutoSize = true;
            this.lblMaxPixel.Location = new System.Drawing.Point(3, 227);
            this.lblMaxPixel.Name = "lblMaxPixel";
            this.lblMaxPixel.Size = new System.Drawing.Size(87, 15);
            this.lblMaxPixel.TabIndex = 2;
            this.lblMaxPixel.Text = "Max Pixel:";
            // 
            // vsbWin
            // 
            this.vsbWin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vsbWin.Location = new System.Drawing.Point(119, 365);
            this.vsbWin.Name = "vsbWin";
            this.vsbWin.Size = new System.Drawing.Size(22, 223);
            this.vsbWin.TabIndex = 1;
            // 
            // vsbLev
            // 
            this.vsbLev.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vsbLev.Location = new System.Drawing.Point(36, 365);
            this.vsbLev.Name = "vsbLev";
            this.vsbLev.Size = new System.Drawing.Size(22, 223);
            this.vsbLev.TabIndex = 1;
            // 
            // gbxMouseFunc
            // 
            this.gbxMouseFunc.Controls.Add(this.rbtMouseFuncLine);
            this.gbxMouseFunc.Controls.Add(this.rbtMouseFuncRect);
            this.gbxMouseFunc.Controls.Add(this.rbtMouseFuncEllipse);
            this.gbxMouseFunc.Controls.Add(this.rbtMouseFuncNone);
            this.gbxMouseFunc.Location = new System.Drawing.Point(3, 13);
            this.gbxMouseFunc.Name = "gbxMouseFunc";
            this.gbxMouseFunc.Size = new System.Drawing.Size(174, 137);
            this.gbxMouseFunc.TabIndex = 0;
            this.gbxMouseFunc.TabStop = false;
            this.gbxMouseFunc.Text = "groupBox1";
            // 
            // rbtMouseFuncLine
            // 
            this.rbtMouseFuncLine.AutoSize = true;
            this.rbtMouseFuncLine.Location = new System.Drawing.Point(11, 103);
            this.rbtMouseFuncLine.Name = "rbtMouseFuncLine";
            this.rbtMouseFuncLine.Size = new System.Drawing.Size(60, 19);
            this.rbtMouseFuncLine.TabIndex = 3;
            this.rbtMouseFuncLine.Text = "Line";
            this.rbtMouseFuncLine.UseVisualStyleBackColor = true;
            this.rbtMouseFuncLine.CheckedChanged += new System.EventHandler(this.rbtMouseFunc_CheckedChanged);
            // 
            // rbtMouseFuncRect
            // 
            this.rbtMouseFuncRect.AutoSize = true;
            this.rbtMouseFuncRect.Location = new System.Drawing.Point(11, 77);
            this.rbtMouseFuncRect.Name = "rbtMouseFuncRect";
            this.rbtMouseFuncRect.Size = new System.Drawing.Size(116, 19);
            this.rbtMouseFuncRect.TabIndex = 2;
            this.rbtMouseFuncRect.Text = "Rectangular";
            this.rbtMouseFuncRect.UseVisualStyleBackColor = true;
            this.rbtMouseFuncRect.CheckedChanged += new System.EventHandler(this.rbtMouseFunc_CheckedChanged);
            // 
            // rbtMouseFuncEllipse
            // 
            this.rbtMouseFuncEllipse.AutoSize = true;
            this.rbtMouseFuncEllipse.Location = new System.Drawing.Point(11, 51);
            this.rbtMouseFuncEllipse.Name = "rbtMouseFuncEllipse";
            this.rbtMouseFuncEllipse.Size = new System.Drawing.Size(84, 19);
            this.rbtMouseFuncEllipse.TabIndex = 1;
            this.rbtMouseFuncEllipse.Text = "Ellipse";
            this.rbtMouseFuncEllipse.UseVisualStyleBackColor = true;
            this.rbtMouseFuncEllipse.CheckedChanged += new System.EventHandler(this.rbtMouseFunc_CheckedChanged);
            // 
            // rbtMouseFuncNone
            // 
            this.rbtMouseFuncNone.AutoSize = true;
            this.rbtMouseFuncNone.Checked = true;
            this.rbtMouseFuncNone.Location = new System.Drawing.Point(11, 25);
            this.rbtMouseFuncNone.Name = "rbtMouseFuncNone";
            this.rbtMouseFuncNone.Size = new System.Drawing.Size(60, 19);
            this.rbtMouseFuncNone.TabIndex = 0;
            this.rbtMouseFuncNone.TabStop = true;
            this.rbtMouseFuncNone.Text = "None";
            this.rbtMouseFuncNone.UseVisualStyleBackColor = true;
            this.rbtMouseFuncNone.CheckedChanged += new System.EventHandler(this.rbtMouseFunc_CheckedChanged);
            // 
            // btnOpenTest
            // 
            this.btnOpenTest.Location = new System.Drawing.Point(140, 12);
            this.btnOpenTest.Name = "btnOpenTest";
            this.btnOpenTest.Size = new System.Drawing.Size(119, 23);
            this.btnOpenTest.TabIndex = 4;
            this.btnOpenTest.Text = "Open Test";
            this.btnOpenTest.UseVisualStyleBackColor = true;
            this.btnOpenTest.Click += new System.EventHandler(this.btnOpenTest_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(265, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlImages
            // 
            this.pnlImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlImages.Controls.Add(this.tplImages);
            this.pnlImages.Location = new System.Drawing.Point(2, 63);
            this.pnlImages.Name = "pnlImages";
            this.pnlImages.Size = new System.Drawing.Size(594, 635);
            this.pnlImages.TabIndex = 6;
            // 
            // tplImages
            // 
            this.tplImages.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tplImages.ColumnCount = 1;
            this.tplImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tplImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tplImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tplImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tplImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplImages.Location = new System.Drawing.Point(0, 0);
            this.tplImages.Name = "tplImages";
            this.tplImages.RowCount = 1;
            this.tplImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplImages.Size = new System.Drawing.Size(592, 633);
            this.tplImages.TabIndex = 0;
            // 
            // btn1X1
            // 
            this.btn1X1.Location = new System.Drawing.Point(346, 11);
            this.btn1X1.Name = "btn1X1";
            this.btn1X1.Size = new System.Drawing.Size(75, 23);
            this.btn1X1.TabIndex = 7;
            this.btn1X1.Text = "1X1";
            this.btn1X1.UseVisualStyleBackColor = true;
            this.btn1X1.Click += new System.EventHandler(this.btn1X1_Click);
            // 
            // btn2X2
            // 
            this.btn2X2.Location = new System.Drawing.Point(428, 11);
            this.btn2X2.Name = "btn2X2";
            this.btn2X2.Size = new System.Drawing.Size(75, 23);
            this.btn2X2.TabIndex = 8;
            this.btn2X2.Text = "2X2";
            this.btn2X2.UseVisualStyleBackColor = true;
            this.btn2X2.Click += new System.EventHandler(this.btn2X2_Click);
            // 
            // btn3X3
            // 
            this.btn3X3.Location = new System.Drawing.Point(509, 11);
            this.btn3X3.Name = "btn3X3";
            this.btn3X3.Size = new System.Drawing.Size(75, 23);
            this.btn3X3.TabIndex = 9;
            this.btn3X3.Text = "3X3";
            this.btn3X3.UseVisualStyleBackColor = true;
            this.btn3X3.Click += new System.EventHandler(this.btn3X3_Click);
            // 
            // btnSaveDicom
            // 
            this.btnSaveDicom.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnSaveDicom.Location = new System.Drawing.Point(645, 12);
            this.btnSaveDicom.Name = "btnSaveDicom";
            this.btnSaveDicom.Size = new System.Drawing.Size(129, 23);
            this.btnSaveDicom.TabIndex = 10;
            this.btnSaveDicom.Text = "Save to Dicom";
            this.btnSaveDicom.UseVisualStyleBackColor = true;
            this.btnSaveDicom.Click += new System.EventHandler(this.btnSaveDicom_Click);
            // 
            // tplImageIcon
            // 
            this.tplImageIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tplImageIcon.AutoScroll = true;
            this.tplImageIcon.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tplImageIcon.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tplImageIcon.ColumnCount = 1;
            this.tplImageIcon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplImageIcon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tplImageIcon.Location = new System.Drawing.Point(656, 63);
            this.tplImageIcon.Name = "tplImageIcon";
            this.tplImageIcon.RowCount = 1;
            this.tplImageIcon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tplImageIcon.Size = new System.Drawing.Size(200, 635);
            this.tplImageIcon.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 701);
            this.Controls.Add(this.tplImageIcon);
            this.Controls.Add(this.btnSaveDicom);
            this.Controls.Add(this.btn3X3);
            this.Controls.Add(this.btn2X2);
            this.Controls.Add(this.btn1X1);
            this.Controls.Add(this.pnlImages);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOpenTest);
            this.Controls.Add(this.btnOpenImage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlToolsUp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.pnlToolsUp.ResumeLayout(false);
            this.pnlToolsUp.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbxMouseFunc.ResumeLayout(false);
            this.gbxMouseFunc.PerformLayout();
            this.pnlImages.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlToolsUp;
        private System.Windows.Forms.Button btnOpenImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOpenTest;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlImages;
        private System.Windows.Forms.TableLayoutPanel tplImages;
        private System.Windows.Forms.CheckBox cbxShowPixelValue;
        private System.Windows.Forms.Button btn1X1;
        private System.Windows.Forms.Button btn2X2;
        private System.Windows.Forms.Button btn3X3;
        private System.Windows.Forms.GroupBox gbxMouseFunc;
        private System.Windows.Forms.RadioButton rbtMouseFuncLine;
        private System.Windows.Forms.RadioButton rbtMouseFuncRect;
        private System.Windows.Forms.RadioButton rbtMouseFuncEllipse;
        private System.Windows.Forms.RadioButton rbtMouseFuncNone;
        private System.Windows.Forms.VScrollBar vsbLev;
        private System.Windows.Forms.VScrollBar vsbWin;
        private System.Windows.Forms.TextBox tbxMaxPixel;
        private System.Windows.Forms.Label lblMaxPixel;
        private System.Windows.Forms.Label lblLev;
        private System.Windows.Forms.Label lblWin;
        private System.Windows.Forms.TextBox tbxLev;
        private System.Windows.Forms.TextBox tbxWin;
        private System.Windows.Forms.TextBox tbxMinPixel;
        private System.Windows.Forms.Label lblMinPixel;
        private System.Windows.Forms.Button btnSaveDicom;
        private System.Windows.Forms.TableLayoutPanel tplImageIcon;
    }
}

