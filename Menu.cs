using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Input;

namespace Consoletest
{
    internal class Menu
    {
        [STAThread]
        public static void Main()
        {
            MainMenu();
            void MainMenu()
            {
                Game game = new Game();
                Console.Clear();
                Console.WriteLine(
                "************* \n" +
                "SPICY INVADER \n" +
                "************* \n" +
                "[1] Jouer \n" +
                "[2] A propos \n" +
                "[3] quitter \n");
                Console.WriteLine(
                   "                          _                     _               \r\n" +
                   "                         (_)                   | |              \r\n" +
                   " ___ _ __   __ _  ___ ___ _ _ ____   ____ _  __| | ___ _ __ ___ \r\n" +
                   "/ __| '_ \\ / _` |/ __/ _ \\ | '_ \\ \\ / / _` |/ _` |/ _ \\ '__/ __|\r\n" +
                   "\\__ \\ |_) | (_| | (_|  __/ | | | \\ V / (_| | (_| |  __/ |  \\__ \\\r\n" +
                   "|___/ .__/ \\__,_|\\___\\___|_|_| |_|\\_/ \\__,_|\\__,_|\\___|_|  |___/\r\n" +
                   "    | |                                                         \r\n" +
                   "    |_|");

                Console.WriteLine(
                       "  ■     ■\n" +
                       "   ■   ■\n" +
                       "  ■■■■■■■\n" +
                       " ■■ ■■■ ■■\n" +
                       "■■■■■■■■■■■\n" +
                       "■ ■■■■■■■ ■\n" +
                       "■ ■     ■ ■\n" +
                       "   ■■ ■■\n");

                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.KeyChar)
                {
                    case '1':
                        DifficultyChoice();
                        Console.Clear();
                        break;

                    case '2':
                        Informations();
                        break;

                    case '3':
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
            }

            void DifficultyChoice()
            {
                //Game game = new Game();
                Console.Clear();
                Console.WriteLine(
                    "********************** \n" +
                    "Choix de la difficulté \n" +
                    "********************** \n" +
                    "[1] mode facile \n" +
                    "[2] mode difficile \n" +
                    "[3] retour\n \n" +
                    "Appuyer sur une touche pour revenir au menu");

                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.KeyChar)
                {
                    case '1':
                        Game.EasyMode();
                        break;

                    case '2':
                        //HardMode();
                        break;

                    case '3':
                        Main();
                        break;

                    default:
                        Main();
                        break;
                }
            }

            void Informations()
            {
                Console.Clear();
                Console.WriteLine(
                    "Spicy Invader est un jeu basé sur le jeu, connu mondialement, Space Invaders \n" +
                    "\n Appuyer sur une touche pour revenir au menu");

                ConsoleKeyInfo key = Console.ReadKey();

                {
                    switch (key.KeyChar)
                    {
                        default:
                            MainMenu();
                            break;
                    }
                }
            }
        }
    }
}