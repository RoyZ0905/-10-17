namespace WebApplication3
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BlogDatabase : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“NewsDatabase”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“WebApplication3.NewsDatabase”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“NewsDatabase”
        //连接字符串。
        public BlogDatabase()
            : base("name=BlogDatabase")
        {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

         public virtual DbSet<Blog> Blog { get; set; }
    }

    /// <summary>
    /// 博客
    /// </summary>
    public class Blog
    {
        public int Id { get; set; }
    }
}