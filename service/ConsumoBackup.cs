using System.Text.Json;

namespace api;

public class ConsumoBackup
{

    private static string nombreDir = "json"; // Define el nombre del directorio donde se almacenan los archivos JSON.
    private static string nombreArchivo = "backup-personajes.json";// Define el nombre del archivo de respaldo JSON.
    private static List<CharactersPersonaje>? personajesBackup; // Lista que almacenará los personajes cargados desde el archivo de respaldo.

    /// <summary>
    /// Se encarga de traer los datos del archivo backup JSON
    /// </summary>
    public static void CargarBackup()
    {
        string path = @$"{nombreDir}/{nombreArchivo}"; // Construye la ruta completa al archivo de respaldo.

        if (!File.Exists(path)) // Verifica si el archivo existe.
        {
            personajesBackup = new List<CharactersPersonaje>();// Si no existe, inicializa una lista vacía para los personajes.
            return; // Sale del método si no existe el archivo.
        }

        try
        {
            //abre el archivo en modo de lectura
            using (var archivoOpen = new FileStream(path, FileMode.Open))
            {
                //Usa un StreamReader para leer todo el contenido del archivo
                using (var strReader = new StreamReader(archivoOpen))
                {
                    //Lee el contenido del archivo JSON como una cadena
                    string json = strReader.ReadToEnd();

                    // Deserializa la cadena JSON en una lista de objetos CharactersPersonaje.
                    personajesBackup = JsonSerializer.Deserialize<List<CharactersPersonaje>>(json);
                }
            }
        }
        catch (Exception ex)
        {
            // Maneja cualquier excepción que ocurra durante la lectura del archivo y muestra un mensaje de error en la consola.
            Console.WriteLine($"\nHa ocurrido un error leyendo el archivo backup de personajes: {ex.Message}\n");

            personajesBackup = new List<CharactersPersonaje>();// Inicializa una lista vacía en caso de error.
        }
    }

    public static CharactersPersonaje? ObtenerPersonaje(int id)
    {
        // Si aún no se cargó el backup, leo el json
        if (personajesBackup == null) CargarBackup();

        // Si no se pudo leer el json, la lista estará vacía y no podré obtener un personaje
        if (personajesBackup != null && !personajesBackup.Any()) return null;

        CharactersPersonaje? personajeBuscado = null;
        foreach (var personaje in personajesBackup!) // Recorre la lista de personajes buscando un personaje con el ID especificado.
        {
            if (personaje.Id == id) personajeBuscado = personaje;  // Si encuentra el personaje con el ID correspondiente, lo asigna a la variable personajeBuscado.
        }

        return personajeBuscado; // Retorna el personaje encontrado o null si no lo encontró.
    }
}