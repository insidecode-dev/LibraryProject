using FluentValidation;

namespace LibraryProject.Models.FluentValidators
{
    public class AuthorValidator : AbstractValidator<Authors>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(15)
                .WithMessage("maximum character size is 15"); 
            
            RuleFor(x => x.LastName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(15)
                .WithMessage("maximum character size is 15");
        }
    }
}
