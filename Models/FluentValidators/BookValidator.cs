using FluentValidation;

namespace LibraryProject.Models.FluentValidators
{
    public class BookValidator : AbstractValidator<Books>
    {
        public BookValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(15)
                .WithMessage("max character size is 15");

            When(x => x.Name == "Deneme",
                () =>
                {
                    RuleFor(x => x.PageCount).Must(y => y == "50").WithMessage("if the name is deneme page must be 50");
                });

            RuleFor(x=>x.PageCount).Must(y=>int.TryParse(y, out int value)).WithMessage("please enter number");
        }
    }
}
