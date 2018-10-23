using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Mapping
{
    public class GPSItemMap : EntityTypeConfiguration<GPSItem>
    {
        public GPSItemMap()
        {
            this.HasKey(x => x.Id);
            this.ToTable("GPSItem");

            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Pwd).HasColumnName("Pwd");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CardNum).HasColumnName("CardNum");
            this.Property(t => t.Lat).HasColumnName("Lat");

            this.Property(t => t.Lng).HasColumnName("Lng");
            this.Property(t => t.Speed).HasColumnName("Speed");
            this.Property(t => t.Oil).HasColumnName("Oil");
            this.Property(t => t.LoacationInfo).HasColumnName("LoacationInfo");
            this.Property(t => t.States).HasColumnName("States");
            this.Property(t => t.LastUpdateTime).HasColumnName("LastUpdateTime");
            

        }
    }
}
