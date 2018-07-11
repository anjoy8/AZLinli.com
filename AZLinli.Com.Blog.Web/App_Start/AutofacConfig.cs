using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace AZLinli.Com.Blog.Web
{
    public class AutofacConfig
    {
        /// <summary>
        /// 负责调用autofac框架实现业务逻辑层和数据仓储层程序集中的类型对象的创建
        /// 负责创建MVC控制器类的对象(调用控制器中的有参构造函数),接管DefaultControllerFactory的工作
        /// </summary>
        public static void Register()
        {
            //实例化一个autofac的创建容器
            var builder = new ContainerBuilder();
            //告诉Autofac框架，将来要创建的控制器类存放在哪个程序集 (Wchl.CRM.WebUI)
            Assembly controllerAss = Assembly.Load("AZLinli.Com.Blog.Web");
            builder.RegisterControllers(controllerAss);

            //告诉autofac框架注册数据仓储层所在程序集中的所有类的对象实例
            Assembly respAss = Assembly.Load("AZLinli.Com.Blog.Repository");
            //创建respAss中的所有类的instance以此类的实现接口存储
            builder.RegisterTypes(respAss.GetTypes()).AsImplementedInterfaces();

            //告诉autofac框架注册业务逻辑层所在程序集中的所有类的对象实例
            Assembly serpAss = Assembly.Load("AZLinli.Com.Blog.Services");
            //创建serAss中的所有类的instance以此类的实现接口存储
            builder.RegisterTypes(serpAss.GetTypes()).AsImplementedInterfaces();

            //builder.RegisterType<RedisCacheManager>().As<ICacheManager>();

            //创建一个Autofac的容器
            var container = builder.Build();

            //将container对象缓存到HttpRuntime.cache中，并且是永久有效
            //CacheMgr.SetData(Keys.AutofacContainer, container);

            //将MVC的控制器对象实例 交由autofac来创建
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }

}