using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkForce.Models
{
	public class Employee
	{   
        [Required]
		public int EmployeeId {get; set;}
		public string LastName { get; set; }
		public string FirstName { get; set; }
        public DateTime StartDate { get; set; }
        public int DeptId { get; set; }
	}
}