using AZLinli.Com.Blog.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZLinli.Com.Blog.Model.Maps
{
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.HasKey(u => u.uID);
            this.Property(u => u.uLoginName).HasMaxLength(60);
            this.Property(u => u.uLoginPWD).HasMaxLength(60);
            this.Property(u => u.uRealName).HasMaxLength(60);
        }
    }
}
