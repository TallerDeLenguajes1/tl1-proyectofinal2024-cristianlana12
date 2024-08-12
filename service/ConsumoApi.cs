using System.Net;
using System.Text.Json; // Importa el espacio de nombres para manejar la serialización y deserialización JSON.

namespace api
{
    public class consumoApi
    {
        // Método asincrónico que obtiene un personaje de la API usando su ID.
        public static async Task<CharactersPersonaje?> Get(int id)
        {
            //// Defino la URL de la API, incluyendo el ID del personaje.
            var url = $"https://dragonball-api.com/api/characters/{id}"; //declaro la variable var donde tiene la url para llegar a la api
            try
            {
                // Uso de HttpClient para realizar la solicitud HTTP a la API.
                using (HttpClient clienteHttp = new HttpClient()) //obj propio de c# que permite realizar peticiones a las api
                {
                    
                    HttpResponseMessage apiRespuesta = await clienteHttp.GetAsync(url);// Realiza una solicitud GET a la URL especificada.
                    apiRespuesta.EnsureSuccessStatusCode(); // Verifica si la respuesta fue exitosa 

                    var cuerpoRespuesta = await apiRespuesta.Content.ReadAsStringAsync(); // Lee el cuerpo de la respuesta como una cadena de texto.
                    var respuestaDeserealizada = JsonSerializer.Deserialize<CharactersPersonaje>(cuerpoRespuesta); // Deserializa la cadena JSON en un objeto de tipo CharactersPersonaje.

                    return respuestaDeserealizada;// Retorna el objeto deserializado.
                }
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que ocurra durante la solicitud y muestra un mensaje de error en la consola.
                System.Console.WriteLine($"\n* Ha ocurrido un error consumiendo la API: {ex.Message}");

                // En caso de error, llama a un método de respaldo para obtener el personaje.
                return ConsumoBackup.ObtenerPersonaje(id);
            }
        }
    }
}
