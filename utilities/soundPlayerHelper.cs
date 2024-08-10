using System.Media;

namespace utilities
{
    public static class SoundPlayerHelper
    {
        private static SoundPlayer _player;

        public static void PlaySound(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                Console.WriteLine("El archivo de sonido no se encontró en la ruta especificada: " + path);
                return;
            }

            if (_player != null)
            {
                _player.Stop(); // Detener la reproducción actual
            }

            _player = new SoundPlayer(path);
            _player.Load();
            _player.Play();
        }

        public static void StopSound()
        {
            if (_player != null)
            {
                _player.Stop();
            }
        }
    }
}