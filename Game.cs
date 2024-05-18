using System;
using System.Media;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using System.Diagnostics;

namespace Consoletest
{

    class Game
    {
        // Position initiale du joueur
        static int playerPositionX = 40;

        // liste des Missile
        static List<Missile> missiles = new List<Missile>();

        // liste des Bunker
        static List<Bunker> bunkers = new List<Bunker>();

        // liste des ennemis
        private List<Enemy> enemies = new List<Enemy>();

        // booléen pour faire bouber les ennemies à gauche ou à droite
        public bool moveRight { get; set; } = true;

        // compteur pour faire bouger les ennemies
        static int invadersFrameCount = 0;

        [STAThread]
        public void EasyMode()
        {
            int oldPlayerPositionX = playerPositionX;

            // paramètres de la fenêtre
            Console.WindowHeight = 40;
            Console.WindowWidth = 85;
            Console.BufferHeight = 40;
            Console.BufferWidth = 85;

            // Efface le menu pour laisser place au jeu
            Console.Clear();


            // Lancement de la musique de fond du jeu
            Sounds.PlayBackgroundMusic();

            // Ajout de bunkers
            InitializeBunkers();

            // Ajoute des ennemies
            InitializeEnemies();

            // curseur invisible pour la jouabilité du jeu
            Console.CursorVisible = false;

            ConsoleKeyInfo keyInfo;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey(true);
                    // Vide la file d'attente des touches pour éviter le déplacement continu
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }

                    if (Keyboard.IsKeyDown(Key.Left) && playerPositionX > 0)
                    {
                        playerPositionX--;
                    }
                    if (Keyboard.IsKeyDown(Key.Right) && playerPositionX < Console.WindowWidth - 6)
                    {
                        playerPositionX++;
                    }
                    if (Keyboard.IsKeyDown(Key.Space))
                    {
                        // Tire du missile et son du missile
                        FireMissile();
                        //BlastShot.PlayBlastShot();
                    }

                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        // Sort de la boucle
                        break;
                    }
                }

                MoveMissiles();

                // Efface et redessine le joueur
                DrawPlayer(oldPlayerPositionX);
                oldPlayerPositionX = playerPositionX;

                // Redessine les missiles et les bunkers
                DrawMissiles();
                DrawBunkers();

                if (invadersFrameCount == 10)
                {
                    // Redessin des ennemis
                    MoveEnemies(enemies);
                    DrawEnemies();

                    invadersFrameCount = 0;
                }


                // Ajoute un délai pour ralentir le mouvement du vaisseau et des missiles
                Thread.Sleep(1);
                invadersFrameCount++;
            }
        }

        void InitializeBunkers()
        {
            // Initialisation des bunkers
            for (int i = 0; i < 3; i++)
            {
                bunkers.Add(new Bunker(13 + i * 25, Console.WindowHeight - 5));
            }
        }

        void DrawBunkers()
        {
            foreach (var bunker in bunkers)
            {
                bunker.Draw();
            }
        }

        void DrawPlayer(int oldPlayerPositionX)
        {
            // Efface l'ancien dessin du vaisseau
            Console.SetCursorPosition(oldPlayerPositionX, Console.WindowHeight - 1);
            
            // Efface le vaisseau à son ancienne position
            Console.Write("     ");

            // Dessine le vaisseau à sa nouvelle position
            Console.SetCursorPosition(playerPositionX, Console.WindowHeight - 1);
            Console.Write("|-O-|");
        }

        void FireMissile()
        {
            missiles.Add(new Missile(playerPositionX + 2, Console.WindowHeight - 2, life: 1));
        }

        void DrawMissiles()
        {
            foreach (var missile in missiles)
            {
                missile.Draw();
            }
        }

        void MoveMissiles()
        {
            foreach (var missile in missiles)
            {
                missile.Move();
            }

            // Supprime les missiles qui sont sortis de l'écran
            missiles.RemoveAll(m => m.PositionY < 0);
        }

        #region Enemies
        void InitializeEnemies()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    int enemyX = col * 15;
                    int enemyY = row * 4;
                    enemies.Add(new Enemy(enemyX, enemyY));
                }
            }
        }

        void DrawEnemies()
        {
            foreach (var enemy in enemies)
            {
                // dessine l'ennemies
                enemy.Draw();
            }
        }

        public void MoveEnemies(List<Enemy> enemies)
        {
            bool shouldChangeDirection = false;
            // Déterminer la direction du mouvement des ennemis en fonction de MoveDirection


            foreach (var enemy in enemies)
            {
                if (enemy.PositionX + 7 >= Console.WindowWidth && moveRight)
                {
                    shouldChangeDirection = true;
                    moveRight = false;
                    break;
                }

                else if (enemy.PositionX <= 1 && !moveRight)
                {
                    shouldChangeDirection = true;
                    moveRight = true;
                    break;
                }
                enemy.Move(moveRight);
            }

            // Déplacez tous les ennemis
            foreach (var enemy in enemies)
            {
                // Si un ennemi atteint une bordure, faites descendre tous les ennemis
                if (shouldChangeDirection)
                {
                    enemy.Erase();
                    enemy.PositionY++;
                }
                enemy.Move(moveRight);
            }
        }

        enum Direction
        {
            Left,
            Right
        }

        Direction MoveDirection = Direction.Right;
        #endregion
    }
}