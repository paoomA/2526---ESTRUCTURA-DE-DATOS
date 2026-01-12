using System;

class Program
{
    static void Main()
    {
        ListaEstudiantes listaEstudiantes = new ListaEstudiantes();
        ListaVehiculos listaVehiculos = new ListaVehiculos();

        Console.Title = "Sistema de Registro Interactivo";
        Console.ForegroundColor = ConsoleColor.Cyan;

        while (true)
        {
            Console.Clear();
            DibujarCuadro("MENÚ PRINCIPAL - SELECCIONE OPCIÓN");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Ejercicio 1 - Registro de Estudiantes");
            Console.WriteLine("2. Ejercicio 2 - Registro de Vehículos");
            Console.WriteLine("3. Salir");
            Console.ResetColor();
            Console.Write("\nSeleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MostrarEncabezadoEstudiantes();
                    MenuEstudiantes(listaEstudiantes);
                    break;
                case "2":
                    MostrarEncabezadoVehiculos();
                    MenuVehiculos(listaVehiculos);
                    break;
                case "3":
                    MostrarDespedida();
                    return;
                default:
                    Console.WriteLine("Opción inválida. Presione cualquier tecla...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // -------------------- ENCABEZADOS --------------------
    static void MostrarEncabezadoEstudiantes()
    {
        Console.Clear();
        DibujarCuadro("REDES III - LISTAS ENLAZADAS");
        Console.WriteLine("Registro de estudiantes: los aprobados se agregan al inicio,\nlos reprobados al final de la lista.\nDatos: cédula, nombre, apellido, correo, nota (1-10).");
    }

    static void MostrarEncabezadoVehiculos()
    {
        Console.Clear();
        DibujarCuadro("ESTACIONAMIENTO - LISTAS ENLAZADAS");
        Console.WriteLine("Registro de vehículos: placa, marca, modelo, año, precio.\nPermite agregar, buscar, eliminar y listar vehículos por año o todos.");
    }

    // -------------------- MENÚ ESTUDIANTES --------------------
    static void MenuEstudiantes(ListaEstudiantes lista)
    {
        while (true)
        {
            Console.WriteLine("\n1. Agregar Estudiante");
            Console.WriteLine("2. Buscar Estudiante por Cédula");
            Console.WriteLine("3. Eliminar Estudiante");
            Console.WriteLine("4. Total Estudiantes Aprobados");
            Console.WriteLine("5. Total Estudiantes Reprobados");
            Console.WriteLine("6. Mostrar Todos los Estudiantes");
            Console.WriteLine("7. Regresar al Menú Principal");
            Console.Write("\nSeleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Cédula: "); string cedula = Console.ReadLine();
                    Console.Write("Nombre: "); string nombre = Console.ReadLine();
                    Console.Write("Apellido: "); string apellido = Console.ReadLine();
                    Console.Write("Correo: "); string correo = Console.ReadLine();
                    Console.Write("Nota definitiva (1-10): "); double nota = Convert.ToDouble(Console.ReadLine());
                    lista.AgregarEstudiante(cedula, nombre, apellido, correo, nota);
                    Console.WriteLine("\nEstudiante agregado correctamente. Presione cualquier tecla...");
                    Console.ReadKey();
                    break;
                case "2":
                    Console.Write("Ingrese cédula: ");
                    var e = lista.Buscar(Console.ReadLine());
                    if (e != null)
                        Console.WriteLine($"Cédula: {e.Cedula}, Nombre: {e.Nombre} {e.Apellido}, Nota: {e.NotaDefinitiva}");
                    else
                        Console.WriteLine("Estudiante no encontrado.");
                    Console.ReadKey();
                    break;
                case "3":
                    Console.Write("Ingrese cédula a eliminar: ");
                    bool eliminado = lista.Eliminar(Console.ReadLine());
                    Console.WriteLine(eliminado ? "Estudiante eliminado." : "No se encontró el estudiante.");
                    Console.ReadKey();
                    break;
                case "4":
                    DibujarCuadro($"TOTAL ESTUDIANTES APROBADOS: {lista.TotalAprobados()}");
                    Console.ReadKey();
                    break;
                case "5":
                    DibujarCuadro($"TOTAL ESTUDIANTES REPROBADOS: {lista.TotalReprobados()}");
                    Console.ReadKey();
                    break;
                case "6":
                    lista.MostrarEstudiantes();
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Opción inválida. Presione cualquier tecla...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // -------------------- MENÚ VEHÍCULOS --------------------
    static void MenuVehiculos(ListaVehiculos lista)
    {
        while (true)
        {
            Console.WriteLine("\n1. Agregar Vehículo");
            Console.WriteLine("2. Buscar Vehículo por Placa");
            Console.WriteLine("3. Ver Vehículos por Año");
            Console.WriteLine("4. Ver Todos los Vehículos");
            Console.WriteLine("5. Eliminar Vehículo");
            Console.WriteLine("6. Regresar al Menú Principal");
            Console.Write("\nSeleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Placa: "); string placa = Console.ReadLine();
                    Console.Write("Marca: "); string marca = Console.ReadLine();
                    Console.Write("Modelo: "); string modelo = Console.ReadLine();
                    Console.Write("Año: "); int año = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Precio: "); double precio = Convert.ToDouble(Console.ReadLine());
                    lista.AgregarVehiculo(placa, marca, modelo, año, precio);
                    Console.WriteLine("\nVehículo agregado correctamente. Presione cualquier tecla...");
                    Console.ReadKey();
                    break;
                case "2":
                    Console.Write("Ingrese placa: ");
                    var v = lista.BuscarPorPlaca(Console.ReadLine());
                    if (v != null)
                        Console.WriteLine($"{v.Placa} - {v.Marca} {v.Modelo} - Año: {v.Año} - Precio: {v.Precio}");
                    else
                        Console.WriteLine("Vehículo no encontrado.");
                    Console.ReadKey();
                    break;
                case "3":
                    Console.Write("Ingrese año: "); int anioFiltro = Convert.ToInt32(Console.ReadLine());
                    lista.VerPorAño(anioFiltro);
                    Console.WriteLine("\nPresione cualquier tecla...");
                    Console.ReadKey();
                    break;
                case "4":
                    lista.MostrarTodos();
                    Console.WriteLine("\nPresione cualquier tecla...");
                    Console.ReadKey();
                    break;
                case "5":
                    Console.Write("Ingrese placa a eliminar: ");
                    bool eliminado = lista.Eliminar(Console.ReadLine());
                    Console.WriteLine(eliminado ? "Vehículo eliminado." : "Vehículo no encontrado.");
                    Console.ReadKey();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Opción inválida. Presione cualquier tecla...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // -------------------- DIBUJAR CUADRO --------------------
    static void DibujarCuadro(string texto)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(new string('═', 60));
        Console.WriteLine("║" + texto.PadLeft((60 + texto.Length) / 2).PadRight(59) + "║");
        Console.WriteLine(new string('═', 60));
        Console.ResetColor();
    }

    // -------------------- DESPEDIDA --------------------
    static void MostrarDespedida()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(new string('═', 60));
        Console.WriteLine("║" + "Gracias por usar el programa!".PadLeft((60 + "Gracias por usar el programa!".Length) / 2).PadRight(59) + "║");
        Console.WriteLine("║" + "".PadRight(59) + "║");
        Console.WriteLine("║" + "Acosta Paola les manda bendiciones hasta pronto".PadLeft((60 + "Acosta Paola les manda bendiciones hasta pronto".Length) / 2).PadRight(59) + "║");
        Console.WriteLine(new string('═', 60));
        Console.ResetColor();
        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}

// -------------------- CLASES DE ESTUDIANTES --------------------
class Estudiante
{
    public string Cedula;
    public string Nombre;
    public string Apellido;
    public string Correo;
    public double NotaDefinitiva;
    public Estudiante Siguiente;
}

class ListaEstudiantes
{
    private Estudiante cabeza;
    private Estudiante cola;

    public void AgregarEstudiante(string cedula, string nombre, string apellido, string correo, double nota)
    {
        Estudiante nuevo = new Estudiante { Cedula = cedula, Nombre = nombre, Apellido = apellido, Correo = correo, NotaDefinitiva = nota };
        if (nota >= 7)
        {
            nuevo.Siguiente = cabeza;
            cabeza = nuevo;
            if (cola == null) cola = nuevo;
        }
        else
        {
            if (cabeza == null) cabeza = cola = nuevo;
            else { cola.Siguiente = nuevo; cola = nuevo; }
        }
    }

    public Estudiante Buscar(string cedula)
    {
        Estudiante actual = cabeza;
        while (actual != null) { if (actual.Cedula == cedula) return actual; actual = actual.Siguiente; }
        return null;
    }

    public bool Eliminar(string cedula)
    {
        Estudiante actual = cabeza, anterior = null;
        while (actual != null)
        {
            if (actual.Cedula == cedula)
            {
                if (anterior == null) cabeza = actual.Siguiente;
                else anterior.Siguiente = actual.Siguiente;
                if (actual == cola) cola = anterior;
                return true;
            }
            anterior = actual;
            actual = actual.Siguiente;
        }
        return false;
    }

    public int TotalAprobados() { int total = 0; Estudiante a = cabeza; while (a != null) { if (a.NotaDefinitiva >= 7) total++; a = a.Siguiente; } return total; }
    public int TotalReprobados() { int total = 0; Estudiante a = cabeza; while (a != null) { if (a.NotaDefinitiva < 7) total++; a = a.Siguiente; } return total; }

    public void MostrarEstudiantes()
    {
        Estudiante actual = cabeza;
        while (actual != null)
        {
            Console.WriteLine($"Cédula: {actual.Cedula}, Nombre: {actual.Nombre} {actual.Apellido}, Nota: {actual.NotaDefinitiva}");
            actual = actual.Siguiente;
        }
    }
}

// -------------------- CLASES DE VEHÍCULOS --------------------
class Vehiculo
{
    public string Placa;
    public string Marca;
    public string Modelo;
    public int Año;
    public double Precio;
    public Vehiculo Siguiente;
}

class ListaVehiculos
{
    private Vehiculo cabeza;

    public void AgregarVehiculo(string placa, string marca, string modelo, int año, double precio)
    {
        Vehiculo nuevo = new Vehiculo { Placa = placa, Marca = marca, Modelo = modelo, Año = año, Precio = precio, Siguiente = cabeza };
        cabeza = nuevo;
    }

    public Vehiculo BuscarPorPlaca(string placa)
    {
        Vehiculo actual = cabeza;
        while (actual != null) { if (actual.Placa == placa) return actual; actual = actual.Siguiente; }
        return null;
    }

    public void VerPorAño(int año)
    {
        Vehiculo actual = cabeza;
        while (actual != null)
        {
            if (actual.Año == año) Console.WriteLine($"{actual.Placa} - {actual.Marca} {actual.Modelo} - Precio: {actual.Precio}");
            actual = actual.Siguiente;
        }
    }

    public void MostrarTodos()
    {
        Vehiculo actual = cabeza;
        while (actual != null)
        {
            Console.WriteLine($"{actual.Placa} - {actual.Marca} {actual.Modelo} - Año: {actual.Año} - Precio: {actual.Precio}");
            actual = actual.Siguiente;
        }
    }

    public bool Eliminar(string placa)
    {
        Vehiculo actual = cabeza, anterior = null;
        while (actual != null)
        {
            if (actual.Placa == placa)
            {
                if (anterior == null) cabeza = actual.Siguiente;
                else anterior.Siguiente = actual.Siguiente;
                return true;
            }
            anterior = actual;
            actual = actual.Siguiente;
        }
        return false;
    }
}

