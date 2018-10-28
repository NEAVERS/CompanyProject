using Common.Entities;
using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{

    public class GPSManager
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
            string url = string.Format( "http://{0}:89/gpsonline/GPSAPI",ip);
            var para = new NameValueCollection();
            para.Add("version", "1");
            para.Add("method", "vLoginSystem");
            para.Add("name", num);
            para.Add("pwd", pwd);
            string json = Common.HttpHelper.PostData(url,para);
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
            try
            {
                var q = from c in _context.GPSItems
                        select c;

                var list = q.ToList();
                string url = "122.112.213.193";
                list.ForEach(x =>
                {
                    var res = GetToken(url, x.Code, x.Pwd);
                    if (res.success)
                    {
                        var info = GetGpsInfo(url, res.vid, res.vKey);
                        if (info.success && info.locs.Count > 0)
                        {

                            var loc = info.locs[0];
                            x.Lat = Convert.ToDecimal(loc.lat);
                            x.Lng = Convert.ToDecimal(loc.lng);
                            x.Speed = loc.speed.ToString();
                            x.Oil = loc.oil.ToString();
                            x.LoacationInfo = loc.info;
                            x.States = loc.state;
                            x.LastUpdateTime =  Common.Utils.GetTime(loc.gpstime);
                        }
                    }
                });
                UpdateLoc(list);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
            //TODO UPdate数据并保存一条历史
        }


        public ResponseModel AddCar(string carNum)
        {
            var obj = _context.GPSItems.FirstOrDefault(x => x.CardNum == carNum);
            if(obj!=null)
            {
                _response.Msg = "该车牌已存在！";
                return _response;
            }
            try
            {
                GPSItem item = new GPSItem();
                item.Id = Guid.NewGuid();
                item.CardNum = carNum;
                item.Code = carNum;
                item.Lat = 0;
                item.Lng = 0;
                item.LastUpdateTime = DateTime.Now;
                item.Name = carNum;
                _context.GPSItems.Add(item);
                _response.Stutas = _context.SaveChanges()>0;
            }
            catch(Exception ex)
            {
                _response.Msg = ex.Message;
            }
            return _response;
        }

        //获取历史记录 
        public List<GPSHis> GetGPSHises(Guid itemId)
        {
            DateTime start = DateTime.Now.AddDays(-1);

            var q = from c in _context.GPSHises
                    where c.UploadTime > start
                    && c.GPSItemId == itemId
                    select c;
            return q.ToList();
        }

        /// <summary>
        /// 更新位置和并存一条历史记录信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateLoc(List<GPSItem> list)
        {
            list.ForEach(x =>
            {
                var his = new GPSHis();
                his.Id = Guid.NewGuid();
                his.GPSItemId = x.Id;
                his.Lat = x.Lat;
                his.Lng = x.Lng;
                his.LoactionInfo = x.LoacationInfo;
                his.States = x.States;
                his.UploadTime = x.LastUpdateTime;
                _context.GPSHises.Add(his);

                var info = _context.GPSItems.FirstOrDefault(c => c.Id == x.Id);

                info.Lat = x.Lat;
                info.Lng = x.Lng;
                info.Speed = x.Speed;
                info.Oil = x.Oil;
                info.LoacationInfo = x.LoacationInfo;
                info.States = x.States;
                info.LastUpdateTime = x.LastUpdateTime;

            });
            return _context.SaveChanges()>0;
        }


        

    }
}
