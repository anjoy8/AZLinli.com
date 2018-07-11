using AZLinli.Com.Blog.IServices;
using AZLinli.Com.Blog.IRepository;
using AZLinli.Com.Blog.Model.Models;
using AZLinli.Com.Blog.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZLinli.Com.Blog.Services
{
    public partial class UserServices : BaseServices<User>, IUserServices
    {
        IUserRepository dal;
        public UserServices(IUserRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
    }
}
