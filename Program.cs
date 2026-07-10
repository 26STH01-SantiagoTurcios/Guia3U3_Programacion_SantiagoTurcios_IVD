using System;

namespace RegistroParqueo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] parqueo = new string[10, 3];
            int opcion = 0;

            while (opcion != 5)
            {
                Console.WriteLine("\n----- MENÚ -----");
                Console.WriteLine("1. Registrar vehículo");
                Console.WriteLine("2. Mostrar vehículos");
                Console.WriteLine("3. Actualizar vehículo");
                Console.WriteLine("4. Eliminar vehículo");
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
                                if (string.IsNullOrEmpty(parqueo[i, 0]))
                                {
                                    Console.Write("Ingrese la placa: ");
                                    parqueo[i, 0] = Console.ReadLine();
                                    Console.Write("Ingrese el propietario: ");
                                    parqueo[i, 1] = Console.ReadLine();
                                    Console.Write("Ingrese la marca: ");
                                    parqueo[i, 2] = Console.ReadLine();
                                    Console.WriteLine("¡Vehículo registrado!");
                                    registrado = true;
                                    break;
                                }
                            }
                            if (!registrado) Console.WriteLine("El parqueo está lleno.");
                            break;

                        case 2:
                            Console.WriteLine("\n--- Vehículos Registrados ---");
                            bool hayVehiculos = false;
                            for (int i = 0; i < 10; i++)
                            {
                                if (!string.IsNullOrEmpty(parqueo[i, 0]))
                                {
                                    Console.WriteLine($"Placa: {parqueo[i, 0]} | Propietario: {parqueo[i, 1]} | Marca: {parqueo[i, 2]}");
                                    hayVehiculos = true;
                                }
                            }
                            if (!hayVehiculos) Console.WriteLine("No hay vehículos en el parqueo.");
                            break;

                        case 3:
                            Console.Write("\nIngrese la placa del vehículo a actualizar: ");
                            string placaBuscar = Console.ReadLine();
                            bool encontradoAct = false;
                            for (int i = 0; i < 10; i++)
                            {
                                if (parqueo[i, 0] == placaBuscar)
                                {
                                    Console.Write("Ingrese el nuevo propietario: ");
                                    parqueo[i, 1] = Console.ReadLine();
                                    Console.Write("Ingrese la nueva marca: ");
                                    parqueo[i, 2] = Console.ReadLine();
                                    Console.WriteLine("¡Registro actualizado!");
                                    encontradoAct = true;
                                    break;
                                }
                            }
                            if (!encontradoAct) Console.WriteLine("Vehículo no encontrado.");
                            break;

                        case 4:
                            Console.Write("\nIngrese la placa del vehículo a eliminar: ");
                            string placaEliminar = Console.ReadLine();
                            bool encontradoElim = false;
                            for (int i = 0; i < 10; i++)
                            {
                                if (parqueo[i, 0] == placaEliminar)
                                {
                                    parqueo[i, 0] = null;
                                    parqueo[i, 1] = null;
                                    parqueo[i, 2] = null;
                                    Console.WriteLine("¡Vehículo eliminado (salida)! ");
                                    encontradoElim = true;
                                    break;
                                }
                            }
                            if (!encontradoElim) Console.WriteLine("Vehículo no encontrado.");
                            break;

                        case 5:
                            Console.WriteLine("Saliendo del sistema...");
                            break;

                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese un número válido.");
                }
            }
        }
    }
}