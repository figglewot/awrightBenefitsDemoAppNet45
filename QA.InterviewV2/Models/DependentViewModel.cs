using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.InterviewV2.Models
{
    public class DependentViewModel
    {
        public int DependentId { get; set; }
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal CostOfBenefits
        {
            get
            {
                if (Name.ToUpper().StartsWith("A"))
                {
                    return (decimal)(500.00 / 26 - (500.00 / 26 * .1));
                }
                else
                {
                    return (decimal)(500.00 / 26);
                }
            }
        }
    }
}
