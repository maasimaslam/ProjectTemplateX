using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TEKenable.ProjectTemplate.Services.Entities;

namespace TEKenable.ProjectTemplate.Services.Configurations
{
    public class CompanyConfiguration : EntityTypeConfiguration<Company>
    {
        public CompanyConfiguration()
        {
            ToTable("tbl_Company");
            HasKey(t => t.CompanyId);

            Property(t => t.CompanyId)
                .HasColumnName("CompanyId")
                //.HasColumnType("uniqueidentifier")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.CompanyName)
                .HasColumnName("CompanyName");
            //.HasMaxLength(100);
            // .IsRequired();

            Property(t => t.CompanyType)
                .HasColumnName("CompanyType");
            // .HasMaxLength(100);
            // .IsRequired();

            Property(t => t.CompanyBusiness)
                .HasColumnName("CompanyBusiness");
            //.HasMaxLength(100);
            // .IsRequired();

            Property(t => t.CompanyDepartment)
                .HasColumnName("CompanyDepartment");
            //.HasMaxLength(100);
            //.IsRequired();

            Property(t => t.CompanyGrade)
                .HasColumnName("CompanyGrade");
                //.HasMaxLength(100);
            //.IsRequired();

           // Property(t => t.CompanyAdded)
               // .HasColumnName("CompanyAdded");
            //.IsRequired();

            //HasMany(t => t.Users)
            //.WithMany(t => t.Companies)
            //.Map(m =>
            //{
            //    m.ToTable("tbl_user_permitted");
            //    m.MapLeftKey("CompanyId");
            //    m.MapRightKey("user_id");
            //});
        }
    }
}
