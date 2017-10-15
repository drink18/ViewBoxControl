﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewBoxContorl.Annotation;

namespace testViewBox
{
    
    public partial class testViewBox : Form
    {
        string imagePath = @"C:\Users\Windows User\Pictures";
        #region NoCol
        int noCol;
        Shape compShape;

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
        

        public testViewBox()
        {
            InitializeComponent();

            //MouseWheel += new MouseEventHandler(testMouseWheel);
            vbxImage.OnWinChanged += vbxImg_OnWinValChanged;
            vbxImage.OnLvlChanged += vbxImg_OnLvlValChanged;

            dbNewShape.SelectedIndex = 0;

            numColSpacing.DecimalPlaces = 6;
            numRowSpacing.DecimalPlaces = 6;
            numColSpacing.Increment = new Decimal(0.005f);
            numRowSpacing.Increment = new Decimal(0.005f);
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.InitialDirectory = imagePath;
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    img = new Bitmap(ofd.FileName);
            //    vbxImage.Image = img;
            //    tbxInfo.Clear();
            //    tbxInfo.AppendText("像素格式："+vbxImage.Image.PixelFormat.ToString()+"\r\n");
            //    tbxInfo.AppendText("图像宽度：" + vbxImage.Image.Width + "\r\n");
            //    tbxInfo.AppendText("图像高度：" + vbxImage.Image.Height + "\r\n");
            //    tbxInfo.AppendText("观片灯宽度：" + vbxImage.Width + "\r\n");
            //    tbxInfo.AppendText("观片灯高度：" + vbxImage.Height + "\r\n");
            //}
        }

        private void btnLoadRawImage_Click(object sender, EventArgs e)
        {
            OpenRawImage formOpenRawImage = new OpenRawImage();
            if (formOpenRawImage.ShowDialog(this) == DialogResult.OK)
            {
                NoCol = formOpenRawImage.NoCol;
                NoRow = formOpenRawImage.NoRow;
                FileName = formOpenRawImage.FileName;
                using (FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read))
                {
                    vbxImage.NoCol = NoCol;
                    vbxImage.NoRow = NoRow;
                    vbxImage.ResetObserverRect();
                    byte[] rawData=new byte[2*NoCol*NoRow];
                    long fileLen= fs.Read(rawData, 0, rawData.Length);
                    vbxImage.readPixelData(rawData);
                    vbxImage.setGrayLevelData();
                    tbxMaxPixel.Text = vbxImage.MaxPixel.ToString();
                    tbxMinPixel.Text = vbxImage.MinPixel.ToString();
                    tbxWin.Text = vbxImage.Win.ToString();
                    tbxLev.Text = vbxImage.Lev.ToString();
                    hsbWin.Maximum = vbxImage.MaxPixel;
                    hsbWin.Minimum = 1;
                    hsbWin.Value = vbxImage.Win;
                    hsbLev.Maximum = vbxImage.MaxPixel;
                    hsbLev.Minimum = 1;
                    hsbLev.Value = vbxImage.Lev;
                }
            }
        }

