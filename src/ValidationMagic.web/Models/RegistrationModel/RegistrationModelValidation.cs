namespace ValidationMagic.web.Models.RegistrationModel
{
    using System;
    using System.Linq;
    using Data;
    using FluentValidation;

    public class RegistrationModelValidation : AbstractValidator<RegistrationModel>
    {
        private readonly AppDbContext _dbContext;

        public RegistrationModelValidation(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Email).MaximumLength(40);
            RuleFor(x => x.Email).Must(UniqueEmail).WithMessage("This email has already been registered.");

            RuleFor(x => x.HowHeard).NotEmpty();

            RuleFor(x => x.HowHeardOther).NotEmpty().When(x => x.HowHeard == "Other").WithMessage("Please indicate how heard");

            RuleFor(x => x.HowHeard).MaximumLength(40);
        }

        private bool UniqueEmail(string email)
        {
            return ! _dbContext.Registrations.Any(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
    }
}


