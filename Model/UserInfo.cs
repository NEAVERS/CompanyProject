using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserInfo
    {
        public Guid UserId { get; set; }

        public string Password { get; set; }


        public string UserName { get; set; }

        public string Name { get; set; }


        public DateTime CreateTime { get; set; }

        public DateTime LastLoginTime { get; set; }

        public string Permission { get; set; }

    }
}
