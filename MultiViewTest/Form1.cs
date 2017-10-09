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

namespace MultiViewTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var vbxImages = new ViewBoxContorl.ViewBoxForm[] { vb1, vb2, vb3, vb4 };
            foreach (var vbxImg in vbxImages)
            {
                vbxImg.ShowPixelValue = true;
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            var NoCol = 256; // int.Parse(tbxNoCol.Text);
            var NoRow = 256; // int.Parse(tbxNoRow.Text);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"";
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

                var FileName = ofd.FileName;

                using (FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read))
                {
                    byte[] rawData = new byte[2 * NoCol * NoRow];
                    fs.Read(rawData, 0, rawData.Length);
                    var vbxImages = new ViewBoxContorl.ViewBoxForm[] { vb1, vb2, vb3, vb4 };
                    foreach (var vbxImage in vbxImages)
                    {
                        vbxImage.NoCol = NoCol;
                        vbxImage.NoRow = NoRow;
                        vbxImage.ResetObserverRect();
                        vbxImage.readPixelData(rawData);
                        vbxImage.setGrayLevelData();
                    }
                }
            }
        }
    }
}
