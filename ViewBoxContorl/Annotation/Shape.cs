using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewBoxContorl.Annotation.Data;

namespace ViewBoxContorl.Annotation
{
    public class UserData { }
    public class Shape
    {
        public enum CtrlPt
        {
            TopLeft,
            TopMiddle,
            TopRight,
            RightMiddle,
            BottomRight,
            BottomMiddle,
            BottomLeft,
            LeftMiddle, 
            LineEnd0,
            LineEnd1,
            Rotation,
            None
        }

        public static int MinSizeX = 4;
        public static int MinSizeY = 4;
        public static int CtrlPtSize= 8;

        public UserData UserData;
        #region Properties
        #endregion

        virtual public void Draw(Graphics g,  Matrix view, float scale, float strokeWidth, Color strokeColor) { }
        virtual public void Move(PointF delta) { }

        virtual public void Manipulate(CtrlPt ctrlPt, PointF d)
        {
            if(ctrlPt == CtrlPt.TopLeft)
            {
                var x = LocalRect.X + d.X;
                var y = LocalRect.Y + d.Y;
                var w = LocalRect.Width - d.X;
                var h = LocalRect.Height - d.Y;
                LocalRect = new RectangleF(x, y, w, h);
            }
            else if(ctrlPt == CtrlPt.TopMiddle)
            {
                var x = LocalRect.X; 
                var y = LocalRect.Y + d.Y;
                var w = LocalRect.Width;
                var h = LocalRect.Height - d.Y;
                LocalRect = new RectangleF(x, y, w, h);
            }
            else if(ctrlPt == CtrlPt.TopRight)
            {
                var x = LocalRect.X; 
                var y = LocalRect.Y + d.Y;
                var w = LocalRect.Width + d.X;
                var h = LocalRect.Height - d.Y;
                LocalRect = new RectangleF(x, y, w, h);
            }
            else if(ctrlPt == CtrlPt.RightMiddle)
            {
                var x = LocalRect.X; 
                var y = LocalRect.Y;
                var w = LocalRect.Width + d.X;
                var h = LocalRect.Height;
                LocalRect = new RectangleF(x, y, w, h);
            }
            else if(ctrlPt == CtrlPt.BottomRight)
            {
                var x = LocalRect.X; 
                var y = LocalRect.Y;
                var w = LocalRect.Width + d.X;
                var h = LocalRect.Height + d.Y;
                LocalRect = new RectangleF(x, y, w, h);
            }
            else if(ctrlPt == CtrlPt.BottomMiddle)
            {
                var x = LocalRect.X; 
                var y = LocalRect.Y;
                var w = LocalRect.Width;
                var h = LocalRect.Height + d.Y;
                LocalRect = new RectangleF(x, y, w, h);
            }
            else if(ctrlPt == CtrlPt.BottomLeft)
            {
                var x = LocalRect.X + d.X; 
                var y = LocalRect.Y;
                var w = LocalRect.Width - d.X;
                var h = LocalRect.Height + d.Y;
                LocalRect = new RectangleF(x, y, w, h);
            }
            else if(ctrlPt == CtrlPt.LeftMiddle)
            {
                var x = LocalRect.X + d.X; 
                var y = LocalRect.Y;
                var w = LocalRect.Width - d.X;
                var h = LocalRect.Height;
                LocalRect = new RectangleF(x, y, w, h);
            }
            else if(ctrlPt == CtrlPt.Rotation)
            {
                Angle += d.X;
            }
        }

        virtual public bool IsValid()
        {
            return LocalRect.Width >= MinSizeX && LocalRect.Height >= MinSizeY;
        }
        virtual public bool IsPointInsideShape(PointF p) { return false; }

        virtual public ShapeSnapshotData ExportElement()
        {
            var ed = new ShapeSnapshotData();
            ed.LocalRect = _localRect;
            ed.Transform = _transform.Clone();
            return ed;
        }

        virtual public void InitFromElementData(ShapeSnapshotData ed)
        {
            _transform = ed.Transform.Clone();
            LocalRect = ed.LocalRect;
        }

        protected RectangleF _localRect = new RectangleF(0, 0, 0, 0); //rect in absolute coord system
        public RectangleF LocalRect {
            get { return _localRect; }
            set
            {
                _localRect = value;
                UpdateCtrlPts();
            }
        }

