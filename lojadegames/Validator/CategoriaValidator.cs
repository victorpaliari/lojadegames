using FluentValidation;
using lojadegames.Model;



namespace lojadegames.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator() {


            RuleFor(p => p.Console)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);

        }

    }

}

