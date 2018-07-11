namespace AZLinli.Com.Blog.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Reflection;

    public class AZBlogDB : DbContext
    {
        // Your context has been configured to use a 'AZBlogDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AZLinli.Com.Blog.Model.AZBlogDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AZBlogDB' 
        // connection string in the application configuration file.
        public AZBlogDB()
            : base("name=AZBlogDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}