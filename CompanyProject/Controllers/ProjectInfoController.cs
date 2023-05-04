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
    public class ProjectInfoController : Controller
    {
        ProjectInfoManager _projectInfoManager = new ProjectInfoManager();
        ResponseModel _response = new ResponseModel();
        // GET: ProjectInfo
        public ActionResult Index(int index = 1, int size = 10, string key = "")
        {
            var result = _projectInfoManager.GetList(index, size, key);
            ViewBag.List = result.Result == null ? new List<ProjectInfo>() : (List<ProjectInfo>)result.Result;
            ViewBag.TotalPage = result.TotalPages;
            ViewBag.Index = index;
            return View(ViewBag.List);
        }

        // GET: ProjectInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProjectInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectInfo/Create
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

        // GET: ProjectInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectInfo/Edit/5
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

        // GET: ProjectInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectInfo/Delete/5
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
