namespace testViewBox
{
    partial class OpenRawImage
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
            this.lblNoRow = new System.Windows.Forms.Label();
            this.tbxNoRow = new System.Windows.Forms.TextBox();
            this.lblNoCol = new System.Windows.Forms.Label();
            this.tbxNoCol = new System.Windows.Forms.TextBox();
            this.tbxFileName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNoRow
            // 
            this.lblNoRow.AutoSize = true;
            this.lblNoRow.Location = new System.Drawing.Point(29, 13);
            this.lblNoRow.Name = "lblNoRow";
            this.lblNoRow.Size = new System.Drawing.Size(55, 15);
            this.lblNoRow.TabIndex = 0;
            this.lblNoRow.Text = "noRow:";
            // 
            // tbxNoRow
            // 
            this.tbxNoRow.Location = new System.Drawing.Point(90, 10);
            this.tbxNoRow.Name = "tbxNoRow";
            this.tbxNoRow.Size = new System.Drawing.Size(68, 25);
            this.tbxNoRow.TabIndex = 1;
            this.tbxNoRow.Text = "256";
            // 
            // lblNoCol
            // 
            this.lblNoCol.AutoSize = true;
            this.lblNoCol.Location = new System.Drawing.Point(178, 16);
            this.lblNoCol.Name = "lblNoCol";
            this.lblNoCol.Size = new System.Drawing.Size(55, 15);
            this.lblNoCol.TabIndex = 0;
            this.lblNoCol.Text = "noCol:";
            // 
            // tbxNoCol
            // 
            this.tbxNoCol.Location = new System.Drawing.Point(239, 13);
            this.tbxNoCol.Name = "tbxNoCol";
            this.tbxNoCol.Size = new System.Drawing.Size(68, 25);
            this.tbxNoCol.TabIndex = 1;
            this.tbxNoCol.Text = "256";
            // 
            // tbxFileName
            // 
            this.tbxFileName.Location = new System.Drawing.Point(117, 44);
            this.tbxFileName.Name = "tbxFileName";
            this.tbxFileName.Size = new System.Drawing.Size(686, 25);
            this.tbxFileName.TabIndex = 3;
            this.tbxFileName.TextChanged += new System.EventHandler(this.tbxFileName_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(138, 97);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(300, 97);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(13, 45);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(98, 23);
            this.btnOpenFile.TabIndex = 5;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // OpenRawImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 152);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbxFileName);
            this.Controls.Add(this.tbxNoCol);
            this.Controls.Add(this.lblNoCol);
            this.Controls.Add(this.tbxNoRow);
            this.Controls.Add(this.lblNoRow);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenRawImage";
            this.Text = "Open Raw Image";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNoRow;
        private System.Windows.Forms.TextBox tbxNoRow;
        private System.Windows.Forms.Label lblNoCol;
        private System.Windows.Forms.TextBox tbxNoCol;
        private System.Windows.Forms.TextBox tbxFileName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOpenFile;
    }
}