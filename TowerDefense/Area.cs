using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    class Area
    {
        public  int Left, Top, Width, Height;

        public Area(int left, int top, int width, int height)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }

        public int Bottom => Top + Height;
        public int Right => Left + Width;
    }
}
