using System.Net;
using System.Text.Json;

namespace api
{
    public class consumoApi
    {
        public static CharactersPersonaje? Get(int id)
        {  //Defino un evento get Privado
            var url = $"https://dragonball-api.com/api/characters/{id}"; //declaro la variable var donde tiene la url para llegar a la api
            //Console.WriteLine(url);
            var request = (HttpWebRequest)WebRequest.Create(url); //Aca crea el elemento de tipo httpRequest
            request.Method = "GET"; //donde le manto el metodo get
            request.ContentType = "application/json"; // En las 2 lineas le aviso que la aplicacion me debe devolver un archivo de tipo json
            request.Accept = "application/json";

            //Aqui Convertimos el request
            try
            {
                using (WebResponse response = request.GetResponse())  //aqui nos devuelve el reques como un objeto de webResponse
                {
                    using (Stream strReader = response.GetResponseStream()) //aqui a esa respuesta la convertimos en un objeto de tipo stream
                    {
                        if (strReader == null) return null; //si es igual a nulo retorna, si es distinto de null sigue 
                        using (StreamReader objReader = new StreamReader(strReader)) //sigue y nos crea un objeto del tipo streamReader
                        {
                            string responseBody = objReader.ReadToEnd(); //Luego a ese objeto objReader, lo convierto a texto;
                            var options = new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true // Asegura que los nombres de propiedades no sean sensibles a mayúsculas/minúsculas
                            };
                            try
                            {
                                CharactersPersonaje? personaje = JsonSerializer.Deserialize<CharactersPersonaje>(responseBody, options);
                                return personaje;
                            }
                            catch (System.Exception)
                            {
                                throw; //manda el error a un nivel superior
                            }
                        }
                    }
                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}