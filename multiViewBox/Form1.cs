using multiViewBox.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewBoxContorl;
using ViewBoxContorl.Annotation;
using System.Text.RegularExpressions;


namespace multiViewBox
{
    public partial class Form1 : Form
    {
        ViewBoxForm vbxFocused;
        int acqChannels;
        //rawData第一维是通道，第二维是层面数，第三维是采样数据（I、Q、I、Q）
        int[][][] rawData;
        int rawDataMax;
        int rawDataMin;
        short[][][] imageShort;
        short[][] imageAbsSOS;
        Image[] imageIcon;
        //double[][][] imageDbl;
        string defaultRawDataPath;
        string defaultDICOMFolder;
        int firstImageDisplay;
        reconPara reconPar;
        imagePara imagePar;
        ImageLayout imLayout;
        List<ViewBoxForm> vbxImage;
        List<Button> iconButton;
        int[] imageSliceNumber;
        AnnotationType annotationType;
        ContextMenuStrip vbxContextMenuStrip;
        private bool adjustSync = true;
        string rawDataFilter = "raw data|*.raw";
        public bool AdjustSync
        {
            get
            {
                return adjustSync;
            }

            set
            {
                adjustSync = value;
            }
        }

        public int RawDataMax
        {
            get
            {
                return rawDataMax;
            }

            //set
            //{
            //    rawDataMax = value;
            //}
        }

        public int RawDataMin
        {
            get
            {
                return rawDataMin;
            }

            //set
            //{
            //    rawDataMin = value;
            //}
        }

        string[] rawDataFileName;

        int focusedImage;

        //ViewBoxForm[] vbxImage;

        public Form1()
        {
            InitializeComponent();
            defaultRawDataPath = Settings.Default.defaultRawDataPath;
            defaultDICOMFolder = Settings.Default.defaultDICOMFolder;
            imLayout = ImageLayout.layout1X1;

            setImageLayout();

        }

        private void setImageIcon(int number)
        {
            tplImageIcon.Controls.Clear();
            if (iconButton != null)
            {
                iconButton.Clear();
            }
            iconButton = new List<Button>();
            tplImageIcon.RowCount = number;
            int tmp = tplImageIcon.ClientRectangle.Width;
            for (int i = 0; i < number; i++)
            {

                iconButton.Add(new Button());
                iconButton[i].Dock = DockStyle.Fill;
                iconButton[i].FlatStyle = FlatStyle.Flat;
                iconButton[i].FlatAppearance.BorderSize = 2;
                iconButton[i].FlatAppearance.BorderColor = Color.Black;
                //iconButton[i].Image = vbxImage[i].Image;
                iconButton[i].Name = i.ToString();
                iconButton[i].Text = i.ToString();
                iconButton[i].Height = 180;
                iconButton[i].Width = 180;
                iconButton[i].Click += icon_Click;
                tplImageIcon.RowStyles.Add(new RowStyle(SizeType.Absolute, 180));
                //tplImageIcon.SetRow(iconButton[i], i);
                tplImageIcon.Controls.Add(iconButton[i], 0, i);
            }
            iconButton[firstImageDisplay].FlatAppearance.BorderColor = Color.Red;
        }

        private void icon_Click(object sender, EventArgs e)
        {
            foreach (Button item in iconButton)
            {
                item.FlatAppearance.BorderColor = Color.Black;
            }
            firstImageDisplay = int.Parse((sender as Button).Name);
            (sender as Button).FlatAppearance.BorderColor = Color.Red;
            imageShow();
        }

