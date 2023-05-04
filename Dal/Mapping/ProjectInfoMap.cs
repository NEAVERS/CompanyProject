using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Mapping
{
    public class ProjectInfoMap: EntityTypeConfiguration<ProjectInfo>
    {
        public ProjectInfoMap()
        {
            this.HasKey(x => x.Id);
            this.ToTable("ProjectInfo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProName).HasColumnName("ProName");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.Time).HasColumnName("Time");
            this.Property(t => t.ProNo).HasColumnName("ProNo");
        }
    }
}
