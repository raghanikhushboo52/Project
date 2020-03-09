using Assignment.Models;
using Assignment.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class CustomerController : Controller
    {
        public ManagementSystemEntities db = new ManagementSystemEntities();
        // GET: Customer

        public ActionResult Index()
        {
            List<CustomerViewModel> customerlist = new List<CustomerViewModel>();

            var customers = db.Customers.ToList();
            foreach (var c in customers)
            {
                CustomerViewModel cvm = new CustomerViewModel()
                {
                    CustomerId = c.CustomerId,
                    Name = c.Name,
                    Address1 = c.Address1,
                    Address2 = c.Address2,
                    City = c.City,
                    Country = c.Country,
                    PostCode = c.PostCode,
                    Email = c.Email,
                    Mobile = c.Mobile,
                    BirthDate = c.BirthDate,
                    Active = c.Active,
                    CreatedDate = c.CreatedDate,
                    UpdatedDate = c.UpdatedDate


                };
                customerlist.Add(cvm);

            }

            return View(customerlist);
        }

        public ActionResult Create()
        {
            ViewBag.City = new SelectList(db.Cities, "CityId", "CityName", "Select City");
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModel customerViewModel)
        {

            Customer customer = new Customer();
            customer = Mapper.Map<Customer>(customerViewModel);
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Customer c = db.Customers.Find(id);
            CustomerViewModel customer = Mapper.Map<CustomerViewModel>(c);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.City = new SelectList(db.Cities, "CityId", "CityName", c.City);
            return View(customer);

        }
        [HttpPost]
        public ActionResult Edit(int id, CustomerViewModel customerViewModel)
        {
            try
            {
                var customer = Mapper.Map<Customer>(customerViewModel);
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var data = db.Customers.Find(id);
            CustomerViewModel customer = Mapper.Map<CustomerViewModel>(data);
            return View(customer);
        }
        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            var data = db.Customers.FirstOrDefault(m => m.CustomerId == id);
            db.Customers.Remove(data);
            db.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Index");
        }


    }
}