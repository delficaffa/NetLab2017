using Business;
using Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    
    public class HomeController : Controller
    {
        static CustomerService service = new CustomerService();

        public ActionResult Index()
        {
           return View();
        }
        // ---------- UPDATE
        public ActionResult Update(string customerId)
        {
            var customer = service.ReadCustomer(customerId);
            return View(customer);
        }
       
        [HttpPost]
        public ActionResult Update(CustomerDto customer)
        {
            service.UpdateServiceCustomer(customer);
            return View("read", service.ReadCustomers());
        }

        // ---------- CREATE
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerDto customer)
        {
            service.AddNewCustomer(customer);
            return View("read", service.ReadCustomers());
        }

        // ---------- READ
        public ActionResult Read()
        {
            return View(service.ReadCustomers());
        }

        // ---------- DELETE
        public ActionResult Delete(string customerID)
        {
            service.DeleteServiceCustomer(customerID);
            return View("read", service.ReadCustomers());
        }

    }
}