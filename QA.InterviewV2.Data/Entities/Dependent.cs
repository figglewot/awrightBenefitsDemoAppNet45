using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.InterviewV2.Data.Entities
{
    public class Dependent
    {
        public int DependentId { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public Employee Employee { get; set; }
    }
}
