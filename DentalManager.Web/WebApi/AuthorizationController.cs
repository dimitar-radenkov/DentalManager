namespace DentalManager.Web.WebApi
{
    using System.Threading.Tasks;
    using DentalManager.Models.WebApi;
    using DentalManager.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/authorization")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILoginService loginService;

        public AuthorizationController(ILoginService loginService)
        {
            this.loginService = loginService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginBindingModel loginBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var token = await this.loginService.LoginAsync(
                loginBindingModel.Username, 
                loginBindingModel.Password);      

            return this.Ok(new { Token = token });
        }
    }
}