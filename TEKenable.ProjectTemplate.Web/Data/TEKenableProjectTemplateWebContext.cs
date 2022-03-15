using System.Data.Entity;

namespace TEKenable.ProjectTemplate.Web.Data
{
    public class TEKenableProjectTemplateWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public TEKenableProjectTemplateWebContext() : base("name=TEKenableProjectTemplateWebContext")
        {
        }

        public System.Data.Entity.DbSet<TEKenable.ProjectTemplate.Services.Entities.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<TEKenable.ProjectTemplate.Services.Entities.User> Users { get; set; }
    }
}
