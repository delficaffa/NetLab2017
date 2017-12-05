using Business.Dtos;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CustomerService
    {

        public List<CustomerDto> ReadCustomers()
        {
            List<CustomerDto> customers = new List<CustomerDto>();
            foreach (var c in CustomerRepository.GetAll())
            {
                var customer = new CustomerDto
                {
                    CustomerID = c.CustomerID,
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName,
                    ContactTitle = c.ContactTitle,
                    Address = c.Address,
                    City = c.City,
                    Region = c.Region,
                    PostalCode = c.PostalCode,
                    Country = c.Country,
                    Phone = c.Phone,
                    Fax = c.Fax
                };

                customers.Add(customer);
            }
            return customers;
        }

        public CustomerDto ReadCustomer(string id)
        {
            var c = CustomerRepository.GetCustomer(id);
            CustomerDto customer = null;

            if (c != null)
                customer = new CustomerDto
                {
                    CustomerID = c.CustomerID,
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName,
                    ContactTitle = c.ContactTitle,
                    Address = c.Address,
                    City = c.City,
                    Region = c.Region,
                    PostalCode = c.PostalCode,
                    Country = c.Country,
                    Phone = c.Phone,
                    Fax = c.Fax
                };

            return customer;
        }

        public void AddNewCustomer(CustomerDto c)
        {
            var customer = new Customer()
            {
                CustomerID = c.CustomerID,
                CompanyName = c.CompanyName,
                ContactName = c.ContactName,
                ContactTitle = c.ContactTitle,
                Address = c.Address,
                City = c.City,
                Region = c.Region,
                PostalCode = c.PostalCode,
                Country = c.Country,
                Phone = c.Phone,
                Fax = c.Fax
            };

            CustomerRepository.AddCustomer(customer);
        }

        public void UpdateServiceCustomer(CustomerDto c)
        {
            var customer = new Customer
            {
                CustomerID = c.CustomerID,
                ContactName = c.ContactName,
                CompanyName = c.CompanyName,
                ContactTitle = c.ContactTitle,
                Address = c.Address,
                City = c.City,
                Region = c.Region,
                PostalCode = c.PostalCode,
                Country = c.Country,
                Phone = c.Phone,
                Fax = c.Fax
            };

            CustomerRepository.UpdateCustomer(customer);

        }

        public string DeleteServiceCustomer(string id)
        {
            return CustomerRepository.DeleteCustomer(id);
        }
    }
}
