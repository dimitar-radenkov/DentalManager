namespace DentalManager.Web.WebApi
{
    using System;
    using System.Threading.Tasks;
    using DentalManager.Models.BindingModels;
    using DentalManager.Services.Contracts;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/patients")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsService patientsService;

        public PatientsController(IPatientsService patientsService)
        {
            this.patientsService = patientsService;
        }

        [HttpGet("")]
        public async Task<IActionResult> All() => 
            this.Ok(await this.patientsService.AllAsync());

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddPatientBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                await this.patientsService.AddAsync(
                    bindingModel.Name,
                    bindingModel.Email,
                    bindingModel.PhoneNumber);

                return this.Ok();
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Message = e.Message });
            }
        }
    }
}