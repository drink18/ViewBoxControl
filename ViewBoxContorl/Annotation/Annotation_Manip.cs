using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewBoxContorl.Annotation
{
    public class ManipCommand
    {
        protected BaseElement _ele;
        protected Point _lastMousePos;
        protected Annotation _ano;

        public ManipCommand(BaseElement ele, Point p, Annotation ano)
        {
            _ele = ele;
            _lastMousePos = p;
            _ano = ano;
        }

        public virtual void OnMouseMove(Point p)
        {
            _lastMousePos = p;
        }
        public virtual void OnMouseUp(Point p) { }
        public virtual void OnMouseDown(Point p) { }

        public virtual void EndCmd() { _ano.ShapeChangedEvt(_ele); }
    }

    public class MoveCommand : ManipCommand
    {
        public MoveCommand(BaseElement ele, Point p, Annotation ano)
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
        BaseElement.CtrlPt _cpt;
        public DragCtrlPtCommand(BaseElement ele, BaseElement.CtrlPt cpt, Point p, Annotation ano)
            :base(ele, p, ano)
        {
            _cpt = cpt;
        }

        public override void OnMouseMove(Point p)
        {
            _ele.Manipulate(_cpt, _ano.Client2ImgVec(new Point(p.X - _lastMousePos.X, p.Y - _lastMousePos.Y)));
            _ano.ShapeChangingEvt(_ele);
            base.OnMouseMove(p);
        }
    }
}
