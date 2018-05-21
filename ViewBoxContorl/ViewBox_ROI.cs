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
            StandardVariation,
            Length
        }

        public class ROIUserData : UserData
        {
            public Dictionary<StatKey, float> StatDict = new Dictionary<StatKey, float>();
            public bool AllowRealtimeROI = false;
            public ROIUserData(Shape shape)
            {
                AllowRealtimeROI = shape is Line;
            }
        }

        int[] _getPixelsInsideROI(Shape e)
        {
            var pixels = new List<int>();
            var rect = e.GetAABB();
            for (int row = (int)rect.Top; row <= (int)rect.Bottom; row++)
            {
                for (int col = (int)rect.Left; col <= (int)rect.Right; col++)
                {
                    var invMat = e.Transform.Clone();
                    invMat.Invert();
                    var localP = new PointF();
                    var ele = invMat.Elements;
                    localP.X = col * ele[0] + row * ele[1] + ele[4];
                    localP.Y = col * ele[2] + row * ele[3] + ele[5];

                    var pts = new PointF[] { new PointF(col, row) };
                    invMat.TransformPoints(pts);
                    localP = pts[0];

                    if (col >= 0 && row >= 0 && col < NoCol && row < NoRow 
                        && e.IsLocalPointInsideShape(localP))
                    {
                        pixels.Add(pixelData[row, col]);
                    }
                }
            }

            return pixels.ToArray();
        }

        float MeasureMeanPixelValeInDiagram(Shape e,int[] pixelsInROI)
        {
            double mean = 0;
            if(pixelsInROI.Length > 0 )
                mean = pixelsInROI.Average();

            return (float)mean;
        }

        float MeasureSquareVariation(Shape e, int[] pixelsInROI)
        {
            double variaton = 0;

            if (pixelsInROI.Length > 0)
            {
                var mean = pixelsInROI.Average();
                var sum = pixelsInROI.Sum(d => (d - mean) * (d - mean));
                variaton = sum / pixelsInROI.Length;
            }

            return (float)variaton;
        }
        float MeasureStandardVariation(Shape e, int[] pixelsInROI)
        {
            double variaton = 0;

            if (pixelsInROI.Length > 0)
            {
                var mean = pixelsInROI.Average();
                var sum = pixelsInROI.Sum(d => (d - mean) * (d - mean));
                variaton = Math.Sqrt(sum / pixelsInROI.Length);
            }

            return (float)variaton;
        }

        public void _renderROIInfo(Graphics g, Shape roi)
        {
            var userData = roi.UserData as ROIUserData;
            Font font = new Font("Arial", 8, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(ROIMeasurementTextColor);

            g.DrawString(GetROIString(roi), font, brush, _annotation.Img2Client(roi.CenterWld));
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
            // TODO: REFACTOR THIS FOR BETTER ABSTRACTION!
            var userData = e.UserData as ROIUserData;
            if (userData == null)
                return;

            if (e.GetType() != typeof(Line))
            {
                var pixels = _getPixelsInsideROI(e);
                var mean = MeasureMeanPixelValeInDiagram(e, pixels);
                var var = MeasureStandardVariation(e, pixels);

                userData.StatDict[StatKey.Mean] = mean;
                userData.StatDict[StatKey.StandardVariation] = var;
            }
            else
            {
                var l = e as Line;
                var d = new PointF(l.Point0.X - l.Point1.X, l.Point0.Y - l.Point1.Y);
                d.X *= ColSpacing;
                d.Y *= RowSpacing;
                userData.StatDict[StatKey.Length] = (int)Math.Sqrt(d.X * d.X + d.Y * d.Y); 
            }

            e.UserData = userData;
        }

        private string GetROIString(Shape e)
        {
            string roi = "";
            var userData = e.UserData as ROIUserData;
            if (e.GetType() == typeof(CompoundShape))
                return roi;

            if(e.GetType() != typeof(Line))
            {
                roi = string.Format("Mean={0}\nSqrVar={1}", userData.StatDict[StatKey.Mean], userData.StatDict[StatKey.StandardVariation]);
            }
            else
            {
                roi = string.Format("{0} mm",userData.StatDict[StatKey.Length]);
            }
            return roi;
        }

        private void _annotationShapeCreating_ROI(Shape e)
        {
            var ud = new ROIUserData(e);
            e.UserData = ud;
            if (HasImage && ud.AllowRealtimeROI)
                _updateROIStatistics(e);
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

        private void _annotationShapeChanging_ROI(Shape e, ManipCommand cmd)
        {
            var ud = e.UserData as ROIUserData;
            if (_hasImage() && ud != null && ud.AllowRealtimeROI)
                _updateROIStatistics(e);
        }

    }
}
