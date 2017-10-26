using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkForce.Models
{
	public class Employee
	{
		public int EmployeeId {get; set;}
		public string LastName { get; set; }
		public string FirstName { get; set; }
        public DateTime StartDate { get; set; }

        //public virtual Computer Computer { get; set; }
        //public virtual List<Training> Training { get; set; }
        public virtual Department Department { get; set; }
    }
}