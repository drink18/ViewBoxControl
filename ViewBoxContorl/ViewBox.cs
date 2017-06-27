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
                if (value < 1)
                {
                    win = 1;

                }
                else
                {
                    win = value;
                }
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
                lev = value;
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
        #endregion

        public ViewBox()
        {
            InitializeComponent();
        }

        protected override void OnCreateControl()
        {
            int width = this.Width;
            int height = this.Height;
            Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            ////Image<Bgr, Byte> bmp = new Image<Bgr, Byte>(width, height);
            this.Image = bmp;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Debug.WriteLine("OnPaint");
            
            base.OnPaint(pe);
            
        }


        public static byte[] GetGrayArray(Bitmap srcBmp)
        {
            //将Bitmap锁定到系统内存中,获得BitmapData
            //这里的第三个参数确定了该图像信息时rgb存储还是Argb存储
            Rectangle rect = new Rectangle(0, 0, srcBmp.Width, srcBmp.Height);  //表示要锁定全图
            BitmapData srcBmpData = srcBmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //位图中第一个像素数据的地址。它也可以看成是位图中的第一个扫描行
            IntPtr srcPtr = srcBmpData.Scan0;
            //将Bitmap对象的信息存放到byte数组中
            int scanWidth = srcBmpData.Width * 3;
            int src_bytes = scanWidth * rect.Height;
            //int srcStride = srcBmpData.Stride;
            byte[] srcValues = new byte[src_bytes];
            byte[] grayValues = new byte[rect.Width * rect.Height];
            //RGB[] rgb = new RGB[srcBmp.Width * rows];
            //复制GRB信息到byte数组
            Marshal.Copy(srcPtr, srcValues, 0, src_bytes);
            //LogHelper.OutputArray(srcValues, rect.Width * 3, rect.Height, true);
            //Marshal.Copy(dstPtr, dstValues, 0, dst_bytes);
            //解锁位图
            srcBmp.UnlockBits(srcBmpData);
            //灰度化处理
            int m = 0, j = 0;
            int k = 0;
            byte gray;
            //根据Y = 0.299*R + 0.587*G + 0.114*B,intensity为亮度
            for (int i = 0; i < rect.Height; i++)  //行
            {
                for (j = 0; j < rect.Width; j++)  //列
                {
                    //注意位图结构中RGB按BGR的顺序存储
                    k = 3 * j;
                    gray = (byte)(srcValues[i * scanWidth + k + 2] * 0.299
                         + srcValues[i * scanWidth + k + 1] * 0.587
                         + srcValues[i * scanWidth + k + 0] * 0.114);
                    grayValues[m] = gray;  //将灰度值存到byte一维数组中
                    m++;
                }
            }
            return grayValues;
        }

        /// <summary>
        /// 使用GDI+缩放图像。
        /// </summary>
        /// <param name="original">要缩放的图像。</param>
        /// <param name="newWidth">新宽度。</param>
        /// <param name="newHeight">新高度。</param>
        /// <returns>缩放后的图像。</returns>
        public static Bitmap ResizeUsingGDIPlus(Bitmap original, int newWidth, int newHeight)
        {
            try
            {
                Bitmap bitmap = new Bitmap(newWidth, newHeight);
                Graphics graphics = Graphics.FromImage(bitmap);

                // 插值算法的质量
                graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
                //graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(original, new Rectangle(0, 0, newWidth, newHeight),
                    new Rectangle(0, 0, original.Width, original.Height), GraphicsUnit.Pixel);
                graphics.Dispose();

                return bitmap;
            }
            catch
            {
                return null;
            }
        }

        public void setGrayLevelData()
        {
            if (PixelData != null)
            {
                DateTime stTime = DateTime.Now;
                short ceil = (short)(Lev + Win / 2);
                short floor = (short)(Lev - Win / 2);
                double slope = 255D / Win;

                for (int i = 0; i < NoRow; i++)
                {
                    for (int j = 0; j < NoCol; j++)
                    {
                        if (PixelData[i, j] > ceil)
                        {
                            GrayLevelData[j + i * NoCol] = 255;
                        }
                        else if (PixelData[i, j] < floor)
                        {
                            GrayLevelData[j + i * NoCol] = 0;
                        }
                        else
                        {
                            GrayLevelData[j + i * NoCol] = (byte)(slope * (PixelData[i, j] - floor));//(byte)Math.Round( slope * (PixelData[i, j] - floor));
                        }
                    }
                }

                Bitmap bmp = new Bitmap(NoCol, NoRow, PixelFormat.Format24bppRgb);


                //逐像素方式
                for (int i = 0; i < NoRow; i++)
                {
                    for (int j = 0; j < NoCol; j++)
                    {
                        bmp.SetPixel(j, i, Color.FromArgb(GrayLevelData[j + i * NoCol],
                            GrayLevelData[j + i * NoCol], GrayLevelData[j + i * NoCol]));
                    }
                }
                //内存复制方式，将灰阶数组内容复制到bmp中
                //copyBmp(bmp, GrayLevelData);

                Bitmap tmpBmp;
                Rectangle Dest;
                if (this.Width / (double)NoCol >= this.Height / (double)NoRow)
                {
                    double dimScale = (double)this.Height / NoRow;
                    tmpBmp = ResizeUsingGDIPlus(bmp,
                        (int)Math.Round(dimScale * NoCol), this.Height);
                    Dest = new Rectangle((int)(this.Width - dimScale * NoCol) / 2, 0, this.Width, this.Height);
                }
                else
                {
                    double dimScale = (double)this.Width / NoCol;
                    tmpBmp = ResizeUsingGDIPlus(bmp, this.Width,
                        (int)Math.Round(dimScale * NoRow));
                    Dest = new Rectangle(0, (int)(this.Height - dimScale * NoRow) / 2, this.Width, this.Height);
                }
                Graphics gDest = this.CreateGraphics();
                gDest.DrawImage(tmpBmp, Dest, this.ClientRectangle, GraphicsUnit.Pixel);
                this.Image = tmpBmp;
                Trace.WriteLine((DateTime.Now - stTime).Milliseconds.ToString());
            }
        }

        private void copyBmp(Bitmap bmp, byte[] GrayLevelData)
        {
            // Lock the bitmap's bits.  锁定位图  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                                bmp.PixelFormat);
            // Get the address of the first line.获取首行地址  
            IntPtr ptr = bmpData.Scan0;
            // Declare an array to hold the bytes of the bitmap.定义数组保存位图  
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmpData.Stride; j++)
                {
                    if (j < 3 * bmp.Width)
                    {
                        rgbValues[j + i * bmpData.Stride] = GrayLevelData[(j / 3 + i * bmp.Width)];
                    }
                }
            }
            // Copy the RGB values back to the bitmap 把RGB值拷回位图  
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            // Unlock the bits.解锁  
            bmp.UnlockBits(bmpData);
        }

        private void ViewBox_ClientSizeChanged(object sender, EventArgs e)
        {
            //int width = this.Width;
            //int height = this.Height;
            //Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //////Image<Bgr, Byte> bmp = new Image<Bgr, Byte>(width, height);
            //this.Image = bmp;

        }

        public void readPixelData(byte[] rawData)
        {
            try
            {
                if (rawData.Length != 2 * NoCol * NoRow)
                {
                    throw new RawDataSizeErrorException(NoCol, NoRow, rawData.Length);
                }
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

            }
            catch (RawDataSizeErrorException ex)
            {

                MessageBox.Show(ex.row + "," + ex.col + "," + ex.size);
            }
        }

        private void ViewBox_Resize(object sender, EventArgs e)
        {


        }

        private void ViewBox_SizeChanged(object sender, EventArgs e)
        {
            int width = this.Width;
            int height = this.Height;
            Bitmap bmpBk = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            this.Image = bmpBk;

            Debug.WriteLine("resize");

            
            //this.Invalidate();
            setGrayLevelData();
        }

        private void ViewBox_VisibleChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("ViewBox_VisibleChanged");
        }

        private void ViewBox_Paint(object sender, PaintEventArgs e)
        {

        }
    }




}
