namespace ValidationMagic.web.Models.RegistrationModel
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class RegistrationModel
    {
        [Required]
        [StringLength(40)]
        [DataType(DataType.EmailAddress)]
        [Remote("ValidateUniqueName", "Registration")]
        public string Email { get; set; }

        [Required]
        [Display(Name="How did you hear about us?")]
        public string HowHeard { get; set; }

        [Display(Name="If Other, please indicate")]
        [RequiredIf("HowHeard", "Other", "Please indicate how heard")]
        public string HowHeardOther { get; set; }
    }
}