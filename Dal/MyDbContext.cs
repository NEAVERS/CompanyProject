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



        public DbSet<CheckInfo> CheckInfoes { get; set; }

        public DbSet<CheckItem> CheckItems { get; set; }
        public DbSet<PicInfo> PicInfoes { get; set; }


        public DbSet<PassRecord> PassRecords { get; set; }

        public DbSet<UserInfo> UserInfoes { get; set; }

        public DbSet<WeightRecord> WeightRecords { get; set; }

        public DbSet<ProjectInfo> ProjectInfoes { get; set; }
        public DbSet<Expertor> Expertors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmpleyeMap());
            modelBuilder.Configurations.Add(new PayUserMap());
            modelBuilder.Configurations.Add(new PayHisMap());
            modelBuilder.Configurations.Add(new CheckTypeMap());
            modelBuilder.Configurations.Add(new GPSHisMap());
            modelBuilder.Configurations.Add(new GPSItemMap());
            modelBuilder.Configurations.Add(new CheckInfoMap());
            modelBuilder.Configurations.Add(new CheckItemMap());
            modelBuilder.Configurations.Add(new PicInfoMap());
            modelBuilder.Configurations.Add(new PassRecordMap());
            modelBuilder.Configurations.Add(new UserInfoMap());
            modelBuilder.Configurations.Add(new WeightRecordMap());
            modelBuilder.Configurations.Add(new ProjectInfoMap());
            modelBuilder.Configurations.Add(new ExpertorMap());
        }

    }
}
