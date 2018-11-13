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



        /// <summary>
        /// 创建 一个检查对象
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public CheckInfo CreateCheckInfo(Guid typeId)
        {
            CheckType checkType = _context.CheckTypes.FirstOrDefault(x => x.Id == typeId);
            List<CheckSub> checkSubs = checkType.GetTypeItems();

            var checkInfo = new CheckInfo();
            checkInfo.TypeId = checkType.Id;
            checkInfo.TypeName = checkType.Name;
            var checkItems = new List<CheckItem>();

            checkSubs.ForEach(x =>
            {
                var item = new CheckItem(x, checkInfo.Id);
                checkItems.Add(item);
            });
            checkInfo.CheckItems = checkItems;
            return checkInfo;
        }

        public ResponseModel SaveCheckInfo(CheckInfo info)
        {
            try
            {
                _context.CheckInfoes.Add(info);
                _context.CheckItems.AddRange(info.CheckItems);
                info.CheckItems.ForEach(x =>
                {
                    _context.PicInfoes.AddRange(x.Pics);
                });
                _response.Stutas = _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {

                LogsHelper.WriteErrorLog(ex,"保存检查对象");
                _response.Msg = ex.Message;
            }
            return _response;
        }

        /// <summary>
        /// 获取检查信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CheckInfo GetCheckInfo(Guid id)
        {
            var info = _context.CheckInfoes.FirstOrDefault(x => x.Id == id);
            if(info!=null)
            {
                info.CheckItems = _context.CheckItems.Where(x => x.CheckInfoId == id).ToList();
                info.CheckItems.ForEach(x =>
                {
                    x.Pics = _context.PicInfoes.Where(c => c.CheckItemId == c.CheckItemId).ToList();
                });
            }
            return info;
        }

        
    }
}
