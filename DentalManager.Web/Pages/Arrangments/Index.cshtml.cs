namespace DentalManager.Web.Pages.Arrangments
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DentalManager.Models.ViewModels.Arrangments;
    using DentalManager.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class IndexModel : PageModel
    {
        private readonly IArrangmentsService arrangmentsService;

        public IEnumerable<ArrangmentViewModel> Arrangments { get; set; }

        public IndexModel(IArrangmentsService arrangmentsService)
        {
            this.arrangmentsService = arrangmentsService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            this.Arrangments = await this.arrangmentsService.AllAsync();

            return this.Page();
        }
    }
}