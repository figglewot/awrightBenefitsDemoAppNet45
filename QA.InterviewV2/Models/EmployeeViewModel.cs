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
        public decimal CostOfBenefits { get; set; } = (decimal)1000.00 / 26;
        public decimal PayAfterBenefits
        {
            get
            {
                if (Name.ToUpper().StartsWith("A"))
                {
                    return PayRate - (CostOfBenefits - ((CostOfBenefits) * (decimal).1));
                }
                else
                {
                    return PayRate - CostOfBenefits;
                }
            }
        }
        public IEnumerable<DependentViewModel> Dependents { get; set; }
    }
}