namespace ViewBoxContorl
{
    partial class ViewBoxForm
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.View = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // View
            // 
            this.View.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.View.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.View.Location = new System.Drawing.Point(0, 0);
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(313, 288);
            this.View.TabIndex = 0;
            this.View.UseVisualStyleBackColor = true;
            this.View.Paint += new System.Windows.Forms.PaintEventHandler(this.img_OnPaint);
            this.View.KeyDown += new System.Windows.Forms.KeyEventHandler(this.View_KeyDown);
            this.View.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vbxImage_MouseDown);
            this.View.MouseMove += new System.Windows.Forms.MouseEventHandler(this.View_MouseMove);
            this.View.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vbxImg_MouseUp);
            // 
            // ViewBoxForm
            // 
            this.Controls.Add(this.View);
            this.Name = "ViewBoxForm";
            this.Size = new System.Drawing.Size(313, 288);
            this.ClientSizeChanged += new System.EventHandler(this.ViewBox_ClientSizeChanged);
            this.SizeChanged += new System.EventHandler(this.ViewBox_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.ViewBox_VisibleChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vbxImage_MouseDown);
            this.Resize += new System.EventHandler(this.ViewBox_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button View;
    }
}
