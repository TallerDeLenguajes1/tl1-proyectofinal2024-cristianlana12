using clasePersonaje;
using System;
using System.Threading;
using utilities;



namespace combat
{
    class combatPersonaje
    {
        public static void mainCombat(List<PersonajeDatos> grupo)
        {
            Random random = new Random();
            List<PersonajeDatos> finalGrupo = new List<PersonajeDatos>();
            Console.WriteLine("Los combates tendras la siguiente metodologia: \n1_La primera etapa seran combates por sorteo \n");

            combateSemiFinal(grupo, finalGrupo);
        }

        public static void combateSemiFinal(List<PersonajeDatos> grupo, List<PersonajeDatos> final)
        {
            Random random = new Random();
            int opcionAtaque;
            List<int> idConcatenar = new List<int> { 0, 1, 2, 3 };

            int indiceAleatorio = random.Next(idConcatenar.Count);
            PersonajeDatos peleador1 = grupo[idConcatenar[indiceAleatorio]];
            idConcatenar.RemoveAt(indiceAleatorio);

            indiceAleatorio = random.Next(idConcatenar.Count);
            PersonajeDatos peleador2 = grupo[idConcatenar[indiceAleatorio]];
            idConcatenar.RemoveAt(indiceAleatorio);

            indiceAleatorio = random.Next(idConcatenar.Count);
            PersonajeDatos peleador3 = grupo[idConcatenar[indiceAleatorio]];
            idConcatenar.RemoveAt(indiceAleatorio);

            indiceAleatorio = random.Next(idConcatenar.Count);
            PersonajeDatos peleador4 = grupo[idConcatenar[indiceAleatorio]];
            idConcatenar.RemoveAt(indiceAleatorio);

            mostrarParejas(peleador1, peleador2, "PRIMER PELEA");
            mostrarParejas(peleador3, peleador4, "SEGUNDA PELEA");

            ejecucionCombateUsuairo(peleador1, peleador2, final);
            ejecucionCombateUsuairo(peleador3, peleador4, final);

            PersonajeDatos peleadorFinal1 = final[0];
            PersonajeDatos peleadorFinal2 = final[1];

            mostrarParejas(peleadorFinal1, peleadorFinal2, "COMBATE FINAL");
            ejecucionCombateUsuairo(peleadorFinal1, peleadorFinal2, final);

        }
        public static void mostrarParejas(PersonajeDatos peleador1, PersonajeDatos peleador2, string nombrePelea)
        {
            Console.WriteLine(nombrePelea);
            Console.WriteLine(peleador1.Nombre + " VS " + peleador2.Nombre + "\n");
        }

