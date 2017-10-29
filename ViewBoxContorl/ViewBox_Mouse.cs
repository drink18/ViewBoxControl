using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using ViewBoxContorl.Annotation;

namespace ViewBoxContorl
{
    public partial class ViewBoxForm : UserControl
    {
        public enum MouseOps
        {
            None,
            WinLvl,
            Pan,
            Zoom
        }

        [Browsable(false)]
        public MouseOps MouseOpMode { get; set; } = MouseOps.None;
        public MouseButtons WinLvlAdjustingBtn = MouseButtons.Left;
        public MouseButtons PanButton = MouseButtons.Right;

        int _dragX0;
        int _dragY0;
        Point _origMouseDownPos;

        #region delegtaion
        public delegate void WinLvlChangedEvt(ViewBoxForm vb);
        public delegate void MouseRightClickEvt(object sender, MouseEventArgs e);
        #endregion

        #region Events
        public WinLvlChangedEvt OnWinLvlChangingByUI = (o) => { };
        public WinLvlChangedEvt OnWinLvlChangedByUI = (o) => { };
        public MouseRightClickEvt MouseRightClick = (o, b) => { };
        #endregion  

        public int AccelModeScale { get; set; } = 3;

        private void vbxImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (NewAnnotationType != null)
            {
                _annotation.SetupCreationContext(NewAnnotationType);
            }
            var handled = _annotation.MouseDown(sender, e);
            if (!handled)
            {
                BrowseMouseDown(sender, e);
            }
        }

        private void View_MouseMove(object sender, MouseEventArgs e)
        {
            var handled = _annotation.MouseMove(sender, e);
            if (!handled)
            {
                BrowseMouseMove(sender, e);
            }
            View.Invalidate();
        }

        private void vbxImg_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!zoomable)
                return;

            var delta = e.Delta / 120.0f * 0.1f;
            ZoomFactor += delta;
            OnZoomFactorChangedByUI(this);
        }

        private void vbxImg_MouseUp(object sender, MouseEventArgs e)
        {
            var handled = _annotation.MouseUp(sender, e);

            if(!handled)
            {
                BrowseMouseUp(sender, e);
            }
        }

#region browse mouse evet
        private void BrowseMouseDown(object sender, MouseEventArgs e)
        {
            _dragX0 = e.X;
            _dragY0 = e.Y;
            _origMouseDownPos = new Point(e.X, e.Y);
        }

        private void BrowseMouseMove(object sender, MouseEventArgs e)
        { 
            int dx = (e.X - _dragX0);
            int dy = (e.Y - _dragY0);
            if(MouseOpMode == MouseOps.None)
            {
                if( (Math.Abs(dx) > 0 || Math.Abs(dy) > 0))
                {
                    if ((e.Button & WinLvlAdjustingBtn) == WinLvlAdjustingBtn)
                    {
                        MouseOpMode = MouseOps.WinLvl;
                    }
                    if ((e.Button & PanButton) == PanButton)
                    {
                        MouseOpMode = MouseOps.Pan;
                    }
                }
            }
            else if(MouseOpMode == MouseOps.WinLvl)
            {
                bool accelMode = Control.ModifierKeys == Keys.Shift;
                int scale = accelMode ? AccelModeScale : 1;

                int sdx = dx * scale;
                int sdy = dy * scale;
                SetWinAndLevel((short)(Win + sdx), (short)(Lev + sdy));
                OnWinLvlChangingByUI(this);
            }
            else if(MouseOpMode == MouseOps.Pan)
            {
                if (pannable)
                {
                    TranslateObserverPos(-dx, -dy);
                    OnPanPositionChangingByUI(this);
                }
            }

            _dragX0 = e.X;
            _dragY0 = e.Y;
        }


        private void BrowseMouseUp(object sender, MouseEventArgs e)
        {
            bool hasMoved = _origMouseDownPos.X != e.X || _origMouseDownPos.Y != e.Y;
            if (hasMoved)
            {
                if (MouseOpMode == MouseOps.WinLvl)
                {
                    OnWinLvlChangedByUI(this);
                }
                else if (MouseOpMode == MouseOps.Pan)
                {
                    OnPanPositionChangedByUI(this);
                }
            }
            else
            {
                //did't move we want to fire mouse right clicked
                if(e.Button == MouseButtons.Right)
                {
                    MouseRightClick(sender, e);
                }

            }

            MouseOpMode = MouseOps.None;
        }
#endregion

#region annoation mouse event
#endregion

    }
}
