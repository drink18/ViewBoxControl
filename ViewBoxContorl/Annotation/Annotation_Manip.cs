using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewBoxContorl.Annotation.Data;

namespace ViewBoxContorl.Annotation
{
    public class ManipCommand {
        protected Shape _ele;
        protected Point _lastMousePos;
        protected Annotation _ano;
        protected ShapeSnapshotData _initSnapshot;
        public ShapeSnapshotData InitSnapshot { get { return _initSnapshot; } }

        public ManipCommand(Shape shape, Point p, Annotation ano)
        {
            _ele = shape;
            _lastMousePos = p;
            _ano = ano;
            _initSnapshot = shape.ExportElement();
            
            _ano.ShapeChangeBeginEvt(_ele, this);
        }

        public virtual void OnMouseMove(Point p)
        {
            _lastMousePos = p;
        }
        public virtual void OnMouseUp(Point p) { }
        public virtual void OnMouseDown(Point p) { }

        public virtual void EndCmd()
        {
            _ano.ShapeChangeEndEvt(_ele, this);
        }
    }

    public class MoveCommand : ManipCommand
    {
        public MoveCommand(Shape ele, Point p, Annotation ano)
            :base(ele, p, ano)
        {
        }

        public override void OnMouseMove(Point p)
        {
            _ele.Move(_ano.Client2ImgVec(new Point(p.X - _lastMousePos.X, p.Y - _lastMousePos.Y)));
            base.OnMouseMove(p);
        }
    }

    public class DragCtrlPtCommand : ManipCommand
    {
        Shape.CtrlPt _cpt;
        public DragCtrlPtCommand(Shape ele, Shape.CtrlPt cpt, Point p, Annotation ano)
            :base(ele, p, ano)
        {
            _cpt = cpt;
        }

        public override void OnMouseMove(Point p)
        {
            _ele.Manipulate(_cpt, _ano.Client2ImgVec(new Point(p.X - _lastMousePos.X, p.Y - _lastMousePos.Y)));
            _ano.ShapeChangingEvt(_ele, this);
            base.OnMouseMove(p);
        }
    }
}
