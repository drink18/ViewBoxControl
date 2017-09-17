﻿using System;
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
                CtrlPt.LeftMiddle };

            var pts = new Point[] { new Point(topLeft.X, topLeft.Y) };
            client2Img.TransformPoints(pts);
            _absRect.X = pts[0].X;
            _absRect.Y = pts[0].Y;
        }

        public override void Draw(Graphics g, Annotation ano)
        {
            Pen pen = new Pen(Brushes.LightYellow);
            
            var rect = ano.Img2Client(AbsRect);
            g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);

            pen.Dispose();
        }

        public override void OnDragCreating(PointF p)
        {
            var x = _absRect.X;
            var y = _absRect.Y;
            AbsRect = new RectangleF(x, y, p.X - x, p.Y - y);
        }

        public override void Move(PointF delta)
        {
            AbsRect = new RectangleF(_absRect.X + delta.X, _absRect.Y + delta.Y, _absRect.Width, _absRect.Height);
        }
    }
}