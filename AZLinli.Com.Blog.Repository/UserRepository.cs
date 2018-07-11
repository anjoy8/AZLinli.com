using AZLinli.Com.Blog.IRepository;
using AZLinli.Com.Blog.Model.Models;
using AZLinli.Com.Blog.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZLinli.Com.Blog.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
    }
}
