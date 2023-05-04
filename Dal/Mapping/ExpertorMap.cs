using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Mapping
{
    public class ExpertorMap : EntityTypeConfiguration<Expertor>
    {
        public ExpertorMap()
        {
            this.HasKey(x => x.Id);
            this.ToTable("Expertor");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Tel).HasColumnName("Tel");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.Sex).HasColumnName("Sex");
            this.Property(t => t.MasterType).HasColumnName("MasterType");
        }
    }
}
