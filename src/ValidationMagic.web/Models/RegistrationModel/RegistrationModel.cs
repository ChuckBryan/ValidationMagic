namespace ValidationMagic.web.Models.RegistrationModel
{
    using System.ComponentModel.DataAnnotations;

    public class RegistrationModel
    {

        public string Email { get; set; }

        [Display(Name="How did you hear about us?")]
        public string HowHeard { get; set; }

        [Display(Name="If Other, please indicate")]
        public string HowHeardOther { get; set; }
    }
}