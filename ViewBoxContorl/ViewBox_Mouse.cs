﻿using System;
using System.Collections.Generic;
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
        public MouseButtons WinLvlAdjustingBtn = MouseButtons.Left;
        public MouseButtons PosChangeBtn = MouseButtons.Right;

        int _dragX0;
        int _dragY0;

        public delegate void WinChangedEvt(int oldVal, int newVal);
        public delegate void LvlChangedEvt(int oldVal, int newVal);

        public WinChangedEvt OnWinChanged = (o, n) => { };
        public LvlChangedEvt OnLvlChanged = (o, n) => { };

        public int AccelModeScale { get; set; } = 3;

        private void vbxImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (InterationMode == Interaction.Browse)
            {
                BrowseMouseDown(sender, e);
            }
            else
            {
                if (InterationMode == Interaction.Annotation && NewAnnotationType != null)
                {
                    _annotation.SetupCreationContext(NewAnnotationType);
                }
                _annotation.MouseDown(sender, e);
            }
        }

        private void View_MouseMove(object sender, MouseEventArgs e)
        {
            if(InterationMode == Interaction.Browse)
            {
                BrowseMouseMove(sender, e);
                if (ShowPixelValue)
                {
                    View.Invalidate();
                }
            }
            else
            {
                _annotation.MouseMove(sender, e);
                View.Invalidate();
            }

        }

        private void vbxImg_MouseWheel(object sender, MouseEventArgs e)
        {
            var delta = e.Delta / 120.0f * 0.1f;
            SizeScale += delta;
        }

        private void vbxImg_MouseUp(object sender, MouseEventArgs e)
        {
            if (InterationMode == Interaction.Browse)
            {
            }
            else
            {
                _annotation.MouseUp(sender, e);
            }
        }

#region browse mouse evet
        private void BrowseMouseDown(object sender, MouseEventArgs e)
        {
            _dragX0 = e.X;
            _dragY0 = e.Y;
        }

        private void BrowseMouseMove(object sender, MouseEventArgs e)
        { 
            int dx = (e.X - _dragX0);
            int dy = (e.Y - _dragY0);
            if ((e.Button & WinLvlAdjustingBtn) == WinLvlAdjustingBtn )
            {
                bool accelMode = Control.ModifierKeys == Keys.Shift;
                int scale = accelMode ? AccelModeScale : 1;

                int sdx = dx * scale;
                int sdy = dy * scale;
                SetWinAndLevel((short)(Win + sdx), (short)(Lev + sdy));
            }
            else if((e.Button & PosChangeBtn) == PosChangeBtn)
            {
                TranslateObserverPos(-dx, -dy);
            }

            _dragX0 = e.X;
            _dragY0 = e.Y;
        }
#endregion

#region annoation mouse event
#endregion

    }
}
