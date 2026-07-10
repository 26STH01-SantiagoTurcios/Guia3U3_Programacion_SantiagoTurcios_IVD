using System;

namespace ControlInventario
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] inventario = new string[10, 3];
            int opcion = 0;

            while (opcion != 5)
            {
                Console.WriteLine("\n----- MENÚ -----");
                Console.WriteLine("1. Registrar producto");
                Console.WriteLine("2. Mostrar productos");
                Console.WriteLine("3. Actualizar producto");
                Console.WriteLine("4. Eliminar producto");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            bool registrado = false;
                            for (int i = 0; i < 10; i++)
                            {
                                if (string.IsNullOrEmpty(inventario[i, 0]))
                                {
                                    Console.Write("Ingrese el código del producto: ");
                                    inventario[i, 0] = Console.ReadLine();

                                    Console.Write("Ingrese el nombre del producto: ");
                                    inventario[i, 1] = Console.ReadLine();

                                    Console.Write("Ingrese la cantidad en existencia: ");
                                    inventario[i, 2] = Console.ReadLine();

                                    Console.WriteLine("¡Producto registrado con éxito!");
                                    registrado = true;
                                    break;
                                }
                            }

                            if (!registrado)
                            {
                                Console.WriteLine("El inventario está lleno. No se pueden registrar más productos.");
                            }
                            break;

                        case 2:
                            Console.WriteLine("\n--- Lista de Productos ---");
                            bool hayProductos = false;
                            for (int i = 0; i < 10; i++)
                            {
                                if (!string.IsNullOrEmpty(inventario[i, 0]))
                                {
                                    Console.WriteLine($"Código: {inventario[i, 0]} | Nombre: {inventario[i, 1]} | Cantidad: {inventario[i, 2]}");
                                    hayProductos = true;
                                }
                            }

                            if (!hayProductos)
                            {
                                Console.WriteLine("No hay productos registrados en el inventario.");
                            }
                            break;

                        case 3:
                            Console.Write("\nIngrese el código del producto a actualizar: ");
                            string codigoBusqueda = Console.ReadLine();
                            bool encontradoActualizar = false;

                            for (int i = 0; i < 10; i++)
                            {
                                if (inventario[i, 0] == codigoBusqueda)
                                {
                                    Console.Write("Ingrese el nuevo nombre del producto: ");
                                    inventario[i, 1] = Console.ReadLine();

                                    Console.Write("Ingrese la nueva cantidad en existencia: ");
                                    inventario[i, 2] = Console.ReadLine();

                                    Console.WriteLine("¡Producto actualizado correctamente!");
                                    encontradoActualizar = true;
                                    break;
                                }
                            }

                            if (!encontradoActualizar)
                            {
                                Console.WriteLine("Producto no encontrado.");
                            }
                            break;

                        case 4:
                            Console.Write("\nIngrese el código del producto a eliminar: ");
                            string codigoEliminar = Console.ReadLine();
                            bool encontradoEliminar = false;

                            for (int i = 0; i < 10; i++)
                            {
                                if (inventario[i, 0] == codigoEliminar)
                                {
                                    inventario[i, 0] = null;
                                    inventario[i, 1] = null;
                                    inventario[i, 2] = null;

                                    Console.WriteLine("¡Producto eliminado exitosamente!");
                                    encontradoEliminar = true;
                                    break;
                                }
                            }

                            if (!encontradoEliminar)
                            {
                                Console.WriteLine("Producto no encontrado.");
                            }
                            break;

                        case 5:
                            Console.WriteLine("Saliendo del sistema...");
                            break;

                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                }
            }
        }
    }
}