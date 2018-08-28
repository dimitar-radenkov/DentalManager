namespace DentalManager.Web.Pages.Arrangments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DentalManager.Models.BindingModels.Arrangments;
    using DentalManager.Services.Contracts;
    using DentalManager.Web.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class AddModel : PageModel
    {
        private readonly IArrangmentsService arrangmentsService;
        private readonly IPatientsService patientsService;

        [BindProperty]
        public AddArrangmentBindingModel InputModel { get; set; }

        public AddModel(
            IArrangmentsService arrangmentsService, 
            IPatientsService patientsService)
        {
            this.arrangmentsService = arrangmentsService;
            this.patientsService = patientsService;
        }

        public async Task<IActionResult> OnGetAsync()
        {       
            this.InputModel = new AddArrangmentBindingModel
            {
                DateTime = DateTime.UtcNow,
                Patients = await this.GetPatientsList()
            };

            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
            {
                this.InputModel.Patients = await this.GetPatientsList();
                return this.Page();
            }

            try
            {
                await this.arrangmentsService.AddAsync(
                    this.InputModel.DateTime,
                    this.InputModel.Notice,
                    this.InputModel.PatientId);
            }
            catch (Exception)
            {
                this.AddDangerMessage("Unable to add arrangment, please try again later");
                this.InputModel.Patients = await this.GetPatientsList();
                return this.Page();
            }

            this.AddSuccessMessage("Arrangment has been added successfully");
            return this.RedirectToPage("/Arrangments/Index");
        }


        private async Task<IEnumerable<SelectListItem>> GetPatientsList()
        {
            var patients = await this.patientsService.AllAsync();
            return patients.Select(p =>
                    new SelectListItem
                    {
                        Text = p.Name,
                        Value = p.Id.ToString()
                    });
        }
        
    }
}