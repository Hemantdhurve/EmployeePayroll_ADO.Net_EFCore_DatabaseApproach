using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePayroll_ADO.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public readonly IAdminBL iadminBL;

        public AdminController(IAdminBL iadminBL)
        {
            this.iadminBL = iadminBL;
        }

        [HttpPost]
        [Route("Registration")]

        public IActionResult Registration(AdminRegistrationModel adminRegistrationModel)
        {
            try
            {
                var result = iadminBL.Registration(adminRegistrationModel);
                if (result != null)
                {
                    return Ok(new { Status = true, Message = "Registration Successful", data = result });
                }
                else
                {
                    return BadRequest(new { Status = false, Message = "Registration UnSuccessful" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
