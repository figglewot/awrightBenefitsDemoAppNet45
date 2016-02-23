using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA.InterviewV2.Data.Managers;

namespace QA.InterviewV2.Data.Entities
{
    public class Employee
    {
        private readonly BenefitCalculationManager _benefitCalculationManager = new BenefitCalculationManager();

        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal PayRate { get; set; }

        public decimal CostOfBenefits => _benefitCalculationManager.CalculateDeduction(this);

        public decimal PayAfterBenefits => _benefitCalculationManager.CalculateCostOfBenefits(this);
        public ICollection<Dependent> Dependents { get; set; } 
    }
}
