using Bll;
using Common.Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyProject.Controllers
{
    
    [Auth]
    [PermissionFilter]
    public class BuildingWasteController : Controller
    {


        BuildingManager _buildingManager = new BuildingManager();
        UserManager userManager = new UserManager();
        ResponseModel _response = new ResponseModel();

        // GET: BuildingWaste
        public ActionResult Index(int index = 1, int size = 15, string key = "")
        {
            var result = _buildingManager.GetBuildingInfo(index, size, key);
            ViewBag.List = result.Result == null ? new List<WeightRecord>() : (List<WeightRecord>)result.Result;
            return View(ViewBag.List);
        }

        // GET: BuildingWaste/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BuildingWaste/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuildingWaste/Create
        [HttpPost]
        public ActionResult Create(WeightRecord record)
        {
            try
            {
                record.Id = Guid.NewGuid();
                record.CarId= Guid.NewGuid();
                record.InTime = DateTime.Now;
                record.InUserId = Guid.Parse(User.Identity.Name);
                UserInfo user = new UserInfo();
                if (userManager.GetUserInfo(Guid.Parse(User.Identity.Name), ref user))
                {
                    record.InUserName = user.Name;
                    if (_buildingManager.AddRecord(record))
                    {
                        return RedirectToAction("Index");
                    }
                }
                
                return View();

                
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: BuildingWaste/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: BuildingWaste/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
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

        // GET: BuildingWaste/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: BuildingWaste/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
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



        public ActionResult CarInOut(int index = 1, int size = 15, string key = "")
        {
            var result = _buildingManager.GetCarInInfo(index, size, key);
            ViewBag.List = result.Result == null ? new List<PassRecord>() : (List<PassRecord>)result.Result;
            return View(ViewBag.List);
        }



        // GET: BuildingWaste/Create
        public ActionResult CreateCarInOut()
        {
            return View();
        }

        // POST: BuildingWaste/Create
        [HttpPost]
        public ActionResult CreateCarInOut(PassRecord record)
        {
            try
            {
                record.Id = Guid.NewGuid();
                record.CardId = Guid.NewGuid();
                record.PassTime = DateTime.Now;
                record.InUserId = Guid.Parse(User.Identity.Name);
                UserInfo user = new UserInfo();
                if (userManager.GetUserInfo(Guid.Parse(User.Identity.Name), ref user))
                {
                    record.InUserName = user.Name;
                    if (_buildingManager.AddRecord(record))
                    {
                        return RedirectToAction("CarInOut");
                    }
                }

                return View();

            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
