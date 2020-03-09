using Assignment.Models;
using Assignment.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Areas.Cities.Controllers
{
    public class CitiesController : Controller
    {
        public ManagementSystemEntities db = new ManagementSystemEntities();
        // GET: Customer

        public ActionResult Index()
        {
            List<CityViewModel> citylist = new List<CityViewModel>();

            var cities = db.Cities.ToList();
            foreach (var c in cities)
            {
                CityViewModel cvm = new CityViewModel()
                {
                    CityId=c.CityId,
                    CityName=c.CityName,
                    CreatedDate=c.CreatedDate,
                    UpdatedDate=c.UpdatedDate
                   


                };
                citylist.Add(cvm);

            }

            return View(citylist);
        }

        public ActionResult Create()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult Create(CityViewModel cityViewModel)
        {

            City c = new City();
            c = Mapper.Map<City>(cityViewModel);
            db.Cities.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            City c = db.Cities.Find(id);
            CityViewModel city = Mapper.Map<CityViewModel>(c);
            if (city == null)
            {
                return HttpNotFound();
            }
       
            return View(city);

        }
        [HttpPost]
        public ActionResult Edit(int id, CityViewModel cityviewmodel)
        {
            try
            {
                var city = Mapper.Map<Customer>(cityviewmodel);
                db.Entry(city).State = EntityState.Modified;
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
            var data = db.Cities.Find(id);
          CityViewModel city = Mapper.Map<CityViewModel>(data);
            return View(city);
        }
        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            var data = db.Cities.FirstOrDefault(m => m.CityId == id);
            db.Cities.Remove(data);
            db.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Index");
        }



    }
}