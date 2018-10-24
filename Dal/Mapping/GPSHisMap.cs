using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Mapping
{
    public class GPSHisMap : EntityTypeConfiguration<GPSHis>
    {
        public GPSHisMap()
        {
            this.HasKey(x => x.Id);
            this.Property(t => t.Lat).HasPrecision(30, 20);
            this.Property(t => t.Lng).HasPrecision(30, 20);
            this.ToTable("GPSHis");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.GPSItemId).HasColumnName("GPSItemId");
            this.Property(t => t.Lat).HasColumnName("Lat");
            this.Property(t => t.Lng).HasColumnName("Lng");
            this.Property(t => t.LoactionInfo).HasColumnName("LoactionInfo");
            this.Property(t => t.States).HasColumnName("States");
            this.Property(t => t.UploadTime).HasColumnName("UploadTime");

        }
    }
}
