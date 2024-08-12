using System.Text.Json;
using clasePersonaje;

namespace api
{
    public class historialObj
    {
        private string nameJson = "historial.json";
        private string nameFile = "json";
        public void guardarGanador(PersonajeDatos personajeGanador) // Método que guarda el personaje ganador en el historial.
        {
            string nombreArchivo = @$"{nameFile}/{nameJson}"; // Construye la ruta completa al archivo del historial.

            // Lee los ganadores existentes y los añade a la lista.
            List<PersonajeDatos> ganadores = leerGanadores();
            ganadores.Add(personajeGanador);

            // Crea o abre el archivo del historial para escribir los ganadores.
            try
            {
                using (FileStream historialJson = new FileStream(nombreArchivo, FileMode.OpenOrCreate))
                {
                    // Usa un StreamWriter para escribir en el archivo.
                    using (StreamWriter historialWriter = new StreamWriter(historialJson))
                    {
                        // Serializa la lista de ganadores a formato JSON con indentación para mayor legibilidad.
                        string historialSerializado = JsonSerializer.Serialize(ganadores, new JsonSerializerOptions { WriteIndented = true });

                        // Escribe el JSON serializado en el archivo.
                        historialWriter.WriteLine(historialSerializado);
                    }
                }
            }
            catch (Exception)
            {
                 // Maneja cualquier excepción durante la escritura y muestra un mensaje de error en la consola.
                Console.WriteLine("Ocurrio un error mostrando el historial");
            }
        }

        public List<PersonajeDatos> leerGanadores() // Método que lee el historial de ganadores desde el archivo JSON.
        {
            string nombreArchivo = @$"{nameFile}/{nameJson}";
            verificarUbicacion(); // Verifica si el directorio donde se guardará el archivo existe, y si no, lo crea.
            if (!File.Exists(nombreArchivo)) 
            {
                return new List<PersonajeDatos>();// Si el archivo no existe, retorna una lista vacía.
            }

            var ganadores = new List<PersonajeDatos>(); // Inicializa la lista de ganadores.

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

                        // Deserializa la cadena JSON en una lista de objetos PersonajeDatos.
                        ganadores = JsonSerializer.Deserialize<List<PersonajeDatos>>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción durante la lectura y muestra un mensaje de error en la consola.
                Console.WriteLine($"Ha ocurrido un error leyendo el historial de ganadores: {ex.Message}");

                // Inicializa una lista vacía en caso de error.
                ganadores = new List<PersonajeDatos>();
            }
            return ganadores;
        }

        public void verificarUbicacion() // Método que verifica si el directorio donde se guardará el archivo JSON existe, y si no, lo crea.
        {
            if (!Directory.Exists(nameFile))// Verifica si el directorio no existe.
            {
                Directory.CreateDirectory(nameFile); // Crea el directorio si no existe.
            }

        }
    }
}