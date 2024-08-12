using clasePersonaje;

namespace views
{
    public class viewsHistory
    {
        private List<PersonajeDatos> historial;

        public viewsHistory(List<PersonajeDatos> historial)
        {
            this.historial = historial;
        }

        public void mostrarHistorial()
        {
            Console.WriteLine(@" ██████╗  █████╗ ███╗   ██╗ █████╗ ██████╗  ██████╗ ██████╗ ███████╗███████╗
██╔════╝ ██╔══██╗████╗  ██║██╔══██╗██╔══██╗██╔═══██╗██╔══██╗██╔════╝██╔════╝
██║  ███╗███████║██╔██╗ ██║███████║██║  ██║██║   ██║██████╔╝█████╗  ███████╗
██║   ██║██╔══██║██║╚██╗██║██╔══██║██║  ██║██║   ██║██╔══██╗██╔══╝  ╚════██║
╚██████╔╝██║  ██║██║ ╚████║██║  ██║██████╔╝╚██████╔╝██║  ██║███████╗███████║
 ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚══════╝╚══════╝");
            if (historial.Any())
            {
                foreach (PersonajeDatos personaje in historial)
                {
                    Console.WriteLine($"Peleador: {personaje.Nombre}");
                    Console.WriteLine($"Raza: {personaje.Raza}");
                    Console.WriteLine($"ki: {personaje.Ki} \n");
                    Console.WriteLine($"Es personaje del usuario: {(personaje.PersonajeUsuario ? "SI" : "NO")} \n");
                }
            }
            else
            {
                Console.WriteLine("No existen ganadores historicos");
            }
            Console.WriteLine("PRECIONE UNA TECLA PARA VOLVER AL MENU");
            Console.ReadKey();
        }
    }
}