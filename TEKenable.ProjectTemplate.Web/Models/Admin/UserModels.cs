using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TEKenable.ProjectTemplate.Web.Models.Admin
{
    public class UserSearchModel
    {
        public int? page { get; set; }
        public string sortOrder { get; set; }

        public string CurrentSort { get; set; }

        public string SortParm { get; set; }

        public string searchString { get; set; }

        public string currentFilter { get; set; }

        public IPagedList<UserOutModel> ListData { get; set; }
    }

    public class UserOutModel
    {
        public int id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string UserEmail { get; set; }
        public string UserDepartment { get; set; }
        public string EmployeeGrade { get; set; }
        public string UserSalary { get; set; }
        //public string UserAdded { get; set; }
    }

    public class UserInModel
    {
        public int id { get; set; }

        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Username")]
        public string user_name { get; set; }

        [Required]
        //[StringLength(100)]
        [Display(Name = "First Name")]
        public string first_name { get; set; }

        [Required]
        //[StringLength(100)]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }

        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [CompareAttribute("password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        //[StringLength(100)]
        [Display(Name = "Department")]
        public string UserDepartment { get; set; }

        [Required]
        //[StringLength(100)]
        [Display(Name = "Grade")]
        public string EmployeeGrade { get; set; }

        [Required]
       // [StringLength(100)]
        [Display(Name = "Salary")]
        public string UserSalary { get; set; }

        [Display(Name = "Roles")]
        public List<Int32> SelectedRoles { get; set; }

        public UserInModel()
        {
            SelectedRoles = new List<int>();
        }
    }
}