using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QA.InterviewV2.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public decimal PayRate { get; set; }

        public decimal CostOfBenefits { get; set; }

        public decimal PayAfterBenefits { get; set; }

        public IEnumerable<DependentViewModel> Dependents { get; set; }
    }
}