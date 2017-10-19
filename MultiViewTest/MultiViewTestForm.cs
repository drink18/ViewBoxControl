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
using ViewBoxContorl;

namespace MultiViewTest
{
    public partial class MultiViewTestForm : Form
    {
        ViewBoxForm[] _viewBoxes;
        public MultiViewTestForm()
        {
            InitializeComponent();

            _viewBoxes = new ViewBoxContorl.ViewBoxForm[] { vb1, vb2, vb3, vb4 };
            foreach (var vbxImg in _viewBoxes)
            {
                vbxImg.ShowPixelValue = true;
                vbxImg.OnZoomFactorChangedByUI += OnZoomFactorChanged;
                vbxImg.MouseRightClick += OnMouseRightClick;
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

        private void OnWinLvlChanged(ViewBoxForm viewbox)
        {
            foreach (var vb in _viewBoxes)
            {
                if(vb != viewbox)
                {
                    vb.Win = viewbox.Win;
                    vb.Lev = viewbox.Lev;
                }
            }
        }

        private void OnPanPosChanged(ViewBoxForm viewbox)
        {
            foreach (var vb in _viewBoxes)
            {
                if(vb != viewbox)
                {
                    vb.PanPosition = viewbox.PanPosition;
                }
            }
        }

        private void OnWinLvlChanging(ViewBoxForm viewbox)
        {
            foreach (var vb in _viewBoxes)
            {
                if (vb != viewbox)
                {
                    vb.Win = viewbox.Win;
                    vb.Lev = viewbox.Lev;
                }
            }
        }

        private void OnPanPosChanging(ViewBoxForm viewbox)
        {
            foreach (var vb in _viewBoxes)
            {
                if (vb != viewbox)
                {
                    vb.PanPosition = viewbox.PanPosition;
                }
            }
        }

        private void OnZoomFactorChanged(ViewBoxForm viewbox)
        {
            foreach (var vb in _viewBoxes)
            {
                if (vb != viewbox)
                {
                    vb.ZoomFactor = viewbox.ZoomFactor;
                }
            }
        }

        private void cbSync_CheckedChanged(object sender, EventArgs e)
        {
            cbContSync.Enabled = cbSync.Checked;
            
            foreach (var vbxImg in _viewBoxes)
            {
                if (cbSync.Checked)
                {
                    vbxImg.OnWinLvlChangedByUI += OnWinLvlChanged;
                    vbxImg.OnPanPositionChangedByUI += OnPanPosChanged;
                }
                else
                {
                    vbxImg.OnWinLvlChangedByUI -= OnWinLvlChanged;
                    vbxImg.OnPanPositionChangedByUI -= OnPanPosChanged;
                }
            }
        }

        private void cbContSync_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var vbxImg in _viewBoxes)
            {
                if (cbContSync.Checked)
                {
                    vbxImg.OnWinLvlChangingByUI += OnWinLvlChanging;
                    vbxImg.OnPanPositionChangingByUI += OnPanPosChanging;
                }
                else
                {
                    vbxImg.OnWinLvlChangingByUI -= OnWinLvlChanging;
                    vbxImg.OnPanPositionChangingByUI -= OnPanPosChanging;
                }
            }
        }
        
        private void OnMouseRightClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Mouse Clicked");
        }
    }
}
