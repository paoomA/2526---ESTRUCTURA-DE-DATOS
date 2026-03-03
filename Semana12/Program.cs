using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Dictionary<string, HashSet<string>> equipos = new Dictionary<string, HashSet<string>>();
    static Dictionary<string, int> puntos = new Dictionary<string, int>();
    static Dictionary<string, int> golesFavor = new Dictionary<string, int>();
    static Dictionary<string, int> golesContra = new Dictionary<string, int>();
    static Random random = new Random();
    static bool torneoJugado = false;

    static void Main()
    {
        MostrarTitulo();
        MenuPrincipal();
    }

    static void MostrarTitulo()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("====================================================");
        Console.WriteLine("      SISTEMA PROFESIONAL DE TORNEO DE FÚTBOL      ");
        Console.WriteLine("====================================================");
        Console.ResetColor();
    }

    static void MenuPrincipal()
    {
        int opcion;

        do
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n══════════════════════════════════════════════");
            Console.WriteLine("              PANEL DE CONTROL");
            Console.WriteLine("══════════════════════════════════════════════");
            Console.ResetColor();

            Console.WriteLine("1. Registrar nuevos equipos en el torneo");
            Console.WriteLine("2. Ejecutar calendario completo de encuentros");
            Console.WriteLine("3. Visualizar clasificación general");
            Console.WriteLine("4. Consultar información detallada de equipos");
            Console.WriteLine("0. Finalizar sistema");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("══════════════════════════════════════════════");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Seleccione una opción: ");
            Console.ResetColor();

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrada inválida.");
                Console.ResetColor();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    RegistrarEquipos();
                    break;
                case 2:
                    SimularTorneo();
                    break;
                case 3:
                    MostrarTabla();
                    break;
                case 4:
                    MostrarReporteria();
                    break;
                case 0:
                    MostrarSalida();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción fuera de rango.");
                    Console.ResetColor();
                    break;
            }

        } while (opcion != 0);
    }

    static void RegistrarEquipos()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("\nIngrese cantidad de equipos: ");
        Console.ResetColor();

        if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad < 2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Debe ingresar un número válido (mínimo 2).");
            Console.ResetColor();
            return;
        }

        for (int i = 0; i < cantidad; i++)
        {
            Console.Write("\nNombre del equipo: ");
            string nombre = Console.ReadLine().Trim();

            if (equipos.ContainsKey(nombre))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ese equipo ya está registrado.");
                Console.ResetColor();
                i--;
                continue;
            }

            HashSet<string> jugadores = new HashSet<string>();
            Console.WriteLine("Ingrese jugadores (máximo 11). Enter vacío para finalizar.");

            while (jugadores.Count < 11)
            {
                Console.Write("Jugador: ");
                string jugador = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(jugador))
                    break;

                if (!jugadores.Add(jugador))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Jugador repetido.");
                    Console.ResetColor();
                }
            }

            if (jugadores.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Debe ingresar al menos un jugador.");
                Console.ResetColor();
                i--;
                continue;
            }

            equipos[nombre] = jugadores;
            puntos[nombre] = 0;
            golesFavor[nombre] = 0;
            golesContra[nombre] = 0;
        }

        torneoJugado = false;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nEquipos registrados correctamente.");
        Console.ResetColor();
    }

    static void SimularTorneo()
    {
        if (equipos.Count < 2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Debe registrar equipos primero.");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n=========== SIMULACIÓN DEL TORNEO ===========\n");
        Console.ResetColor();

        int n = equipos.Count;
        int totalPartidos = n * (n - 1) / 2;

        Console.WriteLine($"Total de partidos programados: {totalPartidos}\n");

        var lista = equipos.Keys.ToList();

        foreach (var e in lista)
        {
            puntos[e] = 0;
            golesFavor[e] = 0;
            golesContra[e] = 0;
        }

        for (int i = 0; i < lista.Count; i++)
        {
            for (int j = i + 1; j < lista.Count; j++)
            {
                int g1 = random.Next(0, 6);
                int g2 = random.Next(0, 6);

                Console.WriteLine($"{lista[i]} {g1} - {g2} {lista[j]}");

                golesFavor[lista[i]] += g1;
                golesContra[lista[i]] += g2;

                golesFavor[lista[j]] += g2;
                golesContra[lista[j]] += g1;

                if (g1 > g2)
                    puntos[lista[i]] += 3;
                else if (g2 > g1)
                    puntos[lista[j]] += 3;
                else
                {
                    puntos[lista[i]] += 1;
                    puntos[lista[j]] += 1;
                }
            }
        }

        torneoJugado = true;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nTorneo finalizado correctamente.");
        Console.ResetColor();
    }

    static void MostrarTabla()
    {
        if (!torneoJugado)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Debe ejecutar la simulación primero.");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n=========== TABLA DE POSICIONES ===========\n");
        Console.ResetColor();

        Console.WriteLine("Equipo\tPts\tGF\tGC\tDG");

        var tabla = puntos
            .OrderByDescending(p => p.Value)
            .ThenByDescending(p => golesFavor[p.Key] - golesContra[p.Key]);

        foreach (var equipo in tabla)
        {
            int dg = golesFavor[equipo.Key] - golesContra[equipo.Key];
            Console.WriteLine($"{equipo.Key}\t{equipo.Value}\t{golesFavor[equipo.Key]}\t{golesContra[equipo.Key]}\t{dg}");
        }

        var campeon = tabla.First();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n🏆 Campeón del torneo: {campeon.Key}");
        Console.ResetColor();
    }

    static void MostrarReporteria()
    {
        if (equipos.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No hay equipos registrados.");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("\n=========== REPORTE DE EQUIPOS ===========");
        Console.ResetColor();

        foreach (var equipo in equipos)
        {
            Console.WriteLine($"\nEquipo: {equipo.Key}");
            foreach (var jugador in equipo.Value)
            {
                Console.WriteLine($" - {jugador}");
            }
        }
    }

    static void MostrarSalida()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n══════════════════════════════════════════════");
        Console.WriteLine("Gracias por usar el sistema");
        Console.WriteLine("Programadoras: Acosta y Cabrera");
        Console.WriteLine("══════════════════════════════════════════════");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("“El código es el lenguaje con el que construimos el futuro.”");
        Console.ResetColor();
    }
}