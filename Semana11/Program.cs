using System;
using System.Collections.Generic;
using System.Linq;

class TraductorDiccionario
{
    static Dictionary<string, string> diccionario = new Dictionary<string, string>()
    {
        {"time", "tiempo"},
        {"person", "persona"},
        {"year", "año"},
        {"way", "camino"},
        {"day", "día"},
        {"thing", "cosa"},
        {"man", "hombre"},
        {"world", "mundo"},
        {"life", "vida"},
        {"hand", "mano"},
        {"part", "parte"},
        {"child", "niño"},
        {"eye", "ojo"},
        {"woman", "mujer"},
        {"place", "lugar"},
        {"work", "trabajo"},
        {"week", "semana"},
        {"case", "caso"},
        {"point", "punto"},
        {"government", "gobierno"},
        {"company", "empresa"}
    };

    static void Main()
    {
        bool salir = false;
        while (!salir)
        {
            MostrarMenu();
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    TraducirFrase();
                    break;
                case "2":
                    AgregarPalabra();
                    break;
                case "3":
                    MostrarDiccionario();
                    break;
                case "0":
                    Console.WriteLine("\nGracias por usar el sistema de diccionario. ¡Hasta luego, Acosta Paola!");
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }
            Console.WriteLine();
        }
    }

    static void MostrarMenu()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("==================== MENÚ ====================");
        Console.ResetColor();
        Console.WriteLine("1. Traducir una frase");
        Console.WriteLine("2. Agregar palabras al diccionario");
        Console.WriteLine("3. Ver lista de palabras agregadas");
        Console.WriteLine("0. Salir");
        Console.WriteLine();
    }

    static void TraducirFrase()
    {
        Console.Write("\nIngrese la frase a traducir: ");
        string frase = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(frase))
        {
            Console.WriteLine("No ingresaste ninguna frase.");
            return;
        }

        string[] palabras = frase.Split(' ');
        List<string> traduccion = new List<string>();

        foreach (string palabra in palabras)
        {
            string palabraMinuscula = palabra.ToLower();
            string palabraTraducida = palabra;

            // Español -> Inglés
            if (diccionario.ContainsValue(palabraMinuscula))
            {
                palabraTraducida = diccionario.First(x => x.Value == palabraMinuscula).Key;
            }
            // Inglés -> Español
            else if (diccionario.ContainsKey(palabraMinuscula))
            {
                palabraTraducida = diccionario[palabraMinuscula];
            }

            traduccion.Add(palabraTraducida);
        }

        Console.WriteLine("Traducción parcial: " + string.Join(" ", traduccion));
    }

    static void AgregarPalabra()
    {
        Console.Write("\nIngrese la palabra en inglés: ");
        string ingles = Console.ReadLine().ToLower();

        Console.Write("Ingrese la traducción al español: ");
        string espanol = Console.ReadLine().ToLower();

        if (!diccionario.ContainsKey(ingles))
        {
            diccionario.Add(ingles, espanol);
            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }

    static void MostrarDiccionario()
    {
        Console.WriteLine("\n+------------------------- Diccionario -------------------------+");
        Console.WriteLine("| Inglés                 | Español                              |");
        Console.WriteLine("+------------------------+--------------------------------------+");
        foreach (var entry in diccionario)
        {
            string ingles = entry.Key.PadRight(22);
            string espanol = entry.Value.PadRight(38);
            Console.WriteLine($"| {ingles}| {espanol}|");
        }
        Console.WriteLine("+---------------------------------------------------------------+");
    }
}
