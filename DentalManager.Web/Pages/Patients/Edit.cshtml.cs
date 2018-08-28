namespace DentalManager.Web.Pages.Patients
{
    using System;
    using System.Threading.Tasks;
    using DentalManager.Models.BindingModels;
    using DentalManager.Services.Contracts;
    using DentalManager.Web.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class EditModel : PageModel
    {
        private readonly IPatientsService patientsService;

        [BindProperty]
        public EditPatientBindingModels InputModel { get; set; }

        public EditModel(IPatientsService patientsService)
        {
            this.patientsService = patientsService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                var patient = await this.patientsService.GetByIdAsync(id);
                this.InputModel = new EditPatientBindingModels
                {
                    Name = patient.Name,
                    Email = patient.Email,
                    PhoneNumber = patient.PhoneNumber
                };
            }
            catch (Exception)
            {
                this.AddWarningMessage("Unable to get information for patient");
            }

            return this.Page();
        }


        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                await this.patientsService.UpdateAsync(
                    id,
                    this.InputModel.Name,
                    this.InputModel.Email,
                    this.InputModel.PhoneNumber);
            }
            catch (Exception)
            {
                this.AddDangerMessage("Unable to edit patient, please try again later...");
                return this.Page();
            }

            this.AddSuccessMessage("Patient info edited successfully");
            return this.RedirectToPage("/Patients/Index");
        }
    }
}