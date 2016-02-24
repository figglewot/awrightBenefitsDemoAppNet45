using NUnit.Framework;
using QA.InterviewV2.Data.Entities;
using QA.InterviewV2.Data.Repositories;
using QA.InterviewV2.Data.Context;

namespace QA.InterviewV2.UnitTests
{
    [TestFixture]
    public class EditEmployeeTests
    {
        private EmployeeContext _context;
        private EmployeeRepository _employeeRepo;

        public Employee editEmployee = new Employee
        {
            Name = "Charles Xavier",
            PayRate = 2000
        };

        [SetUp]
        public void EditEmployeeTests_DataSetUp()
        {
            _context = new EmployeeContext();
            _employeeRepo = new EmployeeRepository(_context);
        }

        [TearDown]
        public void EditEmployeeTests_DataTearDown()
        {
            _context = null;
            _employeeRepo = null;
        }

        [Test]
        public void EditEmployee_EditNameShouldPass()
        {
            //Arrange
            //Certainly there is a better way of doing this.
            var newEmployeeName = "Dieter Von Cunth";
            _employeeRepo.AddEmployee(editEmployee);
            _context.Employees.Local[0].Name = newEmployeeName;

            //Act
            _employeeRepo.EditEmployee(_context.Employees.Local[0]);

            //Assert
            Assert.That(_context.Employees.Local[0].Name, Is.EqualTo(newEmployeeName));
        }

        [Test]
        public void EditEmployee_EditNameNullShouldFail()
        {
            //Arrange
            string newEmployeeName = null;
            _employeeRepo.AddEmployee(editEmployee);
            _context.Employees.Local[0].Name = newEmployeeName;

            //Act
            _employeeRepo.EditEmployee(_context.Employees.Local[0]);

            //Assert
            Assert.That(() => _employeeRepo.SaveAll(), Throws.Exception);
        }

        [Test]
        public void EditEmployee_EditSalaryShouldPass()
        {
            //I don't actually allow this with the current client-side validation rules,
            //but we should still be able to do it if we force it.
            //Arrange
            decimal newEmployeeSalary = 1000;
            _employeeRepo.AddEmployee(editEmployee);
            _context.Employees.Local[0].PayRate = newEmployeeSalary;

            //Act
            _employeeRepo.EditEmployee(_context.Employees.Local[0]);

            //Assert
            Assert.That(_context.Employees.Local[0].PayRate, Is.EqualTo(newEmployeeSalary));
        }
    }
}
