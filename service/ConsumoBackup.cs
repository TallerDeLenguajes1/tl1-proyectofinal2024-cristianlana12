using System.Text.Json;

namespace api;

public class ConsumoBackup
{
    private static string nombreDir = "json";
    private static string nombreArchivo = "backup-personajes.json";
    private static List<CharactersPersonaje>? personajesBackup;

    /// <summary>
    /// Se encarga de traer los datos del archivo backup JSON
    /// </summary>
    public static void CargarBackup()
    {
        string path = @$"{nombreDir}/{nombreArchivo}";
        
        if (!File.Exists(path))
        {
            personajesBackup = new List<CharactersPersonaje>();
            return;
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
                    personajesBackup = JsonSerializer.Deserialize<List<CharactersPersonaje>>(json);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nHa ocurrido un error leyendo el archivo backup de personajes: {ex.Message}\n");
            personajesBackup = new List<CharactersPersonaje>();
        }
    }

    public static CharactersPersonaje? ObtenerPersonaje(int id)
    {
        // Si aún no se cargó el backup, leo el json
        if (personajesBackup == null) CargarBackup();

        // Si no se pudo leer el json, la lista estará vacía y no podré obtener un personaje
        if (personajesBackup != null && !personajesBackup.Any()) return null;
        
        CharactersPersonaje? personajeBuscado = null;
        foreach (var personaje in personajesBackup!)
        {
            if (personaje.Id == id) personajeBuscado = personaje;
        }

        return personajeBuscado;
    }
}