        public static void ejecucionCombateUsuairo(PersonajeDatos peleador1, PersonajeDatos peleador2, List<PersonajeDatos> final)
        {
            Random random = new Random();
            int ronda = 0;
            int opcionAtaque;
            int daño = 0;
            while (peleador1.Vida > 0 && peleador2.Vida > 0)
            {

                Console.WriteLine($"{peleador1.Nombre}       |   {peleador2.Nombre}");
                Console.WriteLine($"Vida: {peleador1.Vida}   |   Vida: {peleador2.Vida} \n");


                if (ronda % 2 == 0)
                {
                    if (peleador1.PersonajeUsuario)
                    {
                        do
                        {
                            Console.WriteLine("Elegi una opcion correcta: ");
                            Console.WriteLine("1_Ataque Basico");
                            Console.WriteLine("2_Ataque Especial");
                            Console.WriteLine("3_Pasar Ronda");
                            int.TryParse(Console.ReadLine(), out opcionAtaque);
                            if (opcionAtaque < 1 || opcionAtaque > 3)
                            {
                                Console.WriteLine("Selecciona una opcion entre 1 y 3 por favor");
                            }

                        } while (opcionAtaque < 1 || opcionAtaque > 3);

                        switch (opcionAtaque)
                        {
                            case 1:
                                daño = random.Next(100, 200);
                                peleador2.Vida -= daño;
                                Console.WriteLine("Elegiste el ataque basico\n");
                                SoundPlayerHelper.PlaySound("sonido/EfectoAtaqueBase.wav");// reproduccion de sonido

                                break;
                            case 2:
                                daño = random.Next(300, 500);
                                peleador2.Vida -= daño;
                                Console.WriteLine("Elegiste el ataque especial\n");
                                SoundPlayerHelper.PlaySound("sonido/EfectoATAQUE-DE-KI-DBZ-II-_320-kbps_.wav");
                                break;
                            case 3:
                                daño = 0;
                                peleador2.Vida -= daño;
                                Console.WriteLine("Elegiste pasar de ronda\n");
                                break;
                        }
                        Thread.Sleep(2000);

                    }
                    else
                    {
                        if (peleador1.AtaqueEspecial)
                        {

                            Console.WriteLine("1_Ataque Basico");
                            Console.WriteLine("2_Ataque Especial");
                            Console.WriteLine("3_Pasar Ronda");
                            opcionAtaque = random.Next(1, 4);

                            switch (opcionAtaque)
                            {
                                case 1:
                                    daño = random.Next(100, 200);
                                    peleador2.Vida -= daño;
                                    Console.WriteLine($"{peleador1.Nombre} eligio ATAQUE BASE\n");
                                    SoundPlayerHelper.PlaySound("sonido/EfectoAtaqueBase.wav");// reproduccion de sonido

                                    break;
                                case 2:
                                    daño = random.Next(300, 500);
                                    peleador2.Vida -= daño;
                                    Console.WriteLine($"{peleador1.Nombre} eligio ATAQUE ESPECIAL\n");
                                    SoundPlayerHelper.PlaySound("sonido/EfectoATAQUE-DE-KI-DBZ-II-_320-kbps_.wav");
                                    break;
                                case 3:
                                    daño = 0;
                                    peleador2.Vida -= daño;
                                    Console.WriteLine($"{peleador1.Nombre} eligio PASAR RONDA\n");
                                    break;
                            }
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            Console.WriteLine("1_Ataque Basico");
                            Console.WriteLine("2_Pasar Ronda");
                            opcionAtaque = random.Next(1, 3);

                            switch (opcionAtaque)
                            {
                                case 1:
                                    daño = random.Next(100, 200);
                                    peleador2.Vida -= daño;
                                    Console.WriteLine($"{peleador1.Nombre} eligio ATAQUE BASE\n");
                                    SoundPlayerHelper.PlaySound("sonido/EfectoAtaqueBase.wav");// reproduccion de sonido

                                    break;
                                case 2:
                                    daño = 0;
                                    peleador2.Vida -= daño;
                                    Console.WriteLine($"{peleador1.Nombre} eligio PASAR RONDA\n");
                                    break;
                            }
                            Thread.Sleep(2000);
                        }
                    }
                }
                else
                {
                    if (peleador2.PersonajeUsuario)
                    {
                        do
                        {
                            Console.WriteLine("Elegi una opcion correcta: ");
                            Console.WriteLine("1_Ataque Basico");
                            Console.WriteLine("2_Ataque Especial");
                            Console.WriteLine("3_Pasar Ronda");
                            int.TryParse(Console.ReadLine(), out opcionAtaque);
                            if (opcionAtaque < 1 || opcionAtaque > 3)
                            {
                                Console.WriteLine("Selecciona una opcion entre 1 y 3 por favor");
                            }

                        } while (opcionAtaque < 1 || opcionAtaque > 3);

                        switch (opcionAtaque)
                        {
                            case 1:
                                daño = random.Next(100, 200);
                                peleador1.Vida -= daño;
                                Console.WriteLine("Elegiste el ataque basico\n");
                                SoundPlayerHelper.PlaySound("sonido/EfectoAtaqueBase.wav");// reproduccion de sonido

                                break;
                            case 2:
                                daño = random.Next(300, 500);
                                peleador1.Vida -= daño;
                                Console.WriteLine("Elegiste el ataque especial\n");
                                SoundPlayerHelper.PlaySound("sonido/EfectoATAQUE-DE-KI-DBZ-II-_320-kbps_.wav");
                                break;
                            case 3:
                                daño = 0;
                                peleador1.Vida -= daño;
                                Console.WriteLine("Elegiste pasar de ronda \n");
                                break;
                        }
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        if (peleador2.AtaqueEspecial)
                        {
                            Console.WriteLine("1_Ataque Basico");
                            Console.WriteLine("2_Ataque Especial");
                            Console.WriteLine("3_Pasar Ronda");
                            opcionAtaque = random.Next(1, 4);

                            switch (opcionAtaque)
                            {
                                case 1:
                                    daño = random.Next(100, 200);
                                    peleador1.Vida -= daño;
                                    Console.WriteLine($"{peleador2.Nombre} eligio ATAQUE BASE\n");
                                    SoundPlayerHelper.PlaySound("sonido/EfectoAtaqueBase.wav");// reproduccion de sonido

                                    break;
                                case 2:
                                    daño = random.Next(300, 500);
                                    peleador1.Vida -= daño;
                                    Console.WriteLine($"{peleador2.Nombre} eligio ATAQUE ESPECIAL\n");
                                    SoundPlayerHelper.PlaySound("sonido/EfectoATAQUE-DE-KI-DBZ-II-_320-kbps_.wav");
                                    break;
                                case 3:
                                    daño = 0;
                                    peleador1.Vida -= daño;
                                    Console.WriteLine($"{peleador2.Nombre} eligio PASAR RONDA \n");
                                    break;
                            }
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            Console.WriteLine("1_Ataque Basico");
                            Console.WriteLine("2_Pasar Ronda");
                            opcionAtaque = random.Next(1, 4);

                            switch (opcionAtaque)
                            {
                                case 1:
                                    daño = random.Next(100, 200);
                                    peleador1.Vida -= daño;
                                    Console.WriteLine($"{peleador2.Nombre} eligio ATAQUE BASE\n");
                                    SoundPlayerHelper.PlaySound("sonido/EfectoAtaqueBase.wav");// reproduccion de sonido

                                    break;
                                case 2:
                                    daño = 0;
                                    peleador1.Vida -= daño;
                                    Console.WriteLine($"{peleador2.Nombre} eligio PASAR RONDA\n");
                                    break;
                            }
                            Thread.Sleep(2000);
                        }
                    }

                }
                ronda++;
                SoundPlayerHelper.StopSound();

            }

            if (peleador1.Vida <= 0 && peleador2.Vida > 0)
            {
                Console.WriteLine($"\nGANO {peleador2.Nombre}");
                final.Add(peleador2);
            }
            else
            {
                Console.WriteLine($"\nGANO {peleador1.Nombre}");
                final.Add(peleador1);
            }
        }

    }
}