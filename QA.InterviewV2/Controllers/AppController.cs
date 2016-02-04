using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QA.InterviewV2.Data.Repositories;

namespace QA.InterviewV2.Controllers
{
    public class AppController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        public AppController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}