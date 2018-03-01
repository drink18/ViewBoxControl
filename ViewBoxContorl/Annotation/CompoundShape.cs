using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewBoxContorl.Annotation
{
    public class CompoundShape : Shape
    {
        List<Shape> _subShapes = new List<Shape>();

        public List<Shape> SubShapes { get { return _subShapes; } }

        public CompoundShape()
        {
            ValidPickPts = new HashSet<CtrlPt>() {
                   CtrlPt.Rotation,
               };
        }

        public void AddSubShapes(Shape[] subShapes)
        {
            _subShapes.AddRange(subShapes);
            OnSubshapeListChanged();
        }

        public void AddSubShape(Shape s)
        {
            _subShapes.Add(s);
            OnSubshapeListChanged();
        }
        public void RemoveSubShape(Shape s)
        {
            if(_subShapes.Exists(o=>o == s))
            {
                _subShapes.Remove(s);
            }
            OnSubshapeListChanged();
        }

        public void OnSubshapeListChanged()
        {
            _updateRect();
            UpdateCtrlPts();
        }

        public override void Draw(Graphics g, Matrix view, float s, float strokeWidth, Color strokeColor)
        {
            var subView = view.Clone();
            subView.Multiply(_transform);
            foreach (var sub in _subShapes)
            {
                sub.Draw(g, subView, s, strokeWidth, strokeColor);
            }
        }

        public override bool IsPointInsideShape(PointF p)
        {
            var localP = _getPointInLocal(p);
            foreach (var sub in _subShapes)
            {
                if (sub.IsPointInsideShape(localP))
                    return true;
            }

            return false;
        }

        public void DrawSubControlPoints(Graphics g, Matrix view, float scale)
        {
            var m = view.Clone();
            m.Multiply(_transform);

            foreach (var sub in _subShapes)
            {
                sub.DrawControlPoints(g, m, scale);
            }
        }

        public Tuple<Shape, CtrlPt> PickSubControlPoint(PointF pImg)
        {
            var p = _getPointInLocal(pImg);
            foreach (var sub in _subShapes)
            {
                var ctrlPtr = sub.PickControlPoint(p);
                if (ctrlPtr != null)
                {
                    return ctrlPtr;
                }
            }
            return null;
        }

        public override void RenderAuxilaries(Graphics g, Matrix view, float scale)
        {
            DrawBoundingBox(g, view, scale);
            DrawControlPoints(g, view, scale);
        }

        public void _updateRect()
        {
            var rect = _subShapes[0].GetAABB();
            for(int i = 1; i < _subShapes.Count; ++i)
            {
                rect = MergeRect(rect, _subShapes[i].GetAABB());
            }

            _localRect = rect;
        }

        public override void Move(PointF delta)
        {
            var e = _transform.Elements;
            _transform = new Matrix(e[0], e[1], e[2], e[3], _transform.OffsetX + delta.X, _transform.OffsetY + delta.Y);
        }
    }
}
