using Dal.Mapping;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base(ConfigurationManager.ConnectionStrings["ConnectStr"].ToString())
        {
        }


        public DbSet<Empleye> Empleyes { get; set; }

        public DbSet<PayUser> PayUsers { get; set; }

        public DbSet<PayHis> PayHises { get; set; }

        public DbSet<CheckType> CheckTypes { get; set; }

        public DbSet<GPSHis> GPSHises { get; set; }
        public DbSet<GPSItem> GPSItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmpleyeMap());
            modelBuilder.Configurations.Add(new PayUserMap());
            modelBuilder.Configurations.Add(new PayHisMap());
            modelBuilder.Configurations.Add(new CheckTypeMap());
            modelBuilder.Configurations.Add(new GPSHisMap());
            modelBuilder.Configurations.Add(new GPSItemMap());
        }

    }
}
