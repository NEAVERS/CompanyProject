using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Mapping
{
    class PayUserMap : EntityTypeConfiguration<PayUser>
    {

        public PayUserMap()
        {
            this.HasKey(x => x.Id);
            this.ToTable("PayUser");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.UserNum).HasColumnName("UserNum");
            this.Property(t => t.LastPayTime).HasColumnName("LastPayTime");
            this.Property(t => t.PayMoney).HasColumnName("PayMoney");
            this.Property(t => t.Months).HasColumnName("Months");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.Remark).HasColumnName("Remark");
        }
    }
}
