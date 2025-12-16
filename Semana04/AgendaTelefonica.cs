using System;
using System.Collections.Generic;

// ===================================================
// ESTRUCTURA (AUTORES)
// ===================================================
struct Autor
{
    public string Nombre1;
    public string Nombre2;
    public string Carrera;
    public string Universidad;
}

// ===================================================
// REGISTRO / CLASE BASE
// ===================================================
class Contacto
{
    public string Nombre = "";   // Inicializado para evitar null
    public string Telefono = ""; // Inicializado para evitar null

    public virtual string Detalle()
    {
        return "";
    }
}

// ===================================================
// CONTACTO PERSONAL
// ===================================================
class ContactoPersonal : Contacto
{
    public string Relacion = ""; // Inicializado para evitar null

    public override string Detalle()
    {
        return "Personal - " + Relacion;
    }
}

// ===================================================
// CONTACTO PROFESIONAL
// ===================================================
class ContactoProfesional : Contacto
{
    public string Cargo = ""; // Inicializado para evitar null

    public override string Detalle()
    {
        return "Profesional - " + Cargo;
    }
}

// ===================================================
// AGENDA (VECTOR + MATRIZ)
// ===================================================
class Agenda
{
    private List<Contacto> contactos = new List<Contacto>();

    public void Agregar(Contacto c)
    {
        contactos.Add(c);
    }

    // =======================
    // MOSTRAR AGENDA
    // =======================
    public void MostrarComoMatriz()
    {
        string[,] matriz = new string[contactos.Count, 3];

        for (int i = 0; i < contactos.Count; i++)
        {
            matriz[i, 0] = contactos[i].Nombre;
            matriz[i, 1] = contactos[i].Telefono;
            matriz[i, 2] = contactos[i].Detalle();
        }

        Console.Clear();
        Console.WriteLine("╔══════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                       📊 AGENDA TELEFÓNICA 📊                       ║");
        Console.WriteLine("╠══════════════════════════════════════════════════════════════════════╣");
        Console.WriteLine("║ NOMBRE                    ║ TELÉFONO     ║ DETALLE                   ║");
        Console.WriteLine("╠══════════════════════════════════════════════════════════════════════╣");

        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            Console.WriteLine($"║ {matriz[i, 0],-25} ║ {matriz[i, 1],-12} ║ {matriz[i, 2],-25} ║");
        }

        Console.WriteLine("╚══════════════════════════════════════════════════════════════════════╝");
    }

    // =======================
    // LISTAR CONTACTOS
    // =======================
    public void ListarNombres()
    {
        Console.WriteLine("\n📋 LISTA DE CONTACTOS DISPONIBLES\n");

        for (int i = 0; i < contactos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {contactos[i].Nombre}");
        }
    }

    // =======================
    // BUSCAR POR ÍNDICE
    // =======================
    public void BuscarPorIndice(int indice)
    {
        if (indice >= 0 && indice < contactos.Count)
        {
            Contacto c = contactos[indice];

            Console.WriteLine("\n╔══════════════════════════════════╗");
            Console.WriteLine("║       📌 DATOS DEL CONTACTO     ║");
            Console.WriteLine("╠══════════════════════════════════╣");
            Console.WriteLine("║ Nombre   : " + c.Nombre);
            Console.WriteLine("║ Teléfono : " + c.Telefono);
            Console.WriteLine("║ Tipo     : " + c.Detalle());
            Console.WriteLine("╚══════════════════════════════════╝");
        }
        else
        {
            Console.WriteLine("\n❌ Número inválido.");
        }
    }
}

// ===================================================
// PROGRAMA PRINCIPAL
// ===================================================
class Program
{
    static void Main()
    {
        // ESTRUCTURA DE AUTORES
        Autor autores = new Autor
        {
            Nombre1 = "Acosta",
            Nombre2 = "Cabrera",
            Carrera = "Ingeniería",
            Universidad = "Universidad Estatal Amazónica"
        };

        Agenda agenda = new Agenda();

        // =======================
        // REGISTROS (10 CONTACTOS)
        // =======================
        agenda.Agregar(new ContactoProfesional { Nombre = "David Romero", Telefono = "0998901230", Cargo = "Estudiante UEA" });
        agenda.Agregar(new ContactoPersonal { Nombre = "Juan Morales", Telefono = "0987654321", Relacion = "Amigo" });
        agenda.Agregar(new ContactoProfesional { Nombre = "Santiago Nogales", Telefono = "0991234567", Cargo = "Docente UEA" });
        agenda.Agregar(new ContactoPersonal { Nombre = "Stalin Cabrera", Telefono = "098734343", Relacion = "Tio" });
        agenda.Agregar(new ContactoPersonal { Nombre = "Maria Lopez", Telefono = "0976543210", Relacion = "Compañera" });
        agenda.Agregar(new ContactoProfesional { Nombre = "Carlos Perez", Telefono = "0965432109", Cargo = "Ingeniero" });
        agenda.Agregar(new ContactoPersonal { Nombre = "Yamileth Acosta", Telefono = "0954321098", Relacion = "Prima" });
        agenda.Agregar(new ContactoProfesional { Nombre = "Luis Herrera", Telefono = "0943210987", Cargo = "Administrador" });
        agenda.Agregar(new ContactoPersonal { Nombre = "Lady Gavilanes", Telefono = "0932109876", Relacion = "Amiga" });
        agenda.Agregar(new ContactoProfesional { Nombre = "Miguel Castro", Telefono = "0921098765", Cargo = "Analista" });

        int opcion;

        // =======================
        // MENÚ INTERACTIVO
        // =======================
        do
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║     📞 AGENDA TELEFÓNICA - UEA 📞                  ║");
            Console.WriteLine("╠════════════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Mostrar agenda                                   ║");
            Console.WriteLine("║ 2. Buscar contacto                                  ║");
            Console.WriteLine("║ 3. Salir                                           ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝");
            Console.Write("\nSeleccione una opción: ");
            int.TryParse(Console.ReadLine(), out opcion);

            switch (opcion)
            {
                case 1:
                    agenda.MostrarComoMatriz();
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 2:
                    Console.Clear();
                    agenda.ListarNombres();
                    Console.Write("\nSeleccione el número del contacto: ");
                    int num;
                    int.TryParse(Console.ReadLine(), out num);
                    agenda.BuscarPorIndice(num - 1);
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("╔════════════════════════════════════════════════════╗");
                    Console.WriteLine("║   🙌 GRACIAS POR USAR LA AGENDA TELEFÓNICA 🙌     ║");
                    Console.WriteLine("╠════════════════════════════════════════════════════╣");
                    Console.WriteLine("║   Desarrollado por las Ingenieras:                 ║");
                    Console.WriteLine($"║   {autores.Nombre1} y {autores.Nombre2}           ║");
                    Console.WriteLine("║                                                    ║");
                    Console.WriteLine($"║   {autores.Universidad}                            ║");
                    Console.WriteLine("╚════════════════════════════════════════════════════╝");
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("\n❌ Opción no válida.");
                    Console.ReadKey();
                    break;
            }

        } while (opcion != 3);
    }
}