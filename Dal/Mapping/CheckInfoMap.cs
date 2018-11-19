using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Mapping
{
    public class CheckInfoMap : EntityTypeConfiguration<CheckInfo>
    {
        public CheckInfoMap()
        {
            this.HasKey(x => x.Id);
            this.ToTable("CheckInfo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TypeId).HasColumnName("TypeId");

            this.Property(t => t.TypeName).HasColumnName("TypeName");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Lat).HasColumnName("Lat");
            this.Property(t => t.Lng).HasColumnName("Lng");

            this.Property(t => t.Status).HasColumnName("DealUserId");
            this.Property(t => t.Lat).HasColumnName("DealUserName");
            this.Property(t => t.Lng).HasColumnName("DealTime");

            this.Property(t => t.Lng).HasColumnName("DistributeTime");
            this.Property(t => t.LocationInfo).HasColumnName("LocationInfo");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Remark).HasColumnName("Remark");

        }

    }
}
