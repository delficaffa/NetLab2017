using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
   public static class CustomerRepository
    {
        public static List<Customer> GetAll()
        {
            using (var context = new NORTHWINDEntities())
            {
                return context.Customers.AsNoTracking().ToList();
            }
        }

        public static void Remove(string id)
        {
            using (var context = new NORTHWINDEntities())
            {
                context.Customers.Remove(context.Customers.Where(x=>x.CustomerID==id).FirstOrDefault());
                context.SaveChanges();
            }
        }

        public static void Edit(string id)
        {
            using (var context = new NORTHWINDEntities())
            {
                var editar=context.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
                editar.ContactName ="CustomerEditado";
                context.SaveChanges();
            }
        }

        public static void Add(string id)
        {
            using (var context = new NORTHWINDEntities())
            {
                
                context.Customers.Add(new Customer { });
                context.SaveChanges();
            }
        }
    }
}
