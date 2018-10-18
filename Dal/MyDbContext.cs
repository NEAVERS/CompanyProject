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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmpleyeMap());
            modelBuilder.Configurations.Add(new PayUserMap());
            modelBuilder.Configurations.Add(new PayHisMap());
        }

    }
}
