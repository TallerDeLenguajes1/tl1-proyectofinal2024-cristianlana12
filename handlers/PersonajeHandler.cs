using api;
using clasePersonaje;

namespace handlers
{
    public static class PersonajeHandler
    {
        public static PersonajeDatos? CrearPersonajeUsuario(int id)
        {
            Random random = new Random();

            if (id == 1 || id == 2 || id == 3)
            {
                var personajeData = consumoApi.Get(id);
                if (personajeData == null) return null;

                PersonajeDatos newPersonaje = new PersonajeDatos()
                {
                    Id = personajeData.Id,
                    Nombre = personajeData.Name,
                    Raza = personajeData.Race,
                    Ki = personajeData.Ki,
                    Afiliacion = personajeData.Affiliation,
                    Tranformaciones = personajeData.Transformations?.Select(t => t.Name).ToArray()
                };
                return newPersonaje;
            }
            else
            {
                CharactersPersonaje personajeData = consumoApi.Get(id);
                if (personajeData == null) return null;

                PersonajeDatos newPersonaje = new PersonajeDatos()
                {
                    Id = personajeData.Id,
                    Nombre = personajeData.Name,
                    Raza = personajeData.Race,
                    Ki = personajeData.Ki,
                    Afiliacion = personajeData.Affiliation,
                    Tranformaciones = personajeData.Transformations?.Select(t => t.Name).ToArray()
                };
                return newPersonaje;
            }


        }

        public static List<PersonajeDatos> CrearGrupoPersonajesAleatorios(int cantidad, List<int> idPersonajes)
        {
            Random random = new Random();
            List<PersonajeDatos> grupo = new List<PersonajeDatos>();

            for (int i = 0; i < cantidad; i++)
            {
                int indexAleatorioList = random.Next(idPersonajes.Count);
                int idAleatorio = idPersonajes[indexAleatorioList];
                PersonajeDatos newPersonaje = CrearPersonajeUsuario(idAleatorio);
                if (newPersonaje != null)
                {
                    grupo.Add(newPersonaje);
                    idPersonajes.RemoveAt(indexAleatorioList);
                }else{
                    i--; //vuelve a intentar en el caso de que no se locre cargar el personaje
                }   
            }
            return grupo;
        }

        public static void MostrarGrupo(List<PersonajeDatos> grupo, int nroGrupo)
        {
            int i = 0;
            Console.WriteLine($"------- GRUPO {nroGrupo} -------");
            foreach (var personaje in grupo)
            {
                Console.WriteLine($"PELEADOR {i}; Nombre: {personaje.Nombre}; Raza: {personaje.Raza}; Ki: {personaje.Ki}; Afiliación: {personaje.Afiliacion}");
                i++;
            }
            Console.WriteLine("--------------------------");
        }
    }
}