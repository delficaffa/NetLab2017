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

        public int Agregar(OrderDTO orderDto)
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

            // var orderDetails = new List<Order_Details>();//
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

                order.Order_Details.Add(orderDetail);
            }

            orderRepository.Persist(order);
            orderRepository.SaveChanges();
            return order.OrderID;
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
                    Total = GetOrderTotal(order.OrderID)
                });
            }
            return list;

        }

        public void Eliminar(int id)
        {
            try
            {
                var deleteOrder = orderRepository.GetById(id);
                if (deleteOrder == null)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    var pais = deleteOrder.Customers.Country;
                    if (pais == "Mexico" || pais == "France")
                    {
                        Console.WriteLine("No se pueden eliminar ordenes de FRANCIA o MEXICO");

                    }
                    else
                    {
                        var DetailsRepo = new Repository<Order_Details>();
                        var orders = DetailsRepo.Set().Where(d => d.OrderID == deleteOrder.OrderID);

                        foreach (var detail in orders)
                        {
                            DetailsRepo.Remove(detail);
                        }
                        DetailsRepo.SaveChanges();
                        orderRepository.Remove(deleteOrder);
                        orderRepository.SaveChanges();
                        Console.WriteLine("Orden eliminada Correctamente");
                        Console.WriteLine("Presione enter para continuar");

                    }
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine($"No existe una orden con el ID: {id}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("No se pudo eliminar la orden..");
            }

        }

        public bool BuscarCustomerID(string id)
        {
            return orderRepository.GetById(id);

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

        public OrderDTO GetOrderID(int id)
        {
            return FillData(orderRepository.GetById(id));
        }

        public OrderDTO FillData(Orders order)
        {
            return new OrderDTO()
            {
                OrderID = order.OrderID,
                CustomerID = order.CustomerID,
                EmployeeID = order.EmployeeID,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry
            };
        }

        public Orders FillDataInvert(OrderDTO order)
        {
            var neworder = orderRepository.GetById(order.OrderID);

            neworder.OrderID = order.OrderID;
            neworder.CustomerID = order.CustomerID;
            neworder.EmployeeID = order.EmployeeID;
            neworder.OrderDate = order.OrderDate;
            neworder.RequiredDate = order.RequiredDate;
            neworder.ShipName = order.ShipName;
            neworder.ShipAddress = order.ShipAddress;
            neworder.ShipCity = order.ShipCity;
            neworder.ShipRegion = order.ShipRegion;
            neworder.ShipPostalCode = order.ShipPostalCode;
            neworder.ShipCountry = order.ShipCountry;
            return neworder;

        }

        public void Modificar(OrderDTO orderEdited)
        {
            this.orderRepository.Update(FillDataInvert(orderEdited));
            orderRepository.SaveChanges();

        }

        public List<MejorPorPaisDTO> ListarMejoresPorPais()
        {
            var mejoresXPais = new List<MejorPorPaisDTO>();
            var data = orderRepository.GetAll();

            foreach (var order in data)
            {
                mejoresXPais.Add(new MejorPorPaisDTO()
                {
                    Name = order.Customers.ContactName,
                    Country = order.Customers.Country,
                    Total = GetOrderTotal(order.OrderID)
                });
            }
            return SeleccionMejores(mejoresXPais);
        }

        public List<MejorPorPaisDTO> SeleccionMejores(List<MejorPorPaisDTO> all)
        {
            var clientesXPais = all
                .GroupBy(x => x.Country)
                .Select(x => new MejorPorPaisDTO
                {
                    Country = x.Key,
                    Name = x.OrderByDescending(e => e.Total).FirstOrDefault().Name,
                    Total = x.OrderByDescending(e => e.Total).FirstOrDefault().Total
                })
                .ToList();
            return clientesXPais;
        }

        public List<ProductoMasVendidoDTO> ProductosXPais()
        {
            var mejoresXPais = new List<ProductoMasVendidoDTO>();
            var data = orderRepository.GetAll();

            foreach (var order in data)
            {
                mejoresXPais.Add(new ProductoMasVendidoDTO()
                {
                    ProductName = order.Order_Details
                    .GroupBy(b => b.ProductID)
                    .OrderByDescending(t => t.Count())
                    .FirstOrDefault()
                    .Select(b => b.Products.ProductName)
                    .FirstOrDefault(),

                    Country = order.Customers.Country
                });
            }
            mejoresXPais.GroupBy(c => c.Country).ToList();
            return mejoresXPais;
        }

    }
}