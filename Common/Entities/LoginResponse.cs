using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class LoginResponse
    {
        public int version { get; set; }
        public bool success { get; set; }

        public int vid { get; set; }

        public string  vKey { get; set; }
    }
}
