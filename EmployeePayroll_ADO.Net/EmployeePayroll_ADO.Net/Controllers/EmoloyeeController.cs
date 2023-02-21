using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmployeePayroll_ADO.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmoloyeeController : ControllerBase
    {
        private readonly IEmployeeBL iemployeeBL;

        public EmoloyeeController(IEmployeeBL iemployeeBL)
        {
            this.iemployeeBL = iemployeeBL;
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                var result = iemployeeBL.AddEmployee(employeeModel);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Employee Added successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Employee addition Unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
