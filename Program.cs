using System;
using System.Collections.Generic;
using api;
using handlers;
using clasePersonaje;
using utilities;
using combat;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //SoundPlayerHelper.PlaySound("sonido/seleccion-personaje.wav");// reproduccion de sonido

            Console.WriteLine("### Inicia el torneo de la fuerza ###");
            Console.WriteLine("Este torneo sera de 4 Peleadores, Con 2 combates con un sorteo, y un combate final entre los vencedores");
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
                Console.WriteLine("USTED SELECCIONO AL PELEADOR: ");
                Console.WriteLine($"Nombre: {miPersonaje.Nombre}");
                Console.WriteLine($"Raza: {miPersonaje.Raza}");
                Console.WriteLine($"Ki: {miPersonaje.Ki}");
                Console.WriteLine($"Afiliación: {miPersonaje.Afiliacion}");
            }
            else
            {
                Console.WriteLine("No pudimos cargar tu personaje");
            }
            Thread.Sleep(5000);

            Random random = new Random(); //36, 41,45,46,47,48,49,50...,62,79
            List<int> idConcatenar = new List<int> { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };

            List<PersonajeDatos> grupo;
            grupo = PersonajeHandler.CrearGrupoPersonajesAleatorios(3, idConcatenar);
            grupo.Add(miPersonaje);
            PersonajeHandler.MostrarGrupo(grupo, "PELEADORES");
            Thread.Sleep(5000);

            combatPersonaje.mainCombat(grupo);
        }
    }
}