using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Mapping
{
    public class PassRecordMap : EntityTypeConfiguration<PassRecord>
    {
        public PassRecordMap()
        {
            this.HasKey(x => x.Id);
            this.ToTable("PassRecord");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Plate).HasColumnName("plate");

            this.Property(t => t.PassTime).HasColumnName("passTime");
            this.Property(t => t.WeightRecordId).HasColumnName("weightRecordId");
            this.Property(t => t.InUserId).HasColumnName("inUserId");
            this.Property(t => t.InUserName).HasColumnName("inUserName");
            this.Property(t => t.CardId).HasColumnName("carId");

        }

    }
}
