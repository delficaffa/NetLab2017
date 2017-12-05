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
            //ViewBag.Title = "Clients C.R.U.D.";
            return View();
        }

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

        public ActionResult Read()
        {
            return View(service.ReadCustomers());
        }

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Delete(string customerID)
        {
            service.DeleteServiceCustomer(customerID);
            return View("read", service.ReadCustomers());
        }

    }
}