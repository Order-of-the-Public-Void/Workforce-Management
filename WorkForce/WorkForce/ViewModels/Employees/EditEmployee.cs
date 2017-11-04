using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WorkForce.Models;

namespace WorkForce.ViewModels.Employees
{
    public class EditEmployee
    {
        public int EmployeeId { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public int DepartmentId { get; set; }
        public int ComputerId { get; set; }
        public virtual List<Training> Training{get; set;}
        public int NewTrainingId { get; set; }
    }
}