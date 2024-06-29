using cargarPersonaje;
/*DECLARACION de objetos para mi personaje y para la seleccion de personajes*/
Personaje miPersonaje = new Personaje();
List<Personaje>grupo1 = new List<Personaje>();
List<Personaje>grupo2 = new List<Personaje>();
List<Personaje>grupo3 = new List<Personaje>();



Console.WriteLine("### Inicia el torneo de la fuerza ###");
Console.WriteLine("Este torneo sera de 3 grupos, con 3 peleadores cada grupo, donde todos seran por sorteo");

Console.WriteLine("1_Goku");
Console.WriteLine("2_Vegeta");
Console.WriteLine("3_Piccolo");
Console.WriteLine("Eliga su personaje: ");
int opcionPersonaje;
int.TryParse(Console.ReadLine(), out opcionPersonaje);
int id;

switch (opcionPersonaje)
{
    case 1:
        id = 1;
        break;
    case 2:
        id = 2;
        break;
    case 3:
        id = 3;
        break;
}