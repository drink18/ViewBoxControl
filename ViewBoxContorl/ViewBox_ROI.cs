using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewBoxContorl.Annotation;

namespace ViewBoxContorl
{
    partial class ViewBoxForm : UserControl
    {
        public class ROIUserData : UserData
        {
            public float PixelMean;
            public float PixelVariation; 
        }

        int[] _getPixelsInsideROI(Shape e)
        {
            var pixels = new List<int>();

            for (int row = 0; row < NoRow; row++)
            {
                for (int col = 0; col < NoCol; col++)
                {
                    if (col >= 0 && row >= 0 && col < NoCol && row < NoRow 
                        && e.IsPointInsideShape(new PointF(col, row)))
                    {
                        pixels.Add(pixelData[row, col]);
                    }
                }
            }

            return pixels.ToArray();
        }

        float MeasureMeanPixelValeInDiagram(Shape e)
        {
            var pixels = _getPixelsInsideROI(e);
            double mean = 0;
            if(pixels.Length > 0 )
                mean = pixels.Average();

            return (float)mean;
        }

        float MeasureSquareVariation(Shape e)
        {
            var pixels = _getPixelsInsideROI(e);
            double variaton = 0;

            if (pixels.Length > 0)
            {
                var mean = pixels.Average();
                var sum = pixels.Sum(d => (d - mean) * (d - mean));
                variaton = sum / pixels.Length;
            }

            return (float)variaton;
        }

        public void _renderROIInfo(Graphics g, Shape roi)
        {
            if(roi.GetType() != typeof(Line))
            {
                var userData = roi.UserData as ROIUserData;
                Font font = new Font("Arial", 8, FontStyle.Bold);
                SolidBrush brush = new SolidBrush(Color.LightSalmon);
                g.DrawString(string.Format("Mean: {0}\n Var: {1}", userData.PixelMean, userData.PixelVariation), font, brush, _annotation.Img2Client(roi.CenterWld));
                font.Dispose();
                brush.Dispose();
            }
        }

        private void _renderMouseCursorInfo(PaintEventArgs pe)
        {
            // pixel measure
            var e = PointToClient(MousePosition);
            var p = new PointF(e.X, e.Y);
            var pImg = _annotation.Client2Img(p);
            if (pImg.X >= 0 && pImg.Y >= 0 && pImg.X < NoCol && pImg.Y < NoRow)
            {
                var val = PixelData[(int)pImg.Y, (int)pImg.X];

                Graphics g = pe.Graphics;
                Font font = new Font("Arial", 10);
                SolidBrush brush = new SolidBrush(Color.LightYellow);
                g.DrawString(string.Format("{0}", val), font, brush, new PointF(p.X + 5, p.Y - 5));
                font.Dispose();
                brush.Dispose();
            }
        }

        private void _updateROIStatistics(Shape e)
        {
            var userData = new ROIUserData();

            var mean = MeasureMeanPixelValeInDiagram(e);
            var var = MeasureSquareVariation(e);
            userData.PixelMean = mean;
            userData.PixelVariation = var;

            e.UserData = userData;
        }

        private void _annotationShapeCreated_ROI(Shape e)
        {
            if(_hasImage())
                _updateROIStatistics(e);
        }

        private void _annotationShapeChanged_ROI(Shape e, ManipCommand cmd)
        {
            if(_hasImage())
                _updateROIStatistics(e);
        }
    }
}
