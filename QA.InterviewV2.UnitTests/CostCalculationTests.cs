using NUnit.Framework;
using QA.InterviewV2.Data.Entities;
using QA.InterviewV2.Data.Repositories;
using QA.InterviewV2.Data.Context;

namespace QA.InterviewV2.UnitTests
{
    [TestFixture]
    public class CostCalculationTests
    {
        private EmployeeContext _context;
        private EmployeeRepository _employeeRepo;
        private const decimal employeeNoDiscountCost = 38.4615384615385m;
        private const decimal employeeDiscountCost = 34.61538461538465m;
        private const decimal dependentNoDiscountCost = 19.2307692307692m;
        private const decimal dependentDiscountCost = 17.30769230769228m;

        [SetUp]
        public void CostCalculationTests_DataSetUp()
        {
            _context = new EmployeeContext();
            _employeeRepo = new EmployeeRepository(_context);
        }

        [TearDown]
        public void CostCalculationTests_DataTearDown()
        {
            _context = null;
            _employeeRepo = null;
        }

        [Test]
        public void CostCalculation_DiscountNotApplied()
        {
            //Arrange
            var noDiscountEmployee = new Employee
            {
                Name = "Macgruber",
                PayRate = 2000
            };

            //Act
            _employeeRepo.AddEmployee(noDiscountEmployee);
            var employee = _context.Employees.Local[0];

            //Assert
            Assert.That(employee.CostOfBenefits, Is.EqualTo(employeeNoDiscountCost));
        }

        [Test]
        public void CostCalculation_DiscountAppliedUpperCase()
        {
            //Arrange
            var noDiscountEmployee = new Employee
            {
                Name = "Arthas Menethil",
                PayRate = 2000
            };

            //Act
            _employeeRepo.AddEmployee(noDiscountEmployee);
            var employee = _context.Employees.Local[0];

            //Assert
            Assert.That(employee.CostOfBenefits, Is.EqualTo(employeeDiscountCost));
        }

        [Test]
        public void CostCalculation_DiscountAppliedLowerCase()
        {
            //Arrange
            var noDiscountEmployee = new Employee
            {
                Name = "avenged sevenfold",
                PayRate = 2000
            };

            //Act
            _employeeRepo.AddEmployee(noDiscountEmployee);
            var employee = _context.Employees.Local[0];

            //Assert
            Assert.That(employee.CostOfBenefits, Is.EqualTo(employeeDiscountCost));
        }

        [Test]
        public void CostCalculation_NoDiscountAppliedToDependent()
        {
            //Arrange
            var noDiscountDependent = new Dependent
            {
                Name = "Tyrande"
            };

            //Act
            _context.Dependents.Add(noDiscountDependent);
            var dependent = _context.Dependents.Local[0];
            

            //Assert
            Assert.That(dependent.CostOfBenefits, Is.EqualTo(dependentNoDiscountCost));
        }

        [Test]
        public void CostCalculation_DiscountAppliedToDependentUpperCase()
        {
            //Arrange
            var noDiscountDependent = new Dependent
            {
                Name = "Attack Attack"
            };

            //Act
            _context.Dependents.Add(noDiscountDependent);
            var dependent = _context.Dependents.Local[0];


            //Assert
            Assert.That(dependent.CostOfBenefits, Is.EqualTo(dependentDiscountCost));
        }

        [Test]
        public void CostCalculation_DiscountAppliedToDependentLowerCase()
        {
            //Arrange
            var noDiscountDependent = new Dependent
            {
                Name = "august burns red"
            };

            //Act
            _context.Dependents.Add(noDiscountDependent);
            var dependent = _context.Dependents.Local[0];


            //Assert
            Assert.That(dependent.CostOfBenefits, Is.EqualTo(dependentDiscountCost));
        }
    }
}
