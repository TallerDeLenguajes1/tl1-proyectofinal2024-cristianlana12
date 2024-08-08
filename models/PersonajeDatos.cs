namespace clasePersonaje
{
    public class PersonajeDatos{
        private string nombre;
        private string raza;
        private string ki;
        private string afiliacion;
        private string[]? tranformaciones;
        private int id;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Raza { get => raza; set => raza = value; }
        public string Ki { get => ki; set => ki = value; }
        public string Afiliacion { get => afiliacion; set => afiliacion = value; }
        public string[]? Tranformaciones { get => tranformaciones; set => tranformaciones = value; }
        public int Id { get => id; set => id = value; }
    }
}