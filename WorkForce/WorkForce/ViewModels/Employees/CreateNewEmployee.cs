using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkForce.ViewModels.Employees
{
    public class CreateNewEmployee
    {
        [Required]
        [Display(Name = "Last Name")]
        public int LastName { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

         
    }
}