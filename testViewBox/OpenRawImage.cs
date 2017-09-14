using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testViewBox
{
    public partial class OpenRawImage : Form
    {
        #region NoCol
        int noCol;

        public int NoCol
        {
            get { return noCol; }
            set { noCol = value; }
        }
        #endregion
        #region NoRow
        int noRow;

        public int NoRow
        {
            get { return noRow; }
            set { noRow = value; }
        }
        #endregion
        #region FileName
        string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        #endregion
        #region MyRegion
        string defaultRawImagePath = @".\";
        #endregion

        public OpenRawImage()
        {
            InitializeComponent();
            btnOK.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            NoCol = int.Parse(tbxNoCol.Text);
            NoRow = int.Parse(tbxNoRow.Text);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = defaultRawImagePath;
            ofd.Filter = "raw mri image|*.img";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                long fileLen = fi.Length;
                if (NoRow * NoCol * 2 != fileLen)
                {
                    MessageBox.Show("wrong file size!");
                    return;
                }
                    FileName = ofd.FileName;
                    tbxFileName.Text = FileName;
            }
        }

        private void tbxFileName_TextChanged(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == null)
            {
                btnOK.Enabled = false;
            }
            else
            {
                btnOK.Enabled = true;
            }
        }
    }
}
