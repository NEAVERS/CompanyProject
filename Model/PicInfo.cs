using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PicInfo
    {
        public Guid Id { get; set; }

        public Guid CheckItemId { get; set; }

        public string  Path { get; set; }
        public string Remark { get; set; }
    }
}
