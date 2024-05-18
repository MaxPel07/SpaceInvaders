using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Consoletest
{
    internal class Missile
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Life { get; set; }

        public Missile(int x, int y, int life)
        {
            PositionX = x;
            PositionY = y;
            Life = life;
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

            if (PositionY < 0 || Life <= 0)
            {
                // Le missile a atteint le bord supérieur de l'écran ou n'a plus de vie.
                // Il sera supprimé dans la méthode "MoveMissiles()"
                PositionY = -1;
            }
        }
    }
}
