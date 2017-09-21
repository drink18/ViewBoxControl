using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewBoxContorl
{
    public partial class ViewBoxForm : UserControl
    {
        /// <summary>
        /// keyboard event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_KeyDown(object sender, KeyEventArgs e)
        {
            if(InterationMode == Interaction.Annotation)
            {
                if(e.KeyCode == Keys.Delete)
                {
                    foreach (var ele in _annotation.SelectedShapes)
                    {
                        _annotation.RemoveShape(ele);
                    }

                    this.View.Refresh();
                }

                if(e.KeyCode == Keys.Z && e.Control)
                {
                    _annotation.UndoLastEvent();
                    View.Refresh();
                }
            }
        }

    }
}
