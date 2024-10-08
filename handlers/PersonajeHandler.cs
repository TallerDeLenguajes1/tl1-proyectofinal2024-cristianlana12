using api;
using clasePersonaje;

namespace handlers
{
    public static class PersonajeHandler
    {

        public static PersonajeDatos? crearPersonajeUsuario(int id)
        {
            Random random = new Random();

            var personajeData = consumoApi.Get(id).GetAwaiter().GetResult();
            if (personajeData == null) return null;

            PersonajeDatos newPersonaje = new PersonajeDatos()
            {
                Id = personajeData.Id,
                Nombre = personajeData.Name,
                Raza = personajeData.Race,
                Ki = personajeData.Ki,
                Afiliacion = personajeData.Affiliation,
                PersonajeUsuario = id == 1 || id == 2 || id == 3,
                Tranformaciones = personajeData.Transformations?.Select(t => t.Name).ToArray()
            };
            return newPersonaje;
        }

        public static List<PersonajeDatos> crearGrupoPersonajesAleatorios(int cantidad, List<int> idPersonajes)
        {
            Random random = new Random();
            List<PersonajeDatos> grupo = new List<PersonajeDatos>();

            for (int i = 0; i < cantidad; i++)
            {
                int indexAleatorioList = random.Next(idPersonajes.Count);
                int idAleatorio = idPersonajes[indexAleatorioList];
                PersonajeDatos? newPersonaje = crearPersonajeUsuario(idAleatorio);

                if (newPersonaje == null)
                {
                    throw new Exception("No se pudieron obtener personajes para el combate, el torneo no puede continuar");
                }

                cargadoDetallesCombate(newPersonaje);
                grupo.Add(newPersonaje);
                idPersonajes.RemoveAt(indexAleatorioList);
            }
            return grupo;
        }

        public static void mostrarGrupo(List<PersonajeDatos> grupo, string nombreGrupo)
        {
            int i = 1;
            Console.WriteLine($"------- GRUPO {nombreGrupo} -------");
            foreach (var personaje in grupo)
            {
                Console.WriteLine($"PELEADOR {i}; Nombre: {personaje.Nombre}; Raza: {personaje.Raza}; Ki: {personaje.Ki}");
                i++;
            }
            Console.WriteLine("--------------------------");
        }

        public static void cargadoDetallesCombate(PersonajeDatos personaje)
        {
            switch (personaje.Raza)
            {
                case "Saiyan":
                    personaje.Vida = 1000;
                    personaje.Velocidad = 50;
                    personaje.AtaqueBasico = true;
                    personaje.AtaqueEspecial = true;
                    break;

                case "Namekian":
                    personaje.Vida = 900;
                    personaje.Velocidad = 45;
                    personaje.AtaqueBasico = true;
                    personaje.AtaqueEspecial = true;
                    break;

                case "Nucleico benigno":
                    personaje.Vida = 950;
                    personaje.Velocidad = 50;
                    personaje.AtaqueBasico = true;
                    personaje.AtaqueEspecial = false;
                    break;
                case "Nucleico":
                    personaje.Vida = 950;
                    personaje.Velocidad = 50;
                    personaje.AtaqueBasico = true;
                    personaje.AtaqueEspecial = false;
                    break;

                case "Human":
                    personaje.Vida = 200;
                    personaje.Velocidad = 10;
                    personaje.AtaqueBasico = false;
                    personaje.AtaqueEspecial = false;
                    break;

                case "Frieza Race":
                    personaje.Vida = 1200;
                    personaje.Velocidad = 60;
                    personaje.AtaqueBasico = true;
                    personaje.AtaqueEspecial = true;
                    break;

                case "Android":
                    personaje.Vida = 1400;
                    personaje.Velocidad = 70;
                    personaje.AtaqueBasico = true;
                    personaje.AtaqueEspecial = true;
                    break;

                case "Majin":
                    personaje.Vida = 1600;
                    personaje.Velocidad = 80;
                    personaje.AtaqueBasico = true;
                    personaje.AtaqueEspecial = true;
                    break;

                case "Jiren Race":
                    personaje.Vida = 1700;
                    personaje.Velocidad = 85;
                    personaje.AtaqueBasico = true;
                    personaje.AtaqueEspecial = true;
                    break;

                case "God":
                    personaje.Vida = 1800;
                    personaje.Velocidad = 90;
                    personaje.AtaqueBasico = true;
                    personaje.AtaqueEspecial = true;
                    break;

                case "Angel":
                    personaje.Vida = 1900;
                    personaje.Velocidad = 95;
                    personaje.AtaqueBasico = true;
                    personaje.AtaqueEspecial = true;
                    break;
                case "Unknown":
                    personaje.Vida = 2000;
                    personaje.Velocidad = 100;
                    personaje.AtaqueBasico = true;
                    personaje.AtaqueEspecial = true;
                    break;
            }
        }
    }
}