        public PointF Center
        {
            get
            {
                return new PointF(_localRect.X + _localRect.Width / 2, _localRect.Y + _localRect.Height / 2);
            }
        }

        public PointF CenterWld
        {
            get { return _getPointInWld(Center); }
        }

        public float Angle // angle around piviot (Center)
        {
            get
            {
                return _getAngleFromMatrixDeg(_transform.Elements);
            }
            set
            {
                var diff = value - Angle;
                var m = new Matrix();
                var c = CenterWld;
                m.RotateAt(diff, new PointF(c.X, c.Y));
                m.Multiply(_transform);
                _transform = m;
            }
        }

        protected Matrix _transform = new Matrix();
        public Matrix Transform
        {
            get { return _transform; }
            set { _transform = value; }
        }

        protected Dictionary<CtrlPt, PointF> CtrlPoints = new Dictionary<CtrlPt, PointF>();
        protected HashSet<CtrlPt> ValidPickPts = new HashSet<CtrlPt>();

        public void Init(PointF startPos)
        {
            _transform = new Matrix();
            _transform.Translate(startPos.X, startPos.Y);

        }

        virtual protected Dictionary<CtrlPt, PointF> _getCtrlPtRects()
        {
            var rects = new Dictionary<CtrlPt, PointF>();
            var hf = CtrlPtSize / 2;

            rects[CtrlPt.TopLeft] = new PointF(LocalRect.X, LocalRect.Y);
            rects[CtrlPt.TopMiddle] = new PointF(LocalRect.X + LocalRect.Width / 2 , LocalRect.Y); 
            rects[CtrlPt.TopRight] = new PointF(LocalRect.Right, LocalRect.Y);

            rects[CtrlPt.BottomRight] = new PointF(LocalRect.Right, LocalRect.Bottom);
            rects[CtrlPt.BottomMiddle] = new PointF(LocalRect.X + LocalRect.Width/ 2, LocalRect.Bottom);
            rects[CtrlPt.BottomLeft] = new PointF(LocalRect.X, LocalRect.Bottom);


            rects[CtrlPt.RightMiddle] = new PointF(LocalRect.Right, LocalRect.Y + LocalRect.Height / 2);
            rects[CtrlPt.LeftMiddle] = new PointF(LocalRect.X, LocalRect.Y + LocalRect.Height / 2);

            rects[CtrlPt.Rotation] = new PointF(LocalRect.X + LocalRect.Width /2, LocalRect.Y + LocalRect.Height / 2);

            return rects;
        }

        virtual protected void UpdateCtrlPts()
        {
            var ctrlPts = _getCtrlPtRects();
            CtrlPoints.Clear();
            foreach(var e in ctrlPts)
            {
                if (ValidPickPts.Contains(e.Key))
                    CtrlPoints[e.Key] = e.Value;
            }
        }

        virtual public Tuple<Shape, CtrlPt> PickControlPoint(PointF pImg)
        {
            foreach(var cpt in CtrlPoints)
            {
                var p = cpt.Value;
                var p1 = _getPointInLocal(pImg);
                if(Math.Abs(p1.X - p.X) <= CtrlPtSize && Math.Abs(p1.Y - p.Y) <= CtrlPtSize)
                {
                    return new Tuple<Shape, CtrlPt>(this, cpt.Key);
                }
            }
            return null; 
        }

        virtual public void DrawBoundingBox(Graphics g, Matrix view, float scale)
        {
            var m = view.Clone();
            m.Multiply(_transform);
            g.Transform = m;

            Pen pen = new Pen(Brushes.CornflowerBlue);
            pen.Width /= scale;
            g.DrawRectangle(pen, (int)LocalRect.X - 1, (int)LocalRect.Y - 1, (int)LocalRect.Width + 1, (int)LocalRect.Height + 1);
            pen.Dispose();
        }

        virtual public void RenderAuxilaries(Graphics g, Matrix view, float scale)
        {
            DrawControlPoints(g, view, scale);
        }
        
