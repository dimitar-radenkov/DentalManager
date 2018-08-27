namespace DentalManager.Models
{
    using System;

    public class Arrangment
    {
        public int Id { get; set; }

        public ArrangmentStatus Status { get; set; }

        public DateTime DateTime { get; set; }

        public string Notice { get; set; }

        public decimal Total { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
