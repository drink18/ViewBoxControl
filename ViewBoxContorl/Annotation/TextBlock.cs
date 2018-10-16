using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewBoxContorl.Annotation
{
    public class TextBlock : Shape
    {
        public string Text
        {
            get;
            set;
        }

        public Color TextColor { get; set; }
        public int TextSize { get; set; } = 8;
        public TextBlock(PointF position)
        {
            _initControlPoints();
            Init(position);
            TextColor = Color.Blue; 
        }

        public TextBlock(PointF position, string text)
        {
            _initControlPoints();
            Init(position);
            TextColor = Color.Blue;
            Text = "文本块";
        }

        private void _initControlPoints()
        {
            ValidPickPts = new HashSet<CtrlPt>() {
            };
        }

        public override void Draw(Graphics g, Matrix view, float scale, float strokeWidth, Color strokeColor)
        {
            using (Font font = new Font("Arial", TextSize / scale, FontStyle.Bold))
            using (SolidBrush brush = new SolidBrush(TextColor))
            {
                _buildBoundingRect(g, font);

                var m = view.Clone();
                m.Multiply(_transform);
                g.Transform = m;
                g.DrawString(Text, font, brush, _getPointInWld(new PointF(LocalRect.X, LocalRect.Y)));
            }
        }

        private void _buildBoundingRect(Graphics g, Font font)
        {
            SizeF size = g.MeasureString(Text, font);
            _localRect.Size = size;
        }
    }
}
