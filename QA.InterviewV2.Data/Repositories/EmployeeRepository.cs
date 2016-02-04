using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA.InterviewV2.Data.Context;
using QA.InterviewV2.Data.Entities;
using System.Data.Entity;

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
            return _context.Employees.OrderBy(x => x.Name).ToList();
        }

        public IEnumerable<Employee> GetAllEmployeesWithDependents()
        {
            return _context.Employees
                .Include(x => x.Dependents)
                .OrderBy(x => x.EmployeeId)
                .ToList();
        }

        public Employee GetEmployeesWithDependentsById(int employeeId)
        {
            return _context.Employees
                .Include(x => x.Dependents)
                .FirstOrDefault(x => x.EmployeeId == employeeId);
        }

        public void AddEmployee(Employee newEmployee)
        {
            _context.Employees.Add(newEmployee);
        }

        public void EditEmployee(Employee editEmployee)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.EmployeeId == editEmployee.EmployeeId);
            if (employee == null) return;
            employee.Name = editEmployee.Name;
            employee.PayRate = editEmployee.PayRate;
        }

        public Employee DeleteEmployee(int employeeId)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
            return _context.Employees.Remove(employee);
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
