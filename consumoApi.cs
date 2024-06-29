using System.Net;
using System.Text.Json;

namespace api
{
    public class originPlanet
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public bool IsDestroyed { get; set; }
        public string ?Description { get; set; }
        public string ?Image { get; set; }
        public object ?DeletedAt { get; set; }
    }

    public class transformationPersonaje
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public string ?Image { get; set; }
        public int Ki { get; set; }
        public object ?DeletedAt { get; set; }
    }

    public class charactersPersonaje
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public int Ki { get; set; }
        public int MaxKi { get; set; }
        public string ?Race { get; set; }
        public string ?Gender { get; set; }
        public string ?Description { get; set; }
        public string ?Image { get; set; }
        public string ?Affiliation { get; set; }
        public object ?DeletedAt { get; set; } // Use `object` if the type is not known
        public originPlanet ?OriginPlanet { get; set; }
        public List<transformationPersonaje> ?Transformations { get; set; }
    }

    public class consumoApi
    {
        public static charactersPersonaje? Get(int id)
        {  //Defino un evento get Privado
            var url = $"https://dragonball-api.com/api/characters/{id}"; //declaro la variable var donde tiene la url para llegar a la api
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
                            charactersPersonaje? personaje = JsonSerializer.Deserialize<charactersPersonaje>(responseBody);
                            return personaje;
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