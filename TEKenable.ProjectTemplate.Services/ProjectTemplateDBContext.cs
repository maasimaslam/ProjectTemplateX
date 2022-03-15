using System;
using System.Collections.Generic;
using System.Data.Entity;
using TEKenable.ProjectTemplate.Services.Configurations;
using TEKenable.ProjectTemplate.Services.Entities;

namespace TEKenable.ProjectTemplate.Services
{
    public class ProjectTemplateDBContext : DbContext
    {
        public ProjectTemplateDBContext()
            : base("ProjectTemplateDBContext")
        {
            Database.SetInitializer<ProjectTemplateDBContext>(new ProjectTemplateDBContextInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new CompanyConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companies { get; set; }


    }

    public class ProjectTemplateDBContextInitializer : DropCreateDatabaseIfModelChanges<ProjectTemplateDBContext>
    {
        protected override void Seed(ProjectTemplateDBContext context)
        {
            var companies = new List<Company>
            {
                new Company {    CompanyName = "Tera Data",
                    CompanyType = "Data Sciences", CompanyBusiness = "Software House",CompanyDepartment = "I.T.",
                    CompanyGrade = "B+", CompanyWebsite = "http://teradata.com", CompanyContact = "92518888888", CompanyEmail = "info@teradata.com"
                    },
                new Company {    CompanyName = "Elixir",
                    CompanyType = "Business Intelligence", CompanyBusiness = "Software House",CompanyDepartment = "I.T.",
                    CompanyGrade = "B+", CompanyWebsite = "http://elixir.com", CompanyContact = "92514565456", CompanyEmail = "info@elixir.com"
                     },
                new Company {   CompanyName = "Ovex Tech",
                    CompanyType = "SaaS", CompanyBusiness = "Software House",CompanyDepartment = "I.T.",
                    CompanyGrade = "B+", CompanyWebsite = "http://ovextech.com", CompanyContact = "92518968968", CompanyEmail = "info@ovextech"
                    },
                new Company {    CompanyName = "Bentley Systems",
                    CompanyType = "Data Composition", CompanyBusiness = "Software House",CompanyDepartment = "I.T.",
                    CompanyGrade = "B+", CompanyWebsite = "http://bentleysystems.com", CompanyContact = "92519586458", CompanyEmail = "info@bentleysystems.com"
                    },
                new Company {   CompanyName = "Quaid Technologies",
                    CompanyType = "Open Sources", CompanyBusiness = "Software House",CompanyDepartment = "I.T.",
                    CompanyGrade = "B+", CompanyWebsite = "http://quaidtechnologies.com", CompanyContact = "92517898789", CompanyEmail = "info@quaidtech.com"
                    },
                new Company {    CompanyName = "Avenir Tech",
                    CompanyType = "Data Sciences", CompanyBusiness = "Software House",CompanyDepartment = "I.T.",
                    CompanyGrade = "B+", CompanyWebsite = "http://avenirtech.com", CompanyContact = "92518888888", CompanyEmail = "info@avenirtech.com"
                     },
                new Company {    CompanyName = "Global Soft",
                    CompanyType = "Business Intelligence", CompanyBusiness = "Software House",CompanyDepartment = "I.T.",
                    CompanyGrade = "B+", CompanyWebsite = "http://globalsoft.com", CompanyContact = "92514565456", CompanyEmail = "info@globalsoft.com"
                   },
                new Company {   CompanyName = "Systems Tech",
                    CompanyType = "SaaS", CompanyBusiness = "Software House",CompanyDepartment = "I.T.",
                    CompanyGrade = "B+", CompanyWebsite = "http://systemstech.com", CompanyContact = "92518968968", CompanyEmail = "info@systemstech.com"
                    },
                new Company {    CompanyName = "Innovative Research",
                    CompanyType = "Data Composition", CompanyBusiness = "Software House",CompanyDepartment = "I.T.",
                    CompanyGrade = "B+", CompanyWebsite = "http://innovativeresearch.com", CompanyContact = "92519586458", CompanyEmail = "info@innovativeresearch.com"
                     },
                new Company {   CompanyName = "Quaid Strategic tech",
                    CompanyType = "Open Sources", CompanyBusiness = "Software House",CompanyDepartment = "I.T.",
                    CompanyGrade = "B+", CompanyWebsite = "http://quaidstrategic.com", CompanyContact = "92517898789", CompanyEmail = "info@quaidstrategic.com"
                    },
            };
            companies.ForEach(s => context.Companies.Add(s));
            context.SaveChanges();

            var users = new List<User>
            {
                new User {    first_name = "Abdul", last_name = "Hanan", user_name = "abdul.hanan@tekenable.com", password = "845954",
                    UserEmail = "abdul.hanan@tekenable.com", UserDepartment = "Software Engineering",EmployeeGrade = "B+.",
                    UserSalary = "855000" },
                new User {    first_name = "Atta", last_name = "Rehman", user_name = "atta.rehman@tekenable.com", password = "456456",
                    UserEmail = "atta.rehman@tekenable.com", UserDepartment = "Director Communicationb",EmployeeGrade = "A+.",
                    UserSalary = "855000"},
                new User {    first_name = "Khalid", last_name = "Khan", user_name = "khalid.khan@tekenable.com", password = "854856",
                    UserEmail = "khalid.khan@tekenable.com", UserDepartment = "Director Communicationb",EmployeeGrade = "A+.",
                    UserSalary = "855000"},
                new User {    first_name = "Imtiaz", last_name = "Jafri", user_name = "imtiaz.jafri@tekenable.com", password = "785985",
                    UserEmail = "imtiaz.jafri@tekenable.com", UserDepartment = "Director Communicationb",EmployeeGrade = "A+.",
                    UserSalary = "855000"},
                new User {    first_name = "Zeeshan", last_name = "Khan", user_name = "zeeshan.khan@tekenable.com", password = "125325",
                    UserEmail = "zeeshan.khan@tekenable.com", UserDepartment = "Director Communicationb",EmployeeGrade = "A+.",
                    UserSalary = "855000"},
                new User {    first_name = "Zia", last_name = "Bhatti", user_name = "zia.bhatti@tekenable.com", password = "959595",
                    UserEmail = "zia.bhatti@tekenable.com", UserDepartment = "Software Engineering",EmployeeGrade = "B+.",
                    UserSalary = "855000" },
                new User {    first_name = "Khurshid", last_name = "Alam", user_name = "khurshid.alam@tekenable.com", password = "454545",
                    UserEmail = "khurshid.alam@tekenable.com", UserDepartment = "Director Communicationb",EmployeeGrade = "A+.",
                    UserSalary = "855000" },
                new User {    first_name = "Khalid", last_name = "Khan", user_name = "Talat.Mehmood@tekenable.com", password = "656565",
                    UserEmail = "Talat.Mehmoodtekenable.com", UserDepartment = "Director Communicationb",EmployeeGrade = "A+.",
                    UserSalary = "855000" },
                new User {    first_name = "Shahab", last_name = "Rabbani", user_name = "shahab.rabbani@tekenable.com", password = "959595",
                    UserEmail = "shahab.rabbani@tekenable.com", UserDepartment = "Director Communicationb",EmployeeGrade = "A+.",
                    UserSalary = "855000" },
                new User {    first_name = "Sohail", last_name = "Warraich", user_name = "sohail.warraich@tekenable.com", password = "525252",
                    UserEmail = "sohail.warraich@tekenable.com", UserDepartment = "Director Communicationb",EmployeeGrade = "A+.",
                    UserSalary = "855000" },

            };
            users.ForEach(x => context.Users.Add(x));
            context.SaveChanges();

            //var roles = new List<Role>
            //{
            //new Role { RoleName = "Administration"},
            //new Role { RoleName = "Normal"},
            //new Role { RoleName = "Anonymous"},
            //};
            //roles.ForEach(t => context.Roles.Add(t));
            //context.SaveChanges();

            //Administration set starts
            var roleAdministration = new Role() { role_id = (int)Roles.Administrator, role_name = Roles.Administrator.ToString() };

            context.Roles.Add(roleAdministration);
            context.Users.Add(new User()
            {

                user_name = "aasim.aslam@tekenable.com",
                first_name = "Aasim",
                last_name = "Aslam",
                password = "987654",
                UserEmail = "aasim.aslam@tekenable.com",
                UserDepartment = "Software Development",
                EmployeeGrade = "B+",
                UserSalary = "985000",
                //UserAdded = DateTime.Parse("2022-03-01"),

                Roles = new List<Role>() { roleAdministration }
            });
            context.SaveChanges();
            //Administration set ends
            base.Seed(context);
        }
    }
}
