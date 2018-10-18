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
    public class PayUserManager
    {
        private MyDbContext _context = new MyDbContext();
        private ResponseModel _response = new ResponseModel();



        /// <summary>
        /// 添加付社保用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ResponseModel AddPayUserInfo(PayUser user)
        {
            try
            {
                _context.PayUsers.Add(user);
                _response.Stutas = _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _response.Msg = ex.Message;
            }
            return _response;
        }

        /// <summary>
        /// 获取社保用户列表
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="size">每页大小</param>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        public ResponseModel GetUserInfo(int index, int size, string key = "")
        {
            try
            {
                var q = from c in _context.PayUsers
                        where c.Name.Contains(key)
                        || c.UserNum.Contains(key)
                        select c;
                _response.Result = q.OrderByDescending(x => x.LastPayTime).Skip((index - 1) * size).Take(size).ToList();
                _response.Stutas = true;
            }
            catch (Exception ex)
            {
                _response.Msg = ex.Message;
            }
            return _response;
        }

        /// <summary>
        /// 获取单个用户的社保支付记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ResponseModel GetPayList(Guid userId)
        {
            try
            {
                var q = from c in _context.PayHises
                        where c.PayUserId == userId
                        select c;
                _response.Result = q.OrderByDescending(x => x.PayTime).ToList();
                _response.Stutas = true;
            }
            catch (Exception ex)
            {
                _response.Msg = ex.Message;
            }
            return _response;
        }


        /// <summary>
        /// 添加一条支付记录
        /// </summary>
        /// <param name="his"></param>
        /// <returns></returns>
        public ResponseModel AddPayHis(PayHis his)
        {
            using (var scope = _context.Database.BeginTransaction())
            {
                
                try
                {
                    _context.PayHises.Add(his);
                    var model = _context.PayUsers.FirstOrDefault(x => x.Id == his.PayUserId);
                    model.LastPayTime = DateTime.Now;
                    model.PayMoney = his.PayMoney;
                    model.Months = his.Months;
                    model.EndTime = model.EndTime.AddMonths(his.Months);
                    model.Remark = his.Reamrk;
                    _context.SaveChanges();
                    scope.Commit();//正常完成就可以提交
                    _response.Stutas = true;
                }
                catch (Exception ex)
                {
                    _response.Msg = ex.Message;
                    scope.Rollback();//发生异常就回滚
                    
                }
            }
            return _response;
        }

    }
}
