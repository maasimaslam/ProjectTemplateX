using System;
using System.ComponentModel.DataAnnotations;

namespace TEKenable.ProjectTemplate.Services.Entities
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public string CompanyType { get; set; }

        public string CompanyBusiness { get; set; }

        public string CompanyDepartment { get; set; }

        public string CompanyGrade { get; set; }

        public string CompanyWebsite { get; set; }

        public string CompanyContact { get; set; }

        public string CompanyEmail { get; set; }

       // public DateTime CompanyAdded { get; set; }

        //public virtual User User { get; set; }

    }
}
