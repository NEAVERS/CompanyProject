using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CheckType
    {
        public Guid Id { get; set; }


        public string Name { get; set; }


        public string TypeItems { get; set; }


        public CheckType()
        {
            this.Id = Guid.NewGuid();
            this.Name = string.Empty;
            this.TypeItems = string.Empty;
        }

        /// <summary>
        /// 获取检查子项
        /// </summary>
        /// <returns></returns>
        public List<CheckItem> GetTypeItems()
        {
            List<CheckItem> list = new List<CheckItem>();
            if (!string.IsNullOrWhiteSpace(this.TypeItems))
            {
                string[] items = this.TypeItems.Split(',');
                foreach (var item in items)
                {
                    int num = Utils.ParseInt(item);
                    if (num > 0)
                        list.Add((CheckItem)num);
                }
            }
            
            return list;
        }
    }

}
