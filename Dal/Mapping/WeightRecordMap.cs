using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Mapping
{
    public class WeightRecordMap : EntityTypeConfiguration<WeightRecord>
    {
        public WeightRecordMap()
        {
            this.HasKey(x => x.Id);
            this.ToTable("WeightRecord");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Plate).HasColumnName("plate");

            this.Property(t => t.TotalWeight).HasColumnName("totalWeight");
            this.Property(t => t.InTime).HasColumnName("inTime");
            this.Property(t => t.InUserId).HasColumnName("inUserId");
            this.Property(t => t.InUserName).HasColumnName("inUserName");
            this.Property(t => t.CarId).HasColumnName("carId");

        }

    }
}




