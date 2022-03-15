using PagedList;
using System.ComponentModel.DataAnnotations;

namespace TEKenable.ProjectTemplate.Web.Models.Admin
{
    public class CompanySearchModel
    {
        public int? page { get; set; }
        public string sortOrder { get; set; }

        public string CurrentSort { get; set; }

        public string SortParm { get; set; }

        public string searchString { get; set; }

        public string currentFilter { get; set; }

        public IPagedList<CompanyOutModel> ListData { get; set; }
    }

    public class CompanyOutModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public string CompanyBusiness { get; set; }
        public string CompanyDepartment { get; set; }
        public string CompanyGrade { get; set; }
        public string CompanyWebsite { get; set; }
        public string CompanyContact { get; set; }
        public string CompanyEmail { get; set; }
    }

    public class CompanyInModel
    {
        public int CompanyId { get; set; }

        [Required]
        //[StringLength(100)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
       // [StringLength(100)]
        [Display(Name = "Company Type")]
        public string CompanyType { get; set; }

        [Required]
        //[StringLength(100)]
        [Display(Name = "Company Business")]
        public string CompanyBusiness { get; set; }

        [Required]
        //[StringLength(100)]
        [Display(Name = "Company Department")]
        public string CompanyDepartment { get; set; }

        [Required]
        //[StringLength(100)]
        [Display(Name = "Company Grade")]
        public string CompanyGrade { get; set; }

        [Url]
        [Required]
        //[StringLength(100)]
        [Display(Name = "Company Website")]
        public string CompanyWebsite { get; set; }

        [Required]
        //[StringLength(100)]
        [Display(Name = "Company Contact")]
        public string CompanyContact { get; set; }

        [Required]
        //[StringLength(100)]
        [Display(Name = "Company Email")]
        public string CompanyEmail { get; set; }

    }
}