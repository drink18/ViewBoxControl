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
        List<Shape> _shapeList = new List<Shape>();
        public List<Shape> ShapeList
        {
            get { return _shapeList; }
        }
        ViewBoxForm _vb;

        public Annotation(ViewBoxForm vb)
        {
            _vb = vb;

            ShapeCreatedEvt += OnShapeCreated_Undo;
            ShapeDeletedEvt += OnShapeDeleted_Undo;
            ShapeChangeEndEvt += OnShapeChanged_Undo;
        }

        AnnotationSelection _selection = new AnnotationSelection();
        public Shape[] SelectedShapes
        {
            get
            {
                return _selection.SelectedShapes.ToArray();
            }

        }

        #region mouse crap
        Point _mouseDownPos;
        #endregion
        #region mainp
        ManipCommand _cmd = null;
        #endregion

        #region display control
        public bool ShowStatistics { get; set; }
        public bool ShowPixelValue { get; set; }
        #endregion

        public Matrix matImg2Client
        {
            get { return _vb.matImageToClient; }
        }

        public Matrix matClient2Img
        {
            get { return _vb.matClientToImage; }
        }

        public float ViewScale
        {
            get { return _vb.ZoomFactor; }
        }

        #region utils
        public Tuple<Shape, Shape.CtrlPt> PickCtrlPts(PointF pImg)
        {
            foreach(var e in _selection.SelectedShapes)
            {
                var ctrlPt = e.PickControlPoint(pImg);
                if(ctrlPt != null)
                {
                    return ctrlPt;
                }
            }

            return null;
        }

        // coord in client area to coord in element
        public Shape PickShape(Point point)
        {
            foreach (var ele in _shapeList)
            {
                var p = Client2Img(point);
                if (ele.IsPointInsideShape(new PointF(p.X, p.Y)))
                    return ele;
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

        #region Event raising
        public delegate void ShapeChangeBegin(Shape e, ManipCommand cmd);
        public delegate void ShapeChanging(Shape e, ManipCommand cmd);
        public delegate void ShapeChangeEnd(Shape e, ManipCommand cmd);
        public delegate void ShapeCreating(Shape e);
        public delegate void ShapeCreated(Shape e);
        public delegate void ShapeDeleted(Shape e);

        public ShapeChangeBegin ShapeChangeBeginEvt = (o,c) => { };
        public ShapeChanging ShapeChangingEvt = (o,c)=> { };
        public ShapeChangeEnd ShapeChangeEndEvt = (o,c)=> { };
        public ShapeCreating ShapeCreatingEvt = o=> { };
        public ShapeCreated ShapeCreatedEvt = o=> { };
        public ShapeDeleted ShapeDeletedEvt = o => { };
        #endregion  

        #region event handler
        public bool MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return false;

            bool handled = false;
            if(_cmd != null)
            {
                _cmd.OnMouseMove(new Point(e.X, e.Y ));
                _vb.Refresh();
                handled = true;
            }
            else if(_creating)
            {
                _creatingEle.OnDragCreating(Client2Img(new Point(e.X, e.Y)));
                ShapeChangingEvt(_creatingEle, null);
                _vb.Refresh();
                handled = true;
            }
            return handled;
        }

        public bool MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return false;

            bool handled = false;
            if (_creating)
            {
                if (_creatingEle.IsValid())
                {
                    _shapeList.Add(_creatingEle);
                    ShapeCreatedEvt(_creatingEle);
                }
                _creating = false;
                _creatingEle = null;
                _vb.Invalidate();
                handled = true;
            }

            if(_cmd != null)
            {
                _cmd.EndCmd();
                handled = true;
            }
            _cmd = null;

            return handled;
        }

        public bool MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return false;

            bool handled = false;
            _mouseDownPos = new Point(e.X, e.Y);
            var p = new Point(e.X, e.Y);
            if (CurrentInteractContext == InteractContext.Create && NewElementType != null)
            {
                _creatingEle = CreateNewElement(NewElementType, p, _vb.matClientToImage);
                ShapeCreatingEvt(_creatingEle);
                _creating = true;
                NewElementType = null;
                handled = true;
            }
            else
            {
                // first check if we can pick ctrl pt of selected items
                var ctrlP = PickCtrlPts(Client2Img(p));
                if (ctrlP != null)
                {
                    _cmd = new DragCtrlPtCommand(ctrlP.Item1, ctrlP.Item2, p, this);
                }
                else
                {
                    var shape = PickShape(p);
                    if (shape != null)
                    {
                        if (_selection.IsSelected(shape))
                        {
                            // move
                            _cmd = new MoveCommand(shape, p, this);
                        }
                        else
                        {
                            _selection.ClearSelection();
                            _selection.AddToSelection(shape);
                        }

                        handled = true;
                    }
                    else
                    {
                        if (_selection.SelectedShapes.Count > 0)
                        {
                            _selection.ClearSelection();
                            handled = true;
                        }
                    }
                    _vb.Invalidate();
                }
            }
            return handled;
        }

        public void OnPaint(PaintEventArgs args)
        {
            args.Graphics.Transform.Reset();
            var viewMat = matImg2Client;
            foreach(var e in _shapeList)
            {
                e.Draw(args.Graphics, viewMat, ViewScale, _vb.AnnotationStrokeWidth, _vb.AnnotationShapeColor);
                if(_selection.IsSelected(e))
                {
                    e.RenderAuxilaries(args.Graphics, viewMat, ViewScale);
                }
            }

            if(_creatingEle != null)
                _creatingEle.Draw(args.Graphics, viewMat, ViewScale, _vb.AnnotationStrokeWidth, _vb.AnnotationShapeColor);
        }
        #endregion

        protected void DeleteShape(Shape e)
        {
            _shapeList.Remove(e);
            _selection.RemoveFromSelectoin(e);
        }

        public void RemoveShape(Shape e)
        {
            DeleteShape(e);
            ShapeDeletedEvt(e);
        }

        public void ClearAll()
        {
            _shapeList.Clear();
            _selection.ClearSelection();
        }
    }
}
