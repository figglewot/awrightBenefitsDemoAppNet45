using System.Security.Policy;
using NUnit.Framework;
using QA.InterviewV2.Data.Entities;
using QA.InterviewV2.Data.Repositories;
using QA.InterviewV2.Data.Context;

namespace QA.InterviewV2.UnitTests
{
    [TestFixture]
    public class AddEmployeeTests
    {
        private EmployeeContext _context;
        private EmployeeRepository _employeeRepo;
        private const int ValidEmployeeId = 1337;
        private const string ValidEmployeeName = "GetYour TestOn";
        private const decimal ValidEmployeePayRate = 2000;
        private const string InvalidEmployeeName = null;
        private const int ValidDependentId = 9001;
        private const string ValidDependentName = "CoolKid McCoolington";

        [SetUp]
        public void AddEmployeeTests_DataSetUp()
        {
            _context = new EmployeeContext();
            _employeeRepo = new EmployeeRepository(_context);
        }

        [TearDown]
        public void AddEmployeeTests_DataTearDown()
        {
            _context = null;
            _employeeRepo = null;
        }

        [Test]
        public void AddEmployee_ShouldAddEmployeeToContext()
        {
            //Arrange
            var validEmployee = new Employee
            {
                EmployeeId = ValidEmployeeId,
                Name = ValidEmployeeName,
                PayRate = ValidEmployeePayRate
            };

            //Act
            _employeeRepo.AddEmployee(validEmployee);
            _employeeRepo.SaveAll();
            var validatedEmployee = _context.Employees.Local[0];

            //Assert
            Assert.That(validEmployee, Is.EqualTo(validatedEmployee));

        }

        [Test]
        public void AddEmployee_NoNameShouldFail()
        {
            //Arrange
            var invalidEmployee = new Employee
            {
                EmployeeId = ValidEmployeeId,
                Name = InvalidEmployeeName,
                PayRate = ValidEmployeePayRate
            };

            //Act
            _employeeRepo.AddEmployee(invalidEmployee);

            //Assert
            Assert.That(() => _employeeRepo.SaveAll(), Throws.Exception);

        }

        [Test]
        public void AddEmployee_ShouldAddEmployeeToContextWithDependent()
        {
            var validEmployee = new Employee
            {
                EmployeeId = ValidEmployeeId,
                Dependents = new[]
                {
                    new Dependent
                    {
                        DependentId = ValidDependentId,
                        EmployeeId = ValidEmployeeId,
                        Name = ValidDependentName
                    }
                },
                Name = ValidEmployeeName,
                PayRate = ValidEmployeePayRate
            };

            _employeeRepo.AddEmployee(validEmployee);
            _employeeRepo.SaveAll();
            var validatedEmployee = _context.Employees.Local[0];

            Assert.That(validEmployee, Is.EqualTo(validatedEmployee));
        }

        [Test]
        public void AddEmployee_ShouldAddMultipleEmployeesToContext()
        {
            var validEmployee = new Employee
            {
                EmployeeId = ValidEmployeeId,
                Name = ValidEmployeeName,
                PayRate = ValidEmployeePayRate
            };
            var validEmployee2 = new Employee
            {
                EmployeeId = 1338,
                Name = "Dio",
                PayRate = ValidEmployeePayRate
            };
            var validEmployee3 = new Employee
            {
                EmployeeId = 1339,
                Name = "Jack Black",
                PayRate = ValidEmployeePayRate
            };

            //Act
            _employeeRepo.AddEmployee(validEmployee);
            _employeeRepo.AddEmployee(validEmployee2);
            _employeeRepo.AddEmployee(validEmployee3);
            _employeeRepo.SaveAll();
            var validatedEmployee = _context.Employees.Local[0];
            var validatedEmployee2 = _context.Employees.Local[1];
            var validatedEmployee3 = _context.Employees.Local[2];

            //Assert
            Assert.That(validEmployee, Is.EqualTo(validatedEmployee));
            Assert.That(validEmployee2, Is.EqualTo(validatedEmployee2));
            Assert.That(validEmployee3, Is.EqualTo(validatedEmployee3));
        }

        [Test]
        public void AddEmployee_ShouldAddEmployeeWithMultipleDependentsToContext()
        {
            var validEmployee = new Employee
            {
                EmployeeId = ValidEmployeeId,
                Dependents = new[]
                 {
                    new Dependent
                    {
                        DependentId = ValidDependentId,
                        EmployeeId = ValidEmployeeId,
                        Name = ValidDependentName
                    },

                    new Dependent
                    {
                        DependentId = 9002,
                        EmployeeId = ValidEmployeeId,
                        Name = "Howard Jones"
                    },

                    new Dependent
                    {
                        DependentId = 9003,
                        EmployeeId = ValidEmployeeId,
                        Name = "Lzzy Hale"
                    }
                },
                Name = ValidEmployeeName,
                PayRate = ValidEmployeePayRate
            };

            _employeeRepo.AddEmployee(validEmployee);
            _employeeRepo.SaveAll();
            var validatedEmployee = _context.Employees.Local[0];

            Assert.That(validEmployee, Is.EqualTo(validatedEmployee));
        }

        [Test]
        public void AddEmployee_ShouldAddMultipleEmployeesWithMultipleDependentsToContext()
        {
            var validEmployee = new Employee
            {
                EmployeeId = ValidEmployeeId,
                Dependents = new []
                {
                    new Dependent
                    {
                        EmployeeId = ValidEmployeeId,
                        DependentId = ValidDependentId,
                        Name = ValidDependentName
                    }
                },
                Name = ValidEmployeeName,
                PayRate = ValidEmployeePayRate
            };
            var validEmployee2 = new Employee
            {
                EmployeeId = 1338,
                Dependents = new []
                {
                    new Dependent
                    {
                        EmployeeId = 1338,
                        DependentId = 9002,
                        Name = "Lzzy Hale"
                    },
                    new Dependent
                    {
                        EmployeeId = 1338,
                        DependentId = 9003,
                        Name = "Tarja Turunen"
                    }
                },
                Name = "Dio",
                PayRate = ValidEmployeePayRate
            };
            var validEmployee3 = new Employee
            {
                EmployeeId = 1339,
                Dependents = new []
                {
                    new Dependent
                    {
                        EmployeeId = 1339,
                        DependentId = 9004,
                        Name = "Wayne Static"
                    },
                    new Dependent
                    {
                        EmployeeId = 1339,
                        DependentId = 9005,
                        Name = "Freddie Mercury"
                    },
                    new Dependent
                    {
                        EmployeeId = 1339,
                        DependentId = 9006,
                        Name = "John BonJovi"
                    }
                },
                Name = "Jack Black",
                PayRate = ValidEmployeePayRate
            };

            //Act
            _employeeRepo.AddEmployee(validEmployee);
            _employeeRepo.AddEmployee(validEmployee2);
            _employeeRepo.AddEmployee(validEmployee3);
            _employeeRepo.SaveAll();
            var validatedEmployee = _context.Employees.Local[0];
            var validatedEmployee2 = _context.Employees.Local[1];
            var validatedEmployee3 = _context.Employees.Local[2];

            //Assert
            Assert.That(validEmployee, Is.EqualTo(validatedEmployee));
            Assert.That(validEmployee2, Is.EqualTo(validatedEmployee2));
            Assert.That(validEmployee3, Is.EqualTo(validatedEmployee3));
        }
    }
}
