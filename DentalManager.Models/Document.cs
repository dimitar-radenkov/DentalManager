namespace DentalManager.Models
{
    using System;

    public class Document
    {
        public int Id { get; set; }

        public byte[] Data { get; set; }

        public string ContentType { get; set; }

        public DateTime DateUploaded { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
