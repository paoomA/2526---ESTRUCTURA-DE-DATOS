using System;

namespace ArbolBinarioBST
{
    // Clase Nodo
    class Nodo
    {
        public int Valor;
        public Nodo Izquierda;
        public Nodo Derecha;

        public Nodo(int valor)
        {
            Valor = valor;
            Izquierda = null;
            Derecha = null;
        }
    }

    // Clase Árbol BST
    class ArbolBST
    {
        public Nodo Raiz;

        public void Insertar(int valor)
        {
            Raiz = InsertarNodo(Raiz, valor);
        }

        private Nodo InsertarNodo(Nodo nodo, int valor)
        {
            if (nodo == null)
                return new Nodo(valor);

            if (valor < nodo.Valor)
                nodo.Izquierda = InsertarNodo(nodo.Izquierda, valor);
            else if (valor > nodo.Valor)
                nodo.Derecha = InsertarNodo(nodo.Derecha, valor);

            return nodo;
        }

        public bool Buscar(int valor)
        {
            return BuscarNodo(Raiz, valor);
        }

        private bool BuscarNodo(Nodo nodo, int valor)
        {
            if (nodo == null)
                return false;

            if (valor == nodo.Valor)
                return true;

            if (valor < nodo.Valor)
                return BuscarNodo(nodo.Izquierda, valor);
            else
                return BuscarNodo(nodo.Derecha, valor);
        }

        public void Eliminar(int valor)
        {
            Raiz = EliminarNodo(Raiz, valor);
        }

        private Nodo EliminarNodo(Nodo nodo, int valor)
        {
            if (nodo == null) return nodo;

            if (valor < nodo.Valor)
                nodo.Izquierda = EliminarNodo(nodo.Izquierda, valor);
            else if (valor > nodo.Valor)
                nodo.Derecha = EliminarNodo(nodo.Derecha, valor);
            else
            {
                if (nodo.Izquierda == null)
                    return nodo.Derecha;
                else if (nodo.Derecha == null)
                    return nodo.Izquierda;

                nodo.Valor = Minimo(nodo.Derecha);
                nodo.Derecha = EliminarNodo(nodo.Derecha, nodo.Valor);
            }

            return nodo;
        }

        public void Inorden(Nodo nodo)
        {
            if (nodo != null)
            {
                Inorden(nodo.Izquierda);
                Console.Write(nodo.Valor + " ");
                Inorden(nodo.Derecha);
            }
        }

        public void Preorden(Nodo nodo)
        {
            if (nodo != null)
            {
                Console.Write(nodo.Valor + " ");
                Preorden(nodo.Izquierda);
                Preorden(nodo.Derecha);
            }
        }

        public void Postorden(Nodo nodo)
        {
            if (nodo != null)
            {
                Postorden(nodo.Izquierda);
                Postorden(nodo.Derecha);
                Console.Write(nodo.Valor + " ");
            }
        }

        public int Minimo(Nodo nodo)
        {
            while (nodo.Izquierda != null)
                nodo = nodo.Izquierda;

            return nodo.Valor;
        }

        public int Maximo()
        {
            Nodo actual = Raiz;

            while (actual.Derecha != null)
                actual = actual.Derecha;

            return actual.Valor;
        }

        public int Altura(Nodo nodo)
        {
            if (nodo == null)
                return -1;

            int izquierda = Altura(nodo.Izquierda);
            int derecha = Altura(nodo.Derecha);

            return Math.Max(izquierda, derecha) + 1;
        }

        public void Limpiar()
        {
            Raiz = null;
        }
    }

    class Program
    {
        static void MostrarTitulo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("        🌳 SISTEMA ÁRBOL BINARIO BST 🌳      ");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        static void MostrarMenu()
        {
            Console.ForegroundColor = ConsoleColor.Magenta; // color cambiado a femenino
            Console.WriteLine("\n📋 MENÚ PRINCIPAL");
            Console.WriteLine("════════════════════════════════════");
            Console.WriteLine("1️⃣  Insertar valor");
            Console.WriteLine("2️⃣  Buscar valor");
            Console.WriteLine("3️⃣  Eliminar valor");
            Console.WriteLine("4️⃣  Recorrido INORDEN");
            Console.WriteLine("5️⃣  Recorrido PREORDEN");
            Console.WriteLine("6️⃣  Recorrido POSTORDEN");
            Console.WriteLine("7️⃣  Mostrar valor mínimo");
            Console.WriteLine("8️⃣  Mostrar valor máximo");
            Console.WriteLine("9️⃣  Mostrar altura del árbol");
            Console.WriteLine("🔟  Limpiar árbol");
            Console.WriteLine("0️⃣  Salir");
            Console.WriteLine("════════════════════════════════════");
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            ArbolBST arbol = new ArbolBST();
            int opcion;

            do
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0); // evita cuadros duplicados
                MostrarTitulo();
                MostrarMenu();

                Console.Write("👉 Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese valor: ");
                        int valorInsertar = int.Parse(Console.ReadLine());

                        if (arbol.Buscar(valorInsertar))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("🚫 El valor ya existe en el árbol.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            arbol.Insertar(valorInsertar);
                            Console.WriteLine("✅ Valor insertado correctamente.");
                            Console.ResetColor();
                        }
                        break;

                    case 2:
                        Console.Write("Ingrese valor a buscar: ");
                        int valorBuscar = int.Parse(Console.ReadLine());

                        if (arbol.Buscar(valorBuscar))
                            Console.WriteLine("🔎 Valor encontrado en el árbol.");
                        else
                            Console.WriteLine("❌ Valor no encontrado.");
                        break;

                    case 3:
                        Console.Write("Ingrese valor a eliminar: ");
                        int valorEliminar = int.Parse(Console.ReadLine());

                        if (arbol.Buscar(valorEliminar))
                        {
                            arbol.Eliminar(valorEliminar);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("🗑 Valor eliminado correctamente.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("⚠ El valor no existe en el árbol.");
                            Console.ResetColor();
                        }
                        break;

                    case 4:
                        Console.WriteLine("📊 Recorrido INORDEN:");
                        arbol.Inorden(arbol.Raiz);
                        break;

                    case 5:
                        Console.WriteLine("📊 Recorrido PREORDEN:");
                        arbol.Preorden(arbol.Raiz);
                        break;

                    case 6:
                        Console.WriteLine("📊 Recorrido POSTORDEN:");
                        arbol.Postorden(arbol.Raiz);
                        break;

                    case 7:
                        Console.WriteLine("🔹 Valor mínimo: " + arbol.Minimo(arbol.Raiz));
                        break;

                    case 8:
                        Console.WriteLine("🔹 Valor máximo: " + arbol.Maximo());
                        break;

                    case 9:
                        Console.WriteLine("📏 Altura del árbol: " + arbol.Altura(arbol.Raiz));
                        break;

                    case 10:
                        arbol.Limpiar();
                        Console.WriteLine("🧹 Árbol limpiado completamente.");
                        break;

                    case 0:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\n════════════════════════════════════");
                        Console.WriteLine("🍒 Gracias por usar este programa 🍒");
                        Console.WriteLine("👩‍💻 Atentamente: Programadora Acosta Paola");
                        Console.WriteLine("════════════════════════════════════");
                        Console.ResetColor();
                        break;

                    default:
                        Console.WriteLine("⚠ Opción inválida.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }
    }
}