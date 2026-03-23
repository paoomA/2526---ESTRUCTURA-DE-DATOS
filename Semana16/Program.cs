using System;
using System.Drawing;
using System.Drawing.Imaging;

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
            if (nodo == null) return false;
            if (valor == nodo.Valor) return true;
            if (valor < nodo.Valor) return BuscarNodo(nodo.Izquierda, valor);
            return BuscarNodo(nodo.Derecha, valor);
        }

        public void Eliminar(int valor)
        {
            Raiz = EliminarNodo(Raiz, valor);
        }

        private Nodo EliminarNodo(Nodo nodo, int valor)
        {
            if (nodo == null) return nodo;

            if (valor < nodo.Valor) nodo.Izquierda = EliminarNodo(nodo.Izquierda, valor);
            else if (valor > nodo.Valor) nodo.Derecha = EliminarNodo(nodo.Derecha, valor);
            else
            {
                if (nodo.Izquierda == null) return nodo.Derecha;
                if (nodo.Derecha == null) return nodo.Izquierda;

                int minValor = Minimo(nodo.Derecha);
                nodo.Valor = minValor;
                nodo.Derecha = EliminarNodo(nodo.Derecha, minValor);
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
            while (nodo.Izquierda != null) nodo = nodo.Izquierda;
            return nodo.Valor;
        }

        public int Maximo()
        {
            Nodo actual = Raiz;
            while (actual.Derecha != null) actual = actual.Derecha;
            return actual.Valor;
        }

        public int Altura(Nodo nodo)
        {
            if (nodo == null) return -1;
            int izquierda = Altura(nodo.Izquierda);
            int derecha = Altura(nodo.Derecha);
            return Math.Max(izquierda, derecha) + 1;
        }

        public void Limpiar()
        {
            Raiz = null;
        }

        // Método para generar imagen PNG del árbol
        public void GenerarImagen(string nombreArchivo)
        {
            if (Raiz == null)
            {
                Console.WriteLine("El árbol está vacío, no se puede generar imagen.");
                return;
            }

            int ancho = 800;
            int alto = 600;

            using (Bitmap bmp = new Bitmap(ancho, alto))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                DibujarNodo(g, Raiz, ancho / 2, 50, 200);
                bmp.Save(nombreArchivo, ImageFormat.Png);
            }

            Console.WriteLine($"✅ Imagen generada: {nombreArchivo}");
        }

        private void DibujarNodo(Graphics g, Nodo nodo, int x, int y, int offset)
        {
            if (nodo == null) return;

            int radio = 20;

            if (nodo.Izquierda != null)
            {
                g.DrawLine(Pens.Black, x, y, x - offset, y + 80);
                DibujarNodo(g, nodo.Izquierda, x - offset, y + 80, offset / 2);
            }
            if (nodo.Derecha != null)
            {
                g.DrawLine(Pens.Black, x, y, x + offset, y + 80);
                DibujarNodo(g, nodo.Derecha, x + offset, y + 80, offset / 2);
            }

            g.FillEllipse(Brushes.LightBlue, x - radio, y - radio, radio * 2, radio * 2);
            g.DrawEllipse(Pens.Black, x - radio, y - radio, radio * 2, radio * 2);
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Center;
            g.DrawString(nodo.Valor.ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, x, y, formato);
        }
    }

    class Program
    {
        static void MostrarMenu()
        {
            Console.Clear();

            // Título con cuadro
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║      🌟 SISTEMA ÁRBOL BINARIO BST 🌟      ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.ResetColor();

            // Opciones con cuadro
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║ 1️⃣  Insertar valor                       ║");
            Console.WriteLine("║ 2️⃣  Buscar valor 🔍                      ║");
            Console.WriteLine("║ 3️⃣  Eliminar valor 🗑                    ║");
            Console.WriteLine("║ 4️⃣  Recorrido INORDEN 📊                ║");
            Console.WriteLine("║ 5️⃣  Recorrido PREORDEN 📊               ║");
            Console.WriteLine("║ 6️⃣  Recorrido POSTORDEN 📊              ║");
            Console.WriteLine("║ 7️⃣  Mostrar valor mínimo 🔹             ║");
            Console.WriteLine("║ 8️⃣  Mostrar valor máximo 🔹             ║");
            Console.WriteLine("║ 9️⃣  Mostrar altura del árbol 📏         ║");
            Console.WriteLine("║ 1️0️⃣ Limpiar árbol 🧹                     ║");
            Console.WriteLine("║ 1️1️⃣ Generar imagen PNG 🌳               ║");
            Console.WriteLine("║ 0️⃣  Salir 🚪                             ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            ArbolBST arbol = new ArbolBST();
            int opcion;

            do
            {
                MostrarMenu();
                Console.Write("\nSeleccione opción: ");
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("⚠ Opción inválida, ingrese un número.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese valor a insertar: ");
                        if (int.TryParse(Console.ReadLine(), out int valorInsertar))
                        {
                            if (arbol.Buscar(valorInsertar))
                                Console.WriteLine("🚫 El valor ya existe.");
                            else
                            {
                                arbol.Insertar(valorInsertar);
                                Console.WriteLine("✅ Valor insertado correctamente.");
                            }
                        }
                        break;

                    case 2:
                        Console.Write("Ingrese valor a buscar: ");
                        if (int.TryParse(Console.ReadLine(), out int valorBuscar))
                        {
                            if (arbol.Buscar(valorBuscar))
                                Console.WriteLine("🔎 Valor encontrado.");
                            else
                                Console.WriteLine("❌ Valor no encontrado.");
                        }
                        break;

                    case 3:
                        Console.Write("Ingrese valor a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int valorEliminar))
                        {
                            if (arbol.Buscar(valorEliminar))
                            {
                                arbol.Eliminar(valorEliminar);
                                Console.WriteLine("🗑 Valor eliminado.");
                            }
                            else
                                Console.WriteLine("⚠ El valor no existe.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("📊 Recorrido INORDEN:");
                        arbol.Inorden(arbol.Raiz);
                        Console.WriteLine();
                        break;

                    case 5:
                        Console.WriteLine("📊 Recorrido PREORDEN:");
                        arbol.Preorden(arbol.Raiz);
                        Console.WriteLine();
                        break;

                    case 6:
                        Console.WriteLine("📊 Recorrido POSTORDEN:");
                        arbol.Postorden(arbol.Raiz);
                        Console.WriteLine();
                        break;

                    case 7:
                        if (arbol.Raiz != null)
                            Console.WriteLine("🔹 Valor mínimo: " + arbol.Minimo(arbol.Raiz));
                        else
                            Console.WriteLine("⚠ Árbol vacío.");
                        break;

                    case 8:
                        if (arbol.Raiz != null)
                            Console.WriteLine("🔹 Valor máximo: " + arbol.Maximo());
                        else
                            Console.WriteLine("⚠ Árbol vacío.");
                        break;

                    case 9:
                        Console.WriteLine("📏 Altura del árbol: " + arbol.Altura(arbol.Raiz));
                        break;

                    case 10:
                        arbol.Limpiar();
                        Console.WriteLine("🧹 Árbol limpiado correctamente.");
                        break;

                    case 11:
                        Console.Write("Ingrese nombre del archivo PNG (ejemplo: arbol.png): ");
                        string nombreArchivo = Console.ReadLine();
                        if (string.IsNullOrEmpty(nombreArchivo))
                            nombreArchivo = "arbol.png";
                        arbol.GenerarImagen(nombreArchivo);
                        break;

                    case 0:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\n════════════════════════════════════");
                        Console.WriteLine("🍒 Gracias por usar el sistema 🍒");
                        Console.WriteLine("💡 Sigue aprendiendo estructuras de datos");
                        Console.WriteLine("👩‍💻 Programadoras: Acosta y Cabrera");
                        Console.WriteLine("════════════════════════════════════");
                        Console.ResetColor();
                        break;

                    default:
                        Console.WriteLine("⚠ Opción inválida.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }
    }
}