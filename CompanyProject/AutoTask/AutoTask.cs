using Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyProject
{

    [AutoTask(EnterMethod = "StartTask", IntervalSeconds = 600, StartTime = "2016-12-28 10:45:00")]
    public class AutoTask
    {
        public static GPSManager _manager = new GPSManager();
        public static void StartTask()
        {
         
            try
            {
                var res =  _manager.UpdateGpsInfo();
                string msg = "更新地理位置成功！";
                if (!res)
                    msg = "更新地理位置失败！";
                Common.LogsHelper.WriteLog(msg,"更新地理位置");
            }
            catch(Exception ex)
            {
                Common.LogsHelper.WriteErrorLog(ex, "更新地理位置错误");
            }
        }
    }
}