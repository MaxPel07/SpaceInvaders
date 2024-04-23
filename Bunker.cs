using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoletest
{
    internal class Bunker
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Health { get; set; }

        public Bunker(int x, int y)
        {
            PositionX = x;
            PositionY = y;
            Health = 3;
        }

        public void Draw()
        {
            Console.SetCursorPosition(PositionX, PositionY);
            Console.Write("█████████");
        }
    }
}
