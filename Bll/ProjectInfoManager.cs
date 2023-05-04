using Common.Entities;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{

    public class ProjectInfoManager
    {
        private MyDbContext _context = new MyDbContext();
        private ResponseModel _response = new ResponseModel();
        public ResponseModel GetList(int index, int size, string key = "")
        {
            try
            {
                var q = from c in _context.ProjectInfoes
                        where c.ProName.Contains(key)
                        || c.PersionList.Contains(key)
                        select c;
                _response.Result = q.OrderByDescending(x => x.Time).Skip((index - 1) * size).Take(size).ToList();

                _response.TotalCount = q.Count();
                _response.TotalPages = _response.TotalCount % size == 0 ? _response.TotalCount / size : (_response.TotalCount / size + 1);
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
