using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyProject.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (Request.Files.Count == 0)
            {
                return Json(new { jsonrpc = 2.0, error = new { code = 102, message = "没有任何文件上传" }, id = "id" });
            }
            string ex = Path.GetExtension(file.FileName);
            try
            {
                string path = "/GoodImg/" + DateTime.Now.ToString("yyyy_MM_dd") + "/";
                string savepath = Server.MapPath(path);//设定上传的文件路径
                if (!Directory.Exists(savepath))
                {
                    Directory.CreateDirectory(savepath);
                }
                string fileName = Guid.NewGuid().ToString("N") + ex;
                file.SaveAs(savepath + fileName);
                string returnPath = path + fileName;
                return Json(new
                {
                    status = true,
                    filePath = returnPath,
                    saveName = file.FileName,
                    extension = ex
                });
            }
            catch (Exception e)
            {
                LogsHelper.WriteErrorLog("上传图片失败！", e);
            }
            return Json(new
            {
                status = false,
                filePath = "",
                saveName = "",
                extension = ""
            });
        }
    }
}