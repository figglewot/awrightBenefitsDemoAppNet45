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
    [Route("api/employees/{id}/dependents")]
    public class DependentsController : ApiController
    {
        private IEmployeeRepository _employeeRepository;
        public DependentsController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var results = _employeeRepository.GetEmployeesWithDependentsById(id);

            return Ok(Mapper.Map<IEnumerable<DependentViewModel>>(results.Dependents));
        }

        [HttpPost]
        public IHttpActionResult Post(int id, [FromBody] DependentViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var newDependent = Mapper.Map<Dependent>(viewModel);
                _employeeRepository.AddDependent(id, newDependent);
                if (_employeeRepository.SaveAll())
                {
                    return Created("", Mapper.Map<DependentViewModel>(newDependent));
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
