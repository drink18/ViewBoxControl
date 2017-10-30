using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FFTWSharp;

namespace multiViewBox
{
    public static class MRIFFTW
    {
        public static double[] doFFT2D(double[] kSpace, int NoRow, int NoColumn, bool shift)
        {
            IntPtr pi, po, f2dPlan;
            double[] Image = new double[2 * NoColumn * NoRow];
            int len = kSpace.Length;
            if (len != 2 * NoColumn * NoRow)
            {
                MessageBox.Show("wrong array size!");
                return Image;
            }
            pi = fftw.malloc(8 * len);
            po = fftw.malloc(8 * len);
            f2dPlan = fftw.dft_2d( NoRow, NoColumn, pi, po, fftw_direction.Backward, fftw_flags.Estimate);
            Marshal.Copy(kSpace, 0, pi, len);
            fftw.execute(f2dPlan);
            Marshal.Copy(po, Image, 0, len);
            fftw.free(pi);
            fftw.free(po);
            fftw.free(f2dPlan);
            if (!shift)
            {
                return Image;
            }
            else
            {
                double[] shiftImage = new double[len];
                for (int i = 0; i < len; i++)
                {
                    shiftImage[i] = Image[(i + NoColumn) % (2 * NoColumn) + (i / (2 * NoColumn)) * 2 * NoColumn];
                }
                for (int i = 0; i < len; i++)
                {
                    Image[i] = shiftImage[(i + (NoRow + 1) / 2 * 2 * NoColumn) % (len)];
                }
                return Image;
            }
        }

        public static double[] doFFT2D(int[] kSpace, int NoRow, int NoColumn, bool shift)
        {
            double[] kSpaceDbl = new double[kSpace.Length];
            for (int i = 0; i < kSpace.Length; i++)
            {
                kSpaceDbl[i] = (double)kSpace[i];
            }
            return doFFT2D(kSpaceDbl, NoRow, NoColumn, shift);
        }

        public static double[] doFFT1D(double[] td, bool shift)
        {
            IntPtr pi, po, fdPlan;
            int len = td.Length;
            double[] sd = new double[len];
            pi = fftw.malloc(8 * len);
            po = fftw.malloc(8 * len);
            fdPlan = fftw.dft_1d(len/2, pi, po, fftw_direction.Backward, fftw_flags.Estimate);
            Marshal.Copy(td, 0, pi, len);
            fftw.execute(fdPlan);
            Marshal.Copy(po, sd, 0, len);
            fftw.free(pi);
            fftw.free(po);
            fftw.free(fdPlan);
            if(shift)
            {
                double[] sdShift = new double[len];
                //偶数点个复数
                if((len%4)==0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        sdShift[i] = sd[(i +len / 2) % len];
                    }
                }
                else
                //奇数点个复数
                {
                    for (int i = 0; i < len; i++)
                    {
                        sdShift[i] = sd[(i+1+ len / 2)%len];
                    }
                }
                return sdShift;
            }
            else
            {
                return sd;
            }
            
        }

        public static double[] doFFT1D(int[] td,bool shift)
        {
            int len = td.Length;
            double[] tmp = new double[len];
            for (int i = 0; i < len; i++)
            {
                tmp[i] = (double)td[i];
            }
            return doFFT1D(tmp,shift);
        }
    }
}
