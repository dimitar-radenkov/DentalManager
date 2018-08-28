namespace DentalManager.Web.Pages.Patients
{
    using System;
    using System.Threading.Tasks;
    using DentalManager.Models.ViewModels;
    using DentalManager.Services.Contracts;
    using DentalManager.Web.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class DetailsModel : PageModel
    {
        private readonly IPatientsService patientsService;

        public DetailsPatientViewModel PatientDetails { get; set; }

        public DetailsModel(IPatientsService patientsService)
        {
            this.patientsService = patientsService;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            try
            {
                this.PatientDetails = await this.patientsService.GetDetailsAsync(id);
            }
            catch (Exception)
            {
                this.AddWarningMessage("Unable to get patient....");
            }        

            return this.Page();
        }
    }
}