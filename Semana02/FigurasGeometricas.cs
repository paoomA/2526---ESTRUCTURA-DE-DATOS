using System;

namespace FigurasGeometricas
{
    // ===============================
    // Clase Circulo
    // ===============================
    public class Circulo
    {
        private double radio;  // Encapsulación del radio

        public double Radio
        {
            get { return radio; }
            set
            {
                if (value > 0)
                    radio = value;
                else
                    throw new ArgumentException("El radio debe ser mayor que cero.");
            }
        }

        public Circulo(double radio)
        {
            Radio = radio;
        }

        // Método para calcular el área del círculo
        public double CalcularArea()
        {
            return Math.PI * radio * radio;
        }

        // Método para calcular el perímetro del círculo
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }
    }

    // ===============================
    // Clase Cuadrado
    // ===============================
    public class Cuadrado
    {
        private double lado; // Encapsulación del dato

        public double Lado
        {
            get { return lado; }
            set
            {
                if (value > 0)
                    lado = value;
                else
                    throw new ArgumentException("El lado debe ser mayor que cero.");
            }
        }

        public Cuadrado(double lado)
        {
            Lado = lado;
        }

        // Método para calcular área
        public double CalcularArea()
        {
            return lado * lado;
        }

        // Método para calcular perímetro
        public double CalcularPerimetro()
        {
            return 4 * lado;
        }
    }

    // ===============================
    // Clase principal Program
    // ===============================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== FIGURAS GEOMÉTRICAS ===\n");

            // ---- Círculo ----
            Circulo circulo = new Circulo(5);
            Console.WriteLine("Círculo (radio = 5)");
            Console.WriteLine("Área: " + circulo.CalcularArea());
            Console.WriteLine("Perímetro: " + circulo.CalcularPerimetro());
            Console.WriteLine();

            // ---- Cuadrado ----
            Cuadrado cuadrado = new Cuadrado(4);
            Console.WriteLine("Cuadrado (lado = 4)");
            Console.WriteLine("Área: " + cuadrado.CalcularArea());
            Console.WriteLine("Perímetro: " + cuadrado.CalcularPerimetro());
            Console.WriteLine();

            Console.WriteLine("Presione una tecla para salir...");
            Console.ReadKey();
        }
    }
}

