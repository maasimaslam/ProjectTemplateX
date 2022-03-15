using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TEKenable.ProjectTemplate.Services.Entities;

namespace TEKenable.ProjectTemplate.Services.Configurations
{

    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("tbl_user_permitted");
            HasKey(t => t.id);

            Property(t => t.id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(t => t.first_name)
                .HasColumnName("first_name");
                //  .HasMaxLength(100)
                //.IsRequired();

            Property(t => t.last_name)
                .HasColumnName("last_name");
                // .HasMaxLength(100)
                // .IsRequired();

            Property(t => t.user_name)
                .HasColumnName("user_name");
                //.HasMaxLength(100)
                //.IsRequired();

            Property(t => t.password)
                .HasColumnName("password");

            Property(t => t.UserEmail)
                    .HasColumnName("UserEmail");
                //.HasMaxLength(100)
                //.IsRequired();

            Property(t => t.UserDepartment)
                .HasColumnName("UserDepartment");
                //.HasMaxLength(100)
                //.IsRequired();

            Property(t => t.EmployeeGrade)
                .HasColumnName("EmployeeGrade");
                //.HasMaxLength(100)
                //.IsRequired();

            Property(t => t.UserSalary)
                .HasColumnName("UserSalary");
                //.HasMaxLength(100)
                //.IsRequired();

            //Property(t => t.UserAdded)
            //    .HasColumnName("UserAdded")
            //    .IsRequired();

            HasMany(t => t.Roles)
                .WithMany(t => t.Users)
                .Map(m =>
                {
                    m.ToTable("tbl_user_role");
                    m.MapLeftKey("user_id");
                    m.MapRightKey("role_id");
                });



        }
    }
}
