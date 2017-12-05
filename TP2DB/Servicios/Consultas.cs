using DataAccess;
using Servicios.DTO;
using System;
using System.Collections;
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

      
        public void Agregar(OrderDTO orderDto)
        {
            var order = new Orders()
            {
                EmployeeID = orderDto.EmployeeID,
                OrderDate = orderDto.OrderDate,
                RequiredDate = orderDto.RequiredDate,
                ShipName = orderDto.ShipName,
                ShipAddress = orderDto.ShipAddress,
                ShipCity = orderDto.ShipCity,
                ShipRegion = orderDto.ShipRegion,
                ShipPostalCode = orderDto.ShipPostalCode,
                ShipCountry = orderDto.ShipCountry
                
            };

            var orderDetails = new List<Order_Details>();
            var orderDetailsDTO = orderDto.OrderDetail;
            foreach (var detail in orderDetailsDTO)
            {
                var orderDetail = new Order_Details()
                {
                    OrderID = detail.OrderID,
                    ProductID = detail.ProductID,
                    UnitPrice = detail.UnitPrice,
                    Quantity = detail.Quantity,
                    Discount = detail.Discount
                };

                orderDetails.Add(orderDetail);
            }
          
            orderRepository.Persist(order);
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

        public void BuscarkCustomerID(string id)
        {
             orderRepository.GetById(id); 
        }

        public int BuscarEmployeeID(string n, string a)
        {
            return orderRepository.GetEmployeeID(n, a);

        }

        public int GetProductID(string nombre)
        {
            return orderRepository.GetByName(nombre);
        }

        public decimal GetProductPrice(int id)
        {
            return orderRepository.GetPrice(id);
        }
        public decimal GetOrderTotal(int id)
        {
            return orderRepository.GetTotal(id);
        }

        



        //public OrderDTO PartialModificar(int id)
        //{
        //    var orderToEdit = orderRepository.GetById(id);
        //    var orderEdited = new OrderDTO()
        //    {
        //        OrderID = orderToEdit.OrderID,
        //        CustomerID = orderToEdit.CustomerID,
        //        EmployeeID = orderToEdit.EmployeeID,
        //        OrderDate = orderToEdit.OrderDate,
        //        RequiredDate = orderToEdit.RequiredDate,
        //        ShipName = orderToEdit.ShipName,
        //        ShipAddress = orderToEdit.ShipAddress,
        //        ShipCity = orderToEdit.ShipCity,
        //        ShipRegion = orderToEdit.ShipRegion,
        //        ShipPostalCode = orderToEdit.ShipPostalCode,
        //        ShipCountry = orderToEdit.ShipCountry
        //    };
        //    return orderEdited;

        //}

        //public void Modificar(OrderDTO orderEdited)
        //{
        //    var newOrder = new Orders()
        //    {
        //        OrderID = orderEdited.OrderID,
        //        CustomerID = orderEdited.CustomerID,
        //        EmployeeID = orderEdited.EmployeeID,
        //        OrderDate = orderEdited.OrderDate,
        //        RequiredDate = orderEdited.RequiredDate,
        //        ShipName = orderEdited.ShipName,
        //        ShipAddress = orderEdited.ShipAddress,
        //        ShipCity = orderEdited.ShipCity,
        //        ShipRegion = orderEdited.ShipRegion,
        //        ShipPostalCode = orderEdited.ShipPostalCode,
        //        ShipCountry = orderEdited.ShipCountry
        //    };

        //    orderRepository.Update(newOrder);
        //    orderRepository.SaveChanges();

        //}



    }
}
