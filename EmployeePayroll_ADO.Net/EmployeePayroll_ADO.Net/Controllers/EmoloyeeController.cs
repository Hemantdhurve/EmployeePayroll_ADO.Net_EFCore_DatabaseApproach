using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
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

        [Authorize]
        [HttpGet]
        [Route("RetriveAllEmp")]

        public IActionResult RetriveAllEmployee()
        {
            try
            {
                var result = iemployeeBL.RetriveEmployees();
                if(result != null)
                {
                    return this.Ok(new { Status = true, Message = "Getting All Employees", data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Fail to Get All Employees" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteEmployee")]

        public IActionResult DeleteEmployee(int employeeId)
        {
            try
            {
                var result = iemployeeBL.DeleteEmployee(employeeId);
                if(result != null)
                {
                    return Ok(new { Status = true,Message="Employee Deleted Successfully",data=result});
                }
                else
                {
                    return BadRequest(new { Status = false, Message = "Employee Deletion UnSuccessful" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateEmp")]

        public IActionResult UpdateEmployee(int employeeId,EmployeeModel employeeModel)
        {
            try
            {
                var result = iemployeeBL.UpdateEmployee(employeeModel, employeeId);
                if (result != null)
                {
                    return Ok(new { Status = true, Message = "Employee Successfully Updated", data = result });
                }
                else
                {
                    return BadRequest(new { Status = false, Message = "Employee Updation UnSuccessful" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
