using Common.Entities;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class UserManager
    {
        private MyDbContext _context = new MyDbContext();
        private ResponseModel _response = new ResponseModel();


        public bool Login(string userName,string passId,ref Guid userId)
        {
            bool loginResult = false;

            var model = _context.UserInfoes.FirstOrDefault(x => x.UserName == userName && x.Password == passId);
            if (model != null)
            {
                userId = model.UserId;
                loginResult = true;
            }
            return loginResult;
        }

    }
}
