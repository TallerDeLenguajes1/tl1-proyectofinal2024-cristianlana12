using System;
using System.Media;
using System.Collections.Generic;
using api;
using handlers;
using clasePersonaje;
using utilities;
using combat;
using claseLista;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            SoundPlayerHelper.PlaySound("sonido/seleccion-personaje.wav");// reproduccion de sonido
            Console.Clear();

            int opcionJuego;
            
            Console.WriteLine("###########################################");
            Console.WriteLine("### INICIO EL TORNEO DE ARTES MARCIALES ###");
            Console.WriteLine("###########################################");

            Console.WriteLine("Este torneo sera de 4 Peleadores, Con 2 combates por sorteo, y un combate final entre los vencedores");

            int opcionPersonaje;
            do
            {
                Console.WriteLine("Eliga su personaje: ");
                Console.WriteLine("1_Goku");
                Console.WriteLine("2_Vegeta");               //SELECCION DE ALGUNO DE LOS PERSONAJES
                Console.WriteLine("3_Piccolo");

                int.TryParse(Console.ReadLine(), out opcionPersonaje);

                if (opcionPersonaje < 1 || opcionPersonaje > 3)
                {
                    Console.WriteLine("Valor incorrecto, seleccione un personaje que esta en sus posibilidades");
                }

            } while (opcionPersonaje < 1 || opcionPersonaje > 3);  //filtro para evitar que el usuario ingrese valores no permitidos

            PersonajeDatos miPersonaje = PersonajeHandler.crearPersonajeUsuario(opcionPersonaje); //Creacion de personaje
            PersonajeHandler.cargadoDetallesCombate(miPersonaje);

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
            Thread.Sleep(3000);
            SoundPlayerHelper.StopSound();

            List<int> idConcatenar = new List<int>();
            lista.cargarListaId(idConcatenar);

            List<PersonajeDatos> grupo;
            grupo = PersonajeHandler.crearGrupoPersonajesAleatorios(3, idConcatenar);
            grupo.Add(miPersonaje);
            PersonajeHandler.mostrarGrupo(grupo, "PELEADORES");
            Thread.Sleep(3000);

            combatPersonaje.mainCombat(grupo);


        }
    }
}