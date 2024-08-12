using System.Net;
using System.Text.Json;

namespace api
{
    public class consumoApi
    {
        public static async Task<CharactersPersonaje?> Get(int id)
        {
            //Defino un evento get Privado
            var url = $"https://dragonball-api.com/api/characters/{id}"; //declaro la variable var donde tiene la url para llegar a la api
            try
            {
                using (HttpClient clienteHttp = new HttpClient()) //obj propio de c# que permite realizar peticiones a las api
                {
                    HttpResponseMessage apiRespuesta = await clienteHttp.GetAsync(url);
                    apiRespuesta.EnsureSuccessStatusCode();

                    var cuerpoRespuesta = await apiRespuesta.Content.ReadAsStringAsync();
                    var respuestaDeserealizada = JsonSerializer.Deserialize<CharactersPersonaje>(cuerpoRespuesta);

                    return respuestaDeserealizada;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"\n* Ha ocurrido un error consumiendo la API: {ex.Message}");
                return ConsumoBackup.ObtenerPersonaje(id);
            }
        }
    }
}
