using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace multiViewBox
{
    public class LowLevelEventArgs : EventArgs
    {
        private int selectedImage;

        public int SelectedImage
        {
            get
            {
                return selectedImage;
            }

            //set
            //{
            //    selectedImage = value;
            //}
        }

        public LowLevelEventArgs(int value)
        {
            this.selectedImage = value;
        }
    }

    [ComVisible(true)]
    public delegate void LowLevelImageEventHandler(object sender, LowLevelEventArgs e);
}
