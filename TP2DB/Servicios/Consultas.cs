using DataAccess;
using Servicios.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicios
{
    public class Consultas
    {
        private Repository<Orders> orderRepository;

        public Consultas()
        {
            orderRepository = new Repository<Orders>();
        }


        public void Agregar(OrderDTO order)
        {
            var newOrder = new Orders()
            {
                OrderID = order.OrderID,
                CustomerID = order.CustomerID,
                Customers = order.Customers,
                EmployeeID = order.EmployeeID,
                Employees = order.Employees,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                ShipVia = order.ShipVia,
                Freight = order.Freight,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry,
                Order_Details = order.Order_Details
            };

            orderRepository.Persist(newOrder);
            orderRepository.SaveChanges();

        }

        public List<OrderGetDTO> Read()
        {
            var list = new List<OrderGetDTO>();
            var data = orderRepository.GetAll();

            foreach (var order in data)
            {
                list.Add(new OrderGetDTO()
                {
                    OrderID = order.OrderID,
                    CustomerName = order.Customers.ContactName,
                    Freight = order.Freight
                });
            }

            return list;
        }

        public void Eliminar(int id)
        {
            var deleteOrder = orderRepository.GetById(id);
            var pais = deleteOrder.Customers.Country;
            if (pais == "Mexico" || pais == "France")
            {
                Console.WriteLine("No se puede eliminar esta orden");
            }
            else
            {
                orderRepository.Remove(deleteOrder);
                Console.WriteLine("Orden eliminada Correctamente");
                orderRepository.SaveChanges();
            }
        }


        public OrderDTO PartialModificar(int id)
        {
            var orderToEdit = orderRepository.GetById(id);
            var orderEdited = new OrderDTO()
            {
                OrderID = orderToEdit.OrderID,
                CustomerID = orderToEdit.CustomerID,
                Customers = orderToEdit.Customers,
                EmployeeID = orderToEdit.EmployeeID,
                Employees = orderToEdit.Employees,
                OrderDate = orderToEdit.OrderDate,
                RequiredDate = orderToEdit.RequiredDate,
                ShippedDate = orderToEdit.ShippedDate,
                ShipVia = orderToEdit.ShipVia,
                Freight = orderToEdit.Freight,
                ShipName = orderToEdit.ShipName,
                ShipAddress = orderToEdit.ShipAddress,
                ShipCity = orderToEdit.ShipCity,
                ShipRegion = orderToEdit.ShipRegion,
                ShipPostalCode = orderToEdit.ShipPostalCode,
                ShipCountry = orderToEdit.ShipCountry,
                Order_Details = orderToEdit.Order_Details
            };
            return orderEdited;

        }
        
        public void Modificar(OrderDTO orderEdited)
        {
            var newOrder = new Orders()
            {
                OrderID = orderEdited.OrderID,
                CustomerID = orderEdited.CustomerID,
                Customers = orderEdited.Customers,
                EmployeeID = orderEdited.EmployeeID,
                Employees = orderEdited.Employees,
                OrderDate = orderEdited.OrderDate,
                RequiredDate = orderEdited.RequiredDate,
                ShippedDate = orderEdited.ShippedDate,
                ShipVia = orderEdited.ShipVia,
                Freight = orderEdited.Freight,
                ShipName = orderEdited.ShipName,
                ShipAddress = orderEdited.ShipAddress,
                ShipCity = orderEdited.ShipCity,
                ShipRegion = orderEdited.ShipRegion,
                ShipPostalCode = orderEdited.ShipPostalCode,
                ShipCountry = orderEdited.ShipCountry,
                Order_Details = orderEdited.Order_Details
            };
            
            orderRepository.Update(newOrder);
            orderRepository.SaveChanges();

        }

      
       
    }
}
