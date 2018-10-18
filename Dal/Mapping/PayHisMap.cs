using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Mapping
{
    class PayHisMap : EntityTypeConfiguration<PayHis>
    {
        public PayHisMap()
        {
            this.HasKey(x => x.Id);
            this.ToTable("PayHis");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PayUserId).HasColumnName("PayUserId");
            this.Property(t => t.PayMoney).HasColumnName("PayMoney");
            this.Property(t => t.PayTime).HasColumnName("PayTime");
            this.Property(t => t.Months).HasColumnName("Months");

            this.Property(t => t.Reamrk).HasColumnName("Reamrk");

        }

    }
}
