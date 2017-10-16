using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Diagnostics;
using ViewBoxContorl.Annotation;

namespace ViewBoxContorl
{
    public partial class ViewBoxForm : UserControl
    {
        [Browsable(true)]
        #region Win
        Int16 win;

        public Int16 Win
        {
            get { return win; }
            set
            {
                var old = win;
                _setWin(value);
                OnWinChanged(old, win);
                setGrayLevelData();
            }
        }


        #endregion
        #region Lev
        Int16 lev;

        public Int16 Lev
        {
            get { return lev; }
            set
            {
                var old = lev;
                _setLevel(value);
                OnLvlChanged(old, lev);
                setGrayLevelData();
            }
        }
        #endregion

        #region MaxPixel
        private short maxPixel;

        public short MaxPixel
        {
            get { return maxPixel; }
            //set { maxPixel = value; }
        }
        #endregion
        #region MinPixel
        short minPixel;

        public short MinPixel
        {
            get { return minPixel; }
            //set { minPixel = value; }
        }
        #endregion
        #region NoRow
        int noRow = 100;

        public int NoRow
        {
            get { return noRow; }
            set { noRow = value;
                ResetObserverRect();
            }
        }
        #endregion
        #region NoCol
        int noCol = 100;

        public int NoCol
        {
            get { return noCol; }
            set { noCol = value;
                ResetObserverRect();
            }
        }
        #endregion

        #region FovRow
        private double fovRow;
        public double FovRow
        {
            get { return fovRow; }
            set { fovRow = value; }
        }
        #endregion
        #region FovCol
        private double fovCol;
        public double FovCol
        {
            get { return fovCol; }
            set { fovCol = value; }
        }
        #endregion
        #region Zoomable
        bool zoomable = false;

        public bool Zoomable
        {
            get { return zoomable; }
            set { zoomable = value; }
        }
        #endregion
        #region Pannable
        bool pannable = false;

        public bool Pannable
        {
            get { return pannable; }
            set { pannable = value; }
        }
        #endregion

        #region Col spacing
        float _colSpacing = 1.0f;
        public float ColSpacing {
            get { return _colSpacing; }
            set
            {
                _colSpacing = value;
                _updateObserverRect();
                RenderToPictureBox();
            }
        }
        #endregion

        #region Row spacing
        float _rowSpacing = 1.0f;
        public float RowSpacing
        {
            get { return _rowSpacing; }
            set
            {
                _rowSpacing = value;
                _updateObserverRect();
                RenderToPictureBox();
            }
        }
        #endregion

        #region PixelData
        short[,] pixelData;

        public short[,] PixelData
        {
            get { return pixelData; }
            set { pixelData = value; }
        }
        #endregion
        #region GrayLevelData
        byte[] grayLevelData;

        public byte[] GrayLevelData
        {
            get { return grayLevelData; }
            set { grayLevelData = value; }
        }
        Bitmap _rawBmp; // raw bmp built from gray level data (same size)
        #endregion

        public bool HasImage
        {
            get { return _hasImage(); }
        }

        public Button ImageView
        {
            get { return this.View; }
        }

        public Image Image
        {
            get { return View.Image; }
            set { View.Image = value; }
        }

        public bool ShowStatistics { get; set; }
        public bool ShowPixelValue { get; set; }
        public Shape[] AnnotationShapes { get { return _annotation.ShapeList.ToArray();} }

        public Type NewAnnotationType = null;

        #region privates
        Graphics _cachedGraphics;
        PixelFormat _imgFormat = PixelFormat.Format24bppRgb;
        Annotation.Annotation _annotation;
        #endregion

        public ViewBoxForm()
        {
            InitializeComponent();
            this.ResizeRedraw = true;
            this.MouseWheel += vbxImg_MouseWheel;
            _annotation =  new Annotation.Annotation(this);
            _annotation.ShapeCreatedEvt += _annotationShapeCreated_ROI;
            _annotation.ShapeChangingEvt += vbxImage_AnnotationShapeChanging;
            _annotation.ShapeChangeEndEvt += _annotationShapeChanged_ROI;
        }

        protected override void OnCreateControl()
        {
            this.View.Image = new Bitmap(this.Width, this.Height, _imgFormat);
            _cachedGraphics = Graphics.FromImage(this.View.Image);
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void _setWin(short value)
        {
            if (value == win)
                return;

            var old = win;
            if (value < 1)
            {
                win = 1;
            }
            else
            {
                win = value;
            }
        }

        private void _setLevel(short value)
        {
            if (lev == value)
                return;

            lev = value;
        }

        private void _renderWithObserverRect(Bitmap srcImg, Rectangle destRectInPicture)
        {
            var graphics = Graphics.FromImage(this.View.Image);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Color.Black);
            graphics.DrawImage(srcImg, destRectInPicture, SampleRect, GraphicsUnit.Pixel);
            graphics.Dispose();
            Refresh();
        }

        public void RenderToPictureBox()
        {
            if (this.View.Image == null || _rawBmp == null)
                return;

            _renderWithObserverRect(_rawBmp, new Rectangle(0, 0, Width, Height)); 
        }

        public byte getTransferedPixedlVal(short rawVal)
        {
            short ceil = (short)(Lev + Win / 2);
            short floor = (short)(Lev - Win / 2);
            double slope = 255D / Win;

            byte ret = 0;
            if (rawVal > ceil)
            {
                ret = 255;
            }
            else if (rawVal < floor)
            {
                ret = 0;
            }
            else
            {
               ret = (byte)(slope * (rawVal - floor));//(byte)Math.Round( slope * (PixelData[i, j] - floor));
            }

            return ret;
        }

