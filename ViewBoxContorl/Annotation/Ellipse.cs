using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ViewBoxContorl.Annotation  
{

    public class Ellipse : Shape
    {
        float Width {
            get { return _localRect.Width; }
        }

        float Height{
            get { return _localRect.Height; }
        }

        public Ellipse(PointF center)
        {
            _initControlPoints();

            _localRect.X = 0;
            _localRect.Y = 0; 

            Init(center);
        }

        public Ellipse(PointF center, float axis1, float axis2)
        {
            _localRect = new RectangleF(-axis1 / 2, -axis2 / 2, axis1, axis2);
            _transform.Reset();
            _transform.Translate(center.X, center.Y);

            _initControlPoints();
            UpdateCtrlPts();

        }

        public override void Draw(Graphics g, Matrix m, float scale, float strokeWidth, Color strokeColor)
        {
            Pen pen = new Pen(strokeColor);
            pen.Width = strokeWidth;
            pen.Width /= scale;

            var mat = m.Clone();
            mat.Multiply(_transform);
            g.Transform = mat;
            g.DrawEllipse(pen, LocalRect);

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
            float lx = LocalRect.Width / 2;
            float ly = LocalRect.Height / 2;

            PointF np = new PointF(p.X , p.Y);
            return ((np.X * np.X) / (lx * lx) + (np.Y * np.Y) / (ly * ly) <= 1);
        }
        public override bool IsLocalPointInsideShape(PointF p)
        {
            float lx = LocalRect.Width / 2;
            float ly = LocalRect.Height / 2;

            PointF np = new PointF(p.X , p.Y);
            return ((np.X * np.X) / (lx * lx) + (np.Y * np.Y) / (ly * ly) <= 1);
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
