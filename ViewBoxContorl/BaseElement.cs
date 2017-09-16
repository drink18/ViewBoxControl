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
        public static int MinSizeX = 4;
        public static int MinSizeY = 4;
        virtual public void Draw(Graphics g, Annotation ano) { }
        virtual public void Move(PointF delta) { }
        virtual public void Manipulae() { }

        protected RectangleF _absRect = new RectangleF(0, 0, MinSizeX, MinSizeY); //rect in absolute coord system
        public RectangleF AbsRect {
            get { return _absRect; }
            set { _absRect = value; }
        }
        
        virtual public void DrawControlPoints(Graphics g, Annotation ano) { }
        virtual public void OnDragCreating(PointF p) {}
    }
}
