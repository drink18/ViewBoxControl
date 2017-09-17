using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ViewBoxContorl.Annotation
{
    public partial class Annotation
    {
        List<BaseElement> _elementsList = new List<BaseElement>();
        ViewBox _vb;

        public Annotation(ViewBox vb)
        {
            _vb = vb;
        }


        AnnotationSelection _selection = new AnnotationSelection();

        #region mouse crap
        Point _mouseDownPos;
        #endregion
        #region mainp
        ManipCommand _cmd = null;
        #endregion

        #region utils
        public Tuple<BaseElement, BaseElement.CtrlPt> PickCtrlPts(PointF p)
        {
            foreach(var e in _selection.SelectedElements)
            {
                var ctrlPt = e.PickControlPoint(p, this);
                if(ctrlPt != BaseElement.CtrlPt.None)
                {
                    return new Tuple<BaseElement, BaseElement.CtrlPt>(e, ctrlPt);
                }
            }

            return null;
        }

        // coord in client area to coord in element
        public BaseElement PickElement(Point point)
        {
            foreach (var ele in _elementsList)
            {
                var rect = Img2Client(ele.AbsRect);
                if (rect.Contains(point))
                {
                    return ele;
                }
            }
            return null;
        }

        public Point Client2Img(Point p)
        {
            var tp = new Point[] { new Point(p.X, p.Y) };
            _vb.matClientToImage.TransformPoints(tp);
            return tp[0];
        }

        public Point Img2Client(Point p)
        {
            var tp = new Point[] { new Point(p.X, p.Y) };
            _vb.matImageToClient.TransformPoints(tp);
            return tp[0];
        }

        public PointF Client2Img(PointF p)
        {
            var tp = new PointF[] { new PointF(p.X, p.Y) };
            _vb.matClientToImage.TransformPoints(tp);
            return tp[0];
        }

        public PointF Img2Client(PointF p)
        {
            var tp = new PointF[] { new PointF(p.X, p.Y) };
            _vb.matImageToClient.TransformPoints(tp);
            return tp[0];
        }

        public Point Client2ImgVec(Point p)
        {
            var tp = new Point[] { new Point(p.X, p.Y) };
            _vb.matClientToImage.TransformVectors(tp);
            return tp[0];
        }

        public Point Img2ClientVec(Point p)
        {
            var tp = new Point[] { new Point(p.X, p.Y) };
            _vb.matImageToClient.TransformVectors(tp);
            return tp[0];
        }

        public PointF Client2ImgVec(PointF p)
        {
            var tp = new PointF[] { new PointF(p.X, p.Y) };
            _vb.matClientToImage.TransformVectors(tp);
            return tp[0];
        }

        public PointF Img2ClientVec(PointF p)
        {
            var tp = new PointF[] { new PointF(p.X, p.Y) };
            _vb.matImageToClient.TransformVectors(tp);
            return tp[0];
        }

        public Rectangle Client2Img(Rectangle r)
        {
            var tp = new Point[] { new Point(r.X, r.Y), new Point(r.Right, r.Bottom) };
            _vb.matClientToImage.TransformPoints(tp);

            return new Rectangle(tp[0].X, tp[0].Y, tp[1].X - tp[0].X, tp[1].Y - tp[0].Y);
        }

        public Rectangle Img2Client(Rectangle r)
        {
            var tp = new Point[] { new Point(r.X, r.Y), new Point(r.Right, r.Bottom) };
            _vb.matImageToClient.TransformPoints(tp);

            return new Rectangle(tp[0].X, tp[0].Y, tp[1].X - tp[0].X, tp[1].Y - tp[0].Y);
        }

        public RectangleF Client2Img(RectangleF r)
        {
            var tp = new PointF[] { new PointF(r.X, r.Y), new PointF(r.Right, r.Bottom) };
            _vb.matClientToImage.TransformPoints(tp);

            return new RectangleF(tp[0].X, tp[0].Y, tp[1].X - tp[0].X, tp[1].Y - tp[0].Y);
        }

        public RectangleF Img2Client(RectangleF r)
        {
            var tp = new PointF[] { new PointF(r.X, r.Y), new PointF(r.Right, r.Bottom) };
            _vb.matImageToClient.TransformPoints(tp);

            return new RectangleF(tp[0].X, tp[0].Y, tp[1].X - tp[0].X, tp[1].Y - tp[0].Y);
        }
        #endregion

        #region event handler
        public void MouseMove(object sender, MouseEventArgs e)
        {
            if(_cmd != null)
            {
                _cmd.OnMouseMove(new Point(e.X, e.Y ));
                _vb.Invalidate();
            }
            else if(_creating)
            {
                _creatingEle.OnDragCreating(Client2Img(new Point(e.X, e.Y)));
                _vb.Invalidate();
            }
        }

        public void MouseUp(object sender, MouseEventArgs e)
        {
            if (_creating)
            {
                if (_creatingEle.IsValid())
                {
                    _elementsList.Add(_creatingEle);
                }
                _creating = false;
                _creatingEle = null;
                _vb.Invalidate();
            }

            _cmd = null;
        }

        public void MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDownPos = new Point(e.X, e.Y);
            var p = new Point(e.X, e.Y);
            if (CurrentInteractContext == InteractContext.Create && NewElementType != null)
            {
                _creatingEle = CreateNewElement(NewElementType, p, _vb.matClientToImage);
                _creating = true;
                NewElementType = null;
            }
            else
            {
                // first check if we can pick ctrl pt of selected items
                var ctrlP = PickCtrlPts(p);
                if (ctrlP != null)
                {
                    _cmd = new DragCtrlPtCommand(ctrlP.Item1, ctrlP.Item2, p, this);
                }
                else
                {
                    var ele = PickElement(p);
                    if (ele != null)
                    {
                        if (_selection.IsSelected(ele))
                        {
                            // move
                            _cmd = new MoveCommand(ele, p, this);
                        }
                        else
                        {
                            _selection.ClearSelection();
                            _selection.AddToSelection(ele);
                        }
                    }
                    else
                    {
                        _selection.ClearSelection();
                    }
                    _vb.Invalidate();
                }
            }
        }

        public void OnPaint(PaintEventArgs args)
        {
            foreach(var e in _elementsList)
            {
                e.Draw(args.Graphics, this);
                if(_selection.IsSelected(e))
                {
                    e.DrawControlPoints(args.Graphics, this);
                }
            }

            if(_creatingEle != null)
                _creatingEle.Draw(args.Graphics, this);
        }
        #endregion


    }
}
