namespace DentalManager.Models
{
    using System;
    using System.Collections.Generic;

    public class Patient
    {
        public int Id { get; set;}

        public string Name { get; set;}

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public ICollection<Arrangment> Arrangments { get; set; }

        public ICollection<Document> Document { get; set; }
    }
}
