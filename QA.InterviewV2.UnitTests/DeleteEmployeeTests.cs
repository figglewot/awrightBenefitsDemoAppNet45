using NUnit.Framework;
using QA.InterviewV2.Data.Entities;
using QA.InterviewV2.Data.Repositories;
using QA.InterviewV2.Data.Context;
namespace QA.InterviewV2.UnitTests
{
    [TestFixture]
    public class DeleteEmployeeTests
    {
        private EmployeeContext _context;
        private EmployeeRepository _employeeRepo;

        public Employee deleteEmployee = new Employee
        {
            Name = "Axl Rose",
            PayRate = 2000
        };

        [SetUp]
        public void DeleteEmployeeTests_DataSetUp()
        {
            _context = new EmployeeContext();
            _employeeRepo = new EmployeeRepository(_context);
        }

        [TearDown]
        public void DeleteEmployeeTests_DataTearDown()
        {
            _context = null;
            _employeeRepo = null;
        }

        [Test]
        public void DeleteEmployee_ShouldDeleteEmployee()
        {
            //Arrange
            _employeeRepo.AddEmployee(deleteEmployee);

            //Act
            _context.Employees.Remove(_context.Employees.Local[0]);

            //Assert
            Assert.That(_context.Employees.Local, Is.Empty);
        }
    }
}
