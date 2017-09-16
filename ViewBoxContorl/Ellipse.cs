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
        int Width {
            get { return _absRect.Width; }
        }

        int Height{
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
            g.DrawRectangle(pen, selRect);
        }

        public override void OnDragCreating(Point p)
        {
            var x = _absRect.X;
            var y = _absRect.Y;
            _absRect = new Rectangle(x, y, p.X - x, p.Y - y);
        }

        public override void Move(Point delta)
        {
            _absRect.X += delta.X;
            _absRect.Y += delta.Y;
        }
    }
}
