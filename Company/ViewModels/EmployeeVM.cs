using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Company.ViewModels
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Range(18, 99)] 
        public int Age { get; set; }
        [StringLength(100)]
        public string? Address { get; set; }
        [Range(0, double.MaxValue)]
        public float? Salary { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
       
        [Display(Name = "Office")]
        public int Office_id { get; set; }

        //Minimum eight characters, at least one letter and one number
        [RegularExpression("^(?=.*[A-Za-z])(?=.*[0-9])[A-Za-z0-9]{8,}$")]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [ValidateNever]
        public SelectList Offices { get; set; }
    }
}
