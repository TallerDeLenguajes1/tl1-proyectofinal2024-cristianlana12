using System;
using System.Collections.Generic;
using api;
using handlers;
using clasePersonaje;
using utilities;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //SoundPlayerHelper.PlaySound("sonido/seleccion-personaje.wav");// reproduccion de sonido

            Console.WriteLine("### Inicia el torneo de la fuerza ###");
            Console.WriteLine("Este torneo sera de 3 grupos, con 3 peleadores cada grupo, donde todos seran por sorteo");
            Console.WriteLine("1_Goku");
            Console.WriteLine("2_Vegeta");
            Console.WriteLine("3_Piccolo");
            Console.WriteLine("Eliga su personaje: ");

            int opcionPersonaje;
            int.TryParse(Console.ReadLine(), out opcionPersonaje);

            PersonajeDatos miPersonaje = PersonajeHandler.CrearPersonajeUsuario(opcionPersonaje); //Creacion de personaje
            PersonajeHandler.CargadoDetallesCombate(miPersonaje);

            if (miPersonaje != null)
            {
                Console.WriteLine($"Nombre: {miPersonaje.Nombre}");
                Console.WriteLine($"Raza: {miPersonaje.Raza}");
                Console.WriteLine($"Ki: {miPersonaje.Ki}");
                Console.WriteLine($"Afiliación: {miPersonaje.Afiliacion}");
            }
            else
            {
                Console.WriteLine("No pudimos cargar tu personaje");
            }

            Random random = new Random(); //36, 41,45,46,47,48,49,50...,62,79
            List<int> idConcatenar = new List<int> { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30};
            List<PersonajeDatos> grupo1;
            List<PersonajeDatos> grupo2;
            List<PersonajeDatos> grupo3;

            int opcionGrupo = random.Next(1, 4);
            Console.WriteLine($"### Usted fue colocado en un grupo aleatorio, grupo: {opcionGrupo} ###");

            switch (opcionGrupo)
            {
                case 1:
                    grupo1 = PersonajeHandler.CrearGrupoPersonajesAleatorios(2, idConcatenar);
                    grupo1.Add(miPersonaje);
                    grupo2 = PersonajeHandler.CrearGrupoPersonajesAleatorios(3, idConcatenar);
                    grupo3 = PersonajeHandler.CrearGrupoPersonajesAleatorios(3, idConcatenar);
                    PersonajeHandler.MostrarGrupo(grupo1, 1);
                    PersonajeHandler.MostrarGrupo(grupo2, 2);
                    PersonajeHandler.MostrarGrupo(grupo3, 3);
                    break;
                case 2:
                    grupo2 = PersonajeHandler.CrearGrupoPersonajesAleatorios(2, idConcatenar);
                    grupo2.Add(miPersonaje);
                    grupo1 = PersonajeHandler.CrearGrupoPersonajesAleatorios(3, idConcatenar);
                    grupo3 = PersonajeHandler.CrearGrupoPersonajesAleatorios(3, idConcatenar);
                    PersonajeHandler.MostrarGrupo(grupo1, 1);
                    PersonajeHandler.MostrarGrupo(grupo2, 2);
                    PersonajeHandler.MostrarGrupo(grupo3, 3);
                    break;
                case 3:
                    grupo3 = PersonajeHandler.CrearGrupoPersonajesAleatorios(2, idConcatenar);
                    grupo3.Add(miPersonaje);
                    grupo2 = PersonajeHandler.CrearGrupoPersonajesAleatorios(3, idConcatenar);
                    grupo1 = PersonajeHandler.CrearGrupoPersonajesAleatorios(3, idConcatenar);
                    PersonajeHandler.MostrarGrupo(grupo1, 1);
                    PersonajeHandler.MostrarGrupo(grupo2, 2);
                    PersonajeHandler.MostrarGrupo(grupo3, 3);
                    break;
            }
        }
    }
}