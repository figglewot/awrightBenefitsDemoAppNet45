using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.InterviewV2.Data.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal PayRate { get; set; }
        public ICollection<Dependent> Dependents { get; set; } 
    }
}
