using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Mapping
{
    public class UserInfoMap : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoMap()
        {
            this.HasKey(x => x.UserId);
            this.ToTable("UserInfo");
            this.Property(t => t.UserId).HasColumnName("userId");
            this.Property(t => t.UserName).HasColumnName("userName");

            this.Property(t => t.Password).HasColumnName("password");
            this.Property(t => t.Name).HasColumnName("name");
            this.Property(t => t.CreateTime).HasColumnName("createTime");
            this.Property(t => t.LastLoginTime).HasColumnName("lastLoginTime");
            this.Property(t => t.Permission).HasColumnName("permission");

        }

    }
}

