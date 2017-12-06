using Services;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerServices _customerServices;

        public CustomerController()
        {
            _customerServices = new CustomerServices();
        }

        public ActionResult Index()
        {
            return View(_customerServices.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( CustomerDto customer)
        {
            _customerServices.Create(customer);
            return View("Index", _customerServices.GetAll());
        }


        public ActionResult Delete(string customerId)
        {
            _customerServices.Remove(new CustomerDto
            {
                CustomerID=customerId
            });
            return View("Index", _customerServices.GetAll());
        }


        public ActionResult Actualizar(string customerId)
        {
            var x=_customerServices.GetAll().FirstOrDefault(c=>c.CustomerID == customerId);

            ViewBag.id = customerId;
            ViewBag.CompanyName = x.CompanyName;
            ViewBag.ContactName = x.ContactName;
            ViewBag.Address = x.Address;
            return View();
        }

        [HttpPost]
        public ActionResult ActualizarCompleta(CustomerDto customer)
        {
            _customerServices.Update(customer);
           return View("Index", _customerServices.GetAll());
        }


    }
}