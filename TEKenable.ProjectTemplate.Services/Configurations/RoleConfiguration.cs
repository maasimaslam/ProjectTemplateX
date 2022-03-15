using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TEKenable.ProjectTemplate.Services.Entities;

namespace TEKenable.ProjectTemplate.Services.Configurations
{

    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            ToTable("tbl_role");
            HasKey(t => t.role_id);

            Property(t => t.role_id)
                .HasColumnName("role_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.role_name)
                .HasColumnName("role_name");
                //.HasMaxLength(256)
                //.IsRequired();
        }
    }
}
