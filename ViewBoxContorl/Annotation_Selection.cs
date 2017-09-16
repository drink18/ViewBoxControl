﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewBoxContorl.Annotation
{
    partial class AnnotationSelection
    {
        HashSet<BaseElement> _selectedElements = new HashSet<BaseElement>();

        public void AddToSelection(BaseElement ele)
        {
            _selectedElements.Add(ele);
        }

        public bool IsSelected(BaseElement ele)
        {
            return _selectedElements.Contains(ele);
        }

        public void RemoveFromSelectoin(BaseElement ele)
        {
            _selectedElements.Remove(ele);
        }

        public void ClearSelection()
        {
            _selectedElements.Clear();
        }
    }
}
