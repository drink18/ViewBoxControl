using System;
using System.Collections.Generic;
using System.Drawing;
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

        int[] _getPixelsInsideROI(BaseElement e)
        {
            var pixels = new List<int>();
            int x = (int)e.AbsRect.X;
            int y = (int)e.AbsRect.Y;

            for (int row = y; row < e.AbsRect.Bottom; row++)
            {
                for (int col = x; col < e.AbsRect.Right; col++)
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

        float MeasureMeanPixelValeInDiagram(BaseElement e)
        {
            var pixels = _getPixelsInsideROI(e);
            var mean = pixels.Average();

            return (float)mean;
        }

        float MeasureSquareVariation(BaseElement e)
        {
            var pixels = _getPixelsInsideROI(e);
            var mean = pixels.Average();
            var sum = pixels.Sum(d => (d - mean) * (d - mean));
            var variaton = sum / pixels.Length;

            return (float)variaton;
        }

        public void DrawROIInfo(Graphics g, BaseElement roi)
        {
            if(roi.GetType() != typeof(Line))
            {
                var userData = roi.UserData as ROIUserData;
                Font font = new Font("Arial", 8, FontStyle.Bold);
                SolidBrush brush = new SolidBrush(Color.LightSalmon);
                g.DrawString(string.Format("Mean: {0}\n Var: {1}", userData.PixelMean, userData.PixelVariation), font, brush, _annotation.Img2Client(roi.Center));
            }
        }

        private void _updateROIStatistics(BaseElement e)
        {
            var userData = new ROIUserData();

            var mean = MeasureMeanPixelValeInDiagram(e);
            var var = MeasureMeanPixelValeInDiagram(e);
            userData.PixelMean = mean;
            userData.PixelVariation = var;

            e.UserData = userData;
        }

        private void _annotationShapeCreated_ROI(BaseElement e)
        {
            _updateROIStatistics(e);
        }

        private void _annotationShapeChanged_ROI(BaseElement e)
        {
            _updateROIStatistics(e);
        }
    }
}
