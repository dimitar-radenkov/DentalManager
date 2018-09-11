namespace DentalManager.Models.ViewModels
{
    using System.Collections.Generic;
    using DentalManager.Models.ViewModels.Arrangments;

    public class DetailsPatientViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public IEnumerable<ArrangmentViewModel> Arrangments { get; set; }
    }
}
