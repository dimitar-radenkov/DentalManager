namespace DentalManager.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class EditPatientBindingModels
    {
        public const int NAME_MIN_LEN = 5;
        public const int NAME_MAX_LEN = 50;

        [Required]
        [MinLength(NAME_MIN_LEN, ErrorMessage = "Name must be between 5 and 50 symbols")]
        [MaxLength(NAME_MAX_LEN, ErrorMessage = "Name must be between 5 and 50 symbols")]
        public string Name { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
