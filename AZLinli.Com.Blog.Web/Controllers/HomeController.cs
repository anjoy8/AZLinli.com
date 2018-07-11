using AZLinli.Com.Blog.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AZLinli.Com.Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        IUserServices userServices;

        public HomeController(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        // GET: Home
        public ActionResult Index()
        {
            var users = userServices.QueryWhere(c => c.uID > 0).FirstOrDefault();
            return Content(users != null ? users.uLoginName : "老张好呀");
        }
    }
}