        public void SetWinAndLevel(short win, short lvl)
        {
            var oldWin = Win;
            var oldLvl = Lev;
            _setWin(win);
            _setLevel(lvl);
            OnWinChanged(oldWin, win);
            OnLvlChanged(oldLvl, lvl);
            setGrayLevelData();
        }

        public void setGrayLevelData()
        {
            if (PixelData != null)
            {
                if (_rawBmp == null || (_rawBmp.Width != NoCol || _rawBmp.Height != NoRow))
                    _rawBmp = new Bitmap(NoCol, NoRow, _imgFormat);

                _rawBmp = _buildRawBitMap(_rawBmp, GrayLevelData);

                RenderToPictureBox();
            }
        }

        private void ViewBox_ClientSizeChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("ViewBox_ClientSizeChanged");
        }

        public void readPixelData(byte[] rawData)
        {
            try
            {
                if (rawData.Length != 2 * NoCol * NoRow)
                {
                    throw new RawDataSizeErrorException(NoCol, NoRow, rawData.Length);
                }
                Bitmap bmpBk = new Bitmap(this.Width, this.Height, PixelFormat.Format24bppRgb);
                this.View.Image = bmpBk;
                PixelData = new Int16[NoRow, NoCol];
                GrayLevelData = new byte[NoRow * NoCol];
                maxPixel = Int16.MinValue;
                minPixel = Int16.MaxValue;
                for (int i = 0; i < NoRow; i++)
                {
                    for (int j = 0; j < NoCol; j++)
                    {
                        PixelData[i, j] = BitConverter.ToInt16(rawData, 2 * j + 2 * i * NoCol);
                        if (MaxPixel < PixelData[i, j])
                        {
                            maxPixel = PixelData[i, j];
                        }
                        if (MinPixel > PixelData[i, j])
                        {
                            minPixel = PixelData[i, j];
                        }
                    }
                }
                lev = (Int16)((MaxPixel + MinPixel) / 2);
                win = (Int16)(MaxPixel - MinPixel);
                setGrayLevelData();
            }
            catch (RawDataSizeErrorException ex)
            {
                MessageBox.Show(ex.row + "," + ex.col + "," + ex.size);
                return;
            }
        }

        public void readPixelData(Int16[] rawData)
        {
            try
            {
                if (rawData.Length != NoCol * NoRow)
                {
                    throw new RawDataSizeErrorException(NoCol, NoRow, rawData.Length);

                }
                Bitmap bmpBk = new Bitmap(this.Width, this.Height, PixelFormat.Format24bppRgb);
                this.View.Image = bmpBk;
                PixelData = new Int16[NoRow, NoCol];
                GrayLevelData = new byte[NoRow * NoCol];
                maxPixel = Int16.MinValue;
                minPixel = Int16.MaxValue;
                for (int i = 0; i < NoRow; i++)
                {
                    for (int j = 0; j < NoCol; j++)
                    {
                        PixelData[i, j] = rawData[j + i * NoCol];
                        if (MaxPixel < PixelData[i, j])
                        {
                            maxPixel = PixelData[i, j];
                        }
                        if (MinPixel > PixelData[i, j])
                        {
                            minPixel = PixelData[i, j];
                        }
                    }
                }
                lev = (Int16)((MaxPixel + MinPixel) / 2);
                win = (Int16)(MaxPixel - MinPixel);
                setGrayLevelData();
            }
            catch (RawDataSizeErrorException ex)
            {
                MessageBox.Show(ex.row + "," + ex.col + "," + ex.size);
                return;
            }
        }

        private void ViewBox_Resize(object sender, EventArgs e)
        {
            //Bitmap bmpBk = new Bitmap(this.Width, this.Height, PixelFormat.Format24bppRgb);
            Debug.WriteLine("ViewBox_Resize");
        }

        private void ViewBox_SizeChanged(object sender, EventArgs e)
        {
            if ((this.Width > 12) && (this.Height > 12))
            {
                //int width = this.Width;
                //int height = this.Height;
                Bitmap bmpBk = new Bitmap(this.Width, this.Height,  _imgFormat);

                this.View.Image = bmpBk;

                _updateObserverRect();
                if(_rawBmp != null)
                    RenderToPictureBox();

            }
        }

        private void ViewBox_VisibleChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("ViewBox_VisibleChanged");
        }

        private void ViewBox_LocationChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("ViewBox_LocationChanged");
        }

        private void ViewBox_Validated(object sender, EventArgs e)
        {
        }

        private bool _hasImage()
        {
            return grayLevelData != null;
        }

        private void vbxImage_AnnotationShapeChanging(Shape e, ManipCommand cmd)
        {
        }

        private void img_OnPaint(object sender, PaintEventArgs e)
        {
            _annotation.OnPaint(e);
            e.Graphics.ResetTransform();

            if(ShowPixelValue && _hasImage())
            {
                _renderMouseCursorInfo(e);
            }

            if (ShowStatistics)
            {
                foreach (var roi in _annotation.ShapeList)
                {
                    if (!_annotation.SelectedShapes.Contains(roi))
                        _renderROIInfo(e.Graphics, roi);
                }
            }
        }

        private void View_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (var ele in _annotation.SelectedShapes)
                {
                    _annotation.RemoveShape(ele);
                }

                this.View.Refresh();
            }

            if (e.KeyCode == Keys.Z && e.Control)
            {
                _annotation.UndoLastEvent();
                View.Refresh();
            }
        }


        // became focus
        private void View_Enter(object sender, EventArgs e)
        {
            View.FlatAppearance.BorderColor = Color.Red;
        }

        // lost focus
        private void View_Leave(object sender, EventArgs e)
        {
            View.FlatAppearance.BorderColor = Color.Black;
        }

    }
}
