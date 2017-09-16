using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ViewBoxContorl.Annotation  
{
    public class Ellipse : BaseElement
    {
        float Width {
            get { return _absRect.Width; }
        }

        float Height{
            get { return _absRect.Height; }
        }

        public Ellipse(Point topLeft, Matrix client2Img)
        {
            var pts = new Point[] { new Point(topLeft.X, topLeft.Y) };
            client2Img.TransformPoints(pts);
            _absRect.X = pts[0].X;
            _absRect.Y = pts[0].Y;
        }

        public override void Draw(Graphics g, Annotation ano)
        {
            Pen pen = new Pen(Brushes.White);
            
            var rect = ano.Img2Client(AbsRect);
            g.DrawEllipse(pen, rect);

            pen.Dispose();
        }

        public override void DrawControlPoints(Graphics g, Annotation ano) 
        {
            Pen pen = new Pen(Brushes.CornflowerBlue);
            var selRect = ano.Img2Client(_absRect);
            g.DrawRectangle(pen, (int)selRect.X, (int)selRect.Y, (int)selRect.Width, (int)selRect.Height);
        }

        public override void OnDragCreating(PointF p)
        {
            var x = _absRect.X;
            var y = _absRect.Y;
            _absRect = new RectangleF(x, y, p.X - x, p.Y - y);
        }

        public override void Move(PointF delta)
        {
            _absRect.X += delta.X;
            _absRect.Y += delta.Y;
        }
    }
}
