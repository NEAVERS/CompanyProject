using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WeightRecord
    {
        public Guid Id { get; set; }


        public string Plate { get; set; }


        public decimal TotalWeight { get; set; }


        public DateTime InTime { get; set; }

        public Guid InUserId { get; set; }


        public string InUserName { get; set; }


        public Guid CarId { get; set; }
    }
}