        private void tbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Return)
            //{
            //    if ((sender as TextBox).Name == "tbxWin")
            //    {
            //        vbxImage.Win = Int16.Parse((sender as TextBox).Text);
            //        tbxWin.Text = vbxImage.Win.ToString();
            //    }
            //    else if ((sender as TextBox).Name == "tbxLev")
            //    {
            //        vbxImage.Lev = Int16.Parse((sender as TextBox).Text);
            //    }
            //}
        }

        private void hsbWin_Scroll(object sender, ScrollEventArgs e)
        {
            vbxImage.Win = (Int16)e.NewValue;
            tbxWin.Text = vbxImage.Win.ToString();
        }

        private void hsbLev_Scroll(object sender, ScrollEventArgs e)
        {
            vbxImage.Lev = (Int16)e.NewValue;
            tbxLev.Text = vbxImage.Lev.ToString();
        }

        private void vbxImage_SizeChanged(object sender, EventArgs e)
        {
            tbxInfo.AppendText("vbxImage_SizeChanged\r\n");
            Debug.WriteLine("vbxImage_SizeChanged");
        }

        private void vbxImage_Resize(object sender, EventArgs e)
        {
            tbxInfo.AppendText("vbxImage_Resize\r\n");
            Debug.WriteLine("vbxImage_Resize");
        }

        private void vbxImage_VisibleChanged(object sender, EventArgs e)
        {
            tbxInfo.AppendText("vbxImage_VisibleChanged\r\n");
            Debug.WriteLine("vbxImage_VisibleChanged");
        }

        private void vbxImage_Paint(object sender, PaintEventArgs e)
        {
        }

        private void vbxImage_Validated(object sender, EventArgs e)
        {
            Debug.WriteLine("vbxImage_Validated");
        }

        private void vbxImage_Validating(object sender, CancelEventArgs e)
        {
            Debug.WriteLine("vbxImage_Validating");
        }

        private void vbxImage_ClientSizeChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("vbxImage_ClientSizeChanged");
        }


        private void vbxImage_Click(object sender, EventArgs e)
        {

        }


        private void vbxImg_OnWinValChanged(int oldVal, int newVal)
        {
            hsbWin.Value = Math.Min(hsbWin.Maximum, Math.Max(hsbWin.Minimum, newVal));
            tbxWin.Text = string.Format("{0}", newVal);
        }

        private void vbxImg_OnLvlValChanged(int oldVal, int newVal)
        {
           hsbLev.Value = Math.Min(hsbLev.Maximum, Math.Max(hsbLev.Minimum, newVal));
           tbxLev.Text = string.Format("{0}", newVal);
        }

        private void testMouseWheel(object sender, MouseEventArgs args)
        {
            var delta = args.Delta / 120.0f * 0.1f;
            vbxImage.SizeScale += delta;
        }

        private void cbAnnotation_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void dbNewShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = dbNewShape.SelectedItem as string;
            if(str == "None")
            {
                vbxImage.NewAnnotationType = null;
            }
            else if(str == "Ellipse")
            {
                vbxImage.NewAnnotationType = typeof(Ellipse);
            }
            else if(str == "Box")
            {
                vbxImage.NewAnnotationType = typeof(Box);
            }
            else if(str == "Line")
            {
                vbxImage.NewAnnotationType = typeof(Line);
            }
        }

        private void ShowPixelMeasure_CheckedChanged(object sender, EventArgs e)
        {
            vbxImage.ShowPixelValue = cbShowPixelMeasure.Checked;
            vbxImage.Refresh();
        }

        private void cbShowStatistics_CheckedChanged(object sender, EventArgs e)
        {
            vbxImage.ShowStatistics = cbShowStatistics.Checked;
            vbxImage.Refresh();
        }

        private void btnPrintROI_Click(object sender, EventArgs e)
        {
            var shapes = vbxImage.AnnotationShapes;
            string dump = "Begin of ROI dump\n";
            foreach (var shape in shapes)
            {
                var roiInfo = shape.UserData as ViewBoxContorl.ViewBoxForm.ROIUserData;
                if (roiInfo != null)
                {
                    dump += string.Format("Shape is {0}\n", shape.GetType().Name);
                    //dump += string.Format("Var={0}, Mean={1}\n", roiInfo.PixelVariation, roiInfo.PixelMean);
                }
            }
            dump += "End of ROI dump\n";
            tbxInfo.AppendText(dump);
        }

        private void btnTestCompound_Click(object sender, EventArgs e)
        {
            List<Shape> shapes = new List<Shape>();
            for (int i = 0; i < 5; ++i)
            {
                var l = new Line(new PointF(10, 100 + i * 8), new PointF(245, 100 + i * 8));
                shapes.Add(l);
            }

            var comp = new CompoundShape();
            comp.AddSubShapes(shapes.ToArray());
            comp.Angle = hsbAngle.Value;
            vbxImage.AddShape(comp);
            compShape = comp;
        }

        private void hsbAngle_ValueChanged(object sender, EventArgs e)
        {
            compShape.Angle = hsbAngle.Value;
            vbxImage.Refresh();
        }

        private void numColSpacing_ValueChanged(object sender, EventArgs e)
        {
            vbxImage.ColSpacing = (float)numColSpacing.Value;
        }

        private void numRowSpacing_ValueChanged(object sender, EventArgs e)
        {
            vbxImage.RowSpacing = (float)numRowSpacing.Value;
        }
    }
}
