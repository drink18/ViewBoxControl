﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace ViewBoxContorl
{
    public partial class ViewBox : PictureBox
    {
        public enum MouseOps
        {
            PosLvl
        }
        public MouseOps MouseOpMode { get; set; } = MouseOps.PosLvl;
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
            _dragX0 = e.X;
            _dragY0 = e.Y;
        }

        private void vbxImg_MouseMove(object sender, MouseEventArgs e)
        {
            int dx = (e.X - _dragX0);
            int dy = (e.Y - _dragY0);
            if ((e.Button & WinLvlAdjustingBtn) == WinLvlAdjustingBtn && MouseOpMode == MouseOps.PosLvl)
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

    }
}
