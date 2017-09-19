using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewBoxContorl.Annotation.Data
{
    public class ShapeSnapshotData
    {
        public RectangleF LocalRect;
        public Matrix Transform;
    }

    public class LineData : ShapeSnapshotData
    {
        public PointF P0;
        public PointF P1;
    }
}
