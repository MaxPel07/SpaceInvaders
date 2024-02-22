using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Consoletest
{
    internal class Missile
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public Missile(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }

        public void Draw()
        {
            Console.SetCursorPosition(PositionX, PositionY);
            Console.Write("^");
        }

        public void Move()
        {
            Console.SetCursorPosition(PositionX, PositionY);
            Console.Write(" ");

            PositionY--;

            if (PositionY < 0)
            {
                // Le missile a atteint le bord supérieur de l'écran, marquez-le pour suppression
                PositionY = -1;
            }
        }

    }
}
