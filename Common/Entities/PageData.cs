using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class PageData<T>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPage
        {
            get
            {
                if (TotalCount % PageSize == 0)
                    return TotalCount / PageSize;
                else
                    return TotalCount / PageSize + 1;
            }
        }

        public List<T> ListData { get; set; }
    }
}
