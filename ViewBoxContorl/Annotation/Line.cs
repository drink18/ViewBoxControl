using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewBoxContorl.Annotation
{
    public class Line : BaseElement
    {
        public PointF Point0 { get; set; }
        public PointF Point1 { get; set; }

        public Line(Point topLeft, Matrix client2Img)
        {
            ValidPickPts = new HashSet<CtrlPt>() {
                CtrlPt.LineEnd0,
                CtrlPt.LineEnd1};

            var pts = new Point[] { new Point(topLeft.X, topLeft.Y) };
            client2Img.TransformPoints(pts);
            _absRect.X = pts[0].X;
            _absRect.Y = pts[0].Y;
            Point0 = pts[0];
        }


        public override void OnDragCreating(PointF p)
        {
            Point1 = p;
            _buildBoundingRect();
        }

        public override void Draw(Graphics g, Annotation ano)
        {
            Pen pen = new Pen(Brushes.White);
            g.DrawLine(pen, ano.Img2Client(Point0), ano.Img2Client(Point1));
            pen.Dispose();
        }

        public override void Move(PointF delta)
        {
            AbsRect = new RectangleF(_absRect.X + delta.X, _absRect.Y + delta.Y, _absRect.Width, _absRect.Height);
            Point0 = new PointF(Point0.X + delta.X, Point0.Y + delta.Y);
            Point1 = new PointF(Point1.X + delta.X, Point1.Y + delta.Y);
        }

        public override void DrawControlPoints(Graphics g, Annotation ano)
        {
            Pen pen = new Pen(Brushes.CornflowerBlue);
            var selRect = ano.Img2Client(_absRect);
            g.DrawRectangle(pen, (int)selRect.X, (int)selRect.Y, (int)selRect.Width + 1, (int)selRect.Height + 1);
            pen.Dispose();

            Pen ctrlPen= new Pen(Brushes.CornflowerBlue);
            var pt0 = ano.Img2Client(Point0);
            var pt1 = ano.Img2Client(Point1);
            g.FillRectangle(ctrlPen.Brush, (int)pt0.X - CtrlPtSize / 2, (int)pt0.Y - CtrlPtSize / 2, CtrlPtSize, CtrlPtSize);
            g.FillRectangle(ctrlPen.Brush, (int)pt1.X - CtrlPtSize / 2, (int)pt1.Y - CtrlPtSize / 2, CtrlPtSize, CtrlPtSize);
            ctrlPen.Dispose();
        }

        public override CtrlPt PickControlPoint(PointF pClt, Annotation ano)
        {
            var pt0 = ano.Img2Client(Point0);
            var pt1 = ano.Img2Client(Point1);

            var r0 = new RectangleF(pt0.X - CtrlPtSize / 2, pt0.Y - CtrlPtSize / 2, CtrlPtSize, CtrlPtSize);
            var r1 = new RectangleF(pt1.X - CtrlPtSize / 2, pt1.Y - CtrlPtSize / 2, CtrlPtSize, CtrlPtSize);

            if (r0.Contains(pClt))
                return CtrlPt.LineEnd0;

            if (r1.Contains(pClt))
                return CtrlPt.LineEnd1;

            return CtrlPt.None;
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
            AbsRect = new RectangleF(x, y, w, h);
        }
    }
}
