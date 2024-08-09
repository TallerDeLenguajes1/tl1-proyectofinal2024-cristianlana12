namespace clasePersonaje
{
    public class PersonajeDatos{
        private string nombre;
        private string raza;
        private string ki;
        private string afiliacion;
        private string[]? tranformaciones;
        private int id;
        private int vida;
        private int velocidad;
        private bool ataqueBasico;
        private bool ataqueEspecial;
        private bool personajeUsuario;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Raza { get => raza; set => raza = value; }
        public string Ki { get => ki; set => ki = value; }
        public string Afiliacion { get => afiliacion; set => afiliacion = value; }
        public string[]? Tranformaciones { get => tranformaciones; set => tranformaciones = value; }
        public int Id { get => id; set => id = value; }
        public int Vida { get => vida; set => vida = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public bool AtaqueBasico { get => ataqueBasico; set => ataqueBasico = value; }
        public bool AtaqueEspecial { get => ataqueEspecial; set => ataqueEspecial = value; }
        public bool PersonajeUsuario { get => personajeUsuario; set => personajeUsuario = value; }
    }
}