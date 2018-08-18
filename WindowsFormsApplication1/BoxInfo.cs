using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class BoxInfo
    {
        public BoxInfo()
        {

        }

        public char C;
        public int X;
        public int Y;


        public BoxInfo(char c)
        {

        }

        public override string ToString()
        {
            return $"X:{X} Y:{Y} C:{C}";
        }
    }
}
