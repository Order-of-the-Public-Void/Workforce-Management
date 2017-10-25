using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkForce.Models
{
    public class Training
    {
        public int TrainingId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public int MaxAttendees { get; set; }
        public virtual List<Employee> Employees{ get; set; }
    }
  }