        virtual public void DrawControlPoints(Graphics g, Matrix view, float scale)
        {
            var m = view.Clone();
            m.Multiply(_transform);
            g.Transform = m;

            Pen ctrlPen= new Pen(Brushes.CornflowerBlue);
            foreach(var cpt in CtrlPoints)
            {
                var r = cpt.Value;
                ctrlPen.Color = cpt.Key == CtrlPt.TopLeft ? Color.Red : Color.CornflowerBlue;
                if (cpt.Key == CtrlPt.Rotation)
                    ctrlPen.Color = Color.Orange;
                float s = CtrlPtSize / scale; // make sure ctrl points are always the same size regardless the scale

                if (cpt.Key == CtrlPt.Rotation)
                {
                    g.DrawEllipse(ctrlPen, r.X - s / 2, r.Y - s / 2, s, s);
                }
                else
                {
                    g.FillRectangle(ctrlPen.Brush, (int)r.X - s / 2, (int)r.Y - s / 2, s, s);
                }
            }
            ctrlPen.Dispose();
        }

        virtual public void OnDragCreating(PointF p)
        {
            var x = _localRect.X;
            var y = _localRect.Y;
            var pt = _getPointInLocal(new PointF(p.X, p.Y));
            x = Math.Min(_localRect.X, pt.X);
            y = Math.Min(_localRect.Y, pt.Y);

            var w = Math.Max(pt.X, _localRect.X) - x;
            var h = Math.Max(pt.Y, _localRect.Y) - y;

            // top loft in wld space
            var p0 = _getPointInWld(new PointF(x, y));
            var cWld = new PointF((p.X + p0.X) / 2, (p.Y + p0.Y) / 2); //center in world

            _transform = _setMatrixTranslation(_transform, cWld);

            // now update local rect
            LocalRect = new RectangleF(- w/2, -h/2, w, h);
        }

        protected PointF _getPointInWld(PointF pLocal)
        {
            var pts = new PointF[] {new PointF(pLocal.X, pLocal.Y) };
            _transform.TransformPoints(pts);
            return pts[0];
        }

        protected PointF _getPointInLocal(PointF pWld)
        {
            var inv = _transform.Clone();
            inv.Invert();
            var pts = new PointF[] {new PointF(pWld.X, pWld.Y) };
            inv.TransformPoints(pts);
            return pts[0];
        }

        protected Matrix _getRenderMatrix(Annotation ano)
        {
            var m = ano.matImg2Client.Clone();
            m.Multiply(_transform);
            return m;
        }

        // given a rectangle, return the new center in world so that the rect's center is 
        // repositioned at (0, 0)
        protected PointF _realignOffcenterRect(RectangleF r)
        {
            var  p0 = _getPointInWld(new PointF(r.X, r.Y)); // topleft
            var  p1 = _getPointInWld(new PointF(r.Right, r.Bottom)); // bottom right
            var center = new PointF((p0.X + p1.X) / 2, (p0.Y + p1.Y) / 2);
            return center;
        }

        protected Matrix _setMatrixTranslation(Matrix m, PointF pos)
        {
            var e = m.Elements;
            var _m = new Matrix(e[0], e[1], e[2], e[3], pos.X, pos.Y);
            return _m;
        }

        protected float _getAngleFromMatrixDeg(float[] e)
        {
            var angle = (float)Math.Atan2(e[1], e[0]);
            angle *= 180.0f / (float)Math.PI;
            return angle;
        }

        // merge other into r
        protected RectangleF MergeRect(RectangleF r1, RectangleF other)
        {
            float x = Math.Min(r1.X, other.X);
            float y = Math.Min(r1.Y, other.Y);

            float r = Math.Max(r1.Right, other.Right);
            float b = Math.Max(r1.Bottom, other.Bottom);

            return new RectangleF(x, y, r - x, b - y);
        }

        public RectangleF GetAABB()
        {
            var p = new PointF[4];
            p[0] = _getPointInWld(new PointF(_localRect.X, _localRect.Y));
            p[1] = _getPointInWld(new PointF(_localRect.Right, _localRect.Y));
            p[2] = _getPointInWld(new PointF(_localRect.Right, _localRect.Bottom));
            p[3] = _getPointInWld(new PointF(_localRect.X, _localRect.Bottom));

            float x0, y0, x1, y1;
            x0 = x1 = p[0].X;
            y0 = y1 = p[0].Y;
            for(int i =1; i < 4; i++)
            {
                var c = p[i];
                x0 = Math.Min(c.X, x0);
                y0 = Math.Min(c.Y, y0);

                x1 = Math.Max(c.X, x1);
                y1 = Math.Max(c.Y, y1);
            }

            var ret = new RectangleF(x0, y0, x1 - x0, y1 - y0);
            return ret;
        }
    }

}
