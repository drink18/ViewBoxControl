using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewBoxContorl
{
    public class RawDataSizeErrorException : Exception
    {
        public int col;
        public int row;
        public int size;
        public RawDataSizeErrorException(int Col, int Row, int Size)
        {
            col = Col;
            row = Row;
            size = Size;
        }
    }
}
