using api;
using clasePersonaje;
using System;
using System.Threading;
using utilities;
using handlers;
using claseLista;
using modelos;
namespace combat
{
    class combatPersonaje
    {
        public void inicioCombate()
        {

            Console.WriteLine(@"██╗███╗   ██╗██╗ ██████╗██╗ ██████╗     ███████╗██╗         ████████╗ ██████╗ ██████╗ ███╗   ██╗███████╗ ██████╗ 
██║████╗  ██║██║██╔════╝██║██╔═══██╗    ██╔════╝██║         ╚══██╔══╝██╔═══██╗██╔══██╗████╗  ██║██╔════╝██╔═══██╗
██║██╔██╗ ██║██║██║     ██║██║   ██║    █████╗  ██║            ██║   ██║   ██║██████╔╝██╔██╗ ██║█████╗  ██║   ██║
██║██║╚██╗██║██║██║     ██║██║   ██║    ██╔══╝  ██║            ██║   ██║   ██║██╔══██╗██║╚██╗██║██╔══╝  ██║   ██║
██║██║ ╚████║██║╚██████╗██║╚██████╔╝    ███████╗███████╗       ██║   ╚██████╔╝██║  ██║██║ ╚████║███████╗╚██████╔╝
╚═╝╚═╝  ╚═══╝╚═╝ ╚═════╝╚═╝ ╚═════╝     ╚══════╝╚══════╝       ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝╚══════╝ ╚═════╝ ");
            Console.WriteLine(@"██████╗ ███████╗     █████╗ ██████╗ ████████╗███████╗███████╗    ███╗   ███╗ █████╗ ██████╗  ██████╗██╗ █████╗ ██╗     ███████╗███████╗
██╔══██╗██╔════╝    ██╔══██╗██╔══██╗╚══██╔══╝██╔════╝██╔════╝    ████╗ ████║██╔══██╗██╔══██╗██╔════╝██║██╔══██╗██║     ██╔════╝██╔════╝
██║  ██║█████╗      ███████║██████╔╝   ██║   █████╗  ███████╗    ██╔████╔██║███████║██████╔╝██║     ██║███████║██║     █████╗  ███████╗
██║  ██║██╔══╝      ██╔══██║██╔══██╗   ██║   ██╔══╝  ╚════██║    ██║╚██╔╝██║██╔══██║██╔══██╗██║     ██║██╔══██║██║     ██╔══╝  ╚════██║
██████╔╝███████╗    ██║  ██║██║  ██║   ██║   ███████╗███████║    ██║ ╚═╝ ██║██║  ██║██║  ██║╚██████╗██║██║  ██║███████╗███████╗███████║
╚═════╝ ╚══════╝    ╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝   ╚══════╝╚══════╝    ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝╚═╝  ╚═╝╚══════╝╚══════╝╚══════╝");
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

            try 
            {
                PersonajeDatos? miPersonaje = PersonajeHandler.crearPersonajeUsuario(opcionPersonaje); //Creacion de personaje
                if (miPersonaje == null)
                {
                    throw new Exception("No pudimos cargar tu personaje, el torneo no puede continuar");
                }
                PersonajeHandler.cargadoDetallesCombate(miPersonaje);

                Console.WriteLine("USTED SELECCIONO AL PELEADOR: ");
                Console.WriteLine($"Nombre: {miPersonaje.Nombre}");
                Console.WriteLine($"Raza: {miPersonaje.Raza}");
                Console.WriteLine($"Ki: {miPersonaje.Ki}");
                Console.WriteLine($"Afiliación: {miPersonaje.Afiliacion}");
    
                Thread.Sleep(3000);
                SoundPlayerHelper.StopSound();

                List<int> idConcatenar = new List<int>();
                lista.cargarListaId(idConcatenar);
                List<PersonajeDatos> grupo;
                grupo = PersonajeHandler.crearGrupoPersonajesAleatorios(3, idConcatenar);
                grupo.Add(miPersonaje);
                PersonajeHandler.mostrarGrupo(grupo, "PELEADORES");
                Thread.Sleep(3000);
                
                mainCombat(grupo);
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"{e.Message}\n");
            }

        }

        public static void mainCombat(List<PersonajeDatos> grupo)
        {
            List<PersonajeDatos> finalGrupo = new List<PersonajeDatos>();
            Console.WriteLine("Los combates tendras la siguiente modalidad: \n1_La primera etapa seran combates por sorteo \n2_Los vencedores se enfrentaran automaticamente, sin descanso.");

            combateSemiFinal(grupo, finalGrupo);
        }

        public static void combateSemiFinal(List<PersonajeDatos> grupo, List<PersonajeDatos> final)
        {
            Random random = new Random();
            int opcionAtaque;
            List<int> idConcatenar = new List<int> { 0, 1, 2, 3 };

            int indiceAleatorio = random.Next(idConcatenar.Count); //obtengo un indice aleatorio de la lista idConcatenar
            PersonajeDatos peleador1 = grupo[idConcatenar[indiceAleatorio]]; //con el contenido de este indice idConcatenar[indiceAleatorio], elijo un peleador aleatorio de la lista grupo
            idConcatenar.RemoveAt(indiceAleatorio); //una vez obtenido el personaje aleatorio, elimino de la lista idConcatenar el elemento de indice indiceAleatorio
            //con esto evito que se repitan los elementos

            indiceAleatorio = random.Next(idConcatenar.Count);
            PersonajeDatos peleador2 = grupo[idConcatenar[indiceAleatorio]];
            idConcatenar.RemoveAt(indiceAleatorio);

            indiceAleatorio = random.Next(idConcatenar.Count);
            PersonajeDatos peleador3 = grupo[idConcatenar[indiceAleatorio]];
            idConcatenar.RemoveAt(indiceAleatorio);

            indiceAleatorio = random.Next(idConcatenar.Count);
            PersonajeDatos peleador4 = grupo[idConcatenar[indiceAleatorio]];
            idConcatenar.RemoveAt(indiceAleatorio);

            mostrarParejas(peleador1, peleador2, "PRIMER PELEA"); //muestro la primer pelea
            mostrarParejas(peleador3, peleador4, "SEGUNDA PELEA"); //muestro la segunda pelea


            ejecucionCombateUsuairo(peleador1, peleador2, final);
            ejecucionCombateUsuairo(peleador3, peleador4, final);

            PersonajeDatos peleadorFinal1 = final[0];
            PersonajeDatos peleadorFinal2 = final[1];

            mostrarParejas(peleadorFinal1, peleadorFinal2, "COMBATE FINAL");
            ejecucionCombateUsuairo(peleadorFinal1, peleadorFinal2, final, true);

        }

        public static void mostrarParejas(PersonajeDatos peleador1, PersonajeDatos peleador2, string nombrePelea)
        {
            Console.WriteLine(nombrePelea);
            Console.WriteLine(peleador1.Nombre + " VS " + peleador2.Nombre + "\n");
        }

        public static void ejecucionCombateUsuairo(PersonajeDatos peleador1, PersonajeDatos peleador2, List<PersonajeDatos> final, bool peleaFinal = false)
        {
            Random random = new Random();
            int ronda = 0;
            int opcionAtaque;
            while (peleador1.Vida > 0 && peleador2.Vida > 0)
            {

                Console.WriteLine($"{peleador1.Nombre}            |       {peleador2.Nombre}");
                Console.WriteLine($"Vida: {peleador1.Vida}        |       Vida: {peleador2.Vida} \n");
                
                var personajeTurno = ronda % 2 == 0 ? peleador1 : peleador2;

                var opcionesDisponibles = personajeTurno.AtaqueEspecial ?
                    new List<TipoAtaque>() 
                    {
                        TipoAtaque.ATAQUE_BASICO,
                        TipoAtaque.ATAQUE_ESPECIAL,
                        TipoAtaque.PASAR_RONDA
                    }
                    :
                    new List<TipoAtaque>() 
                    {
                        TipoAtaque.ATAQUE_BASICO,
                        TipoAtaque.PASAR_RONDA
                    };
                
                TipoAtaque ataqueRealizar;
                if (personajeTurno.PersonajeUsuario)
                {
                    do
                    {
                        Console.WriteLine("Elegi una opcion correcta: ");

                        for (int i=0 ; i<opcionesDisponibles.Count() ; i++)
                        {
                            var linea = $"{i+1}_" + opcionesDisponibles[i] switch
                            {
                                TipoAtaque.ATAQUE_BASICO => "Ataque Basico",
                                TipoAtaque.ATAQUE_ESPECIAL => "Ataque Especial",
                                _ => "Pasar ronda"
                            };
                            Console.WriteLine(linea);
                        }

                        int.TryParse(Console.ReadLine(), out opcionAtaque);
                        if (opcionAtaque < 1 || opcionAtaque > 3)
                        {
                            Console.WriteLine("Selecciona una opcion entre 1 y 3 por favor");
                        }
                    } while (opcionAtaque < 1 || opcionAtaque > 3);

                    ataqueRealizar = opcionesDisponibles[opcionAtaque-1];
                }
                else
                {
                    ataqueRealizar = opcionesDisponibles[random.Next(opcionesDisponibles.Count())];
                }

                ejecutarAtaque(ataqueRealizar, personajeTurno, personajeTurno.Id == peleador1.Id ? peleador2 :
                                                                                                   peleador1);
                Thread.Sleep(2000);
                ronda++;
                SoundPlayerHelper.StopSound();

            }

            var ganador = determinarGanador(peleador1, peleador2);
            Console.WriteLine($"\nGANO {ganador.Nombre}");
            final.Add(ganador);

            if (peleaFinal)
            {
                historialObj newhistorial = new();
                newhistorial.guardarGanador(ganador);
            }

            
        }
    
        private static void ejecutarAtaque(TipoAtaque tipoAtaque, PersonajeDatos atacante, PersonajeDatos peleadorDañado)
        {
            var random = new Random();
            int daño;
            switch (tipoAtaque)
            {
                case TipoAtaque.ATAQUE_BASICO:
                    daño = random.Next(100, 200);
                    peleadorDañado.Vida -= daño;
                    Console.WriteLine($"{atacante.Nombre} realiza un ataque basico\n");
                    SoundPlayerHelper.PlaySound("sonido/EfectoAtaqueBase.wav");// reproduccion de sonido

                    break;
                case TipoAtaque.ATAQUE_ESPECIAL:
                    daño = random.Next(300, 500);
                    peleadorDañado.Vida -= daño;
                    Console.WriteLine($"{atacante.Nombre} realiza un ataque especial\n");
                    SoundPlayerHelper.PlaySound("sonido/EfectoATAQUE-DE-KI-DBZ-II-_320-kbps_.wav");

                    break;
                default:
                    daño = 0;
                    peleadorDañado.Vida -= daño;
                    Console.WriteLine($"{atacante.Nombre} elige pasar de ronda\n");

                    break;
            }
        }
    
        private static PersonajeDatos determinarGanador(PersonajeDatos peleador1, PersonajeDatos peleador2)
        {
            return (peleador1.Vida <= 0 && peleador2.Vida > 0) ? peleador2 : peleador1;
        }
    }
}