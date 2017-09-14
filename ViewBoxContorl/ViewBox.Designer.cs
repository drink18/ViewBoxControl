namespace ViewBoxContorl
{
    partial class ViewBox
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
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ViewBox
            // 
            this.ClientSizeChanged += new System.EventHandler(this.ViewBox_ClientSizeChanged);
            this.SizeChanged += new System.EventHandler(this.ViewBox_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.ViewBox_VisibleChanged);
            this.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.OnMouseDrag);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewBox_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vbxImage_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.vbxImg_MouseMove);
            this.Resize += new System.EventHandler(this.ViewBox_Resize);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
