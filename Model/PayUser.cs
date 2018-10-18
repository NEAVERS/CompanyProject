using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PayUser
    {
        public Guid Id { get; set; }

        
        public string Name { get; set; }


        public string UserNum { get; set; }

        public DateTime LastPayTime { get; set; }

        public decimal PayMoney { get; set; }

        public int Months { get; set; }

        public DateTime EndTime { get; set; }

        public string Remark { get; set; }

        public PayUser()
        {
            this.Id = Guid.NewGuid();
            this.LastPayTime = DateTime.Now;
            this.EndTime = DateTime.Now;
        }

    }
}
