using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Consoletest
{
    class Game
    {
        // Position initiale du joueur
        static int playerPositionX = 40;
        static List<Missile> missiles = new List<Missile>();

        static void Main()
        {
            Console.WindowHeight = 40;
            Console.WindowWidth = 85;
            Console.BufferHeight = 40;
            Console.BufferWidth = 85;

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

                    if (keyInfo.Key == ConsoleKey.LeftArrow && playerPositionX > 0)
                    {
                        playerPositionX--;
                    }
                    else if (keyInfo.Key == ConsoleKey.RightArrow && playerPositionX < Console.WindowWidth - 6)
                    {
                        playerPositionX++;
                    }
                    else if (keyInfo.Key == ConsoleKey.Spacebar)
                    {
                        FireMissile();
                    }
                }

                MoveMissiles();

                Console.Clear();
                DrawPlayer();
                DrawMissiles();

                Thread.Sleep(20); // Ajoute un délai pour ralentir le mouvement du vaisseau et des missiles
            }
        }
        
        static void DrawPlayer()
        {
            Console.SetCursorPosition(playerPositionX, Console.WindowHeight - 1);
            Console.Write("|-O-|");
        }
        
        static void FireMissile()
        {
            missiles.Add(new Missile(playerPositionX + 2, Console.WindowHeight - 2));
        }

        static void DrawMissiles()
        {
            foreach (var missile in missiles)
            {
                missile.Draw();
            }
        }

        static void MoveMissiles()
        {
            foreach (var missile in missiles)
            {
                missile.Move();
            }

            // Supprime les missiles qui sont sortis de l'écran
            missiles.RemoveAll(m => m.PositionY < 0);
        }
    }
}


