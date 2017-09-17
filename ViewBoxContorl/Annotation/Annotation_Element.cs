using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewBoxContorl.Annotation
{
    partial class Annotation
    {
        public enum InteractContext
        {
            Create,
            Manipulate
        }

        public InteractContext CurrentInteractContext
        {
            get;
            set;
        }

        public Type NewElementType = null;

        bool _creating = false;
        BaseElement _creatingEle = null;
        BaseElement _pickedElement = null;
        public BaseElement CreateNewElement(Type t, Point position, Matrix client2Img) 
        {
            _creating = true;
            _creatingEle = (BaseElement)Activator.CreateInstance(t, new object[] { position, client2Img });
            return _creatingEle;
        }

        public void SetupCreationContext(Type t)
        {
            if(t.IsSubclassOf(typeof(BaseElement)))
            {
                CurrentInteractContext = InteractContext.Create;
                NewElementType = t;
            }
        }
    }
}
