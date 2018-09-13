namespace DentalManager.Web.Rest
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
        private const string UNABLE_TO_GET_PATIENT = "Unable to get information about patient";

        private readonly IPatientsService patientsService;

        public PatientsController(IPatientsService patientsService)
        {
            this.patientsService = patientsService;
        }

        [HttpGet("")]
        public async Task<IActionResult> All() => 
            this.Ok(await this.patientsService.AllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return this.Ok(await this.patientsService.GetByIdAsync(id));
            }
            catch (Exception)
            {
                return this.BadRequest(UNABLE_TO_GET_PATIENT);
            }
        }
            

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
                return this.BadRequest(new { e.Message });
            }
        }


        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var patient = await this.patientsService.GetByIdAsync(id);
                return this.Ok(patient);
            }
            catch (Exception)
            {
                return this.BadRequest(UNABLE_TO_GET_PATIENT);
            }
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(int id, EditPatientBindingModel editModel)
        {
            try
            {
                var patient = await this.patientsService.GetByIdAsync(id);
                await this.patientsService.UpdateAsync(
                    id,
                    editModel.Name,
                    editModel.Email,
                    editModel.PhoneNumber);
                return this.Ok();
            }
            catch (Exception)
            {
                return this.BadRequest(UNABLE_TO_GET_PATIENT);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this.patientsService.DeleteAsync(id);
                return this.Ok();
            }
            catch (Exception)
            {
                return this.BadRequest("Unable to delete patient");
            }
        }
    }
}