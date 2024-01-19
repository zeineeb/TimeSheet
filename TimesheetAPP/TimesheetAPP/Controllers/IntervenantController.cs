using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimesheetAPP.Core.Entities;
using TimesheetAPP.Core.Interfaces;
using TimesheetAPP.Core.Services;

namespace TimesheetAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntervenantController : ControllerBase
    {
        public readonly IIntervenantService intervenantService;
        public IntervenantController(IIntervenantService intervenantService)
        {
            this.intervenantService = intervenantService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Intervenant model)
        {
            var result = await intervenantService.Login(model);
            if (result != null)
            {
                return Ok(result);
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> logout([FromBody] Intervenant model)
        {
            var result = await intervenantService.Logout(model);

                return Ok(result);

        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Intervenant model)
        {
            var result = await intervenantService.Register(model);
            return Ok(result);
        }

        [HttpPost("verify-email/{email}/{otp}")]
        public async Task<IActionResult> VerifyEmail(string email , string otp)
        {
            try
            {
                var result = await intervenantService.VerifyEmail(email, otp);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { Status = "Error", Message = "An error occurred while processing the request." });
            }
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await intervenantService.GetAllUsers();
     
                return Ok(result);
          
        }

        [HttpGet]
        [Route("GetById/{userId}")]
        public async Task<IActionResult> GetById(int userId)
        {
            var result = await intervenantService.GetUserById(userId);
             return Ok(result);

        }

        [HttpDelete("{unsername}")]
        public async Task<ActionResult> DeleteUsertByUsername(string unsername)
        {
            var result = await intervenantService.DeleteUserByUsername(unsername);

            return Ok(result);

        }

        [HttpDelete("delete/{userId}")]
        public async Task<ActionResult> DeleteUsertById(int userId)
        {
            var result = await intervenantService.DeleteIntervenantById(userId);

            return Ok(result);

        }

    }
}
