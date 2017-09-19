using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewBoxContorl.Annotation.Data;

namespace ViewBoxContorl.Annotation
{
    public partial class Annotation
    {
        public class ShapeEvent
        {
            public enum  ShapeEventType
            {
                Create,
                Delete,
                Change
            }

            public ShapeEventType EvtType;
            public Shape shape;
            public ShapeSnapshotData SnapshotData;
        }

        Stack<ShapeEvent> _shapeEvents = new Stack<ShapeEvent>();

        public bool HasUndos
        { get { return _shapeEvents.Count > 0; } }

        public void PushEvent(ShapeEvent evt)
        {
            _shapeEvents.Push(evt);
        }

        public void UndoLastEvent()
        {
            if (!HasUndos)
                return;

            var undo = _shapeEvents.Pop();
            switch (undo.EvtType)
            {
                case ShapeEvent.ShapeEventType.Create:
                    DeleteShape(undo.shape); // call delete shape to avoid fire events again
                    break;
                case ShapeEvent.ShapeEventType.Delete:
                    _shapeList.Add(undo.shape);
                    break;
                case ShapeEvent.ShapeEventType.Change:
                    undo.shape.InitFromElementData(undo.SnapshotData);
                    break;
                default:
                    break;
            }
        }

        private void OnShapeCreated_Undo(Shape element)
        {
            var undoEvt = new ShapeEvent();
            undoEvt.shape = element;
            undoEvt.EvtType = ShapeEvent.ShapeEventType.Create;

            PushEvent(undoEvt);
        }

        private void OnShapeChanged_Undo(Shape shape, ManipCommand cmd)
        {
            var undoEvt = new ShapeEvent();
            undoEvt.shape = shape;
            undoEvt.EvtType = ShapeEvent.ShapeEventType.Change;
            undoEvt.SnapshotData = cmd.InitSnapshot;

            PushEvent(undoEvt);
        }

        private void OnShapeDeleted_Undo(Shape element)
        {
            var undoEvt = new ShapeEvent();
            undoEvt.shape= element;
            undoEvt.EvtType = ShapeEvent.ShapeEventType.Delete;

            PushEvent(undoEvt);
        }
    }
}
