using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NewspaperAdManagementSystem.Models
{
    public class EmployDetailsClass
    {
        [Key]
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpContactNo { get; set; }
        public string EmailID { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pwd { get; set; }
        public string Role { get; set; }
    }
}
