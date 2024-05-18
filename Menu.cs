using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Input;

namespace Consoletest
{
    public class Menu
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
                   "\t\t\t                             _                     _               \r\n" +
                   "\t\t\t                            (_)                   | |              \r\n" +
                   "\t\t\t    ___ _ __   __ _  ___ ___ _ _ ____   ____ _  __| | ___ _ __ ___ \r\n" +
                   "\t\t\t   / __| '_ \\ / _` |/ __/ _ \\ | '_ \\ \\ / / _` |/ _` |/ _ \\ '__/ __|\r\n" +
                   "\t\t\t   \\__ \\ |_) | (_| | (_|  __/ | | | \\ V / (_| | (_| |  __/ |  \\__ \\\r\n" +
                   "\t\t\t   |___/ .__/ \\__,_|\\___\\___|_|_| |_|\\_/ \\__,_|\\__,_|\\___|_|  |___/\r\n" +
                   "\t\t\t       | |                                                         \r\n" +
                   "\t\t\t       |_|");

                Console.WriteLine(
                "\n\n                                              ************* \n" +
                "                                              SPICY INVADER \n" +
                "                                              ************* \n" +
                "                                              [1] Jouer \n" +
                "                                              [2] A propos \n" +
                "                                              [3] quitter \n");

                Console.WriteLine(
                       "                                                   ██          ██\n" +
                       "                                                     ██      ██\n" +
                       "                                                   ██████████████\n" +
                       "                                                 ████  ██████  ████\n" +
                       "                                               ██████████████████████\n" +
                       "                                               ██  ██████████████  ██\n" +
                       "                                               ██  ██          ██  ██\n" +
                       "                                                     ████  ████\n");

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
                    "\n\n\n\n\n\n\n\n\n\n                                              ********************** \n" +
                    "                                              Choix de la difficulté \n" +
                    "                                              ********************** \n" +
                    "                                              [1] mode facile \n" +
                    "                                              [2] mode difficile \n" +
                    "                                              [3] retour\n \n" +
                    "                                    Appuyer sur une touche pour revenir au menu");

                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.KeyChar)
                {
                    case '1':
                        Game game = new Game();
                        game.EasyMode();
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