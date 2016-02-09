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
        public HttpResponseMessage Get()
        {
            //Perhaps Service Action should be same as repo method name for consistency?
            var results = Mapper.Map<IEnumerable<EmployeeViewModel>>(_employeeRepository.GetAllEmployeesWithDependents());
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var results = Mapper.Map<EmployeeViewModel>(_employeeRepository.GetEmployeesWithDependentsById(id));
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]EmployeeViewModel viewModel)
        {
            try
            {
                var newEmployee = Mapper.Map<Employee>(viewModel);
                _employeeRepository.AddEmployee(newEmployee);
                if (_employeeRepository.SaveAll())
                {     
                    return Request.CreateResponse(HttpStatusCode.Created, Mapper.Map<EmployeeViewModel>(newEmployee));
                }
            }
            catch (Exception ex)
            {
                //Out of concerns for security, we do need to be careful using CreateErrorResponse, but for this case it should be fine.
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPatch]
        public HttpResponseMessage Patch([FromBody]EmployeeViewModel viewModel, int id)
        {
            try
            {
                var editEmployee = Mapper.Map<Employee>(viewModel);
                _employeeRepository.EditEmployee(editEmployee);
                if (_employeeRepository.SaveAll())
                {   
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<EmployeeViewModel>(editEmployee));
                }
            }
            catch (Exception ex)
            {
                //Out of concerns for security, we do need to be careful using CreateErrorResponse, but for this case it should be fine.
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _employeeRepository.DeleteEmployee(id);
                if (_employeeRepository.SaveAll())
                {   
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                //Out of concerns for security, we do need to be careful using CreateErrorResponse, but for this case it should be fine.
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
