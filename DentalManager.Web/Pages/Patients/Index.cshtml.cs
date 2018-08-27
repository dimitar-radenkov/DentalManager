namespace DentalManager.Web.Pages.Patients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DentalManager.Models.ViewModels;
    using DentalManager.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class IndexModel : PageModel
    {
        private readonly IPatientsService patientsService;


        public IEnumerable<PatientViewModel> AllPatiens { get; set; }

        public IndexModel(IPatientsService patientsService)
        {
            this.patientsService = patientsService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            this.AllPatiens = await this.patientsService.AllAsync();

            return this.Page();
        }
    }
}