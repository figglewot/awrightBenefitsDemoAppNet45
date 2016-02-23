using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA.InterviewV2.Data.Managers;

namespace QA.InterviewV2.Data.Entities
{
    public class Dependent
    {
        private readonly BenefitCalculationManager _benefitCalculationManager = new BenefitCalculationManager();
        public int DependentId { get; set; }
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }

        public decimal CostOfBenefits => _benefitCalculationManager.CalculateCostOfBenefits(this);

        public Employee Employee { get; set; }
    }
}
