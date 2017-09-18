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

        public void DrawROIStats(Graphics g, BaseElement roi)
        {
            if(roi.GetType() != typeof(Line))
            {
                float mean = MeasureMeanPixelValeInDiagram(roi);
                float variation = MeasureSquareVariation(roi);
                Font font = new Font("Arial", 8);
                SolidBrush brush = new SolidBrush(Color.LightYellow);
                g.DrawString(string.Format("Mean: {0}\n Var: {1}", mean, variation), font, brush, _annotation.Img2Client(roi.Center));
            }
        }
    }
}
