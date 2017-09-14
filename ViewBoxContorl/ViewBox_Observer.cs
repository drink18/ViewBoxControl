using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ViewBoxContorl
{
    partial class ViewBox : PictureBox
    {
        Rectangle _samplingRect;
        Rectangle _pictureRect;
        public Rectangle ObserverRect
        {
            get
            {
                return _samplingRect;
            }
            set { _samplingRect = value; }
        }


        float _sizeScale = 1.0f;
        public float SizeScale
        {

            get { return _sizeScale; }
            set
            {
                _sizeScale = Math.Max(1.0f, value);
                _updateObserverRect();
                RenderToPictureBox();
            }
        } 

        public Point ObserverPos
        {
            get { return new Point(_samplingRect.X, _samplingRect.Y); }
            set
            {
                //var x = Math.Max(0, value.X);
                //var y = Math.Max(0, value.Y);
                _samplingRect.X = value.X;
                _samplingRect.Y = value.Y;

                _updateObserverRect();
                RenderToPictureBox();
            }
        }

        public void ResetObserverRect()
        {
            _samplingRect = new Rectangle(0, 0, NoCol, NoRow);
        }

        void _updateObserverRect()
        {
            int cx = _samplingRect.X + _samplingRect.Width / 2;
            int cy = _samplingRect.Y + _samplingRect.Height/ 2;

            float factor = 1.0f / SizeScale;

            _samplingRect.Width = (int)(NoCol * factor);
            _samplingRect.Height = (int)(NoRow * factor);

            _samplingRect.X = cx - _samplingRect.Width / 2;
            _samplingRect.Y = cy - _samplingRect.Height / 2; 
        }

        public Bitmap _buildRawBitMap(byte[] rawData)
        {
            Bitmap bmp = new Bitmap(NoCol, NoRow, PixelFormat.Format24bppRgb);
            // Lock the bitmap's bits.  锁定位图  

            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite,
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
                        rgbValues[j + i * bmpData.Stride] = GrayLevelData[j / 3 + i * NoCol];
                    }
                }
            }
            // Copy the RGB values back to the bitmap 把RGB值拷回位图  
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            // Unlock the bits.解锁  
            bmp.UnlockBits(bmpData);

            return bmp;
        }

        public Bitmap _sampleRawImgWithObserverRect(Bitmap rawBmp, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(bitmap);

            // 插值算法的质量
            //graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.DrawImage(rawBmp, new Rectangle(0, 0, width, height),
                ObserverRect, GraphicsUnit.Pixel);
            graphics.Dispose();

            return bitmap;
        }
    }
}
