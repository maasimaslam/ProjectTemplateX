using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TEKenable.ProjectTemplate.Services.Entities
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string user_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string password { get; set; }
        public string UserEmail { get; set; }
        public string UserDepartment { get; set; }
        public string EmployeeGrade { get; set; }
        public string UserSalary { get; set; }

        //public DateTime UserAdded { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", first_name, last_name);
            }
        }

        public virtual List<Role> Roles { get; set; }
        //public virtual Company Company { get; set; }
    }
}
