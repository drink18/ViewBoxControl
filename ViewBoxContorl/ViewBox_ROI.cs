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
        public Color PixelValueColor = Color.Yellow;
        public Color AnnotationShapeColor = Color.Yellow;
        public Color ROIMeasurementTextColor = Color.Red;
        public float AnnotationStrokeWidth = 2.0f;
        public enum StatKey
        {
            Mean,
            SqrVariation,
            Length
        }

        public class ROIUserData : UserData
        {
            public Dictionary<StatKey, float> StatDict = new Dictionary<StatKey, float>();
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
            var userData = roi.UserData as ROIUserData;
            Font font = new Font("Arial", 8, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(ROIMeasurementTextColor);

            string statStr = "";
            foreach (var stat in userData.StatDict)
            {
                statStr += string.Format("{0} = {1}\n", Enum.GetName(typeof(StatKey), stat.Key), stat.Value);
            }

            g.DrawString(statStr, font, brush, _annotation.Img2Client(roi.CenterWld));
            font.Dispose();
            brush.Dispose();
        }

        private void _renderMouseCursorInfo(PaintEventArgs pe)
        {
            if (View.Focused)
            {
                // pixel measure
                var e = PointToClient(MousePosition);
                if (View.ClientRectangle.Contains(e))
                {
                    var p = new PointF(e.X, e.Y);
                    var pImg = _annotation.Client2Img(p);
                    if (pImg.X >= 0 && pImg.Y >= 0 && pImg.X < NoCol && pImg.Y < NoRow)
                    {
                        var val = PixelData[(int)pImg.Y, (int)pImg.X];

                        Graphics g = pe.Graphics;
                        Font font = new Font("Arial", 10);
                        SolidBrush brush = new SolidBrush(PixelValueColor);
                        g.DrawString(string.Format("{0}", val), font, brush, new PointF(p.X + 5, p.Y - 5));
                        font.Dispose();
                        brush.Dispose();
                    }
                }
            }
        }

        private void _updateROIStatistics(Shape e)
        {
            var userData = new ROIUserData();

            if (e.GetType() != typeof(Line))
            {
                var mean = MeasureMeanPixelValeInDiagram(e);
                var var = MeasureSquareVariation(e);

                userData.StatDict[StatKey.Mean] = mean;
                userData.StatDict[StatKey.SqrVariation] = var;
            }
            else
            {
                var l = e as Line;
                var d = new PointF(l.Point0.X - l.Point1.X, l.Point0.Y - l.Point1.Y);
                userData.StatDict[StatKey.Length] = (int)Math.Sqrt(d.X * d.X + d.Y * d.Y); 
            }

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
