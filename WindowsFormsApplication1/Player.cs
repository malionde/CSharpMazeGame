using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Player
    {
        public int X;
        public int Y;
        public Direction Yon;


    }


    public enum Direction
    {    
        Top,
        Right,
        Down,
        Left,
        Stop
    }
}
