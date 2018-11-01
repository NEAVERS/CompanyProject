using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Mapping
{
    public class PicInfoMap : EntityTypeConfiguration<PicInfo>
    {
        public PicInfoMap()
        {
            this.HasKey(x => x.Id);
            this.ToTable("PicInfo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CheckItemId).HasColumnName("CheckItemId");

            this.Property(t => t.Path).HasColumnName("Path");
            this.Property(t => t.Remark).HasColumnName("Remark");

        }

    }
}
