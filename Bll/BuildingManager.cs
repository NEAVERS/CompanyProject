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
    public class BuildingManager
    {
        private MyDbContext _context = new MyDbContext();
        private ResponseModel _response = new ResponseModel();

        public ResponseModel GetBuildingInfo(int index, int size, string key = "")
        {
            try
            {
                var q = from c in _context.WeightRecords
                        where c.Plate.Contains(key)
                        || c.InUserName.Contains(key)
                        select c;
                _response.Result = q.OrderByDescending(x => x.InTime).Skip((index - 1) * size).Take(size).ToList();
                _response.Stutas = true;
            }
            catch (Exception ex)
            {
                _response.Msg = ex.Message;
            }
            return _response;
        }


        public bool AddRecord(WeightRecord weightRecord)
        {
            _context.WeightRecords.Add(weightRecord);
            return _context.SaveChanges() > 0;
        }



        public ResponseModel GetCarInInfo(int index, int size, string key = "")
        {
            try
            {
                var q = from c in _context.PassRecords
                        where c.Plate.Contains(key)
                        || c.InUserName.Contains(key)
                        select c;
                _response.Result = q.OrderByDescending(x => x.PassTime).Skip((index - 1) * size).Take(size).ToList();
                _response.Stutas = true;
            }
            catch (Exception ex)
            {
                _response.Msg = ex.Message;
            }
            return _response;
        }
    }
}
