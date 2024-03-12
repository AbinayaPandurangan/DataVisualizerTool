using FluentValidation;

namespace Snow.DataVisualizer.API.Validators
{
    public class FileValidator : AbstractValidator<IFormFile>
    {
        public FileValidator()
        {      
            RuleFor(x => Path.GetExtension(x.FileName)).NotNull().NotEmpty().Equal(".txt");
            RuleFor(x => x.Length).NotNull().GreaterThan(0);
         }
    }
}
