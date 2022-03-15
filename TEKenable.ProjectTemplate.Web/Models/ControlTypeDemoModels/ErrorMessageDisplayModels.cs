using System;
using System.ComponentModel.DataAnnotations;

namespace TEKenable.ProjectTemplate.Web.Models.Demo
{
    public class EMDEmployee
    {
        public Int32 Id { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(20, ErrorMessage = "First Name cannot exceed 20 characters!")]
        [Required(ErrorMessage = "First Name is required")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(20, ErrorMessage = "Last Name cannot exceed 20 characters!")]
        [Required(ErrorMessage = "Last Name is required")]
        public String LastName { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "Age is required")]
        public Byte Age { get; set; }

        [Display(Name = "Cars Nr.")]
        [Required(ErrorMessage = "Cars Nr. is required")]
        [Range(0, 4, ErrorMessage = "Number of Cars has to be between 0 and 4")]
        public Byte NumberOfCars { get; set; }

        [Display(Name = "Dogs Nr.")]
        [Required(ErrorMessage = "Dogs Nr. is required")]
        public Byte NumberOfDogs { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Company Name is required")]
        public String CompanyName { get; set; }

        [Display(Name = "Position")]
        [Required(ErrorMessage = "Position is required")]
        public String Position { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Department is required")]
        public String Department { get; set; }


    }
}
