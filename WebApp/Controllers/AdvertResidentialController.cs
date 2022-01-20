using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.ModelBase;
using WebApp.DataAccess;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    public class AdvertResidentialController : Controller
    {
        // GET: AdvertResidential
        public ActionResult Index()
        {
            AdvertResidentialDal advertiesment = new AdvertResidentialDal(new ResidentialDal());
            List<AdvertResidential> advertResidentials= advertiesment.GetAdvertResidentials();
            List<AdverticeViewModel> adverticeViewModels = new List<AdverticeViewModel>();

            advertResidentials.ForEach(ad=>
                adverticeViewModels.Add(new AdverticeViewModel { 
                 PublishDate=ad.PublishDate,
                 IsActive=ad.IsActive,
                 Title=ad.Title,
                 Explaination=ad.Explaination,
                 Square=ad.RealEstate.Square,
                 Balcony=ad.RealEstate.Balcony,
                 Furnished=ad.RealEstate.Furnished    
                })
            
            
            );

         





            //ViewBag.resid = residential.Select()[0].ToString()+ residential.Select()[1].ToString()+ residential.Select()[2].ToString();
            return View(adverticeViewModels);
        }

        // GET: AdvertResidential/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdvertResidential/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdvertResidential/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdvertResidential/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdvertResidential/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdvertResidential/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdvertResidential/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
