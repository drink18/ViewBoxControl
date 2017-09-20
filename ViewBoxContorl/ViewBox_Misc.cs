using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewBoxContorl.Annotation;

namespace ViewBoxContorl
{
    public partial class ViewBoxForm
    {
        public void AddShape(Shape s)
        {
            _annotation.ShapeList.Add(s);
            View.Refresh();
        }

        public void AddEllipse(PointF center, float axis1, float axis2)
        {
            var e = new Ellipse(center, axis1, axis2);
            _annotation.AddShapeToList(e);

            View.Refresh();
        }

        public void AddLine(PointF p0, PointF p1)
        {
            var l = new Line(p0, p1);

            _annotation.AddShapeToList(l);
            View.Refresh();
        }

        public void AddBox(PointF topleft, PointF bottomRight)
        {
            var box = new Box(topleft, bottomRight);

            _annotation.AddShapeToList(box);
            View.Refresh();
        }
    }
}
