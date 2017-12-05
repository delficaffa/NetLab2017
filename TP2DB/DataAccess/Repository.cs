using System;
using System.Collections.Generic;
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

        public T Persist(T entity)
        {
            return _context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public T Update(T entity)
        {
            _context.Entry<T>(entity);

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

        // A LA MIERCOLE LO GENERICO
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

        public decimal GetTotal(int id) //<<------- NO ANDA....
        {
            var total = 0m;
            total = _context.Orders
                    .FirstOrDefault(c => c.OrderID == id)
                    .Order_Details
                    .Sum(c => (c.UnitPrice * c.Quantity) - ((c.UnitPrice * c.Quantity) * (decimal)c.Discount));
            return total;
        }

        public Customers GetById(string id)
        {
            return _context.Customers.Find(id);
        }

        public int GetEmployeeID(string name, string surname)
        {
            var employeeID = 0;
            employeeID = _context.Employees
                    .FirstOrDefault(e => e.FirstName == name && e.LastName == surname)
                    .EmployeeID;

            return employeeID;

        }
    }
}


