using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Diagnostics;

namespace ViewBoxContorl
{
    partial class ViewBox : PictureBox
    {
        Rectangle _samplingRect;
        [Browsable(false)]
        public Rectangle SampleRect
        {
            get
            {
                return _samplingRect;
            }
            set { _samplingRect = value; }
        }


        float _sizeScale = 1.0f;
        [Browsable(false)]
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

        public Matrix matClientToImage = new Matrix();
        public Matrix matImageToClient = new Matrix();

        public void TranslateObserverPos(int dxInPixel, int dyInPixel)
        {
            _samplingRect.X += (int)(dxInPixel / SizeScale);
            _samplingRect.Y += (int)(dyInPixel / SizeScale);
            _updateObserverRect();
            RenderToPictureBox();
        }

        public void ResetObserverRect()
        {
            int x = -(Width - NoCol) / 2;
            int y = -(Height- NoRow) / 2;
            _samplingRect = new Rectangle(x, y, Width, Height);
            _sizeScale = 1.0f;
        }

        // keep the center of current sampling rect and apply scale
        void _updateObserverRect()
        {
            if (!_hasImage())
                return;

            int cx = _samplingRect.X + _samplingRect.Width / 2;
            int cy = _samplingRect.Y + _samplingRect.Height/ 2;

            float factor = 1.0f / SizeScale;

            _samplingRect.Width = (int)(this.Width * factor);
            _samplingRect.Height = (int)(this.Height * factor);

            _samplingRect.X = cx - _samplingRect.Width / 2;
            _samplingRect.Y = cy - _samplingRect.Height / 2;

            _updateMatrices();
        }

        public Bitmap _buildRawBitMap(Bitmap raw, byte[] rawData)
        {
            Bitmap bmp = raw;
            // Lock the bitmap's bits.  锁定位图  

            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite,
                            bmp.PixelFormat);

            unsafe
            {
                // Get the address of the first line.获取首行地址  
                byte* ptr = (byte*)bmpData.Scan0;
                int bytesPerPix = Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int widthInPix = bmp.Width;
                Parallel.For(0, bmp.Height, i =>
                {
                    byte* ptrCurLine = ptr + bmpData.Stride * i;  
                    for(int j = 0; j < widthInPix; ++j) 
                    {
                        byte pixVal = getTransferedPixedlVal(PixelData[i, j]);
                        for(int k = 0; k < bytesPerPix; k++)
                            ptrCurLine[j * bytesPerPix + k] = pixVal;
                    }
                });
            }
            // Unlock the bits.解锁  
            bmp.UnlockBits(bmpData);

            return bmp;
        }

        public void _updateMatrices()
        {
            float ox = -SampleRect.X;
            float oy = -SampleRect.Y;

            float sxx = (float)this.Width / SampleRect.Width;
            float syy = (float)this.Height / SampleRect.Height;

            // transform from image to client. 
            matImageToClient = new Matrix();
            matImageToClient.Scale(sxx, syy); 
            matImageToClient.Translate(ox, oy);

            matClientToImage = matImageToClient.Clone();
            matClientToImage.Invert();

            PointF a0 = new PointF(1, 2);
            var pts = new PointF[] {new PointF(a0.X, a0.Y)};
            matImageToClient.TransformPoints(pts);

            var pts1 = new PointF[] { new PointF(pts[0].X, pts[0].Y) };
            matClientToImage.TransformPoints(pts1);
        }
    }
}
