using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Business.Dtos;

namespace ConsoleApp
{
    class Program
    {

        static CustomerService service = new CustomerService();

        static void Main(string[] args)
        {

            var input = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Clientes C.R.U.D:");
                Console.WriteLine("C: Create, R: Read, U: Update, D: Delete, Q: Quit");
                input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "c":
                        CreateMenu();
                        break;
                    case "r":
                        ReadMenu();
                        break;
                    case "u":
                        UpdateMenu();
                        break;
                    case "d":
                        DeleteMenu();
                        break;
                    case "q":
                        break;
                    default:
                        Console.WriteLine("Error, comando invalida...");
                        break;
                }
            } while (input != "q");
        }

        static void CreateMenu()
        {
            var customer = new CustomerDto();
            var customerId = "";
            var customerCompany = "";

            do
            {
                Console.Write("Ingrese ID, 5 letras max: ");
                customerId = Console.ReadLine();
            } while (customerId == "" || customerId.Length > 5);

            customer.CustomerID = customerId;

            Console.Write("Ingrese nombre de contacto: ");
            customer.ContactName = Console.ReadLine();

            Console.Write("Ingrese titulo de contacto: ");
            customer.ContactName = Console.ReadLine();


            do
            {
                Console.Write("Ingrese nombre de compania: ");
                customerCompany = Console.ReadLine();
            } while (customerCompany == "");

            customer.CompanyName = customerCompany;

            Console.Write("Ingrese dirección: ");
            customer.Address = Console.ReadLine();

            Console.Write("Ingrese ciudad: ");
            customer.City = Console.ReadLine();

            Console.Write("Ingrese región: ");
            customer.Region = Console.ReadLine();

            Console.Write("Ingrese codigo postal: ");
            customer.PostalCode = Console.ReadLine();

            Console.Write("Ingrese país: ");
            customer.Country = Console.ReadLine();

            Console.Write("Ingrese fax: ");
            customer.Fax = Console.ReadLine();

            service.AddNewCustomer(customer);

            Console.WriteLine("Cliente creado con exito!");
            Console.Read();
        }

        static void ReadMenu()
        {
            Console.WriteLine("A: Mostrar todos, S: Mostrar uno, Q: volver atras:");
            var input = "";
            do
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "a":
                        var customers = service.ReadCustomers();
                        foreach (var c in customers)
                        {
                            Console.WriteLine($"ID: {c.CustomerID}");
                            Console.WriteLine($"Nombre:{c.ContactName}");
                            Console.WriteLine($"Compania: {c.CompanyName} ({c.ContactTitle})");
                            Console.WriteLine($"Dirección: {c.Address}, {c.City}({c.PostalCode}), {c.Country}");
                            Console.WriteLine($"Telefono: {c.Phone}, Fax: {c.Fax}");
                            Console.WriteLine();
                        }

                        Console.Read();
                        return;
                    case "s":
                        Console.Write("Ingrese ID del cliente: ");
                        var id = Console.ReadLine();
                        var customer = service.ReadCustomer(id);
                        if (customer != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"ID: {customer.CustomerID}");
                            Console.WriteLine($"Nombre:{customer.ContactName}");
                            Console.WriteLine($"Compania: {customer.CompanyName} ({customer.ContactTitle})");
                            Console.WriteLine($"Dirección: {customer.Address}, {customer.City}({customer.PostalCode}), {customer.Country}");
                            Console.WriteLine($"Telefono: {customer.Phone}, Fax: {customer.Fax}");
                        }
                        else
                            Console.WriteLine("No existe el cliente!");
                        Console.WriteLine();
                        Console.Read();
                        return;
                    case "q":
                        break;
                    default:
                        Console.WriteLine("Error, comando invalido...");
                        break;
                }
            } while (input != "q");
        }


        static void UpdateMenu()
        {
            Console.Write("Ingrese ID del cliente a editar: ");
            var id = Console.ReadLine();
            var data = service.ReadCustomer(id);

            if (data != null)
            {
                var customer = new CustomerDto();
                var customerCompany = "";

                customer.CustomerID = data.CustomerID;

                Console.Write("Ingrese nombre de contacto: ");
                customer.ContactName = Console.ReadLine();

                Console.Write("Ingrese titulo de contacto: ");
                customer.ContactName = Console.ReadLine();


                do
                {
                    Console.Write("Ingrese nombre de compania: ");
                    customerCompany = Console.ReadLine();
                } while (customerCompany == "");

                customer.CompanyName = customerCompany;

                Console.Write("Ingrese dirección: ");
                customer.Address = Console.ReadLine();

                Console.Write("Ingrese ciudad: ");
                customer.City = Console.ReadLine();

                Console.Write("Ingrese región: ");
                customer.Region = Console.ReadLine();

                Console.Write("Ingrese codigo postal: ");
                customer.PostalCode = Console.ReadLine();

                Console.Write("Ingrese país: ");
                customer.Country = Console.ReadLine();

                Console.Write("Ingrese fax: ");
                customer.Fax = Console.ReadLine();

                service.UpdateServiceCustomer(customer);

                Console.WriteLine("Cliente creado con exito!");

            }
            else
                Console.WriteLine("No existe el cliente!");
            Console.Read();
        }

        static void DeleteMenu()
        {
            Console.Write("Ingrese ID del cliente a borrar: ");
            var id = Console.ReadLine();

            var result = service.DeleteServiceCustomer(id);

            Console.WriteLine(result);
            Console.Read();
        }

    }
}
