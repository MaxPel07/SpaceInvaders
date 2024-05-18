using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Consoletest
{
    internal class Enemy
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public Enemy(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }

        public void Draw()
        {
            Console.SetCursorPosition(PositionX, PositionY);
            Console.Write("\\--♦--/");
        }

        public void Move(bool moveRight)
        {
            // Efface le dessin de l'ennemi à sa position actuelle
            Erase();

            // Déplacement des ennemis vers la droite
            if (moveRight)
                PositionX++;
            else
                PositionX--;
            Draw();
        }

        public void Erase()
        {
            // Efface le dessin de l'ennemi à sa position actuelle
            Console.SetCursorPosition(PositionX, PositionY);
            Console.Write("       "); 
        }
    }
}
