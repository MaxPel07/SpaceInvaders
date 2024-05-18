using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Consoletest
{
    internal class Sounds
    {
        // Musique du jeu
        private static SoundPlayer backgroundMusic;

        static Sounds()
        {
            // Initialisez le lecteur audio avec le chemin vers votre fichier audio
            backgroundMusic = new SoundPlayer(@"E:\Semestre 2\I226_progObjet\trimestre3\Consoletest\Sounds\DensityAndTime.wav");
        }
        public static void PlayBackgroundMusic()
        {
            backgroundMusic.PlayLooping(); // Joue la musique en boucle
        }
        public static void StopBackgroundMusic()
        {
            backgroundMusic.Stop();
        }
    }

    class BlastShot
    {
        // Son missile
        private static SoundPlayer blastGun;

        static BlastShot()
        {
            // Initialisez le lecteur audio avec le chemin vers votre fichier audio
            blastGun = new SoundPlayer(@"E:\Semestre 2\I226_progObjet\Consoletest\Sounds\DensityAndTime.wav");
        }
        public static void PlayBlastShot()
        {
            blastGun.PlayLooping(); // Joue la musique en boucle
        }
        public static void StopBlastShot()
        {
            blastGun.Stop();
        }
    }
}
