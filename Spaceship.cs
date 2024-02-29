using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoletest
{
    internal class Spaceship
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Life { get; set; }
        public Spaceship(int x, int y, int life)
        {
            PositionX = x;
            PositionY = y;
            Life = life;
        }
    }
}
