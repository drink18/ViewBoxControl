using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewBoxContorl.Annotation
{
    public class Box : BaseElement
    {
        public Box(Point topLeft, Matrix client2Img)
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
            Init(pts[0]);
        }

        public override void Draw(Graphics g, Annotation ano)
        {
            Pen pen = new Pen(Brushes.LightYellow);
            pen.Width /= ano.ViewScale;

            g.Transform = _getRenderMatrix(ano);
            g.DrawRectangle(pen, AbsRect.X, AbsRect.Y, AbsRect.Width, AbsRect.Height);

            pen.Dispose();
        }

        public override void Move(PointF delta)
        {
            var e = _transform.Elements;
            _transform = new Matrix(e[0], e[1], e[2], e[3], _transform.OffsetX + delta.X, _transform.OffsetY + delta.Y);
        }

        public override bool IsPointInsideShape(PointF p)
        {
            var pLocal = _getPointInLocal(p);
            return AbsRect.Contains(pLocal);
        }
    }
}
