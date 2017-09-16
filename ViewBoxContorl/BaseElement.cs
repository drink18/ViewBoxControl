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
        virtual public void Move(Point delta) { }
        virtual public void Manipulae() { }

        protected Rectangle _absRect = new Rectangle(0, 0, MinSizeX, MinSizeY); //rect in absolute coord system
        public Rectangle AbsRect {
            get { return _absRect; }
            set { _absRect = value; }
        }
        
        virtual public void DrawControlPoints(Graphics g, Annotation ano) { }
        virtual public void OnDragCreating(Point p) {}
    }
}
