using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
        public IHttpActionResult Get()
        {
            //Perhaps Service Action should be same as repo method name for consistency?
            var results = Mapper.Map<IEnumerable<EmployeeViewModel>>(_employeeRepository.GetAllEmployeesWithDependents());
            return Ok(results);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var results = Mapper.Map<EmployeeViewModel>(_employeeRepository.GetEmployeesWithDependentsById(id));
            return Ok(results);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]EmployeeViewModel viewModel)
        {
            try
            {
                var newEmployee = Mapper.Map<Employee>(viewModel);
                _employeeRepository.AddEmployee(newEmployee);
                if (_employeeRepository.SaveAll())
                {     
                    return Created("",Mapper.Map<EmployeeViewModel>(newEmployee));
                }
            }
            catch (Exception ex)
            {
                //Out of concerns for security, we do need to be careful showing raw exception data, but for this case it should be fine.
                return BadRequest(ex.Message);
            }

            return BadRequest();
        }

        [HttpPatch]
        public IHttpActionResult Patch([FromBody]EmployeeViewModel viewModel, int id)
        {
            try
            {
                var editEmployee = Mapper.Map<Employee>(viewModel);
                _employeeRepository.EditEmployee(editEmployee);
                if (_employeeRepository.SaveAll())
                {   
                    return Ok(Mapper.Map<EmployeeViewModel>(editEmployee));
                }
            }
            catch (Exception ex)
            {
                //Out of concerns for security, we do need to be careful showing raw exception data, but for this case it should be fine.
                return BadRequest(ex.ToString());
            }

            return BadRequest();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _employeeRepository.DeleteEmployee(id);
                if (_employeeRepository.SaveAll())
                {   
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                //Out of concerns for security, we do need to be careful showing raw exception data, but for this case it should be fine.
                return BadRequest(ex.Message);
            }

            return BadRequest();
        }
    }
}
