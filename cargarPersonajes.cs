using api;

namespace cargarPersonaje
{
    class Personaje
    {
        private string? nombre;
        private string? raza;
        private int ki;
        private string? afiliacion;
        private string[]? tranformaciones;

        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Raza { get => raza; set => raza = value; }
        public int Ki { get => ki; set => ki = value; }
        public string? Afiliacion { get => afiliacion; set => afiliacion = value; }
        public string[]? Tranformaciones { get => tranformaciones; set => tranformaciones = value; }

        public static Personaje? crearPersonajesAleatorio()
        {
            Random random = new Random();
            int id = random.Next(4, 59);
            var personajeData = consumoApi.Get(1);

            if (personajeData == null)return null;

            Personaje newPersonaje = new Personaje();
            newPersonaje.Nombre = personajeData.Name;
            newPersonaje.Raza = personajeData.Race;
            newPersonaje.Ki = personajeData.Ki;
            newPersonaje.Afiliacion = personajeData.Affiliation;
            newPersonaje.Tranformaciones = personajeData.Transformations?.Select(t => t.Name).ToArray();

            return newPersonaje;
        }
    }

    class Grupos
    {

    }
}