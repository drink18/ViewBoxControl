using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ViewBoxContorl.Annotation
{
    partial class AnnotationSelection
    {
        HashSet<Shape> _selectedElements = new HashSet<Shape>();
        public HashSet<Shape> SelectedShapes
        {
            get { return _selectedElements; }
            set { _selectedElements = value; }
        }

        public void AddToSelection(Shape ele)
        {
            _selectedElements.Add(ele);
        }

        public bool IsSelected(Shape ele)
        {
            return _selectedElements.Contains(ele);
        }

        public void RemoveFromSelectoin(Shape ele)
        {
            _selectedElements.Remove(ele);
        }

        public void ClearSelection()
        {
            _selectedElements.Clear();
        }

    }
}
