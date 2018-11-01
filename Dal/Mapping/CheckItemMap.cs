using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Mapping
{
    public class CheckItemMap : EntityTypeConfiguration<CheckItem>
    {
        public CheckItemMap()
        {
            this.HasKey(x => x.Id);
            this.ToTable("CheckItem");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CheckInfoId).HasColumnName("CheckInfoId");

            this.Property(t => t.ItemName).HasColumnName("ItemName");
            this.Property(t => t.Courts).HasColumnName("Courts");
            this.Property(t => t.Remark).HasColumnName("Remark");
        }

    }
}
