using System;
using System.Collections.Generic;
using System.Threading;

#nullable enable
class ProgramaInteractivo
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            MostrarMenuPrincipal();

            Console.Write("Seleccione una opción: ");
            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MenuParentesis();
                    break;
                case "2":
                    ResolverHanoiVisual();
                    break;
                case "3":
                    Console.WriteLine("\nSaliendo del programa Acosta Paola, hasta luego...");
                    Thread.Sleep(1500);
                    return;
                default:
                    Console.WriteLine("\nOpción no válida. Presione Enter para intentar de nuevo.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    // ================================
    // MENÚ PRINCIPAL ESTÉTICO
    // ================================
    static void MostrarMenuPrincipal()
    {
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║          MENÚ PRINCIPAL                ║");
        Console.WriteLine("╠════════════════════════════════════════╣");
        Console.WriteLine("║ 1. Verificación de paréntesis         ║");
        Console.WriteLine("║ 2. Resolver Torres de Hanoi (visual)  ║");
        Console.WriteLine("║ 3. Salir                              ║");
        Console.WriteLine("╚════════════════════════════════════════╝\n");
    }

    // ================================
    // OPCIÓN 1: PARÉNTESIS
    // ================================
    static void MenuParentesis()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Verificación de Paréntesis Balanceados ===");
            Console.WriteLine("Escriba su fórmula matemática (o '0' para regresar al menú):");
            Console.Write("→ ");
            string formula = Console.ReadLine() ?? "";

            if (formula == "0") break; // Regresa al menú inmediatamente

            if (EstaBalanceada(formula))
                Console.WriteLine("\n✅ Fórmula balanceada.");
            else
                Console.WriteLine("\n❌ Fórmula NO balanceada.");

            // Pregunta si desea probar otra fórmula
            Console.Write("\n¿Desea probar otra fórmula? (S/N): ");
            string respuesta = (Console.ReadLine() ?? "").Trim().ToUpper();

            // Acepta "S" o "SI" para continuar; cualquier otra cosa regresa al menú
            if (respuesta != "S" && respuesta != "SI") break;
        }
    }

    static bool EstaBalanceada(string expr)
    {
        Stack<char> pila = new Stack<char>();
        foreach (char c in expr)
        {
            if (c == '(' || c == '{' || c == '[') pila.Push(c);
            else if (c == ')' || c == '}' || c == ']')
            {
                if (pila.Count == 0) return false;
                char top = pila.Pop();
                if ((c == ')' && top != '(') || (c == '}' && top != '{') || (c == ']' && top != '['))
                    return false;
            }
        }
        return pila.Count == 0;
    }

    // ================================
    // OPCIÓN 2: TORRES DE HANOI VISUAL OPTIMIZADO
    // ================================
    static void ResolverHanoiVisual()
    {
        Console.Clear();
        Console.WriteLine("=== Torres de Hanoi Visual ===");
        Console.Write("Ingrese número de discos (máx 10): ");

        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0 || n > 10)
        {
            Console.WriteLine("Número inválido. Presione Enter para regresar al menú.");
            Console.ReadLine();
            return;
        }

        Stack<int> torreA = new Stack<int>();
        Stack<int> torreB = new Stack<int>();
        Stack<int> torreC = new Stack<int>();

        for (int i = n; i >= 1; i--) torreA.Push(i);

        DibujarTorres(torreA, torreB, torreC, n);
        Thread.Sleep(500);

        int delay = n switch
        {
            <= 5 => 800,
            <= 8 => 200,
            _ => 50
        };

        MoverHanoiVisual(n, torreA, torreC, torreB, "A", "C", "B", n, delay);

        Console.WriteLine("\n¡Proceso completado! Presione Enter para regresar al menú.");
        Console.ReadLine();
    }

    static void MoverHanoiVisual(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar,
                                 string origenName, string destinoName, string auxiliarName, int altura, int delay)
    {
        if (n == 1)
        {
            int disco = origen.Pop();
            destino.Push(disco);
            Console.Clear();
            Console.WriteLine($"Mover disco {disco} de {origenName} a {destinoName}\n");
            DibujarTorres(
                origenName == "A" ? origen : auxiliarName == "A" ? auxiliar : destino,
                origenName == "B" ? origen : auxiliarName == "B" ? auxiliar : destino,
                origenName == "C" ? origen : auxiliarName == "C" ? auxiliar : destino,
                altura
            );
            Thread.Sleep(delay);
        }
        else
        {
            MoverHanoiVisual(n - 1, origen, auxiliar, destino, origenName, auxiliarName, destinoName, altura, delay);
            MoverHanoiVisual(1, origen, destino, auxiliar, origenName, destinoName, auxiliarName, altura, delay);
            MoverHanoiVisual(n - 1, auxiliar, destino, origen, auxiliarName, destinoName, origenName, altura, delay);
        }
    }

    // ================================
    // FUNCIONES DE DIBUJO
    // ================================
    static void DibujarTorres(Stack<int> A, Stack<int> B, Stack<int> C, int altura)
    {
        int[][] torres = new int[3][];
        torres[0] = A.ToArray();
        torres[1] = B.ToArray();
        torres[2] = C.ToArray();

        int maxAltura = altura;

        for (int nivel = maxAltura - 1; nivel >= 0; nivel--)
        {
            for (int t = 0; t < 3; t++)
            {
                if (nivel < torres[t].Length)
                    DibujarDisco(torres[t][nivel]);
                else
                    Console.Write("│".PadLeft(maxAltura + 1).PadRight(maxAltura * 2 + 3));
            }
            Console.WriteLine();
        }

        // Base
        for (int t = 0; t < 3; t++)
            Console.Write("─".PadLeft(maxAltura * 2 + 3));
        Console.WriteLine();

        // Nombres
        Console.WriteLine("   A".PadRight(maxAltura * 2 + 3) +
                          "   B".PadRight(maxAltura * 2 + 3) +
                          "   C\n");
    }

    static void DibujarDisco(int tamaño)
    {
        ConsoleColor[] colores = { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow,
                                   ConsoleColor.Blue, ConsoleColor.Magenta, ConsoleColor.Cyan,
                                   ConsoleColor.White, ConsoleColor.DarkRed, ConsoleColor.DarkGreen, ConsoleColor.DarkYellow };
        Console.BackgroundColor = colores[(tamaño - 1) % colores.Length];
        string disco = new string(' ', tamaño * 2);
        Console.Write(disco.PadLeft(10).PadRight(23));
        Console.ResetColor();
    }
}

