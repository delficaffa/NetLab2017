using System;
using Servicios.DTO;
using System.Collections.Generic;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string opcion;
            do
            {
                Console.WriteLine("\nIngrese la opcion deseada:");
                Console.WriteLine("\t'C' - Create\n\t'R' - Read\n\t'U' - Update\n\t'D' - Delete\n\t'E' - Exit");
                opcion = Console.ReadLine();

                switch (opcion.ToLower())
                {
                    case "c":
                        MenuCreate();
                        break;

                    case "r":
                        MenuRead();
                        break;

                    case "u":
                        MenuEdit();
                        break;

                    case "d":
                        MenuDelete();
                        break;
                }
            } while (opcion != "e");

            Console.WriteLine("Fin del programa, ingrese una tecla para continuar");
            Console.ReadLine();

        }

        private static void MenuEdit()
        {
            var servicio = new Servicios.Consultas();
            Console.WriteLine("Ingrese el ID de la orden:");
            var id = int.Parse(Console.ReadLine());
            var ordenEditar = servicio.GetOrderID(id);


            //PEDIDO DE DATOS

            do
            {
                Console.Write("Ingrese el nombre del empleado: ");
                var nombre = Console.ReadLine();

                Console.Write("Ingrese el apellido del empleado: ");
                var apellido = Console.ReadLine();

                ordenEditar.EmployeeID = servicio.BuscarEmployeeID(nombre, apellido);

                if (ordenEditar.EmployeeID == 0)
                    Console.WriteLine("No existe ese empleado intentelo nuevamente.");
            } while (ordenEditar.EmployeeID == 0);


            ordenEditar.OrderDate = DateTime.Today;
            Console.Write("Ingrese la fecha en el siguiente formato dd-mm-yyyy: ");

            DateTime date;
            DateTime.TryParse(Console.ReadLine(), out date); //VALIDAR FORMATO DE LA FECHA!!!
            ordenEditar.RequiredDate = date;

            Console.Write("Ingrese el nombre del envío: ");
            ordenEditar.ShipName = Console.ReadLine();

            Console.Write("Ingrese la direccion de destino: ");
            ordenEditar.ShipAddress = Console.ReadLine();

            Console.Write("Ingrese la ciudad de destino: ");
            ordenEditar.ShipCity = Console.ReadLine();

            Console.Write("Ingrese la region de destino: ");
            ordenEditar.ShipRegion = Console.ReadLine();

            Console.Write("Ingrese el codigo postal de destino: ");
            ordenEditar.ShipPostalCode = Console.ReadLine();

            Console.Write("Ingrese el pais de destino: ");
            ordenEditar.ShipCountry = Console.ReadLine();
            
            servicio.Modificar(ordenEditar);

            
            Console.ReadLine();


        }

        private static void MenuDelete()
        {
            var servicio = new Servicios.Consultas();
            int idOrder;
            Console.WriteLine("Ingrese el ID de la orden a eliminar. ");
            int.TryParse(Console.ReadLine(), out idOrder);
            servicio.Eliminar(idOrder);

        }
        
        private static void MenuCreate()
        {
            var servicio = new Servicios.Consultas();
            var nuevaOrder = new OrderDTO();

            Console.WriteLine("DATOS DE PRUEBA:");//<----- BORRARRRRRRR
            Console.WriteLine("ALFKI - Davolio - Nancy - chai - tofu"); //<----- BORRARRRRRRR


            do
            {
                Console.Write("Ingrese el ID del cliente: ");
                var id = Console.ReadLine().ToUpper();

                if (servicio.BuscarCustomerID(id))
                {
                    nuevaOrder.CustomerID = id;
                }
                else
                {
                    Console.WriteLine($"No existe el cliente con el ID: {id}");
                }
            } while (nuevaOrder.CustomerID == null);

            
            do
            {
                Console.Write("Ingrese el nombre del empleado: ");
                var nombre = Console.ReadLine();

                Console.Write("Ingrese el apellido del empleado: ");
                var apellido = Console.ReadLine();

                nuevaOrder.EmployeeID = servicio.BuscarEmployeeID(nombre, apellido);

                if (nuevaOrder.EmployeeID == 0)
                    Console.WriteLine("No existe ese empleado intentelo nuevamente."); 
            } while (nuevaOrder.EmployeeID == 0);
            

            nuevaOrder.OrderDate = DateTime.Today;
            Console.Write("Ingrese la fecha en el siguiente formato dd-mm-yyyy: ");

            DateTime date;
            DateTime.TryParse(Console.ReadLine(), out date); //VALIDAR FORMATO DE LA FECHA!!!
            nuevaOrder.RequiredDate = date;

            Console.Write("Ingrese el nombre del envío: ");
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

            Console.WriteLine($"La Orden ID: {nuevaOrder.OrderID} con importe total $ {total} se ha creado correctamente.");//<-----DEVUELVE CERO!

            Console.ReadLine();





        }

        private static void MenuRead()
        {
            var servicio = new Servicios.Consultas();
            Console.WriteLine("ID FACTURA - NOMBRE CLIENTE - IMPORTE TOTAL");
            Console.WriteLine("------------------------------------------");
            var lista = servicio.Read();
            foreach (var item in lista)
            {
                Console.WriteLine($"{item.OrderID}\t{item.CustomerName}\t${servicio.GetOrderTotal(item.OrderID)}");
            }
        }
    }
}


