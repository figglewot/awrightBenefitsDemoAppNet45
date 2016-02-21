using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA.InterviewV2.Data.Entities;

namespace QA.InterviewV2.Data.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        IEnumerable<Employee> GetAllEmployeesWithDependents();
        Employee GetEmployeesWithDependentsById(int employeeId);
        void AddEmployee(Employee newEmployee);
        void EditEmployee(Employee editEmployee);
        void DeleteEmployee(int id);
        void AddDependent(int employeeId, Dependent newDependent);
        bool SaveAll();

    }
}
