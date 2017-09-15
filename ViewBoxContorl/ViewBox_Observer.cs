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
        public Rectangle SampleRect
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

        public Bitmap _buildRawBitMap(Bitmap raw, byte[] rawData)
        {
            Bitmap bmp = raw;
            // Lock the bitmap's bits.  锁定位图  

            unsafe
            {
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite,
                                bmp.PixelFormat);

                // Get the address of the first line.获取首行地址  
                byte* ptr = (byte*)bmpData.Scan0;
                // Declare an array to hold the bytes of the bitmap.定义数组保存位图  
                int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
                int bytesPerPix = Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int widthInPix = bmp.Width;
                Parallel.For(0, bmp.Height, i =>
                {
                    byte* ptrCurLine = ptr + bmpData.Stride * i;  
                    for(int j = 0; j < widthInPix; ++j) 
                    {
                        byte pixVal = getTransferedPixedlVal(PixelData[i, j]);
                        ptrCurLine[j * 3] = pixVal;
                        ptrCurLine[j * 3 + 1] = pixVal;
                        ptrCurLine[j * 3 + 2] = pixVal;
                    }
                });
                // Unlock the bits.解锁  
                bmp.UnlockBits(bmpData);
            }

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
                SampleRect, GraphicsUnit.Pixel);
            graphics.Dispose();

            return bitmap;
        }
    }
}
