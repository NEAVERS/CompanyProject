using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Mapping
{
    class CheckTypeMap: EntityTypeConfiguration<CheckType>
    {
        public CheckTypeMap()
        {
            this.HasKey(x => x.Id);

            this.ToTable("CheckType");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.TypeItems).HasColumnName("TypeItems");
        }
    }
}
