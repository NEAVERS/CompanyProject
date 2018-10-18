using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class ResponseModel
    {
        public bool Stutas { get; set; }

        public string Msg { get; set; }

        public object Result { get; set; }


        public ResponseModel()
        {
            this.Stutas = false;
            this.Msg = string.Empty;
            this.Result = null;
        }
    }
}
