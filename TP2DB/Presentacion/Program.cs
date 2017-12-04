using System;
using Servicios;
using Servicios.DTO;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            var servicio = new Servicios.Consultas();
            string opcion;
            do
            {
                Console.WriteLine("\nIngrese la opcion deseada");
                Console.WriteLine("\t'C' - Create\n\t'R' - Read\n\t'U' - Update\n\t'D' - Delete\n\t'E' - Exit");
                opcion = Console.ReadLine();

                switch (opcion.ToLower())
                {
                    case "c":
                        MenuCreate();
                        break;

                    case "r":
                        Console.WriteLine("ID FACTURA - NOMBRE CLIENTE - IMPORTE TOTAL");
                        Console.WriteLine("------------------------------------------");
                        var lista = servicio.Read();
                        foreach (var item in lista)
                        {
                            Console.WriteLine($"{item.OrderID}\t{item.CustomerName}\t${item.Freight}");
                        }

                        break;

                    case "u":
                        
                        break;

                    case "d":
                        int id;
                        Console.WriteLine("Ingrese el ID de la orden a eliminar. ");
                        int.TryParse(Console.ReadLine(), out id);
                        servicio.Eliminar(id);

                        break;
                }
            } while (opcion != "e");

            Console.WriteLine("Fin del programa, ingrese una tecla para continuar");
            Console.ReadLine();



        }

        private static void MenuCreate()
        {
            var servicio = new Servicios.Consultas();
            var nuevaOrden = new OrderDTO();

            Console.WriteLine("Ingrese el ID de la orden");
            var idOrder = nuevaOrden.OrderID;
            int.TryParse(Console.ReadLine(), out idOrder);

            Console.WriteLine("Ingrese el id del cliente");
            nuevaOrden.CustomerID = Console.ReadLine();

            servicio.Agregar(nuevaOrden);
            //TODOS LOS DEMAS DATOS ...
        }
       

       
    }
}
    

