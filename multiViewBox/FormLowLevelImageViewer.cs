using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewBoxContorl;

namespace multiViewBox
{
    public partial class FormLowLevelImageViewer : Form
    {
        private int[][][] rawData;
        private int noSlice;
        int noChannels;
        List<ViewBoxForm> vbxKSpace;
        List<ViewBoxForm> vbxLowImage;
        private short[][][] imageShort;
        private int focusedImage;


        public FormLowLevelImageViewer()
        {
            InitializeComponent();
        }

        public FormLowLevelImageViewer(int[][][] rawData, int v)
        {
            InitializeComponent();
            //this.rawData = rawData;
            //noChannels = rawData.Length;
            //this.Width = 1200;
            //this.Height = 1000;
            //this.noSlice = v;
            //vbxKSpace = new List<ViewBoxForm>();
            //for (int i = 0; i < noChannels; i++)
            //{
            //    vbxKSpace.Add(new ViewBoxForm());

            //}
        }

        public FormLowLevelImageViewer(int[][][] rawData, short[][][] imageShort, int focusedImage,reconPara par)
        {
            InitializeComponent();
            this.rawData = rawData;
            this.imageShort = imageShort;
            this.focusedImage = focusedImage;
            noChannels = rawData.Length;
            setVbx(noChannels,par);
            
           
            //pnlLowLevelImage.Controls.AddRange(vbxKSpace.ToArray());
            
            for (int i = 0; i < noChannels; i++)
            {
                vbxLowImage[i].readPixelData(ImageUtils.ImageFormatTranslate( imageShort[i][focusedImage],enumImgFormat.AbsLinear));
                
            }
            pnlLowLevelImage.Controls.AddRange(vbxLowImage.ToArray());
            
            if (rbtImageAbs.Checked)
            {

            }
        }

        private void setVbx(int noChannels, reconPara reconPar)
        {
            vbxKSpace = new List<ViewBoxForm>();
            vbxLowImage = new List<ViewBoxForm>();
            for (int i = 0; i < imageShort.Length; i++)
            {
                vbxKSpace.Add(new ViewBoxForm());
                vbxKSpace[i].Width = 512;
                vbxKSpace[i].Height = 512;
                vbxKSpace[i].Left = 5;
                vbxKSpace[i].Top = i * (512 + 5);
                //kSpace[i].readPixelData();
                vbxLowImage.Add(new ViewBoxForm());
                vbxLowImage[i].Width = 512;
                vbxLowImage[i].Height = 512;
                vbxLowImage[i].Left = 5 + 5 + 512;
                vbxLowImage[i].Top = i * (512 + 5);
                vbxLowImage[i].AccelModeScale = 3;
                //vbxLowImage[i].Dock = DockStyle.Fill;
                vbxLowImage[i].FovCol = 0d;
                vbxLowImage[i].FovRow = 0d;
                vbxLowImage[i].GrayLevelData = null;
                vbxLowImage[i].Lev = ((short)(0));
                vbxLowImage[i].Name = "vbxImage" + i.ToString();
                vbxLowImage[i].NoCol = 0;
                vbxLowImage[i].NoRow = 0;
                vbxLowImage[i].Pannable = false;
                vbxLowImage[i].PixelData = null;
                vbxLowImage[i].SampleRect = new System.Drawing.Rectangle(-161, -205, 322, 410);
                vbxLowImage[i].ShowPixelValue = false;
                vbxLowImage[i].ShowStatistics = false;
                vbxLowImage[i].Size = new System.Drawing.Size(512, 512);
                vbxLowImage[i].TabIndex = 0;
                vbxLowImage[i].PixelValueColor = Color.Blue;
                vbxLowImage[i].TabStop = false;
                vbxLowImage[i].Win = ((short)(1));
                vbxLowImage[i].Zoomable = false;
                //vbxLowImage[i].SizeChanged += new System.EventHandler(this.vbxImage_SizeChanged);
                //vbxLowImage[i].VisibleChanged += new System.EventHandler(this.vbxImage_VisibleChanged);
                //vbxLowImage[i].Click += new System.EventHandler(this.vbxImage_Click);
                //vbxLowImage[i].Paint += new System.Windows.Forms.PaintEventHandler(this.vbxImage_Paint);
                //vbxLowImage[i].Resize += new System.EventHandler(vbxImage_Resize);
                //vbxLowImage[i].MouseUp += new MouseEventHandler(this.vbxImage_MouseUp);
                //vbxLowImage[i].ImageView.MouseDown += new MouseEventHandler(this.vbxImage_MouseDown);
                //vbxLowImage[i].OnWinLvlChangedByUI += OnWinLvlChanged;
                //vbxLowImage[i].OnPanPositionChangedByUI += OnPanPosChanged;
                //vbxLowImage[i].OnZoomFactorChangedByUI += OnZoomFactorChanged;
                vbxLowImage[i].NoRow = reconPar.noEchoes * reconPar.noScans;
                vbxLowImage[i].NoCol = reconPar.noSamples;
                vbxLowImage[i].ColSpacing = reconPar.colSpacing;
                vbxLowImage[i].RowSpacing = reconPar.rowSpacing;
                float rowScale = (float)vbxLowImage[i].Height / vbxLowImage[i].RowSpacing / (vbxLowImage[i].NoRow - 1);
                float colScale = (float)vbxLowImage[i].Width / vbxLowImage[i].ColSpacing / (vbxLowImage[i].NoCol - 1);
                vbxLowImage[i].ZoomFactor = (rowScale > colScale) ? rowScale : colScale;
                


            }
        }

        private void setVbx(int noCh)
        {
            
        }

        private void OnZoomFactorChanged(ViewBoxForm viewbox)
        {
            foreach (var vb in vbxLowImage)
            {
                if (vb != viewbox)
                {
                    vb.ZoomFactor = viewbox.ZoomFactor;
                }
            }
        }

        private void OnPanPosChanged(ViewBoxForm viewbox)
        {
            foreach (var vb in vbxLowImage)
            {
                if (vb != viewbox)
                {
                    vb.PanPosition = viewbox.PanPosition;
                }
            }
        }

        private void OnWinLvlChanged(ViewBoxForm viewbox)
        {
            foreach (var vb in vbxLowImage)
            {
                if (vb != viewbox)
                {
                    vb.Win = viewbox.Win;
                    vb.Lev = viewbox.Lev;
                }
            }
        }

        private void vbxImage_MouseDown(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void vbxImage_MouseUp(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void vbxImage_Resize(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void vbxImage_Paint(object sender, PaintEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void vbxImage_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void vbxImage_SizeChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void vbxImage_VisibleChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
