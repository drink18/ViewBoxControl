using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewBoxContorl.Annotation.Data;

namespace ViewBoxContorl.Annotation
{
    public class Line : Shape
    {
        public enum AnnotationPosition
        {
            StartPoint,
            EndPoint,
            MidPoint
        }

        #region Properties
        #endregion
        public PointF Point0 { get; set; }
        public PointF Point1 { get; set; }

        string[] _annotationTexts = new string[3];

        public Color AnnotationTextColor { get; set; }

        public string P0Annotation { get { return getAnnotationText(AnnotationPosition.StartPoint); } set { setAnnotationText(AnnotationPosition.StartPoint, value); } }
        public string P1Annotation { get { return getAnnotationText(AnnotationPosition.EndPoint); } set { setAnnotationText(AnnotationPosition.EndPoint, value); } }
        public string MidAnnotation { get { return getAnnotationText(AnnotationPosition.MidPoint); } set { setAnnotationText(AnnotationPosition.MidPoint, value); } }

        public Line(PointF center)
        {
            ValidPickPts = new HashSet<CtrlPt>() {
                CtrlPt.LineEnd0,
                CtrlPt.LineEnd1};

            _localRect.X = center.X;
            _localRect.Y = center.Y;
            Point0 = center;
            Point1 = center;
            _annotationTexts = new string [] { "", "", "" };
            AnnotationTextColor = Color.Blue;
        }

        public Line(PointF p0, PointF p1)
        {
            ValidPickPts = new HashSet<CtrlPt>() {
                CtrlPt.LineEnd0,
                CtrlPt.LineEnd1};

            Point0 = p0;
            Point1 = p1;

            _annotationTexts = new string [] { "", "", "" };

            _buildBoundingRect();
            AnnotationTextColor = Color.Blue;
        }

        public override void OnDragCreating(PointF p)
        {
            Point1 = p;
            _buildBoundingRect();
        }

