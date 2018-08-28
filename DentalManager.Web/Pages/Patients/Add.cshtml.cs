namespace DentalManager.Web.Pages.Patients
{
    using DentalManager.Models.BindingModels;
    using DentalManager.Services.Contracts;
    using DentalManager.Web.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System;
    using System.Threading.Tasks;

    public class AddModel : PageModel
    {
        private readonly IPatientsService patientsService;

        [BindProperty]
        public AddPatientBindingModel InputModel { get; set; }

        public AddModel(IPatientsService patientsService)
        {
            this.patientsService = patientsService;
        }


        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            try
            {
                await this.patientsService.AddAsync(
                    this.InputModel.Name,
                    this.InputModel.Email,
                    this.InputModel.PhoneNumber);

                this.AddSuccessMessage("Patient has been added successfully");
                return this.RedirectToPage("/Patients/Index");
            }
            catch (Exception)
            {
                this.AddDangerMessage("Unable to add patient.");
                return this.Page();              
            }
        }
    }
}