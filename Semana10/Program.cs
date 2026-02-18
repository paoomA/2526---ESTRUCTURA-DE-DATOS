using System;
using System.Collections.Generic;
using System.Linq;

namespace VacunacionCOVID
{
    class Program
    {
        static HashSet<string> ciudadanos = new HashSet<string>();
        static HashSet<string> pfizer = new HashSet<string>();
        static HashSet<string> astrazeneca = new HashSet<string>();

        static void Main(string[] args)
        {
            Console.Title = "📊 Sistema Interactivo de Vacunación COVID-19";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===============================================");
            Console.WriteLine("       SISTEMA INTERACTIVO DE VACUNACIÓN      ");
            Console.WriteLine("===============================================\n");
            Console.ResetColor();

            GenerarDatos();

            int opcion;
            do
            {
                MostrarMenu();
                opcion = LeerOpcion();

                switch (opcion)
                {
                    case 1:
                        MostrarListado("Ciudadanos NO vacunados", ObtenerNoVacunados(), ConsoleColor.Red);
                        break;
                    case 2:
                        MostrarListado("Ciudadanos con AMBAS dosis", ObtenerAmbasDosis(), ConsoleColor.Green);
                        break;
                    case 3:
                        MostrarListado("Ciudadanos SOLO Pfizer", ObtenerSoloPfizer(), ConsoleColor.Blue);
                        break;
                    case 4:
                        MostrarListado("Ciudadanos SOLO AstraZeneca", ObtenerSoloAstra(), ConsoleColor.Yellow);
                        break;
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nGracias por usar el sistema de vacunación. ¡Hasta luego, Acosta Paola!");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\nOpción inválida. Intente nuevamente.");
                        Console.ResetColor();
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (opcion != 0);
        }

        // ================================
        // MENÚ
        // ================================
        static void MostrarMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===============================================");
            Console.WriteLine("                  MENÚ PRINCIPAL              ");
            Console.WriteLine("===============================================");
            Console.ResetColor();

            Console.WriteLine("1. Listar ciudadanos NO vacunados");
            Console.WriteLine("2. Listar ciudadanos con AMBAS dosis");
            Console.WriteLine("3. Listar ciudadanos con SOLO Pfizer");
            Console.WriteLine("4. Listar ciudadanos con SOLO AstraZeneca");
            Console.WriteLine("0. Salir");
            Console.Write("\nSeleccione una opción: ");
        }

        static int LeerOpcion()
        {
            int opcion;
            bool valido = int.TryParse(Console.ReadLine(), out opcion);
            return valido ? opcion : -1;
        }

        // ================================
        // GENERAR DATOS FICTICIOS (Determinista)
        // ================================
        static void GenerarDatos()
        {
            // 1️⃣ Crear 500 ciudadanos
            for (int i = 1; i <= 500; i++)
            {
                ciudadanos.Add($"Ciudadano {i:D3}");
            }

            // 2️⃣ Definir 25 ciudadanos con ambas dosis (Ciudadano 001 a 025)
            HashSet<string> ambas = new HashSet<string>();
            for (int i = 1; i <= 25; i++)
            {
                string c = $"Ciudadano {i:D3}";
                ambas.Add(c);
                pfizer.Add(c);
                astrazeneca.Add(c);
            }

            // 3️⃣ Completar Pfizer a 75 (25 ya en ambas + 50 más: 026 a 075)
            for (int i = 26; i <= 75; i++)
            {
                pfizer.Add($"Ciudadano {i:D3}");
            }

            // 4️⃣ Completar AstraZeneca a 75 (25 ya en ambas + 50 más: 076 a 125)
            for (int i = 76; i <= 125; i++)
            {
                astrazeneca.Add($"Ciudadano {i:D3}");
            }

            // ✅ Ahora: 
            // pfizer.Count = 75
            // astrazeneca.Count = 75
            // intersección = 25
        }

        // ================================
        // OPERACIONES DE CONJUNTOS
        // ================================
        static HashSet<string> ObtenerNoVacunados()
        {
            var noVacunados = new HashSet<string>(ciudadanos);
            var vacunados = new HashSet<string>(pfizer);
            vacunados.UnionWith(astrazeneca);
            noVacunados.ExceptWith(vacunados);
            return noVacunados;
        }

        static HashSet<string> ObtenerAmbasDosis()
        {
            var ambas = new HashSet<string>(pfizer);
            ambas.IntersectWith(astrazeneca);
            return ambas;
        }

        static HashSet<string> ObtenerSoloPfizer()
        {
            var soloP = new HashSet<string>(pfizer);
            soloP.ExceptWith(astrazeneca);
            return soloP;
        }

        static HashSet<string> ObtenerSoloAstra()
        {
            var soloA = new HashSet<string>(astrazeneca);
            soloA.ExceptWith(pfizer);
            return soloA;
        }

        // ================================
        // MOSTRAR RESULTADOS
        // ================================
        static void MostrarListado(string titulo, HashSet<string> conjunto, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("\n-----------------------------------------------");
            Console.WriteLine($"{titulo} (Total: {conjunto.Count})");
            Console.WriteLine("-----------------------------------------------");
            Console.ResetColor();

            foreach (var ciudadano in conjunto.OrderBy(x => x))
            {
                Console.WriteLine(ciudadano);
            }
        }
    }
}

