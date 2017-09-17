using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewBoxContorl.Annotation
{
    public class UserData { }
    public class BaseElement
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
            None
        }

        public static int MinSizeX = 4;
        public static int MinSizeY = 4;
        public static int CtrlPtSize= 8;

        virtual public void Draw(Graphics g, Annotation ano) { }
        virtual public void Move(PointF delta) { }
        virtual public void Manipulate(CtrlPt ctrlPt, PointF d)
        {
            if(ctrlPt == CtrlPt.TopLeft)
            {
                var x = AbsRect.X + d.X;
                var y = AbsRect.Y + d.Y;
                var w = AbsRect.Width + d.X;
                var h = AbsRect.Height + d.Y;
                AbsRect = new RectangleF(x, y, w, h);
            }
            else if(ctrlPt == CtrlPt.TopMiddle)
            {
                var x = AbsRect.X; 
                var y = AbsRect.Y + d.Y;
                var w = AbsRect.Width;
                var h = AbsRect.Height - d.Y;
                AbsRect = new RectangleF(x, y, w, h);
            }
            else if(ctrlPt == CtrlPt.TopRight)
            {
                var x = AbsRect.X; 
                var y = AbsRect.Y + d.Y;
                var w = AbsRect.Width + d.X;
                var h = AbsRect.Height - d.Y;
                AbsRect = new RectangleF(x, y, w, h);
            }
            else if(ctrlPt == CtrlPt.RightMiddle)
            {
                var x = AbsRect.X; 
                var y = AbsRect.Y;
                var w = AbsRect.Width + d.X;
                var h = AbsRect.Height;
                AbsRect = new RectangleF(x, y, w, h);
            }
            else if(ctrlPt == CtrlPt.BottomRight)
            {
                var x = AbsRect.X; 
                var y = AbsRect.Y;
                var w = AbsRect.Width + d.X;
                var h = AbsRect.Height + d.Y;
                AbsRect = new RectangleF(x, y, w, h);
            }
            else if(ctrlPt == CtrlPt.BottomMiddle)
            {
                var x = AbsRect.X; 
                var y = AbsRect.Y;
                var w = AbsRect.Width;
                var h = AbsRect.Height + d.Y;
                AbsRect = new RectangleF(x, y, w, h);
            }
            else if(ctrlPt == CtrlPt.BottomLeft)
            {
                var x = AbsRect.X + d.X; 
                var y = AbsRect.Y;
                var w = AbsRect.Width - d.X;
                var h = AbsRect.Height + d.Y;
                AbsRect = new RectangleF(x, y, w, h);
            }
            else if(ctrlPt == CtrlPt.LeftMiddle)
            {
                var x = AbsRect.X + d.X; 
                var y = AbsRect.Y;
                var w = AbsRect.Width - d.X;
                var h = AbsRect.Height;
                AbsRect = new RectangleF(x, y, w, h);
            }
        }
        virtual public bool IsValid()
        {
            return AbsRect.Width >= MinSizeX && AbsRect.Height >= MinSizeY;
        }

        protected RectangleF _absRect = new RectangleF(0, 0, MinSizeX, MinSizeY); //rect in absolute coord system
        public RectangleF AbsRect {
            get { return _absRect; }
            set
            {
                _absRect = value;
                UpdateCtrlPts();
            }
        }

        protected Dictionary<CtrlPt, PointF> CtrlPoints = new Dictionary<CtrlPt, PointF>();
        protected HashSet<CtrlPt> ValidPickPts = new HashSet<CtrlPt>();

        virtual protected Dictionary<CtrlPt, PointF> _getCtrlPtRects()
        {
            var rects = new Dictionary<CtrlPt, PointF>();
            var hf = CtrlPtSize / 2;

            rects[CtrlPt.TopLeft] = new PointF(AbsRect.X, AbsRect.Y);
            rects[CtrlPt.TopMiddle] = new PointF(AbsRect.X + AbsRect.Width / 2 , AbsRect.Y); 
            rects[CtrlPt.TopRight] = new PointF(AbsRect.Right, AbsRect.Y);

            rects[CtrlPt.BottomRight] = new PointF(AbsRect.Right, AbsRect.Bottom);
            rects[CtrlPt.BottomMiddle] = new PointF(AbsRect.X + AbsRect.Width/ 2, AbsRect.Bottom);
            rects[CtrlPt.BottomLeft] = new PointF(AbsRect.X, AbsRect.Bottom);


            rects[CtrlPt.RightMiddle] = new PointF(AbsRect.Right, AbsRect.Y + AbsRect.Height / 2);
            rects[CtrlPt.LeftMiddle] = new PointF(AbsRect.X, AbsRect.Y + AbsRect.Height / 2);

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

        virtual public CtrlPt PickControlPoint(PointF pClt, Annotation ano)
        {
            foreach(var cpt in CtrlPoints)
            {
                var p = cpt.Value;
                var p1 = ano.Img2Client(p);  //pt in client coord sys
                if(Math.Abs(p1.X - pClt.X) <= CtrlPtSize && Math.Abs(p1.Y - pClt.Y) <= CtrlPtSize)
                {
                    return cpt.Key;
                }
            }
            return CtrlPt.None;
        }
        
        virtual public void DrawControlPoints(Graphics g, Annotation ano)
        { 
            Pen pen = new Pen(Brushes.CornflowerBlue);
            var selRect = ano.Img2Client(_absRect);
            g.DrawRectangle(pen, (int)selRect.X, (int)selRect.Y, (int)selRect.Width + 1, (int)selRect.Height + 1);
            pen.Dispose();

            Pen ctrlPen= new Pen(Brushes.CornflowerBlue);
            foreach(var ar in CtrlPoints.Values)
            {
                var r = ano.Img2Client(ar);
                g.FillRectangle(ctrlPen.Brush, (int)r.X - CtrlPtSize / 2, (int)r.Y - CtrlPtSize / 2, CtrlPtSize, CtrlPtSize);
            }
            ctrlPen.Dispose();
        }

        virtual public void OnDragCreating(PointF p)
        {
            var x = _absRect.X;
            var y = _absRect.Y;
            var x1 = p.X;
            var y1 = p.Y;

            x = Math.Min(x, x1);
            y = Math.Min(y, y1);
            var w = Math.Max(x, x1) - x;
            var h = Math.Max(y, y1) - y;

            AbsRect = new RectangleF(x, y, w, h);
        }
    }
}
