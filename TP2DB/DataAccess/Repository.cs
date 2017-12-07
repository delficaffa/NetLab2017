using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Repository<T>
        where T : class
    {
        private DataBase _context;

        public Repository()
        {
            _context = new DataBase();
        }

        public void Persist(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Added;
        }

        public void Remove(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Deleted;
        }

        public T Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;

            return entity;
        }

        public IQueryable<T> Set()
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id); 
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
       
        public int GetByName(string nombre)
        {
            int id;
            return id = _context.Products
                    .FirstOrDefault(c => c.ProductName == nombre)
                    .ProductID;
        }

        public decimal GetPrice(int id)
        {
            var price = 0m;
            return price = _context.Products
                    .FirstOrDefault(c => c.ProductID == id)
                    .UnitPrice.GetValueOrDefault();
        }

        public decimal GetTotal(int id) 
        {
            var total = 0m;
            total = _context.Orders
                    .FirstOrDefault(t => t.OrderID == id)
                    .Order_Details
                    .Sum(t => (t.UnitPrice * t.Quantity) - ((t.UnitPrice * t.Quantity) * (decimal)t.Discount));
            return total;
        }

        public bool GetById(string id)
        {
            return _context.Customers.Find(id) != null;
        }

        public int GetEmployeeID(string name, string surname)
        {
            try
            {
                var employeeID = 0;
                employeeID = _context.Employees
                        .FirstOrDefault(e => e.FirstName == name && e.LastName == surname)
                        .EmployeeID;

                return employeeID;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("No existe ese empleado.");
            }

            return 0;
        }
    }
}


