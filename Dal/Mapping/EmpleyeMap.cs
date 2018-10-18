using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Mapping
{
    public class EmpleyeMap : EntityTypeConfiguration<Empleye>
    {
        public EmpleyeMap()
        {
            this.HasKey(x => x.Id);
            this.ToTable("Empleye");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");

            this.Property(t => t.Tel).HasColumnName("Tel");
            this.Property(t => t.Lat).HasColumnName("Lat");
            this.Property(t => t.Los).HasColumnName("Los");
            this.Property(t => t.LastUpdateTime).HasColumnName("LastUpdateTime");
            this.Property(t => t.Sex).HasColumnName("Sex");
            this.Property(t => t.BirthDay).HasColumnName("BirthDay");
            this.Property(t => t.EmpleyType).HasColumnName("EmpleyType");
            this.Property(t => t.DepetId).HasColumnName("DepetId");

        }
    }
}
