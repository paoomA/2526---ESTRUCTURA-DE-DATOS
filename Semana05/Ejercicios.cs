using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            MostrarMenu();

            Console.Write("Opción: ");
            string opcion = Console.ReadLine();
            Console.Clear();

            switch (opcion)
            {
                case "1": Ejercicio1(); break;
                case "2": Ejercicio2(); break;
                case "3": Ejercicio3(); break;
                case "4": Ejercicio4(); break;
                case "5": Ejercicio5(); break;
                case "0":
                    MostrarDespedida();
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }

            Console.WriteLine("\nPresione cualquier tecla para regresar al menú...");
            Console.ReadKey();
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("+------------------------------------------------+");
        Console.WriteLine("|           EJERCICIOS DE PROGRAMACIÓN            |");
        Console.WriteLine("+------------------------------------------------+");
        Console.WriteLine("| 1. Eliminar letras en posiciones múltiplos de 3 |");
        Console.WriteLine("| 2. Verificar si una palabra es palíndromo       |");
        Console.WriteLine("| 3. Contar vocales en una palabra                 |");
        Console.WriteLine("| 4. Encontrar precio mínimo y máximo              |");
        Console.WriteLine("| 5. Calcular media y desviación típica            |");
        Console.WriteLine("| 0. Salir                                         |");
        Console.WriteLine("+------------------------------------------------+");
    }

    static void MostrarDespedida()
    {
        Console.WriteLine("+--------------------------------------------------+");
        Console.WriteLine("|          Gracias por usar el programa!           |");
        Console.WriteLine("|                                                  |");
        Console.WriteLine("|  Acosta Paola les manda bendiciones hasta pronto |");
        Console.WriteLine("+--------------------------------------------------+");
    }

    static void Ejercicio1()
    {
        string titulo = "Ejercicio 1: Eliminar letras en posiciones múltiplos de 3 del abecedario";
        string descripcion = "Escribir un programa que almacene el abecedario en una lista, elimine las letras que ocupen posiciones múltiplos de 3, y muestre la lista resultante.\n";

        ImprimirTituloDescripcion(titulo, descripcion);

        List<char> alphabet = new List<char>("abcdefghijklmnñopqrstuvwxyz".ToCharArray());

        for (int i = alphabet.Count; i >= 1; i--)
        {
            if (i % 3 == 0)
                alphabet.RemoveAt(i - 1);
        }

        Console.WriteLine("Lista resultante:");
        Console.WriteLine(string.Join(", ", alphabet));
    }

    static void Ejercicio2()
    {
        string titulo = "Ejercicio 2: Verificar si una palabra es palíndromo";
        string descripcion = "Escribir un programa que pida al usuario una palabra y muestre por pantalla si es un palíndromo.\n";

        ImprimirTituloDescripcion(titulo, descripcion);

        Console.Write("Introduce una palabra: ");
        string palabra = Console.ReadLine().ToLower().Trim();

        string palabraReversa = new string(palabra.Reverse().ToArray());

        if (palabra == palabraReversa)
            Console.WriteLine("\nLa palabra es un palíndromo.");
        else
            Console.WriteLine("\nLa palabra no es un palíndromo.");
    }

    static void Ejercicio3()
    {
        string titulo = "Ejercicio 3: Contar vocales en una palabra";
        string descripcion = "Escribir un programa que pida al usuario una palabra y muestre por pantalla el número de veces que contiene cada vocal.\n";

        ImprimirTituloDescripcion(titulo, descripcion);

        Console.Write("Introduce una palabra: ");
        string palabra = Console.ReadLine().ToLower();

        char[] vocales = { 'a', 'e', 'i', 'o', 'u' };

        foreach (char vocal in vocales)
        {
            int conteo = palabra.Count(c => c == vocal);
            Console.WriteLine($"La vocal '{vocal}' aparece {conteo} veces.");
        }
    }

    static void Ejercicio4()
    {
        string titulo = "Ejercicio 4: Encontrar precio mínimo y máximo";
        string descripcion = "Escribir un programa que almacene en una lista los siguientes precios: 15, 92, 33, 58, 76, 41, 27, y muestre por pantalla el menor y el mayor de los precios.\n";

        ImprimirTituloDescripcion(titulo, descripcion);

        List<int> precios = new List<int> { 15, 92, 33, 58, 76, 41, 27 };

        int minimo = precios.Min();
        int maximo = precios.Max();

        Console.WriteLine($"El precio mínimo es: {minimo}");
        Console.WriteLine($"El precio máximo es: {maximo}");
    }

    static void Ejercicio5()
    {
        string titulo = "Ejercicio 5: Calcular media y desviación típica";
        string descripcion = "Escribir un programa que pregunte por una muestra de números separados por comas, los guarde en una lista y muestre por pantalla su media y desviación típica.\n";

        ImprimirTituloDescripcion(titulo, descripcion);

        Console.Write("Introduce una muestra de números separados por comas: ");
        string input = Console.ReadLine();

        string[] partes = input.Split(',');
        List<double> numeros = new List<double>();

        foreach (string parte in partes)
        {
            if (double.TryParse(parte.Trim(), out double num))
                numeros.Add(num);
            else
                Console.WriteLine($"'{parte}' no es un número válido y será ignorado.");
        }

        if (numeros.Count == 0)
        {
            Console.WriteLine("No se ingresaron números válidos.");
        }
        else
        {
            double media = numeros.Average();
            double sumCuadrados = numeros.Sum(n => Math.Pow(n - media, 2));
            double desviacion = Math.Sqrt(sumCuadrados / numeros.Count);

            Console.WriteLine($"\nMedia: {media:F2}");
            Console.WriteLine($"Desviación típica: {desviacion:F2}");
        }
    }

    static void ImprimirTituloDescripcion(string titulo, string descripcion)
    {
        Console.WriteLine("| {0}", titulo);
        Console.WriteLine("|");
        string[] lineas = descripcion.Split('\n');
        foreach (string linea in lineas)
        {
            if (!string.IsNullOrWhiteSpace(linea))
                Console.WriteLine("| {0}", linea);
        }
        Console.WriteLine();
    }
}


