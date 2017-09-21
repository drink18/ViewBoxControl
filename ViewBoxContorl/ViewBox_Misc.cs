using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewBoxContorl.Annotation;

namespace ViewBoxContorl
{
    /// <summary>
    /// Utilities for adding annotation shapes programmatically
    /// Notice that all coordinates in function arguments are in Image space (unit is hence pixel)
    /// </summary>
    public partial class ViewBoxForm
    {
        /// <summary>
        /// Add an annotation shape
        /// </summary>
        /// <param name="s"></param>
        public void AddShape(Shape s)
        {
            _annotation.AddShapeToList(s);
            View.Refresh();
        }

        /// <summary>
        /// Add an ellipse annotation
        /// </summary>
        /// <param name="center">center of ellipse</param>
        /// <param name="axis1">primary axis</param>
        /// <param name="axis2">secondary axis</param>
        public void AddEllipse(PointF center, float axis1, float axis2)
        {
            var e = new Ellipse(center, axis1, axis2);
            AddShape(e);
        }

        /// <summary>
        /// Add a Line annotation
        /// </summary>
        /// <param name="p0">Point 0</param>
        /// <param name="p1">Poin 1</param>
        public void AddLine(PointF p0, PointF p1)
        {
            var l = new Line(p0, p1);
            AddShape(l);
        }

        /// <summary>
        /// Add a Box annotation
        /// </summary>
        /// <param name="topleft">top left of rectangle</param>
        /// <param name="bottomRight">Bottom right of rectangle</param>
        public void AddBox(PointF topleft, PointF bottomRight)
        {
            var box = new Box(topleft, bottomRight);
            AddShape(box);
        }

        /// <summary>
        /// Add a Box annotation
        /// </summary>
        /// <param name="center">center of box</param>
        /// <param name="width">width of box</param>
        /// <param name="height">height of box</param>
        public void AddBox(PointF center, float width, float height)
        {
            var box = new Box(center, width, height);
            AddShape(box);
        }
    }
}
