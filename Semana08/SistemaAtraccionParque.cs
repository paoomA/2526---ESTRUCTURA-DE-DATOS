using System;
using System.Collections.Generic;

namespace SistemaAtraccionParque
{
    class Persona
    {
        public string Nombre { get; set; }

        public Persona(string nombre)
        {
            Nombre = nombre;
        }
    }

    class Atraccion
    {
        private Queue<Persona> colaPersonas = new Queue<Persona>();
        private const int MAX_ASIENTOS = 30;

        public void AgregarPersona(string nombre)
        {
            if (colaPersonas.Count < MAX_ASIENTOS)
            {
                colaPersonas.Enqueue(new Persona(nombre));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✔ {nombre} agregado correctamente a la fila.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Todos los asientos están ocupados.");
            }
            Console.ResetColor();
        }

        public void MostrarCola()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n🎢 PERSONAS EN LA FILA:");
            Console.ResetColor();

            if (colaPersonas.Count == 0)
            {
                Console.WriteLine("La fila está vacía.");
                return;
            }

            int turno = 1;
            foreach (var persona in colaPersonas)
            {
                Console.WriteLine($"{turno}. {persona.Nombre}");
                turno++;
            }
        }

        public void AtenderPersona()
        {
            if (colaPersonas.Count > 0)
            {
                Persona atendida = colaPersonas.Dequeue();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"🎉 {atendida.Nombre} subió a la atracción.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("No hay personas en la fila.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Atraccion atraccion = new Atraccion();
            int opcion;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("=======================================");
                Console.WriteLine("🎡 SISTEMA DE ATRACCIÓN DEL PARQUE 🎡");
                Console.WriteLine("=======================================");
                Console.ResetColor();

                Console.WriteLine("\n1. Ingresar persona a la fila");
                Console.WriteLine("2. Mostrar fila");
                Console.WriteLine("3. Atender persona");
                Console.WriteLine("4. Salir");
                Console.Write("\nSeleccione una opción: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el nombre de la persona: ");
                        string nombre = Console.ReadLine();
                        atraccion.AgregarPersona(nombre);
                        break;

                    case 2:
                        atraccion.MostrarCola();
                        break;

                    case 3:
                        atraccion.AtenderPersona();
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n👋 Hasta pronto");
                        Console.WriteLine("ACOSTA Y CABRERA les desea un lindo fin de semana 💙✨");
                        Console.ResetColor();
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 4);
        }
    }
}
