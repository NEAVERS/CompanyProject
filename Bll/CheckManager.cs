using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Entities;
using Dal;
using Model;

namespace Bll
{
    public class CheckManager
    {
        private MyDbContext _context = new MyDbContext();
        private ResponseModel _response = new ResponseModel();



        public CheckInfo CreateCheckInfo(Guid typeId)
        {
            var checkType = _context.CheckTypes.FirstOrDefault(x => x.Id == typeId);
            var checkSubs = checkType.GetTypeItems();

        }
    }
}