        private void setImageLayout()
        {

            tplImages.Controls.Clear();
            tplImages.ColumnStyles.Clear();
            tplImages.RowStyles.Clear();
            if (vbxImage != null)
            {
                vbxImage.Clear();
                imageSliceNumber = null;
            }

            vbxImage = new List<ViewBoxForm>();
            if (imLayout == ImageLayout.layout1X1)
            {
                vbxImage.Add(new ViewBoxForm());
                tplImages.ColumnCount = 1;
                tplImages.RowCount = 1;
                imageSliceNumber = new int[1];
            }
            else if (imLayout == ImageLayout.layout2X2)
            {
                //vbxImage = new ViewBoxForm[4];
                for (int i = 0; i < 4; i++)
                {
                    vbxImage.Add(new ViewBoxForm());
                }
                tplImages.ColumnCount = 2;
                tplImages.RowCount = 2;
                imageSliceNumber = new int[4];
            }
            else if (imLayout == ImageLayout.layout3X3)
            {
                //vbxImage = new ViewBoxForm[9];
                for (int i = 0; i < 9; i++)
                {
                    vbxImage.Add(new ViewBoxForm());
                }
                tplImages.ColumnCount = 3;
                tplImages.RowCount = 3;
                imageSliceNumber = new int[9];
            }
            else
            {
                return;
            }

            for (int i = 0; i < vbxImage.Count; i++)
            {

                vbxImage[i].AccelModeScale = 3;
                //    vbxImage[i].Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                //| System.Windows.Forms.AnchorStyles.Left)
                //| System.Windows.Forms.AnchorStyles.Right)));
                vbxImage[i].Dock = DockStyle.Fill;
                this.vbxImage[i].FovCol = 0D;
                this.vbxImage[i].FovRow = 0D;

                this.vbxImage[i].GrayLevelData = null;
                //this.vbxImage[i].Image = ((System.Drawing.Image)(resources.GetObject("vbxImage.Image")));
                this.vbxImage[i].Lev = ((short)(0));
                //this.vbxImage[i].Location = new System.Drawing.Point(12, 12);
                //this.vbxImage[i].Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
                //this.vbxImage[i].MouseOpMode = ViewBoxContorl.ViewBoxForm.MouseOps.PosLvl;
                this.vbxImage[i].Name = "vbxImage" + i.ToString();
                this.vbxImage[i].NoCol = 0;
                this.vbxImage[i].NoRow = 0;
                this.vbxImage[i].Pannable = false;
                this.vbxImage[i].PixelData = null;
                this.vbxImage[i].SampleRect = new System.Drawing.Rectangle(-161, -205, 322, 410);
                this.vbxImage[i].ShowPixelValue = false;
                this.vbxImage[i].ShowStatistics = false;
                this.vbxImage[i].Size = new System.Drawing.Size(512, 512);
                //this.vbxImage[i].SizeScale = 1F;

                this.vbxImage[i].TabIndex = 0;
                this.vbxImage[i].PixelValueColor = Color.Blue;
                this.vbxImage[i].TabStop = false;
                this.vbxImage[i].Win = ((short)(1));
                this.vbxImage[i].Zoomable = true;
                this.vbxImage[i].SizeChanged += new System.EventHandler(this.vbxImage_SizeChanged);
                this.vbxImage[i].VisibleChanged += new System.EventHandler(this.vbxImage_VisibleChanged);
                this.vbxImage[i].Click += new System.EventHandler(this.vbxImage_Click);
                this.vbxImage[i].Paint += new System.Windows.Forms.PaintEventHandler(this.vbxImage_Paint);
                this.vbxImage[i].Resize += new System.EventHandler(vbxImage_Resize);
                this.vbxImage[i].MouseUp += new MouseEventHandler(this.vbxImage_MouseUp);
                this.vbxImage[i].ImageView.MouseDown += new MouseEventHandler(this.vbxImage_MouseDown);
                if (AdjustSync)
                {
                    this.vbxImage[i].OnWinLvlChangedByUI += OnWinLvlChanged;
                    this.vbxImage[i].OnPanPositionChangedByUI += OnPanPosChanged;
                    this.vbxImage[i].OnZoomFactorChangedByUI += OnZoomFactorChanged;
                }
                else
                {
                    this.vbxImage[i].OnWinLvlChangedByUI -= OnWinLvlChanged;
                    this.vbxImage[i].OnPanPositionChangedByUI -= OnPanPosChanged;
                    this.vbxImage[i].OnZoomFactorChangedByUI -= OnZoomFactorChanged;
                }
                this.vbxImage[i].AccelModeScale = 10;
                this.vbxImage[i].MouseRightClick += OnMouseRightClick;
            }
            for (int i = 0; i < tplImages.ColumnCount; i++)
            {
                tplImages.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / tplImages.ColumnCount));
            }
            for (int i = 0; i < tplImages.RowCount; i++)
            {
                tplImages.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / tplImages.RowCount));
            }
            pnlImages.Controls.Add(tplImages);
            for (int row = 0; row < tplImages.RowCount; row++)
            {
                for (int col = 0; col < tplImages.ColumnCount; col++)
                {
                    tplImages.Controls.Add(vbxImage[col + row * tplImages.ColumnCount], col, row);
                }
            }

        }

        private void OnMouseRightClick(object sender, MouseEventArgs e)
        {

            int tmp = tplImages.Controls.Count;
            for (int i = 0; i < tplImages.RowCount; i++)
            {
                for (int j = 0; j < tplImages.ColumnCount; j++)
                {
                    if ((tplImages.GetControlFromPosition(j, i) as ViewBoxForm).ImageView.Focused)
                    {
                        focusedImage = i * tplImages.ColumnCount + j;
                        ContextMenu menu = new ContextMenu();   //初始化menu
                        menu.MenuItems.Add("Image Info");   //添加菜单项c1
                        menu.MenuItems.Add("Show Low Level Images");   //添加菜单项c2
                        menu.MenuItems[0].Name = "ImageInfo";
                        menu.MenuItems[1].Name = "ShowLowImages";
                        menu.MenuItems[0].Click += new EventHandler(sendMsg);
                        //menu.MenuItems[1].Click += Form1_Click;
                        menu.MenuItems[1].Click += new EventHandler(ShowLowImages);
                        menu.Show((sender as Control), new Point(e.X, e.Y));   //在点(e.X, e.Y)处显示menu

                    }
                }
            }



        }



        private void ShowLowImages(object sender, EventArgs e)
        {
            FormLowLevelImageViewer formLowLevel = new FormLowLevelImageViewer(rawData, imageShort, focusedImage,reconPar);
            //List<ViewBoxForm> kSpace = new List<ViewBoxForm>();
            //List<ViewBoxForm> lowImage = new List<ViewBoxForm>();
            //for (int i = 0; i < imageShort.Length; i++)
            //{
            //    kSpace.Add(new ViewBoxForm());
            //    kSpace[i].Width = 512;
            //    kSpace[i].Height = 512;
            //    kSpace[i].Left = 5;
            //    kSpace[i].Top = i * (512 + 5);
            //    //kSpace[i].readPixelData();
            //    lowImage.Add(new ViewBoxForm());
            //    lowImage[i].Width = 512;
            //    lowImage[i].Height = 512;
            //    lowImage[i].Left = 5+5+512;
            //    lowImage[i].Top = i * (512 + 5);

            //}
            //formLowLevel.pnlLowLevelImage.Controls.AddRange(kSpace.ToArray());
            //formLowLevel.pnlLowLevelImage.Controls.AddRange(lowImage.ToArray());
            formLowLevel.ShowDialog();
        }

        private void vbxImage_MouseDown(object sender, MouseEventArgs e)
        {
            //if((sender as ViewBoxForm).ImageView!=null)
            //if (e.Button == MouseButtons.Right)
            //{
            //    ContextMenu menu = new ContextMenu();   //初始化menu
            //    menu.MenuItems.Add("发送消息");   //添加菜单项c1
            //    menu.MenuItems.Add("发送文件");   //添加菜单项c2
            //    menu.MenuItems.Add("断开连接");
            //    menu.MenuItems[0].Name = "发送消息";
            //    menu.MenuItems[1].Name = "发送文件";
            //    menu.MenuItems[2].Name = "断开连接";
            //    menu.MenuItems[0].Click += new EventHandler(sendMsg);     //定义菜单项1上的Click事件处理函数
            //    menu.MenuItems[1].Click += new EventHandler(sendFile);     //定义菜单项2上的Click事件处理函数
            //    menu.MenuItems[2].Click += new EventHandler(cutCon);     //定义菜单项3上的Click事件处理函数
            //    menu.Show(sender as Button, new Point(e.X, e.Y));   //在点(e.X, e.Y)处显示menu
            //}
        }

        private void cutCon(object sender, EventArgs e)
        {
            MessageBox.Show((sender as MenuItem).Name + "clicked!");
        }

        private void sendFile(object sender, EventArgs e)
        {
            MessageBox.Show((sender as MenuItem).Name + "clicked!");
        }

        private void sendMsg(object sender, EventArgs e)
        {
            MessageBox.Show((sender as MenuItem).Name + "clicked!");
        }

        private void vbxImage_MouseUp(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            //base.OnMouseUp(e);
            //MessageBox.Show("mouse up!");
            //if (MMouseUp != null)
            //{
            //    MMouseUp(this, e);
            //}
        }

        private void initImagePanel(int row, int col)
        {

        }

        private void btnOpenTest_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"D:\wuduan\Engineering\MRI_Spectrometer\EDA\Matlab\phantom";
            ofd.Filter = "raw data|*.img";
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    byte[] imageBuf = new byte[fs.Length];
                    fs.Read(imageBuf, 0, imageBuf.Length);
                    //ViewBoxForm vbx = new ViewBoxForm();
                    //foreach (var item in tplImages.Controls)
                    //{
                    //    if ((item as ViewBoxForm).Focused)
                    //    {
                    //        vbx = (ViewBoxForm)item;
                    //    }
                    //}
                    for (int i = 0; i < vbxImage.Count; i++)
                    {
                        vbxImage[i].NoCol = 256;
                        vbxImage[i].NoRow = 256;
                        float colScale = (float)vbxImage[i].Width / vbxImage[i].NoCol;
                        float rowScale = (float)vbxImage[i].Height / vbxImage[i].NoRow;
                        float scale = (colScale > rowScale) ? colScale : rowScale;
                        vbxImage[i].readPixelData(imageBuf);
                        //vbxImage[i].SizeScale = scale;
                        vbxImage[i].Refresh();

                    }

                }


            }
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = defaultRawDataPath;
            ofd.Multiselect = true;
            ofd.Filter = rawDataFilter;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //clearVbx();
                Settings.Default.defaultRawDataPath = Path.GetDirectoryName(ofd.FileName);
                Settings.Default.Save();
                defaultRawDataPath = Settings.Default.defaultRawDataPath;
                //检查文件是否属于同一次扫描
                rawDataFileName = ofd.FileNames;


                if (rawDataFileName.Length > 1)
                {
                    string s = Regex.Replace(rawDataFileName[0], "_ch[0-9]*_", "");
                    for (int i = 1; i < rawDataFileName.Length; i++)
                    {
                        if (s != Regex.Replace(rawDataFileName[i], "_ch[0-9]*_", ""))
                        {
                            MessageBox.Show("not in same scan!");
                            return;
                        }
                    }
                }
                reconPar = getReconPara(ofd.FileNames[0], reconParaFrom.fromRawData);
                imagePar.noCol = reconPar.noSamples;
                imagePar.noRow = reconPar.noScans * reconPar.noEchoes;
                imagePar.colSpacing = reconPar.colSpacing;
                imagePar.rowSpacing = reconPar.rowSpacing;
                imagePar.imageFileName = Regex.Replace(rawDataFileName[0], "_ch[0-9]*_", "_").Replace(".raw", "");
                //FileInfo[] fileInfoArray = new DirectoryInfo(Path.GetDirectoryName(ofd.FileNames[0])).GetFiles(ofd.SafeFileName.Replace("_ch1_","_ch*_"));
                acqChannels = ofd.FileNames.Length;
                //初始化k空间数据
                if (rawData != null)
                {
                    rawData = null;
                }
                rawData = new int[acqChannels][][];
                for (int i = 0; i < acqChannels; i++)
                {
                    rawData[i] = new int[reconPar.noSlices][];
                    for (int j = 0; j < reconPar.noSlices; j++)
                    {
                        rawData[i][j] = new int[2 * reconPar.noScans * reconPar.noEchoes * reconPar.noSamples];
                    }
                }
                imageAbsSOS = new short[reconPar.noSlices][];
                for (int i = 0; i < reconPar.noSlices; i++)
                {
                    imageAbsSOS[i] = new short[reconPar.noScans * reconPar.noEchoes * reconPar.noSamples];
                }
                //初始化图像数据

                int noCData = reconPar.noSlices * reconPar.noScans * reconPar.noEchoes * reconPar.noSamples;
                //for (int i = 0; i < acqChannels; i++)
                //{
                //读取通道i的数据
                rawData = openRawData(ofd.FileNames, reconPar, null, out rawDataMax, out rawDataMin);
                //MessageBox.Show("Max:" + RawDataMax.ToString() + ", Min:" + RawDataMin.ToString());
                //getRawData(fileInfoArray[i].FullName, para);
                //}
                //for (int ch = 0; ch < rawData.Length; ch++)
                //{
                //    for (int slice = 0; slice < rawData[0].Length; slice++)
                //    {
                //        using (StreamWriter sw = new StreamWriter(@"D:\wuduan\Engineering\MRI_Spectrometer\EDA\Matlab\mri_data\20170802_anke\rawData_ch" + ch.ToString() + "_slice" + slice.ToString() + ".txt"))
                //        {
                //            for (int i = 0; i < rawData[0][0].Length; i++)
                //            {
                //                sw.WriteLine(rawData[ch][slice][i].ToString());
                //            }
                //        }
                //    }
                //}

                //重建图像
                imageShort = imageRecon(rawData);


                //imageShort = new short[imageDbl.Length][][];
                //for (int i = 0; i < imageDbl.Length; i++)
                //{
                //    imageShort[i] = new short[imageDbl[0].Length][];
                //    for (int j = 0; j < imageDbl[0].Length; j++)
                //    {
                //        imageShort[i][j] = new short[imageDbl[0][0].Length];
                //    }
                //}
                //for (int i = 0; i < imageDbl.Length; i++)
                //{
                //    for (int j = 0; j < imageDbl[0].Length; j++)
                //    {
                //        for (int k = 0; k < imageDbl[0][0].Length; k++)
                //        {
                //            imageShort[i][j][k] = (short)(imageDbl[i][j][k] * factor);
                //        }
                //    }
                //}
                //imageDbl = null;
                
                imageAbsSOS = ImageUtils.getSOS(imageShort);
                //显示图像

                //for (int slice = firstImageDisplay; slice < firstImageDisplay+vbxImage.Count; slice++)
                //{
                //if (slice < vbxImage.Count)
                //{
                //    imageShow(imageAbsSOS[slice], vbxImage[slice ], reconPar.noScans * reconPar.noEchoes, reconPar.noSamples);
                //    //vbxImage[slice].Image.Save(@"g:\t\bmp_"+slice.ToString()+".bmp");
                //}
                //imageShow(imageAbsSOS[slice], vbxImage[slice], reconPar.noScans * reconPar.noEchoes, reconPar.noSamples);
                imageShow();
                //}

            }
            setImageIcon(reconPar.noSlices);
        }

        private void imageShow()
        {
            foreach (ViewBoxForm item in vbxImage)
            {
                item.NoRow = reconPar.noEchoes * reconPar.noScans;
                item.NoCol = reconPar.noSamples;
                item.ColSpacing = reconPar.colSpacing;
                item.RowSpacing = reconPar.rowSpacing;
                float rowScale = (float)item.Height / item.RowSpacing / (item.NoRow - 1);
                float colScale = (float)item.Width / item.ColSpacing / (item.NoCol - 1);
                item.ZoomFactor = (rowScale > colScale) ? rowScale : colScale;
            }
            for (int i = 0; i < vbxImage.Count; i++)
            {
                if (i + firstImageDisplay < imageAbsSOS.Length)
                {
                    vbxImage[i].readPixelData(imageAbsSOS[i + firstImageDisplay]);
                    
                }
                else
                {
                    vbxImage[i].unloadImage();
                }
            }
        }

        private void clearVbx()
        {
            foreach (ViewBoxForm item in vbxImage)
            {
                item.Image = null;
            }
        }

        //private void imageShow(short[] image, ViewBoxForm vbx, int row, int col)
        //{
        //    vbx.NoRow = row;
        //    vbx.NoCol = col;
        //    float rowScale = (float)vbx.Height / vbx.RowSpacing / (vbx.NoRow - 1);
        //    float colScale = (float)vbx.Width / vbx.ColSpacing / (vbx.NoCol - 1);
        //    vbx.ZoomFactor = (rowScale > colScale) ? rowScale : colScale;
        //    vbx.readPixelData(image);

        //    vbx.ColSpacing = reconPar.colSpacing;
        //    vbx.RowSpacing = reconPar.rowSpacing;
        //    vbx.ShowPixelValue = cbxShowPixelValue.Checked;
        //    short tmpMax = 0;
        //    short tmpMin = 32767;
        //    for (int i = 0; i < image.Length; i++)
        //    {
        //        if (image[i] > tmpMax)
        //        {
        //            tmpMax = image[i];
        //        }
        //        if (image[i] < tmpMin)
        //        {
        //            tmpMin = image[i];
        //        }

        //    }

        //    vbx.Win = (short)(tmpMax - tmpMin);
        //    vbx.Lev = (short)((tmpMax + tmpMin) / 2);

        //}

        private short[][][] imageRecon(int[][][] rawData)
        {
            double[][][] tmpImage = new double[acqChannels][][];
            for (int i = 0; i < acqChannels; i++)
            {
                tmpImage[i] = new double[reconPar.noSlices][];
                for (int j = 0; j < reconPar.noSlices; j++)
                {
                    tmpImage[i][j] = new double[2 * reconPar.noScans * reconPar.noEchoes * reconPar.noSamples];
                }
            }
            short[][][] tmpShort = new short[acqChannels][][];
            for (int i = 0; i < acqChannels; i++)
            {
                tmpShort[i] = new short[reconPar.noSlices][];
                for (int j = 0; j < reconPar.noSlices; j++)
                {
                    tmpShort[i][j] = new short[2 * reconPar.noScans * reconPar.noEchoes * reconPar.noSamples];
                }
            }
            //double[] tmpImage = new double[2 * reconPar.noScans * reconPar.noEchoes * reconPar.noSamples];
            int NoCol = reconPar.noSamples;
            int NoRow = reconPar.noScans * reconPar.noEchoes;
            //double tmpDbl;

            for (int channel = 0; channel < acqChannels; channel++)
            {
                for (int slice = 0; slice < reconPar.noSlices; slice++)
                {

                    tmpImage[channel][slice] = MRIFFTW.doFFT2D(rawData[channel][slice], NoRow, NoCol, true);
                    //using (StreamWriter sw = new StreamWriter(@"D:\wuduan\Engineering\MRI_Spectrometer\EDA\Matlab\mri_data\20170802_anke\img_ch" + channel.ToString() + "_slice" + slice.ToString() + ".txt"))
                    //{
                    //    for (int i = 0; i < tmpImage.Length; i++)
                    //    {
                    //        sw.WriteLine(tmpImage[i].ToString("f1"));
                    //    }
                    //}
                }
            }
            //查找最大像素值
            double tmpMax = 0;
            double tmpMin = double.MaxValue;
            double tmpDbl;
            for (int i = 0; i < tmpImage.Length; i++)
            {
                for (int j = 0; j < tmpImage[0].Length; j++)
                {
                    for (int k = 0; k < tmpImage[0][0].Length / 2; k++)
                    {
                        tmpDbl = Math.Sqrt(tmpImage[i][j][2 * k] * tmpImage[i][j][2 * k] + tmpImage[i][j][2 * k + 1] * tmpImage[i][j][2 * k + 1]);
                        if (tmpDbl > tmpMax)
                        {
                            tmpMax = tmpDbl;
                        }
                        if (tmpDbl < tmpMin)
                        {
                            tmpMin = tmpDbl;
                        }
                    }
                }
            }
            //保证最大像素值不超过32767
            int ord = (int)Math.Ceiling(Math.Log(tmpMax, 2));
            double factor = 32767 / Math.Pow(2, ord) / Math.Sqrt(acqChannels);
            for (int i = 0; i < tmpImage.Length; i++)
            {
                for (int j = 0; j < tmpImage[0].Length; j++)
                {
                    for (int k = 0; k < tmpImage[0][0].Length; k++)
                    {
                        tmpShort[i][j][k] = (short)(tmpImage[i][j][k] * factor);
                    }
                }
            }
            tmpImage = null;
            firstImageDisplay = 0;
            return tmpShort;
        }

        private int[][][] openRawData(string[] fileName, reconPara para, int[] customPO, out int maxData, out int minData)
        {
            maxData = int.MinValue;
            minData = int.MaxValue;
            if (para.noEchoes > 1 && para.po == enumPhaseOrder.UserCustom)
            {
                if (customPO == null || customPO.Length != para.noEchoes * para.noScans)
                {
                    MessageBox.Show("wrong custom phase order array length!");

                    return null;
                }
            }
            int noChannels = fileName.Length;
            int[][][] tmpRawData = new int[noChannels][][];
            for (int i = 0; i < noChannels; i++)
            {
                tmpRawData[i] = new Int32[para.noSlices][];
                for (int j = 0; j < para.noSlices; j++)
                {
                    tmpRawData[i][j] = new int[2 * para.noScans * para.noEchoes * para.noSamples];
                }
            }
            for (int ch = 0; ch < fileName.Length; ch++)
            {
                using (FileStream fs = new FileStream(fileName[ch], FileMode.Open))
                {
                    int noCData = para.noSlices * para.noScans * para.noEchoes * para.noSamples;
                    byte[] buf = new byte[2 * 4 * noCData];
                    fs.Seek(64 * 1024 + 8 + 256, SeekOrigin.Begin);
                    int tmpLen = fs.Read(buf, 0, buf.Length);
                    for (int scan = 0; scan < para.noScans; scan++)
                    {
                        for (int slice = 0; slice < para.noSlices; slice++)
                        {
                            for (int echo = 0; echo < para.noEchoes; echo++)
                            {
                                for (int sample = 0; sample < 2 * para.noSamples; sample++)
                                {
                                    int posRawData = scan * para.noEchoes * 2 * para.noSamples + echo * 2 * para.noSamples + sample;
                                    //channelRawData[slice][posRawData] = swap4Bytes(buf, 4 * (posRawData + slice * 2 * para.noEchoes * para.noSamples));
                                    //int posRawData = scan * para.noEchoes * 2 * para.noSamples*para.noSlices + echo * 2 * para.noSamples + sample;
                                    //channelRawData[slice][posRawData] = swap4Bytes(buf, 4 * (posRawData + slice * 2 * para.noEchoes * para.noSamples));
                                    tmpRawData[ch][slice][posRawData] = swap4Bytes(buf, 4 * (sample + echo * 2 * para.noSamples + slice * 2 * para.noEchoes * para.noSamples + 2 * scan * para.noSlices * para.noEchoes * para.noSamples));
                                }
                            }
                        }
                    }
                    //多回波重排
                    if (para.noEchoes > 1)
                    {
                        int[] phaseOrder = new int[para.noEchoes * para.noScans];
                        if (para.po == enumPhaseOrder.UpDownUpDown)
                        {
                            for (int i = 0; i < para.noScans; i++)
                            {
                                for (int j = 0; j < para.noEchoes; j++)
                                {
                                    phaseOrder[i * para.noEchoes + j] = -j * para.noScans - i + (para.effectiveEcho - 1) * para.noScans + para.noScans / 2 + (para.noScans * para.noEchoes) / 2;
                                }
                            }
                        }
                        else if (para.po == enumPhaseOrder.UpDownDownUp)
                        {
                            for (int i = 0; i < para.noScans; i++)
                            {
                                for (int j = 0; j < para.noEchoes; j++)
                                {
                                    phaseOrder[i * para.noEchoes + j] = j * para.noScans - i + (para.effectiveEcho - 1) * para.noScans + para.noScans / 2 + (para.noScans * para.noEchoes) / 2;
                                }
                            }
                        }
                        else if (para.po == enumPhaseOrder.DownUpUpDown)
                        {
                            for (int i = 0; i < para.noScans; i++)
                            {
                                for (int j = 0; j < para.noEchoes; j++)
                                {
                                    phaseOrder[i * para.noEchoes + j] = -j * para.noScans + i + (para.effectiveEcho - 1) * para.noScans - para.noScans / 2 + (para.noScans * para.noEchoes) / 2;
                                }
                            }
                        }
                        else if (para.po == enumPhaseOrder.DownUpDownUp)
                        {
                            for (int i = 0; i < para.noScans; i++)
                            {
                                for (int j = 0; j < para.noEchoes; j++)
                                {
                                    phaseOrder[i * para.noEchoes + j] = j * para.noScans + i - (para.effectiveEcho - 1) * para.noScans - para.noScans / 2 + (para.noScans * para.noEchoes) / 2;
                                }
                            }
                        }
                        else if (para.po == enumPhaseOrder.UserCustom)
                        {

                        }
                        else
                        {
                            MessageBox.Show("unrecongnized phse order!");
                            return null;
                        }
                        for (int i = 0; i < phaseOrder.Length; i++)
                        {
                            if (phaseOrder[i] < 0)
                            {
                                phaseOrder[i] = phaseOrder[i] + para.noScans * para.noEchoes;
                            }
                            else if (phaseOrder[i] >= para.noScans * para.noEchoes)
                            {
                                phaseOrder[i] = phaseOrder[i] - para.noScans * para.noEchoes;
                            }
                        }

                        //k空间重排
                        int[] tmpRawData1 = new int[2 * para.noScans * para.noEchoes * para.noSamples];
                        int tmpInt;
                        for (int slice = 0; slice < para.noSlices; slice++)
                        {
                            for (int i = 0; i < tmpRawData1.Length; i++)
                            {
                                tmpInt = phaseOrder[i / (2 * para.noSamples)];
                                tmpRawData1[tmpInt * 2 * para.noSamples + i % (2 * para.noSamples)] = tmpRawData[ch][slice][i];
                            }
                            tmpRawData[ch][slice] = tmpRawData1;
                        }
                    }
                }
            }
            //查找最大最小值
            for (int i = 0; i < tmpRawData.Length; i++)
            {
                for (int j = 0; j < tmpRawData[0].Length; j++)
                {
                    for (int k = 0; k < tmpRawData[0][0].Length; k++)
                    {
                        if (tmpRawData[i][j][k] > maxData)
                        {
                            maxData = tmpRawData[i][j][k];
                        }
                        if (tmpRawData[i][j][k] < minData)
                        {
                            minData = tmpRawData[i][j][k];
                        }
                    }
                }
            }
            return tmpRawData;
        }

        private reconPara getReconPara(string fileName, reconParaFrom frm)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                reconPara rp = new reconPara();
                rp.effectiveEcho = 1;
                rp.noSlices = 1;
                rp.noScans = 1;
                rp.noAverages = 1;
                rp.noEchoes = 1;
                rp.noSamples = 1;
                rp.colSpacing = 1;
                rp.rowSpacing = 1;
                rp.po = enumPhaseOrder.DownUpDownUp;
                if (frm == reconParaFrom.fromRawData)
                {
                    //从原始数据提取重建参数
                    byte[] buf = new byte[64 * 1024];
                    fs.Read(buf, 0, buf.Length);
                    string str = System.Text.Encoding.ASCII.GetString(buf);
                    str = str.Remove(str.IndexOf("PARAMEND_V2"));
                    string[] lines = str.Split('\n');
                    double fovPhase = 0;
                    double fovRead = 0;
                    for (int i = 2; i < lines.Length; i++)
                    {
                        if (lines[i].Contains("noScans"))
                        {
                            rp.noScans = (int)double.Parse(lines[i].Remove(0, lines[i].IndexOf(',') + 1).Trim());
                        }
                        else if (lines[i].Contains("noEchoes"))
                        {
                            rp.noEchoes = (int)double.Parse(lines[i].Remove(0, lines[i].IndexOf(',') + 1).Trim());
                        }
                        else if (lines[i].Contains("noSamples"))
                        {
                            rp.noSamples = (int)double.Parse(lines[i].Remove(0, lines[i].IndexOf(',') + 1).Trim());
                        }
                        else if (lines[i].Contains("noAverages"))
                        {
                            rp.noAverages = (int)double.Parse(lines[i].Remove(0, lines[i].IndexOf(',') + 1).Trim());
                        }
                        else if (lines[i].Contains("noSlices"))
                        {
                            rp.noSlices = (int)double.Parse(lines[i].Remove(0, lines[i].IndexOf(',') + 1).Trim());
                        }
                        else if (lines[i].Contains("effectiveEcho"))
                        {
                            rp.effectiveEcho = (int)double.Parse(lines[i].Remove(0, lines[i].IndexOf(',') + 1).Trim());
                        }
                        else if (lines[i].Contains("fovPhase"))
                        {
                            fovPhase = double.Parse(lines[i].Remove(0, lines[i].IndexOf(',') + 1).Trim());
                        }
                        else if (lines[i].Contains("fovRead"))
                        {
                            fovRead = double.Parse(lines[i].Remove(0, lines[i].IndexOf(',') + 1).Trim());
                        }
                        if (fovPhase != 0 && fovRead != 0)
                        {
                            rp.colSpacing = (float)fovRead / rp.noSamples;
                            rp.rowSpacing = (float)fovPhase / rp.noScans / rp.noEchoes;
                        }
                    }
                    return rp;
                }
            }
            return new reconPara();
        }

        private int swap4Bytes(byte[] value, int firstByte)
        {
            return value[firstByte] << 24 | value[firstByte + 1] << 16 | value[firstByte + 2] << 8 | value[firstByte + 3];
            //return BitConverter.ToInt32(value, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(swap4Bytes(new byte[] { 0xff, 0xff, 0xff, 0xfd }, 0).ToString());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < vbxImage.Count; i++)
            {
                vbxImage[i].ShowPixelValue = cbxShowPixelValue.Checked;
                vbxImage[i].Refresh();
            }
        }

        private void btn2X2_Click(object sender, EventArgs e)
        {
            if (imLayout != ImageLayout.layout2X2)
            {
                imLayout = ImageLayout.layout2X2;
                setImageLayout();
            }
        }

        private void btn1X1_Click(object sender, EventArgs e)
        {
            if (imLayout != ImageLayout.layout1X1)
            {
                imLayout = ImageLayout.layout1X1;
                setImageLayout();
            }
        }

        private void btn3X3_Click(object sender, EventArgs e)
        {
            if (imLayout != ImageLayout.layout3X3)
            {
                imLayout = ImageLayout.layout3X3;
                setImageLayout();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pnlImages.Width = pnlImages.Height;
        }

        private void vbxImage_SizeChanged(object sender, EventArgs e)
        {
            //tbxInfo.AppendText("vbxImage_SizeChanged\r\n");
            //Debug.WriteLine("vbxImage_SizeChanged");
        }

        private void vbxImage_VisibleChanged(object sender, EventArgs e)
        {
            //tbxInfo.AppendText("vbxImage_VisibleChanged\r\n");
            //Debug.WriteLine("vbxImage_VisibleChanged");
        }

        private void vbxImage_Paint(object sender, PaintEventArgs e)
        {
        }

        private void vbxImage_Resize(object sender, EventArgs e)
        {
            //tbxInfo.AppendText("vbxImage_Resize\r\n");
            //Debug.WriteLine("vbxImage_Resize");
        }

        private void vbxImage_Click(object sender, EventArgs e)
        {

        }

        private void rbtMouseFunc_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton) == rbtMouseFuncNone)
            {
                annotationType = AnnotationType.None;
            }
            else if ((sender as RadioButton) == rbtMouseFuncEllipse)
            {
                annotationType = AnnotationType.Ellipse;
            }
            else if ((sender as RadioButton) == rbtMouseFuncRect)
            {
                annotationType = AnnotationType.Rectangular;
            }
            else if ((sender as RadioButton) == rbtMouseFuncLine)
            {
                annotationType = AnnotationType.Line;
            }
            for (int i = 0; i < vbxImage.Count; i++)
            {
                if (annotationType == AnnotationType.Ellipse)
                {
                    vbxImage[i].NewAnnotationType = typeof(Ellipse);
                }
                else if (annotationType == AnnotationType.Rectangular)
                {
                    vbxImage[i].NewAnnotationType = typeof(Box);
                }
                else if (annotationType == AnnotationType.Line)
                {
                    vbxImage[i].NewAnnotationType = typeof(Line);
                }
                else
                {
                    vbxImage[i].NewAnnotationType = null;
                }
            }

        }

        private void OnWinLvlChanged(ViewBoxForm viewbox)
        {
            foreach (var vb in vbxImage)
            {
                if (vb != viewbox)
                {
                    vb.Win = viewbox.Win;
                    vb.Lev = viewbox.Lev;
                }
            }
        }

        private void OnPanPosChanged(ViewBoxForm viewbox)
        {
            foreach (var vb in vbxImage)
            {
                if (vb != viewbox)
                {
                    vb.PanPosition = viewbox.PanPosition;
                }
            }
        }

        private void OnWinLvlChanging(ViewBoxForm viewbox)
        {
            foreach (var vb in vbxImage)
            {
                if (vb != viewbox)
                {
                    vb.Win = viewbox.Win;
                    vb.Lev = viewbox.Lev;
                }
            }
        }

        private void OnPanPosChanging(ViewBoxForm viewbox)
        {
            foreach (var vb in vbxImage)
            {
                if (vb != viewbox)
                {
                    vb.PanPosition = viewbox.PanPosition;
                }
            }
        }

        private void OnZoomFactorChanged(ViewBoxForm viewbox)
        {
            foreach (var vb in vbxImage)
            {
                if (vb != viewbox)
                {
                    vb.ZoomFactor = viewbox.ZoomFactor;
                }
            }
        }

        private void btnSaveDicom_Click(object sender, EventArgs e)
        {
            //根据文件名创建目录
            DirectoryInfo DICOMDir = Directory.CreateDirectory(defaultDICOMFolder + @"\" + Path.GetFileName(imagePar.imageFileName));
            for (int i = 0; i < imageAbsSOS.Length; i++)
            {
                DICOMUtils.SaveToDICOMFile(imageAbsSOS[i], imagePar.noRow, imagePar.noCol, DICOMDir.FullName + @"\exa." + i.ToString() + ".dcm");
            }

        }
    }



    public enum reconParaFrom { fromRawData, fromPar }

    public struct reconPara
    {
        public int noScans;
        public int noEchoes;
        public int noSamples;
        public int noAverages;
        public int noSlices;
        public int effectiveEcho;
        public float rowSpacing;
        public float colSpacing;
        public enumPhaseOrder po;

    }

    public struct imagePara
    {
        public int noRow;
        public int noCol;
        public float rowSpacing;
        public float colSpacing;
        public string imageFileName;
    }
    //参见预定义的多回波相位编码顺序.vsdx
    public enum enumPhaseOrder
    {
        CenterOutUpDown, CenterOutDownUp, OutCenterUpDown, OutCenterDownUp, UpDownDownUp,
        DownUpDownUp, UpDownUpDown, DownUpUpDown, UserCustom
    }

    public enum ImageLayout { layout1X1, layout2X2, layout3X3 }

    public enum AnnotationType { None, Ellipse, Rectangular, Line }
}
