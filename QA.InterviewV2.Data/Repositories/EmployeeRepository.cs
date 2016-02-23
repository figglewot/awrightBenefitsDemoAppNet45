using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA.InterviewV2.Data.Context;
using QA.InterviewV2.Data.Entities;
using System.Data.Entity;
using QA.InterviewV2.Data.Managers;

namespace QA.InterviewV2.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            //We can pull the result ordering from the server-side and move it to the client-side using angular's
            //orderBy filter.. i.e. employee in employees | orderBy: 'Name'.
            //Doing that may buy us some performance gains. But for this example, I will keep the server-side logic.
            return _context.Employees.OrderBy(x => x.Name).ToList();
        }

        public IEnumerable<Employee> GetAllEmployeesWithDependents()
        {
            return _context.Employees
                .Include(x => x.Dependents)
                .OrderBy(x => x.EmployeeId)
                .ToList();
        }

        //Using.Single and.SingleOrDefault does have some negative implications which can be discussed as well
        //as some positive ones, however, for this example, I wanted to show that we can do more than just.First and .FirstOrDefault,
        //especially for working with smaller datasets where the negative implications aren't inherent.
        public Employee GetEmployeesWithDependentsById(int employeeId)
        {
            return _context.Employees
                .Include(x => x.Dependents)
                .SingleOrDefault(x => x.EmployeeId == employeeId);
        }

        public void AddEmployee(Employee newEmployee)
        {
            _context.Employees.Add(newEmployee);
        }

        public void EditEmployee(Employee editEmployee)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.EmployeeId == editEmployee.EmployeeId);
            if (employee == null) return;
            employee.Name = editEmployee.Name;
            employee.PayRate = editEmployee.PayRate;
        }

        public void DeleteEmployee(int employeeId)
        {
            var employee = _context.Employees
                .Include(x => x.Dependents)
                .Single(x => x.EmployeeId == employeeId);
            _context.Employees.Remove(employee);
        }

        public void AddDependent(int employeeId, Dependent newDependent)
        {
            var employeeToAddDependent = GetEmployeesWithDependentsById(employeeId);
            employeeToAddDependent.Dependents.Add(newDependent);
            _context.Dependents.Add(newDependent);
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
