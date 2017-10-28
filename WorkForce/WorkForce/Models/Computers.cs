using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkForce.Models
{
    public class Computers
    {
        [Key]
        public int ComputerId { get; set; }
        public int EmployeeId { get; set; }
        public string Manufacturer { get; set; }
        public string Make { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}