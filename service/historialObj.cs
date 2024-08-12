using System.Text.Json;
using clasePersonaje;

namespace api
{
    public class historialObj
    {
        private string nameJson = "historial.json";
        private string nameFile = "json";
        public void guardarGanador(PersonajeDatos personajeGanador)
        {
            string nombreArchivo = @$"{nameFile}/{nameJson}";

            List<PersonajeDatos> ganadores = leerGanadores();
            ganadores.Add(personajeGanador);

            // Creo el archivo del historial
            try
            {
                using (FileStream historialJson = new FileStream(nombreArchivo, FileMode.OpenOrCreate))
                {
                    using (StreamWriter historialWriter = new StreamWriter(historialJson))
                    {

                        string historialSerializado = JsonSerializer.Serialize(ganadores, new JsonSerializerOptions { WriteIndented = true });
                        historialWriter.WriteLine(historialSerializado);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error mostrando el historial");
            }
        }

        public List<PersonajeDatos> leerGanadores()
        {
            string nombreArchivo = @$"{nameFile}/{nameJson}";
            verificarUbicacion();
            if (!File.Exists(nombreArchivo))
            {
                return new List<PersonajeDatos>();
            }

            var ganadores = new List<PersonajeDatos>();

            try
            {
                //abre el archivo en modo de lectura
                using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
                {
                    //Usa un StreamReader para leer todo el contenido del archivo
                    using (var strReader = new StreamReader(archivoOpen))
                    {
                        //Lee el contenido del archivo JSON como una cadena
                        string json = strReader.ReadToEnd();
                        ganadores = JsonSerializer.Deserialize<List<PersonajeDatos>>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error leyendo el historial de ganadores: {ex.Message}");
                ganadores = new List<PersonajeDatos>();
            }
            return ganadores;
        }

        public void verificarUbicacion()
        {
            if (!Directory.Exists(nameFile))
            {
                Directory.CreateDirectory(nameFile);
            }
            
        }
    }
}