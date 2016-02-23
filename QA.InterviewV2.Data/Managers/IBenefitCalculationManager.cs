using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA.InterviewV2.Data.Entities;

namespace QA.InterviewV2.Data.Managers
{
    public interface IBenefitCalculationManager
    {
        decimal CalculateCostOfBenefits(Employee employee);
        decimal CalculateCostOfBenefits(Dependent dependent);

        decimal CalculateDeduction(Employee employee);

        decimal CalculateDeduction(Dependent dependent);
    }
}
