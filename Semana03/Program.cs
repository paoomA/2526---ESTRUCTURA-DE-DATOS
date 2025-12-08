namespace RegistroEstudiante
{
    // ===============================
    // Clase Estudiante
    // ===============================
    public class Estudiante
    {
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string[] Telefonos { get; set; }

        public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            ID = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;

            if (telefonos.Length == 3)
                Telefonos = telefonos;
            else
                throw new System.ArgumentException("Deben ingresarse exactamente 3 números de teléfono.");
        }

        public void MostrarInformacion()
        {
            // Encabezado tipo tabla
            System.Console.WriteLine("┌────────────────────────────────────────────────────┐");
            System.Console.WriteLine("│            REGISTRO DE INFORMACIÓN                 │");
            System.Console.WriteLine("├────────────────────────────────────────────────────┤");

            // Tabla superior
            System.Console.WriteLine("│ ID:         | " + ID.ToString().PadRight(35) + "│");
            System.Console.WriteLine("│ Nombres:    | " + Nombres.PadRight(35) + "│");
            System.Console.WriteLine("│ Apellidos:  | " + Apellidos.PadRight(35) + "│");
            System.Console.WriteLine("│ Dirección:  | " + Direccion.PadRight(35) + "│");

            // Línea divisoria en medio (tabla)
            System.Console.WriteLine("├────────────────────────────────────────────────────┤");

            // Teléfonos como tabla
            for (int i = 0; i < Telefonos.Length; i++)
            {
                string texto = $"Teléfono {i + 1}: {Telefonos[i]}";
                System.Console.WriteLine("│ " + texto.PadRight(50) + "│");
            }

            // Cierre
            System.Console.WriteLine("└────────────────────────────────────────────────────┘");
        }
    }

    // ===============================
    // Programa principal
    // ===============================
    public class Program
    {
        public static void Main(string[] args)
        {
            // Array con los 3 teléfonos
            string[] telefonos = new string[3];
            telefonos[0] = "094-099-8765";
            telefonos[1] = "091-696-5543";
            telefonos[2] = "095-120-2322";

            // Crear estudiante
            Estudiante estudiante = new Estudiante(
                001,
                "Juan",
                "Garcia",
                "Calle Sucumbios 123",
                telefonos
            );

            // Mostrar información
            estudiante.MostrarInformacion();

            System.Console.WriteLine("\nPresione cualquier tecla para salir...");
            System.Console.ReadKey();
        }
    }
}
