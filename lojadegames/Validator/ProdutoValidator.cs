using FluentValidation;
using lojadegames.Model;

namespace lojadegames.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator() {

            RuleFor(p => p.Nome)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(p => p.Descricao)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(1000);

            RuleFor(p => p.Preco)
                .NotEmpty();

            RuleFor(p => p.Foto)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(5000);
        }

    }

}

