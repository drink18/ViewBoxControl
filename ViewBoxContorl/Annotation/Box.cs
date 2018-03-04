using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewBoxContorl.Annotation
{
    public class Box : Shape
    {
        public Box(PointF center)
        {
            _initControlPoints();

            Init(center);
        }


        public Box(PointF topLeft, PointF bottomRight)
        {
            _initControlPoints();
            float x = Math.Min(topLeft.X, bottomRight.X);
            float y = Math.Min(topLeft.Y, bottomRight.Y);
            float w = Math.Max(topLeft.X, bottomRight.X) - x;
            float h = Math.Max(topLeft.Y, bottomRight.Y) - y;

            _localRect = new RectangleF(-w / 2, -h / 2, w, h);

            Init(new PointF(x + w / 2, y + h / 2));

            UpdateCtrlPts();
        }

        // Set  TopLeftLocal coordinate in world space
        public PointF TopLeft
        {
            get
            {
                var p = new PointF(_localRect.X, _localRect.Y);
                var pl = new PointF[] { p };
                _transform.TransformPoints(pl);
                return pl[0];
            }
            set
            {
                var invT = _transform.Clone();
                invT.Invert();
                var pl = new PointF[] { value };
                invT.TransformPoints(pl);

               _localRect.X = pl[0].X;
               _localRect.Y = pl[0].Y;
            }
        }

        // Set  BottomRight coordinate in  World space
        public PointF BottomRight
        {
            get
            {
                var p = new PointF(_localRect.Right, _localRect.Bottom);
                var pl = new PointF[] { p };
                _transform.TransformPoints(pl);
                return pl[0];
            }
            set
            {
                var invT = _transform.Clone();
                invT.Invert();
                var pl = new PointF[] { value };
                invT.TransformPoints(pl);

                _localRect.Width = pl[0].X - _localRect.X;
                _localRect.Height = pl[0].Y - _localRect.Y;
            }
        }


        public override void Draw(Graphics g, Matrix view, float scale, float strokeWidth, Color strokeColor)
        {
            Pen pen = new Pen(strokeColor);
            pen.Width = strokeWidth;
            pen.Width /= scale;

            var m = view.Clone();
            m.Multiply(_transform);

            g.Transform = m;
            g.DrawRectangle(pen, LocalRect.X, LocalRect.Y, LocalRect.Width, LocalRect.Height);

            pen.Dispose();
        }

        public override void Move(PointF delta)
        {
            _transform = _setMatrixTranslation(_transform, new PointF(_transform.OffsetX + delta.X, _transform.OffsetY + delta.Y));
        }

        public override bool IsPointInsideShape(PointF p)
        {
            var pLocal = _getPointInLocal(p);
            return LocalRect.Contains(pLocal);
        }
        private void _initControlPoints()
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
        }

    }
}
