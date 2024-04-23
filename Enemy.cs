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

        public void Move(bool moveRight, List<Enemy> enemies)
        {
            // Efface le dessin de l'ennemi à sa position actuelle
            Erase();

            // Déplacement des ennemis vers la droite
            if (moveRight)
                PositionX++;
            else
                PositionX--;

            // Si l'ennemi atteint le bord droit de l'écran, déplace tous les ennemis vers le bas et changer de direction
            if (PositionX + 6 == Console.WindowWidth && moveRight)
            {
                foreach (var enemy in enemies)
                {
                    Erase();
                    enemy.PositionY++;
                }
                // Changer la direction des ennemis (vers la gauche)
                moveRight = false;
            }

            // Si l'ennemi atteint le bord gauche de l'écran, déplacer tous les ennemis vers le bas et changer de direction
            else if (PositionX <= 0 && !moveRight)
            {
                foreach (var enemy in enemies)
                {
                    enemy.PositionY++;
                }
                // Changer la direction des ennemis (vers la droite)
                moveRight = true;
            }

        }

        public void Erase()
        {
            // Efface le dessin de l'ennemi à sa position actuelle
            Console.SetCursorPosition(PositionX, PositionY);
            Console.Write("       "); 
        }
    }
}
