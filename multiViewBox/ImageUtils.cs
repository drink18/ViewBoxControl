using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiViewBox
{
    public static class ImageUtils
    {
        public static short[] ImageFormatTranslate(short[] SrcImage,enumImgFormat f)
        {
            short[] tmpImage = new short[SrcImage.Length/2];
            if(f==enumImgFormat.AbsLinear)
            {
                for (int i = 0; i < tmpImage.Length; i++)
                {
                    tmpImage[i] = (short)Math.Sqrt(SrcImage[2 * i] * SrcImage[2 * i] + SrcImage[2 * i + 1] * SrcImage[2 * i + 1]);
                }
            }
            else if(f==enumImgFormat.AbsLog)
            {
                for (int i = 0; i < tmpImage.Length; i++)
                {
                    tmpImage[i] = (short)(20*Math.Log10(Math.Sqrt(SrcImage[2 * i] * SrcImage[2 * i] + SrcImage[2 * i + 1] * SrcImage[2 * i + 1])));
                }
            }
            else if(f==enumImgFormat.Phase)
            {
                for (int i = 0; i < tmpImage.Length; i++)
                {
                    tmpImage[i] = (short)(100*Math.Atan2(SrcImage[2 * i+1], SrcImage[2 * i]));
                }
            }
            else if(f==enumImgFormat.Real)
            {
                for (int i = 0; i < tmpImage.Length; i++)
                {
                    tmpImage[i] = SrcImage[2 * i];
                }
            }
            else
            {
                for (int i = 0; i < tmpImage.Length; i++)
                {
                    tmpImage[i] = SrcImage[2 * i+1];
                }
            }
            return tmpImage;
        }

        public static short[] ImageFormatTranslate(int[] SrcImage, enumImgFormat f,int max,int min)
        {
            short[] tmpImage = new short[SrcImage.Length];
            short[] tmpRet = new short[SrcImage.Length / 2];
            //将SrcImage归一化到short格式
            double tmpDbl = (Math.Abs(max) > Math.Abs(min)) ? Math.Abs(max) : Math.Abs(min);
            if(tmpDbl>16383)
            {
                double scale= Math.Ceiling(Math.Log(tmpDbl, 2) - 15);
                for (int i = 0; i < SrcImage.Length; i++)
                {
                    tmpImage[i]=(short)(SrcImage[i]/ scale);
                }
            }
            else
            {
                for (int i = 0; i < SrcImage.Length; i++)
                {
                    tmpImage[i] = (short)SrcImage[i];
                }
            }
            if (f == enumImgFormat.AbsLinear)
            {
                for (int i = 0; i < tmpRet.Length; i++)
                {
                    tmpRet[i] = (short)Math.Sqrt(tmpImage[2 * i] * tmpImage[2 * i] + tmpImage[2 * i + 1] * tmpImage[2 * i + 1]);
                }
            }
            else if (f == enumImgFormat.AbsLog)
            {
                for (int i = 0; i < tmpRet.Length; i++)
                {
                    tmpRet[i] = (short)(20 * Math.Log10(Math.Sqrt(tmpImage[2 * i] * tmpImage[2 * i] + tmpImage[2 * i + 1] * tmpImage[2 * i + 1])));
                }
            }
            else if (f == enumImgFormat.Phase)
            {
                for (int i = 0; i < tmpRet.Length; i++)
                {
                    tmpRet[i] = (short)(100 * Math.Atan2(tmpImage[2 * i + 1], tmpImage[2 * i]));
                }
            }
            else if (f == enumImgFormat.Real)
            {
                for (int i = 0; i < tmpRet.Length; i++)
                {
                    tmpRet[i] = tmpImage[2 * i];
                }
            }
            else
            {
                for (int i = 0; i < tmpRet.Length; i++)
                {
                    tmpRet[i] = tmpImage[2 * i + 1];
                }
            }
            return tmpRet;
        }

        internal static short[][] getSOS(short[][][] img)
        {
            double tmpDblPixel;
            short[][] tmpImg = new short[img[0].Length][];
            for (int i = 0; i < tmpImg.Length; i++)
            {
                tmpImg[i] = new short[img[0][0].Length/2];
            }
            for (int i = 0; i < tmpImg.Length; i++)
            {
                for (int j = 0; j < tmpImg[0].Length; j++)
                {
                    tmpDblPixel = 0;
                    for (int ch = 0; ch < img.Length; ch++)
                    {
                        tmpDblPixel += img[ch][i][2 * j] * img[ch][i][2 * j] + img[ch][i][2 * j + 1] * img[ch][i][2 * j + 1];
                    }
                    tmpImg[i][j]= (short)Math.Sqrt(tmpDblPixel);
                }
            }
            //for (int slice = 0; slice < reconPar.noSlices; slice++)
            //{
            //    for (int i = 0; i < reconPar.noScans * reconPar.noEchoes * reconPar.noSamples; i++)
            //    {
            //        tmpDblPixel = 0;
            //        for (int ch = 0; ch < acqChannels; ch++)
            //        {
            //            tmpDblPixel += imageShort[ch][slice][2 * i] * imageShort[ch][slice][2 * i] + imageShort[ch][slice][2 * i + 1] * imageShort[ch][slice][2 * i + 1];
            //        }
            //        imageAbsSOS[slice][i] = (short)Math.Sqrt(tmpDblPixel);
            //    }
            //}
            return tmpImg;
        }
    }

    public enum enumImgFormat { AbsLog,AbsLinear,Phase,Real,Imag}
}
