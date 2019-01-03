namespace ValidationMagic.web.Data
{
    using System;

    public class Registration
    {

        public Registration()
        {
            Id = Guid.NewGuid();
            
        }

        public Guid Id { get; set; }

        public string Email { get; set; }

        public string HowDidYouHear { get; set; }

        public string HowDidYouHearOther { get; set; }
    }
}