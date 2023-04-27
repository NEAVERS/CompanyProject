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
    public class CheckController : Controller
    {
        CheckManager _checkManager = new CheckManager();
        ResponseModel _response = new ResponseModel();
        // GET: Check
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CkeckTypes()
        {
            var List = _checkManager.GetCheckTypes();
            ViewBag.List = List;
            return View();
        }

        public ActionResult AddCkeckTypes()
        {
            return View();
        }

        public string CreateCkeckTypes(string name ,string subs)
        {
            try
            {
                CheckType type = new CheckType();
                type.Id = Guid.NewGuid();
                type.Name = name;
                type.TypeItems = subs;
                _response.Stutas = _checkManager.AddCheckType(type);

            }
            catch (Exception ex)
            {
                Common.LogsHelper.WriteErrorLog(ex, "添加检查类型");
                _response.Msg = ex.Message;
            }
            return Common.Utils.SerializeObject(_response);
        }

        public string DelCheckType(Guid id)
        {
            try
            {
                _response.Stutas = _checkManager.DeleteCheckType(id);

            }
            catch (Exception ex)
            {
                Common.LogsHelper.WriteErrorLog(ex, "删除检查类型");
                _response.Msg = ex.Message;
            }
            return Common.Utils.SerializeObject(_response);

        }
        public ActionResult EditCheckType(Guid id)
        {
            var model = _checkManager.GetCheckType(id);
            var subs = model.GetTypeItems();
            ViewBag.Subs = subs;
            return View(model);
        }


        public string SaveCheckType(Guid id,string name ,string subs)
        {
            try
            {
                _response.Stutas = _checkManager.UpdateCheckType(id,name,subs);

            }
            catch (Exception ex)
            {
                Common.LogsHelper.WriteErrorLog(ex, "更新检查类型");
                _response.Msg = ex.Message;
            }
            return Common.Utils.SerializeObject(_response);
        }

        public ActionResult CheckInfoList(int index = 1, int size = 15, string start="",string end = "",string key="",int stutas = -1)
        {

            PageData<CheckInfo> list = _checkManager.GetCheckInfoes(index, size, start, end, stutas, key);
            ViewBag.Pager = list;
            return View();
        }

        public ActionResult AddCheckInfo(Guid typeId)
        {
            CheckInfo info = _checkManager.CreateCheckInfo(typeId);
            return View(info);
        }

        public string SaveCheckInfo(CheckInfo checkInfo)
        {
            _response = _checkManager.SaveCheckInfo(checkInfo);
            return "";
        }
    }
}