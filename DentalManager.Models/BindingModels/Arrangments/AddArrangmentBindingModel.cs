namespace DentalManager.Models.BindingModels.Arrangments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class AddArrangmentBindingModel : IValidatableObject
    {
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date Time")]
        public DateTime DateTime { get; set; }

        [Required]
        public string Notice { get; set; }

        [Required]
        [Display(Name = "Patient")]
        public int PatientId { get; set; }

        public IEnumerable<SelectListItem> Patients { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.DateTime.ToUniversalTime() <= DateTime.UtcNow)
            {
                yield return new ValidationResult("Date Time must be in the future");
            }
        }
    }
}
