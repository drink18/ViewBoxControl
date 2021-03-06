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
using ViewBoxContorl;
using ViewBoxContorl.Annotation;

namespace testViewBox
{
    
    public partial class testViewBox : Form
    {
        string imagePath = @"C:\Users\Windows User\Pictures";
        #region NoCol
        int noCol;
        CompoundShape compShape;

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

            vbxImage.OnWinLvlChangedByUI += vbxImg_OnWinValChanged;
            vbxImage.OnWinLvlChangedByUI +=  vbxImg_OnLvlValChanged;
            vbxImage.OnWinLvlChangingByUI += vbxImg_WinChangedTextBox;
            vbxImage.OnWinLvlChangingByUI += vbxImg_LvlChangedTextBox;

            dbNewShape.SelectedIndex = 0;

            numColSpacing.DecimalPlaces = 4;
            numRowSpacing.DecimalPlaces = 4;
            numColSpacing.Increment = new Decimal(0.005f);
            numRowSpacing.Increment = new Decimal(0.005f);

            cbPannable.Checked = vbxImage.Pannable;
            cbZoomable.Checked = vbxImage.Zoomable;
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
                    byte[] rawData=new byte[2*NoCol*NoRow];
                    long fileLen= fs.Read(rawData, 0, rawData.Length);
                    vbxImage.loadRawImage(rawData, NoCol, NoRow);

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

        private void vbxImg_OnWinValChanged(ViewBoxForm vbx)
        {
            hsbWin.Value = Math.Min(hsbWin.Maximum, Math.Max(hsbWin.Minimum, vbxImage.Win));
        }

        private void vbxImg_OnLvlValChanged(ViewBoxForm vbx)
        {
           hsbLev.Value = Math.Min(hsbLev.Maximum, Math.Max(hsbLev.Minimum, vbxImage.Lev));
        }

        private void vbxImg_WinChangedTextBox(ViewBoxForm vbx)
        {
            tbxWin.Text = "" + vbxImage.Win;
        }

        private void vbxImg_LvlChangedTextBox(ViewBoxForm vbx)
        {
            tbxLev.Text = "" + vbxImage.Lev;
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
                    dump += string.Format("Shape is {0}\r\n", shape.GetType().Name);
                    foreach (var keyVal in roiInfo.StatDict)
                    {
                        var key = keyVal.Key;
                        var value = keyVal.Value;
                        dump += string.Format("PropName={0},  Value={1}\r\n", key, value);
                    }
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

            var b = new Box(new PointF(10, 200), new PointF(230, 220));
            shapes.Add(b);

            b.TopLeft = new PointF(-10, 200);
            b.BottomRight = new PointF(245, 245);

            var comp = new CompoundShape();
            comp.AddSubShapes(shapes.ToArray());
            comp.Angle = hsbAngle.Value;
            vbxImage.AddShape(comp);
            compShape = comp;
        }

        private void btnRemoveSub_Click(object sender, EventArgs e)
        {
            if(compShape != null && compShape.SubShapes.Count > 0)
            {
                var lastShape = compShape.SubShapes.Last();
                compShape.RemoveSubShape(lastShape);
                vbxImage.Refresh(); //DO NOT FORGET TO REFRESH!
            }
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

        private void btnUnload_Click(object sender, EventArgs e)
        {
            vbxImage.unloadImage();
        }

        private void cbPannable_CheckedChanged(object sender, EventArgs e)
        {
            vbxImage.Pannable = cbPannable.Checked;
        }

        private void cbZoomable_CheckedChanged(object sender, EventArgs e)
        {
            vbxImage.Zoomable = cbZoomable.Checked;
        }
        
        Line spawnTestLines(PointF p, float len,  float startAngle, float angle)
        {
            float a = angle / 180.0f * (float)Math.PI;
            float a0 = startAngle / 180.0f * (float)Math.PI;
            PointF p1 = new PointF(p.X + len * (float)Math.Cos(a + a0), p.Y + len * (float)Math.Sin(a + a0));
            var line = new Line(p, p1);
            line.P0Annotation = "P000000";
            line.P1Annotation = "P111111";
            line.MidAnnotation = "MidPoint";
            line.AnnotationTextColor = Color.BlueViolet;

            return line;
        }

        private void btnLineText_Click(object sender, EventArgs e)
        {
            var line = new Line(new PointF(0, 0), new PointF(100, 100));
            line.P0Annotation = "起点";
            line.P1Annotation = "终点";
            vbxImage.AddShape(line);
            /*
            for (int i = 0; i < 5; ++i)
            {
                var line = spawnTestLines(new PointF(i * 150, i), 100, 0, 5 * i);
                vbxImage.AddShape(line);
            }

            for (int i = 0; i < 5; ++i)
            {
                var line = spawnTestLines(new PointF(i * 150, 150), 100, 0, - 15 * i);
                vbxImage.AddShape(line);
            }

            for (int i = 0; i < 5; ++i)
            {
                var line = spawnTestLines(new PointF(i * 150, 300), 100, 180, - 15 * i);
                vbxImage.AddShape(line);
            }
            */
        }

        private void testViewBox_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void btnTextBlock_Click(object sender, EventArgs e)
        {
            TextBlock tb = new TextBlock(new PointF(100, 130), "文本块");
            tb.TextColor = Color.Orange;
            tb.TextSize = 16;
            vbxImage.AddShape(tb);
        }
    }
}
