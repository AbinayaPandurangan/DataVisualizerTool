using FluentValidation;
using Snow.DataVisualizer.API.Entities;

namespace Snow.DataVisualizer.API.Validators
{
    public class FileOutputDataValidator : AbstractValidator<FileOutputData>
    {
        public FileOutputDataValidator()
        {
            RuleFor(x => x.Hastag).NotNull().NotEmpty();
            RuleFor(x => x.Hastag).Equal('#');
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Name).Matches("^[a-zA-Z0-9]*$");
            RuleFor(x => x.Color).NotEmpty().NotNull();
            RuleFor(x => x.Color).Matches("^[a-zA-Z]*$");
            RuleFor(x => x.Value).NotEmpty().NotNull();
        }
    }
}
