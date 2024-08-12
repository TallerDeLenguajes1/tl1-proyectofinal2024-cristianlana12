using System;
using System.Media;
using System.Collections.Generic;
using api;
using handlers;
using clasePersonaje;
using utilities;
using combat;
using claseLista;
using views;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {

            SoundPlayerHelper.PlaySound("sonido/seleccion-personaje.wav");// reproduccion de sonido

            int opcionPrincipal;
            vistaMenuPrincipal vistaMenuPrincipal = new();
            bool salir = false;

            Console.Clear();
            do
            {
                vistaMenuPrincipal.menuPrincipal();
                int.TryParse(Console.ReadLine(), out opcionPrincipal);
                if (opcionPrincipal < 1 || opcionPrincipal > 3)
                {
                    Console.WriteLine("Opcion incorrecta, seleccione una opcion valida");
                }
                else
                {
                    switch (opcionPrincipal)
                    {
                        case 1:
                            combatPersonaje newCombate = new();
                            newCombate.inicioCombate();
                            break;
                        case 2:
                            historialObj newLecturaGanadores = new();
                            viewsHistory newHistory = new(newLecturaGanadores.leerGanadores());
                            newHistory.mostrarHistorial();
                            break;
                        case 3:
                            salir = true;
                            break;
                    }
                }
                SoundPlayerHelper.PlaySound("sonido/seleccion-personaje.wav");// reproduccion de sonido

            } while (!salir);
        }
    }
}