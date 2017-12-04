using DataAccess;
using System;
using System.Collections.Generic;

namespace Servicios.DTO
{
   public class OrderDTO
    {
        //blic int OrderID { get; set; }

        public string CustomerID { get; set; }

        public int? EmployeeID { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

       //public DateTime? ShippedDate { get; set; }

        //public int? ShipVia { get; set; }

       // public decimal? Freight { get; set; }

        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipRegion { get; set; }

        public string ShipPostalCode { get; set; }

        public string ShipCountry { get; set; }

        // public virtual Customers Customers { get; set; }

        //public virtual Employees Employees { get; set; }

        // public virtual ICollection<Order_Details> Order_Details { get; set; }

        // public virtual Shippers Shippers { get; set; }

       //-----> public ICollection<OrderDetailDto> OrderDetailDtos { get; set; }
    }
}