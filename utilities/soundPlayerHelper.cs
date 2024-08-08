using System.Media;

namespace utilities
{
    public static class SoundPlayerHelper
    {
        public static void PlaySound(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                Console.WriteLine("El archivo de sonido no se encontró en la ruta especificada: " + path);
                return;
            }

            using (SoundPlayer player = new SoundPlayer(path))
            {
                player.Load();
                player.Play();
            }
        }
    }
}