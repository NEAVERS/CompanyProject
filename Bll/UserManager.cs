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
    public class UserManager
    {
        private MyDbContext _context = new MyDbContext();
        private ResponseModel _response = new ResponseModel();


        public bool Login(string userName,string passId,ref Guid userId,ref string permissions)
        {
            bool loginResult = false;

            var model = _context.UserInfoes.FirstOrDefault(x => x.UserName == userName && x.Password == passId);
            if (model != null)
            {
                userId = model.UserId;
                permissions = model.Permission;
                loginResult = true;
            }
            return loginResult;
        }


        public bool AddUser(UserInfo user)
        {
            _context.UserInfoes.Add(user);
            return _context.SaveChanges() > 0;
        }


        public ResponseModel GetUserInfo(int index, int size, string key = "")
        {
            try
            {
                var q = from c in _context.UserInfoes
                        where c.UserName.Contains(key)
                        || c.Name.Contains(key)
                        select c;
                _response.Result = q.OrderByDescending(x => x.LastLoginTime).Skip((index - 1) * size).Take(size).ToList();
                _response.Stutas = true;
            }
            catch (Exception ex)
            {
                _response.Msg = ex.Message;
            }
            return _response;
        }


        public bool GetUserInfo(Guid userId, ref UserInfo user)
        {
            try
            {
                var q = _context.UserInfoes.FirstOrDefault(x => x.UserId == userId);
                if(q!= null)
                {
                    user = q;
                    return true;
                }
            }
            catch (Exception ex)
            {
                _response.Msg = ex.Message;
            }
            return false;
        }

    }
}
