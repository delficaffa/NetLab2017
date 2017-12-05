using System;
using Servicios.DTO;
using System.Collections.Generic;

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
                Console.WriteLine("\nIngrese la opcion deseada:");
                Console.WriteLine("\t'C' - Create\n\t'R' - Read\n\t'U' - Update\n\t'D' - Delete\n\t'E' - Exit");
                Console.WriteLine("ALFKI - Davolio - Nancy"); //<----- BORRARRRRRRR
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
                        //Eliminar las orderDetails sino no me la va a eliminar
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
            var nuevaOrder = new OrderDTO();

            var repeat = true;
            while (repeat)
            {
                try
                {

                    Console.Write("Ingrese el ID del cliente: ");
                    var id = Console.ReadLine().ToUpper();
                    servicio.BuscarkCustomerID(id);
                    nuevaOrder.CustomerID = id; //<-----------------------

                    var employeeID = 0;
                    do
                    {
                        Console.Write("Ingrese el nombre del empleado: ");
                        var nombre = Console.ReadLine();

                        Console.Write("Ingrese el apellido del empleado: ");
                        var apellido = Console.ReadLine();

                        employeeID = servicio.BuscarEmployeeID(nombre, apellido);

                        if (employeeID == 0)
                            Console.WriteLine("NOP.. OTRA VEZ"); //<-----------------------
                    } while (employeeID == 0);
                    nuevaOrder.EmployeeID = employeeID;

                    nuevaOrder.OrderDate = DateTime.Today;
                    Console.Write("Ingrese la fecha en el siguiente formato dd-mm-yyyy: ");

                    DateTime date;
                    DateTime.TryParse(Console.ReadLine(), out date); //TryParse es suficiente para verificar la fecha?..chan chan chaaaan
                    nuevaOrder.RequiredDate = date;

                    Console.Write("Ingrese el nombre del envío: ");//<----------- keh?!
                    nuevaOrder.ShipName = Console.ReadLine();

                    Console.Write("Ingrese la direccion de destino: ");
                    nuevaOrder.ShipAddress = Console.ReadLine();

                    Console.Write("Ingrese la ciudad de destino: ");
                    nuevaOrder.ShipCity = Console.ReadLine();

                    Console.Write("Ingrese la region de destino: ");
                    nuevaOrder.ShipRegion = Console.ReadLine();

                    Console.Write("Ingrese el codigo postal de destino: ");
                    nuevaOrder.ShipPostalCode = Console.ReadLine();

                    Console.Write("Ingrese el pais de destino: ");
                    nuevaOrder.ShipCountry = Console.ReadLine();
                    
                    //----------------- ORDER DETAIL
                    
                    nuevaOrder.OrderDetail = new List<OrderDetailDTO>();
                    string opcion;
                    do
                    {
                        Console.WriteLine("Ingrese 'A' para agregar un producto o 'S' para Salir");
                        opcion = Console.ReadLine().ToLower();

                        if (opcion == "a")
                        {
                            var orderDetail = new OrderDetailDTO();
                            orderDetail.OrderID = nuevaOrder.OrderID;
                            do
                            {
                                Console.Write("Ingrese el nombre del producto: ");
                                var nombreProducto = Console.ReadLine();

                                var productID = servicio.GetProductID(nombreProducto);

                                if (productID == 0)
                                    Console.WriteLine("No existe ese producto");
                                else
                                    orderDetail.ProductID = productID;

                            } while (orderDetail.ProductID == 0);

                            orderDetail.UnitPrice = servicio.GetProductPrice(orderDetail.ProductID);

                            do
                            {
                                Console.Write("Ingrese la cantidad: ");
                                short quantity;
                                short.TryParse(Console.ReadLine(), out quantity);
                                orderDetail.Quantity = quantity;

                            } while (orderDetail.Quantity <= 0);

                            do
                            {
                                Console.Write("Ingrese el descuento (entre 0 y 30): ");
                                float discount;
                                float.TryParse(Console.ReadLine(), out discount);
                                orderDetail.Discount = discount / 100;

                            } while (orderDetail.Discount < 0 || orderDetail.Discount > 30);

                            nuevaOrder.OrderDetail.Add(orderDetail);
                        }

                    } while (opcion != "s");

                    nuevaOrder.OrderID = servicio.Agregar(nuevaOrder);
                    
                    var total = servicio.GetOrderTotal(nuevaOrder.OrderID);

                    Console.WriteLine($"La Orden ID: {nuevaOrder.OrderID} con importe total ${total} se ha creado correctamente.");

                    Console.Read();


                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Error catastrofico!");

                }
                Console.WriteLine("Desea volver a intentarlo? S/N");
                string go = Console.ReadLine();
                repeat = go.ToLower() == "s";

            }

        }
    }
}


