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
    public partial class ViewBox : PictureBox
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
            set { noRow = value; }
        }
        #endregion
        #region NoCol
        int noCol = 100;

        public int NoCol
        {
            get { return noCol; }
            set { noCol = value; }
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


        public enum Interaction
        {
            Browse,
            Annotation
        }

        public Interaction InterationMode { get; set; } = Interaction.Browse;
        public Type NewAnnotationType = null;


        #region privates
        Graphics _cachedGraphics;
        PixelFormat _imgFormat = PixelFormat.Format24bppRgb;
        Annotation.Annotation _annotation;
        #endregion

        public ViewBox()
        {
            InitializeComponent();
            this.ResizeRedraw = true;
            this.MouseUp += OnMouseUpEvt;
            _annotation =  new Annotation.Annotation(this);
        }

        protected override void OnCreateControl()
        {
            this.Image = new Bitmap(this.Width, this.Height, _imgFormat);
            _cachedGraphics = Graphics.FromImage(this.Image);
        }

        private void RenderMouseCursorInfo(PaintEventArgs pe)
        {
            // pixel measure
            var e = PointToClient(MousePosition);
            var p = new PointF(e.X, e.Y);
            var pImg = _annotation.Client2Img(p);
            if (pImg.X >= 0 && pImg.Y >= 0 && pImg.X < NoCol && pImg.Y < NoRow)
            {
                var val = PixelData[(int)pImg.Y, (int)pImg.X];

                Graphics g = pe.Graphics;
                Font font = new Font("Arial", 10);
                SolidBrush brush = new SolidBrush(Color.LightYellow);
                g.DrawString(string.Format("{0}", val), font, brush, new PointF(p.X + 5, p.Y - 5));
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            _annotation.OnPaint(pe);
            if(InterationMode == Interaction.Annotation)
            {
                RenderMouseCursorInfo(pe);

            }
        }


        //public static byte[] GetGrayArray(Bitmap srcBmp)
        //{
        //    //将Bitmap锁定到系统内存中,获得BitmapData
        //    //这里的第三个参数确定了该图像信息时rgb存储还是Argb存储
        //    Rectangle rect = new Rectangle(0, 0, srcBmp.Width, srcBmp.Height);  //表示要锁定全图
        //    BitmapData srcBmpData = srcBmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
        //    //位图中第一个像素数据的地址。它也可以看成是位图中的第一个扫描行
        //    IntPtr srcPtr = srcBmpData.Scan0;
        //    //将Bitmap对象的信息存放到byte数组中
        //    int scanWidth = srcBmpData.Width * 3;
        //    int src_bytes = scanWidth * rect.Height;
        //    //int srcStride = srcBmpData.Stride;
        //    byte[] srcValues = new byte[src_bytes];
        //    byte[] grayValues = new byte[rect.Width * rect.Height];
        //    //RGB[] rgb = new RGB[srcBmp.Width * rows];
        //    //复制GRB信息到byte数组
        //    Marshal.Copy(srcPtr, srcValues, 0, src_bytes);
        //    //LogHelper.OutputArray(srcValues, rect.Width * 3, rect.Height, true);
        //    //Marshal.Copy(dstPtr, dstValues, 0, dst_bytes);
        //    //解锁位图
        //    srcBmp.UnlockBits(srcBmpData);
        //    //灰度化处理
        //    int m = 0, j = 0;
        //    int k = 0;
        //    byte gray;
        //    //根据Y = 0.299*R + 0.587*G + 0.114*B,intensity为亮度
        //    for (int i = 0; i < rect.Height; i++)  //行
        //    {
        //        for (j = 0; j < rect.Width; j++)  //列
        //        {
        //            //注意位图结构中RGB按BGR的顺序存储
        //            k = 3 * j;
        //            gray = (byte)(srcValues[i * scanWidth + k + 2] * 0.299
        //                 + srcValues[i * scanWidth + k + 1] * 0.587
        //                 + srcValues[i * scanWidth + k + 0] * 0.114);
        //            grayValues[m] = gray;  //将灰度值存到byte一维数组中
        //            m++;
        //        }
        //    }
        //    return grayValues;
        //}

        /// <summary>
        /// 使用GDI+缩放图像。
        /// </summary>
        /// <param name="original">要缩放的图像。</param>
        /// <param name="newWidth">新宽度。</param>
        /// <param name="newHeight">新高度。</param>
        /// <returns>缩放后的图像。</returns>
        public static Bitmap ResizeUsingGDIPlus(Bitmap original, Rectangle origSampleRect, int newWidth, int newHeight)
        {
            try
            {
                Bitmap bitmap = new Bitmap(newWidth, newHeight);
                Graphics graphics = Graphics.FromImage(bitmap);

                // 插值算法的质量
                //graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
                graphics.InterpolationMode = InterpolationMode.Bilinear;
                graphics.SmoothingMode = SmoothingMode.Default;
                graphics.DrawImage(original, new Rectangle(0, 0, newWidth, newHeight),
                   origSampleRect, GraphicsUnit.Pixel);
                graphics.Dispose();
               
                return bitmap;
            }
            catch
            {
                return null;
            }
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
            var graphics = Graphics.FromImage(this.Image);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Color.Black);
            graphics.DrawImage(srcImg, destRectInPicture, SampleRect, GraphicsUnit.Pixel);
            graphics.Dispose();
            Refresh();
        }

        public void RenderToPictureBox()
        {
            if (this.Image == null || _rawBmp == null)
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
            _setWin(win);
            _setLevel(lvl);
            setGrayLevelData();
        }

        public void setGrayLevelData()
        {
            if (PixelData != null)
            {
                if (_rawBmp == null || (_rawBmp.Width != NoCol || _rawBmp.Height != NoRow))
                    _rawBmp = new Bitmap(NoCol, NoRow, _imgFormat);

                DateTime stTime = DateTime.Now;
                _rawBmp = _buildRawBitMap(_rawBmp, GrayLevelData);
                Trace.WriteLine(string.Format("build raw bitmap = {0}", (DateTime.Now - stTime).Milliseconds));

                stTime = DateTime.Now;
                RenderToPictureBox();
                Trace.WriteLine(string.Format("render to pb = {0}", (DateTime.Now - stTime).Milliseconds));

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
                this.Image = bmpBk;
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
                this.Image = bmpBk;
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

                this.Image = bmpBk;

                //ReAdjustToViewPort();
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
    }
}
