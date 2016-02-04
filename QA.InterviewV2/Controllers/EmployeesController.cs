using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using QA.InterviewV2.Data.Entities;
using QA.InterviewV2.Data.Repositories;
using QA.InterviewV2.Models;

namespace QA.InterviewV2.Controllers
{
    [Route("api/employees/{id?}")]
    public class EmployeesController : ApiController
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IEnumerable<EmployeeViewModel> Get()
        {
            var results = Mapper.Map<IEnumerable<EmployeeViewModel>>(_employeeRepository.GetAllEmployeesWithDependents());
            return results;
        }

        [HttpGet]
        public EmployeeViewModel Get(int id)
        {
            var results = Mapper.Map<EmployeeViewModel>(_employeeRepository.GetEmployeesWithDependentsById(id));
            return results;
        }

        [HttpPost]
        public EmployeeViewModel Post([FromBody]EmployeeViewModel viewModel)
        {
            var newEmployee = Mapper.Map<Employee>(viewModel);
            _employeeRepository.AddEmployee(newEmployee);
            _employeeRepository.SaveAll();
            return Mapper.Map<EmployeeViewModel>(newEmployee);
        }

        [HttpPost]
        public EmployeeViewModel Post([FromBody]EmployeeViewModel viewModel, int id)
        {
            var newEmployee = Mapper.Map<Employee>(viewModel);
            var editEmployee = Mapper.Map<Employee>(viewModel);
            if (id > 0)
            {
                _employeeRepository.EditEmployee(editEmployee);
            }
            else
            {
                _employeeRepository.AddEmployee(newEmployee);
            }
            _employeeRepository.SaveAll();
            return Mapper.Map<EmployeeViewModel>(newEmployee);
        }

        [HttpDelete]
        public Employee Delete(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            _employeeRepository.SaveAll();
            return null;
        }
    }
}
