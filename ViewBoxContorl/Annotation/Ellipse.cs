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
            ValidPickPts = new HashSet<CtrlPt>() {
                CtrlPt.TopLeft,
                CtrlPt.TopMiddle,
                CtrlPt.TopRight,
                CtrlPt.RightMiddle,
                CtrlPt.BottomRight,
                CtrlPt.BottomMiddle,
                CtrlPt.BottomLeft,
                CtrlPt.LeftMiddle,
                CtrlPt.Rotation,
            };

            var pts = new Point[] { new Point(topLeft.X, topLeft.Y) };
            client2Img.TransformPoints(pts);

            _absRect.X = 0;
            _absRect.Y = 0; 

            Init(pts[0]);
        }

        public override void Draw(Graphics g, Annotation ano)
        {
            Pen pen = new Pen(Brushes.LightYellow);
            pen.Width /= ano.ViewScale;

            g.Transform = _getRenderMatrix(ano);
            g.DrawEllipse(pen, AbsRect);

            pen.Dispose();
        }

        public override void Move(PointF delta)
        {
            var e = _transform.Elements;
            _transform = new Matrix(e[0], e[1], e[2], e[3], _transform.OffsetX + delta.X, _transform.OffsetY + delta.Y);
        }

        public override bool IsPointInsideShape(PointF pWld)
        {
            var p = _getPointInLocal(pWld);
            float lx = AbsRect.Width / 2;
            float ly = AbsRect.Height / 2;

            PointF np = new PointF(p.X , p.Y);
            return ((np.X * np.X) / (lx * lx) + (np.Y * np.Y) / (ly * ly) <= 1);
        }
    }
}
