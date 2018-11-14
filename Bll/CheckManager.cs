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
        /// 获取检查类型列表
        /// </summary>
        /// <returns></returns>
        public List<CheckType> GetCheckTypes()
        {
            var list = _context.CheckTypes.ToList();
            return list;
        }

        /// <summary>
        /// 添加一个检查类型
        /// </summary>
        /// <param name="checkType"></param>
        /// <returns></returns>
        public bool AddCheckType(CheckType checkType)
        {
            _context.CheckTypes.Add(checkType);
            return _context.SaveChanges() > 0;
        }

        /// <summary>
        /// 更新检查类型
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="name"></param>
        /// <param name="typeItems"></param>
        /// <returns></returns>
        public bool UpdateCheckType(Guid typeId,string name,string typeItems)
        {
            var model = _context.CheckTypes.FirstOrDefault(x => x.Id == typeId);
            if (model != null)
            {
                model.Name = name;
                model.TypeItems = typeItems;
            }
            return _context.SaveChanges() > 0;
        }
        /// <summary>
        /// 根据id获取检查类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CheckType GetCheckType(Guid id)
        {
            var model = _context.CheckTypes.FirstOrDefault(x => x.Id == id);
            return model;
        }
        /// <summary>
        /// 删除检查类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteCheckType(Guid id)
        {
            var model = _context.CheckTypes.FirstOrDefault(x => x.Id == id);
            if (model != null)
                _context.CheckTypes.Remove(model);
            return _context.SaveChanges() > 0;
        }

        /// <summary>
        /// 根据条件获取检查对象
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public PageData<CheckInfo> GetCheckInfoes(int index,int size,string start,string end,int status,string key)
        {
            DateTime sTine = Utils.GetTime(start, true);
            DateTime eTime = Utils.GetTime(end);
            var q = from c in _context.CheckInfoes
                    where c.CreateTime > sTine
                    && c.CreateTime < eTime
                    &&(status == -1||c.Status== status)
                    && (c.DealUserName.Contains(key) || c.TypeName.Contains(key))
                    select c;
            PageData<CheckInfo> pager = new PageData<CheckInfo>();
            pager.PageIndex = index;
            pager.PageSize = size;
            pager.TotalCount = q.Count();
            pager.ListData = q.OrderByDescending(x => x.CreateTime).Skip((index - 1) * size).Take(size).ToList();
            return pager;
        }


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

        /// <summary>
        /// 保存检查对象
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
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
