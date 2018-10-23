using Common.Entities;
using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{

    class GPSManager
    {
        private MyDbContext _context = new MyDbContext();
        private ResponseModel _response = new ResponseModel();


        /// <summary>
        /// 车辆登录获取token
        /// </summary>
        /// <param name="nim"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public LoginResponse GetToken(string ip,string num,string pwd)
        {
            string url = string.Format( "http://{0}:89/gpsonline/GPSAPI?version=1&method=vLoginSystem&name={1}&pwd={2}", ip, num,pwd);

            string json = Common.HttpHelper.Get(url);
            return Common.Utils.DeserializeObject<LoginResponse>(json);
        }


        public GPSInfoResponse GetGpsInfo(string ip, int vid,string vkey)
        {
            string url = string.Format( "http://{0}:89/gpsonline/GPSAPI?version=1&method=loadLocation&vid={1}&vKey={2}",ip,vid,vkey);

            string json = Common.HttpHelper.Get(url);
            return Common.Utils.DeserializeObject<GPSInfoResponse>(json);
        }


        /// <summary>
        /// 获取所有车辆的位置信息
        /// </summary>
        /// <returns></returns>
        public List<GPSItem> GetGpsItems()
        {
            var list = _context.GPSItems.ToList();
            string url = "";
            list.ForEach(x =>
            {
                var res = GetToken(url,x.Code, x.Pwd);
                if(res.success)
                {
                    var info = GetGpsInfo(url, res.vid, res.vKey);
                    if(info.success)
                    {
                        x.Lat = info.locs[0].lat;
                        x.Lng = info.locs[0].lng ;
                        //TODO
                    }
                }
            });

            //TODO UPdate数据并保存一条历史
            return list;
        }




        

    }
}
