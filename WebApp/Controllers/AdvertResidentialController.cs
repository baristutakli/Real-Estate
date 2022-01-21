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
            List<AdvertResidential> advertResidentials = advertiesment.GetAdvertResidentials();
            List<AdverticeViewModel> adverticeViewModels = new List<AdverticeViewModel>();

            advertResidentials.ForEach(ad =>
                adverticeViewModels.Add(new AdverticeViewModel
                {
                    AdverticeId = ad.AdverticeId,
                    PublishDate = ad.PublishDate,
                    IsActive = ad.IsActive,
                    Title = ad.Title,
                    Explaination = ad.Explaination,
                    Square = ad.RealEstate.Square,
                    Balcony = ad.RealEstate.Balcony,
                    Furnished = ad.RealEstate.Furnished
                })


            );







            //ViewBag.resid = residential.Select()[0].ToString()+ residential.Select()[1].ToString()+ residential.Select()[2].ToString();
            return View(adverticeViewModels);
        }

        // GET: AdvertResidential/Details/5
        public ActionResult Details(int id)
        {
            AdvertResidentialDal advertiesment = new AdvertResidentialDal(new ResidentialDal());
            var result = advertiesment.GetResidentialById(id);
            AdverticeViewModel vm;
            try
            {
                vm = new AdverticeViewModel()
                {

                    AdverticeId = result.AdverticeId,
                    PublishDate = result.PublishDate,
                    IsActive = result.IsActive,
                    Title = result.Title,
                    Explaination = result.Explaination,
                    Square = result.RealEstate.Square,
                    Balcony = result.RealEstate.Balcony,
                    Furnished = result.RealEstate.Furnished,
                    AddressId = result.RealEstate.AddressId,
                    Age = result.RealEstate.Age,
                    FloorNumber = result.RealEstate.FloorNumber,
                    Heating = result.RealEstate.Heating,
                    SellType = result.RealEstate.SellType,
                    ResidentialType = result.RealEstate.ResidentialType


                };

            }
            catch (Exception)
            {

                throw;
            }
           

            return View(vm);
        }

        // GET: AdvertResidential/Create
        public ActionResult Create()
        {
            AdverticeViewModel vm = new AdverticeViewModel();
            return View(vm);
        }

        // POST: AdvertResidential/Create
        [HttpPost]
        public ActionResult Create(AdverticeViewModel adverticeViewModel)
        {
            AdvertResidentialDal advertiesment = new AdvertResidentialDal(new ResidentialDal());
            AdvertResidential advertice;
            advertice = new AdvertResidential()
            {
                PublishDate = adverticeViewModel.PublishDate,
                IsActive = adverticeViewModel.IsActive,
                Title = adverticeViewModel.Title,
                Explaination = adverticeViewModel.Explaination,
                AdvertType = adverticeViewModel.AdvertType,
                RealEstate = new Residential
                {
                    SellType = adverticeViewModel.SellType,
                    Square = adverticeViewModel.Square,
                    Age = adverticeViewModel.Age,
                    Balcony = adverticeViewModel.Balcony,
                    Furnished = adverticeViewModel.Furnished,
                    Heating = adverticeViewModel.Heating,
                    FloorNumber = adverticeViewModel.FloorNumber,
                    AddressId = adverticeViewModel.AddressId,
                    ResidentialType = adverticeViewModel.ResidentialType
                }

            };
            try
            {
                advertiesment.Create(advertice);
            }
            catch (Exception)
            {

                throw;
            }
          



            return RedirectToAction("Index");
        }

        // GET: AdvertResidential/Edit/5
        public ActionResult Edit(int id)
        {
            AdvertResidentialDal advertiesment = new AdvertResidentialDal(new ResidentialDal());
            advertiesment.GetResidentialById(id);
            return View();
        }

        // POST: AdvertResidential/Edit/5
        [HttpPut]
        public ActionResult Edit(int id, AdverticeViewModel adverticeViewModel)
        {
           // Benzer işlemler tekrar edilecek
        }

        // GET: AdvertResidential/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdvertResidential/Delete/5
        [HttpDelete]
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
