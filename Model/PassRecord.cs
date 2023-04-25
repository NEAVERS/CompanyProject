using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PassRecord
    {
        public Guid Id { get; set; }

        public string Plate { get; set; }

        public DateTime PassTime { get; set; }


        public Guid WeightRecordId { get; set; }

        public Guid InUserId { get; set; }


        public string InUserName { get; set; }


        public Guid CardId { get; set; }
    }
}
