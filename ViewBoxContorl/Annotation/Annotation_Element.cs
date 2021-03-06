﻿using System;
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
        Shape _creatingEle = null;
        public Shape ShapeBeingCreated
        {
            get { return _creatingEle; }
        }
        public Shape CreateNewElement(Type t, Point position, Matrix client2Img) 
        {
            _creating = true;
            _creatingEle = (Shape)Activator.CreateInstance(t, new object[] {Client2Img(new PointF(position.X, position.Y))});
            return _creatingEle;
        }

        public void SetupCreationContext(Type t)
        {
            if(t.IsSubclassOf(typeof(Shape)))
            {
                CurrentInteractContext = InteractContext.Create;
                NewElementType = t;
            }
        }


        // add shape directly into list, assuming a shape is already setup and valid
        // supposed to be used by code
        public void AddShapeToList(Shape e)
        {
            _shapeList.Add(e);
        }
    }
}
