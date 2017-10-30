namespace multiViewBox
{
    partial class FormLowLevelImageViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLowLevelImageViewer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.gbxKSpaceFormat = new System.Windows.Forms.GroupBox();
            this.rbtKSpaceImag = new System.Windows.Forms.RadioButton();
            this.rbtKSpaceReal = new System.Windows.Forms.RadioButton();
            this.rbtKSpacePhase = new System.Windows.Forms.RadioButton();
            this.rbtKSpaceAbsLinear = new System.Windows.Forms.RadioButton();
            this.rbtKSpaceAbsLog = new System.Windows.Forms.RadioButton();
            this.gbxImageFormat = new System.Windows.Forms.GroupBox();
            this.rbtImageImag = new System.Windows.Forms.RadioButton();
            this.rbtImageReal = new System.Windows.Forms.RadioButton();
            this.rbtImageAbs = new System.Windows.Forms.RadioButton();
            this.rbtImagePhase = new System.Windows.Forms.RadioButton();
            this.pnlLowLevelImage = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.gbxKSpaceFormat.SuspendLayout();
            this.gbxImageFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1017, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // gbxKSpaceFormat
            // 
            this.gbxKSpaceFormat.Controls.Add(this.rbtKSpaceImag);
            this.gbxKSpaceFormat.Controls.Add(this.rbtKSpaceReal);
            this.gbxKSpaceFormat.Controls.Add(this.rbtKSpacePhase);
            this.gbxKSpaceFormat.Controls.Add(this.rbtKSpaceAbsLinear);
            this.gbxKSpaceFormat.Controls.Add(this.rbtKSpaceAbsLog);
            this.gbxKSpaceFormat.Location = new System.Drawing.Point(18, 37);
            this.gbxKSpaceFormat.Name = "gbxKSpaceFormat";
            this.gbxKSpaceFormat.Size = new System.Drawing.Size(485, 96);
            this.gbxKSpaceFormat.TabIndex = 1;
            this.gbxKSpaceFormat.TabStop = false;
            this.gbxKSpaceFormat.Text = "K Space Format";
            // 
            // rbtKSpaceImag
            // 
            this.rbtKSpaceImag.AutoSize = true;
            this.rbtKSpaceImag.Location = new System.Drawing.Point(361, 25);
            this.rbtKSpaceImag.Name = "rbtKSpaceImag";
            this.rbtKSpaceImag.Size = new System.Drawing.Size(60, 19);
            this.rbtKSpaceImag.TabIndex = 1;
            this.rbtKSpaceImag.TabStop = true;
            this.rbtKSpaceImag.Text = "Imag";
            this.rbtKSpaceImag.UseVisualStyleBackColor = true;
            // 
            // rbtKSpaceReal
            // 
            this.rbtKSpaceReal.AutoSize = true;
            this.rbtKSpaceReal.Location = new System.Drawing.Point(285, 25);
            this.rbtKSpaceReal.Name = "rbtKSpaceReal";
            this.rbtKSpaceReal.Size = new System.Drawing.Size(60, 19);
            this.rbtKSpaceReal.TabIndex = 1;
            this.rbtKSpaceReal.TabStop = true;
            this.rbtKSpaceReal.Text = "Real";
            this.rbtKSpaceReal.UseVisualStyleBackColor = true;
            // 
            // rbtKSpacePhase
            // 
            this.rbtKSpacePhase.AutoSize = true;
            this.rbtKSpacePhase.Location = new System.Drawing.Point(211, 25);
            this.rbtKSpacePhase.Name = "rbtKSpacePhase";
            this.rbtKSpacePhase.Size = new System.Drawing.Size(68, 19);
            this.rbtKSpacePhase.TabIndex = 1;
            this.rbtKSpacePhase.TabStop = true;
            this.rbtKSpacePhase.Text = "Phase";
            this.rbtKSpacePhase.UseVisualStyleBackColor = true;
            // 
            // rbtKSpaceAbsLinear
            // 
            this.rbtKSpaceAbsLinear.AutoSize = true;
            this.rbtKSpaceAbsLinear.Location = new System.Drawing.Point(96, 25);
            this.rbtKSpaceAbsLinear.Name = "rbtKSpaceAbsLinear";
            this.rbtKSpaceAbsLinear.Size = new System.Drawing.Size(108, 19);
            this.rbtKSpaceAbsLinear.TabIndex = 0;
            this.rbtKSpaceAbsLinear.Text = "Abs Linear";
            this.rbtKSpaceAbsLinear.UseVisualStyleBackColor = true;
            // 
            // rbtKSpaceAbsLog
            // 
            this.rbtKSpaceAbsLog.AutoSize = true;
            this.rbtKSpaceAbsLog.Checked = true;
            this.rbtKSpaceAbsLog.Location = new System.Drawing.Point(6, 25);
            this.rbtKSpaceAbsLog.Name = "rbtKSpaceAbsLog";
            this.rbtKSpaceAbsLog.Size = new System.Drawing.Size(84, 19);
            this.rbtKSpaceAbsLog.TabIndex = 0;
            this.rbtKSpaceAbsLog.TabStop = true;
            this.rbtKSpaceAbsLog.Text = "Abs Log";
            this.rbtKSpaceAbsLog.UseVisualStyleBackColor = true;
            // 
            // gbxImageFormat
            // 
            this.gbxImageFormat.Controls.Add(this.rbtImageImag);
            this.gbxImageFormat.Controls.Add(this.rbtImageReal);
            this.gbxImageFormat.Controls.Add(this.rbtImageAbs);
            this.gbxImageFormat.Controls.Add(this.rbtImagePhase);
            this.gbxImageFormat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbxImageFormat.Location = new System.Drawing.Point(509, 37);
            this.gbxImageFormat.Name = "gbxImageFormat";
            this.gbxImageFormat.Size = new System.Drawing.Size(485, 96);
            this.gbxImageFormat.TabIndex = 1;
            this.gbxImageFormat.TabStop = false;
            this.gbxImageFormat.Text = "Image Format";
            // 
            // rbtImageImag
            // 
            this.rbtImageImag.AutoSize = true;
            this.rbtImageImag.Location = new System.Drawing.Point(314, 25);
            this.rbtImageImag.Name = "rbtImageImag";
            this.rbtImageImag.Size = new System.Drawing.Size(60, 19);
            this.rbtImageImag.TabIndex = 1;
            this.rbtImageImag.Text = "Imag";
            this.rbtImageImag.UseVisualStyleBackColor = true;
            // 
            // rbtImageReal
            // 
            this.rbtImageReal.AutoSize = true;
            this.rbtImageReal.Location = new System.Drawing.Point(238, 25);
            this.rbtImageReal.Name = "rbtImageReal";
            this.rbtImageReal.Size = new System.Drawing.Size(60, 19);
            this.rbtImageReal.TabIndex = 1;
            this.rbtImageReal.Text = "Real";
            this.rbtImageReal.UseVisualStyleBackColor = true;
            // 
            // rbtImageAbs
            // 
            this.rbtImageAbs.AutoSize = true;
            this.rbtImageAbs.Checked = true;
            this.rbtImageAbs.Location = new System.Drawing.Point(49, 25);
            this.rbtImageAbs.Name = "rbtImageAbs";
            this.rbtImageAbs.Size = new System.Drawing.Size(52, 19);
            this.rbtImageAbs.TabIndex = 0;
            this.rbtImageAbs.TabStop = true;
            this.rbtImageAbs.Text = "Abs";
            this.rbtImageAbs.UseVisualStyleBackColor = true;
            // 
            // rbtImagePhase
            // 
            this.rbtImagePhase.AutoSize = true;
            this.rbtImagePhase.Location = new System.Drawing.Point(140, 25);
            this.rbtImagePhase.Name = "rbtImagePhase";
            this.rbtImagePhase.Size = new System.Drawing.Size(68, 19);
            this.rbtImagePhase.TabIndex = 1;
            this.rbtImagePhase.Text = "Phase";
            this.rbtImagePhase.UseVisualStyleBackColor = true;
            // 
            // pnlLowLevelImage
            // 
            this.pnlLowLevelImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLowLevelImage.AutoScroll = true;
            this.pnlLowLevelImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLowLevelImage.Location = new System.Drawing.Point(0, 139);
            this.pnlLowLevelImage.Name = "pnlLowLevelImage";
            this.pnlLowLevelImage.Size = new System.Drawing.Size(1017, 343);
            this.pnlLowLevelImage.TabIndex = 2;
            // 
            // FormLowLevelImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 485);
            this.Controls.Add(this.pnlLowLevelImage);
            this.Controls.Add(this.gbxImageFormat);
            this.Controls.Add(this.gbxKSpaceFormat);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormLowLevelImageViewer";
            this.Text = "FormLowLevelImageViewer";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbxKSpaceFormat.ResumeLayout(false);
            this.gbxKSpaceFormat.PerformLayout();
            this.gbxImageFormat.ResumeLayout(false);
            this.gbxImageFormat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox gbxKSpaceFormat;
        private System.Windows.Forms.GroupBox gbxImageFormat;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.RadioButton rbtKSpaceImag;
        private System.Windows.Forms.RadioButton rbtKSpaceReal;
        private System.Windows.Forms.RadioButton rbtKSpacePhase;
        private System.Windows.Forms.RadioButton rbtKSpaceAbsLinear;
        private System.Windows.Forms.RadioButton rbtKSpaceAbsLog;
        private System.Windows.Forms.RadioButton rbtImageImag;
        private System.Windows.Forms.RadioButton rbtImageReal;
        private System.Windows.Forms.RadioButton rbtImageAbs;
        private System.Windows.Forms.RadioButton rbtImagePhase;
        private System.Windows.Forms.Panel pnlLowLevelImage;
    }
}