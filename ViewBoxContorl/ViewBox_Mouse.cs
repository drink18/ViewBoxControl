using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewBoxContorl
{
    public partial class ViewBox : PictureBox
    {
        public enum MouseOps
        {
            PosLvl
        }
        MouseOps MouseOpMode { get; set; } = MouseOps.PosLvl;
        int _dragX0;
        int _dragY0;

        public delegate void WinChangedEvt(int oldVal, int newVal);
        public delegate void LvlChangedEvt(int oldVal, int newVal);

        public WinChangedEvt OnWinChanged = (o, n) => { };
        public LvlChangedEvt OnLvlChanged = (o, n) => { };


        private void OnMouseDrag(object sender, GiveFeedbackEventArgs e)
        {
            if ((e.Effect & DragDropEffects.Move) != DragDropEffects.Move)
                return;

            if (MouseOpMode == MouseOps.PosLvl)
            {
                int dx = (MousePosition.X - _dragX0);
                int dy = (MousePosition.Y - _dragY0);

                _dragX0 = dx;
                _dragY0 = dy;

                Win = (short)(Win + dx);
                Lev = (short)(Lev + dy);
            }
        }
        private void vbxImage_MouseDown(object sender, MouseEventArgs e)
        {
            _dragX0 = e.X;
            _dragY0 = e.Y;
        }

        private void vbxImg_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && MouseOpMode == MouseOps.PosLvl)
            {
                int dx = (e.X - _dragX0);
                int dy = (e.Y - _dragY0);

                _dragX0 = e.X;
                _dragY0 = e.Y;

                Win = (short)(Win + dx);
                Lev = (short)(Lev + dy);
            }
        }
    }
}