        public override void Draw(Graphics g, Matrix view, float scale, float strokeWidth, Color strokeColor)
        {
            Pen pen = new Pen(strokeColor);
            Font font = new Font("Arial", 8 / scale, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(AnnotationTextColor);

            pen.Width = strokeWidth;
            pen.Width /= scale;

            var m = view.Clone();
            m.Multiply(_transform);
            g.Transform = m;
            g.DrawLine(pen, Point0, Point1);

            for(var penum = AnnotationPosition.StartPoint; penum <= AnnotationPosition.MidPoint; ++penum)
            {
                SizeF size = g.MeasureString(getAnnotationText(penum), font, 200);

                var pos = getAnnotationTextPos(penum, size);
                g.DrawString(getAnnotationText(penum), font, brush, _getPointInWld(pos));
            }
            pen.Dispose();
        }

       PointF getAnnotationTextPos(AnnotationPosition pos, SizeF stringSize)
       {
            var ret = new PointF();
            
            if(pos == AnnotationPosition.StartPoint)
            {
                var dx = Point1.X - Point0.X;
                var dy = Point1.Y - Point0.Y;
                float ox = 0;
                float oy = 0;
                if (dx > 0 && dy > 0)
                    ox -= stringSize.Width;

                ret = new PointF(Point0.X + ox, Point0.Y + oy);
            }
            else if(pos == AnnotationPosition.EndPoint)
            {
                var dx = Point0.X - Point1.X;
                var dy = Point0.Y - Point1.Y;
                float ox = 0;
                float oy = 0;
                if (dx > 0 && dy > 0)
                    ox -= stringSize.Width;

                ret = new PointF(Point1.X + ox, Point1.Y + oy);
            }
            else
            {
                // mid point 
                ret.X = (Point0.X + Point1.X) / 2;
                ret.Y = (Point0.Y + Point1.Y) / 2;
            }
            return ret;
       }

        public override void Move(PointF delta)
        {
            LocalRect = new RectangleF(_localRect.X + delta.X, _localRect.Y + delta.Y, _localRect.Width, _localRect.Height);
            Point0 = new PointF(Point0.X + delta.X, Point0.Y + delta.Y);
            Point1 = new PointF(Point1.X + delta.X, Point1.Y + delta.Y);
        }

        public override void DrawControlPoints(Graphics g, Matrix view, float scale)
        {
            g.Transform = view;

            Pen ctrlPen= new Pen(Brushes.CornflowerBlue);
            ctrlPen.Width /= scale;
            float s = CtrlPtSize / scale; // make sure ctrl points are always the same size regardless the scale
            g.FillRectangle(ctrlPen.Brush, (int)Point0.X - s / 2, (int)Point0.Y - s / 2, s, s);
            g.FillRectangle(ctrlPen.Brush, (int)Point1.X - s / 2, (int)Point1.Y - s / 2, s, s);
            ctrlPen.Dispose();
        }

        public override Tuple<Shape, CtrlPt> PickControlPoint(PointF pImg, float viewScale)
        {
            var pt0 = _getPointInWld(Point0);
            var pt1 = _getPointInWld(Point1);

            var scp = CtrlPtSize / viewScale;
            var r0 = new RectangleF(pt0.X - scp / 2, pt0.Y - scp / 2, scp, scp);
            var r1 = new RectangleF(pt1.X - scp/ 2, pt1.Y - scp / 2, scp, scp);

            if (r0.Contains(pImg))
                return new Tuple<Shape, CtrlPt>(this, CtrlPt.LineEnd0);

            if (r1.Contains(pImg))
                return new Tuple<Shape, CtrlPt>(this, CtrlPt.LineEnd1);

            return null;
        }

        public override void Manipulate(CtrlPt ctrlPt, PointF d)
        {
            if(ctrlPt == CtrlPt.LineEnd0)
            {
                Point0 = new PointF(d.X + Point0.X, d.Y + Point0.Y);
            }
            if(ctrlPt == CtrlPt.LineEnd1)
            {
                Point1 = new PointF(d.X + Point1.X, d.Y + Point1.Y);
            }

            _buildBoundingRect();
        }

        public override bool IsValid()
        {
            return true;
        }
        
        private void _buildBoundingRect()
        {
            var x = Math.Min(Point0.X, Point1.X);
            var y = Math.Min(Point0.Y, Point1.Y);
            var w = Math.Max(Point0.X, Point1.X) - x;
            var h = Math.Max(Point0.Y, Point1.Y) - y;
            if (w < MinSizeX)
            {
                x -= (MinSizeX - w) / 2;
                w = MinSizeX;
            }

            if (h < MinSizeY)
            {
                y -= (MinSizeY - h) / 2;
                h = MinSizeY;
            }
            LocalRect = new RectangleF(x, y, w, h);
        }

        public override bool IsPointInsideShape(PointF p)
        {
            var v = new PointF(p.X - Point0.X, p.Y - Point0.Y);
            PointF n = new PointF(Point1.X - Point0.X, Point1.Y - Point0.Y);
            float lenSqr = n.X * n.X + n.Y * n.Y;
            float len = (float)Math.Sqrt(lenSqr);
            n.X /= len;
            n.Y /= len;

            //proj
            float d = v.X * n.X + v.Y * n.Y;
            if(d > 0 && d <= len)
            {
                PointF v1 = new PointF(v.X - d * n.X, v.Y - d * n.Y);
                if (v1.X * v1.X + v1.Y * v1.Y < 4) // 2 pixels of fudge factor
                    return true;
            }

            return false;
        }

        public override ShapeSnapshotData ExportElement()
        {
            var ed = new LineData();
            ed.LocalRect = LocalRect;
            ed.Transform = _transform;
            ed.P0 = Point0;
            ed.P1 = Point1;

            return ed;
        }

        public override void InitFromElementData(ShapeSnapshotData ed)
        {
            base.InitFromElementData(ed);
            var led = ed as LineData;
            Point0 = led.P0;
            Point1 = led.P1;
        }

        public override void RenderAuxilaries(Graphics g, Matrix m, float scale)
        {
            DrawControlPoints(g, m, scale);
        }

        void setAnnotationText(AnnotationPosition pos, string text)
        {
            _annotationTexts[(int)pos] = text;
        }
        string getAnnotationText(AnnotationPosition pos)
        {
            return _annotationTexts[(int)pos];
        }
    }
}
