namespace DentalManager.Models.ViewModels.Arrangments
{
    using System;

    public class ArrangmentViewModel
    {
        public int Id { get; set; }

        public ArrangmentStatus Status { get; set; }

        public DateTime DateTime { get; set; }

        public string Notice { get; set; }

        public decimal Total { get; set; }

        public int PatientId { get; set; }

        public string PatientName { get; set; }
    }
}
