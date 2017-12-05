using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    static public class CustomerRepository
    {
        static public List<Customer> GetAll()
        {
            List<Customer> customers;

            using (var context = new TestEntities())
            {
                customers = context.Customers.AsNoTracking().ToList();
            }
            return customers;
        }

        static public Customer GetCustomer(string id)
        {
            Customer customer;

            using (var context = new TestEntities())
            {
                customer = context.Customers.AsNoTracking().FirstOrDefault(c => c.CustomerID == id);
            }

            return customer;
        }

        static public void AddCustomer(Customer customer)
        {
            using (var context = new TestEntities())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        static public void UpdateCustomer(Customer c)
        {
            using (var context = new TestEntities())
            {
                var customer = context.Customers
                    .FirstOrDefault(t => t.CustomerID == t.CustomerID);

                customer.ContactName = c.ContactName;
                customer.CompanyName = c.CompanyName;
                customer.ContactTitle = c.ContactTitle;
                customer.Address = c.Address;
                customer.City = c.City;
                customer.Region = c.Region;
                customer.PostalCode = c.PostalCode;
                customer.Country = c.Country;
                customer.Phone = c.Phone;
                customer.Fax = c.Fax;

                context.Entry(customer).State = System.Data.Entity.EntityState.Modified;

                context.SaveChanges();
            }
        }

        static public string DeleteCustomer(string id)
        {
            using (var context = new TestEntities())
            {
                var customer = context.Customers
                    .FirstOrDefault(c => c.CustomerID == id);

                if (customer != null)
                {
                    try
                    {
                        context.Customers.Remove(customer);
                        context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        return "No se puede borrar el cliente por dependencias";
                    }

                    return "Cliente eliminado con exito!";
                }

                return "No existe el cliente";
            }
        }
    }
}
