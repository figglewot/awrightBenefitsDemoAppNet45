using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA.InterviewV2.Data.Entities;

namespace QA.InterviewV2.Data.Managers
{
    public class BenefitCalculationManager: IBenefitCalculationManager
    {
        public decimal CalculateCostOfBenefits(Employee employee)
        {
            return employee.PayRate - CalculateDeduction(employee); 
        }

        public decimal CalculateCostOfBenefits(Dependent dependent)
        {
            return CalculateDeduction(dependent);
        }

        public decimal CalculateDeduction(Employee employee)
        {
            if (employee.Name.ToUpper().StartsWith("A"))
            {
                return ((decimal)(1000.00/26) - ((decimal)(1000.00/26) * (decimal).1));
            }

            return (decimal) (1000.00/26);
        }

        public decimal CalculateDeduction(Dependent dependent)
        {
            if (dependent.Name.ToUpper().StartsWith("A"))
            {
                return ((decimal)(500.00 / 26) - ((decimal)(500.00 / 26) * (decimal).1));
            }

            return (decimal)(500.00 / 26);
        }
    }
}
