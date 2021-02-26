using ApiSample.Core.Handlers.Commands.Bases;
using FluentValidation;

namespace ApiSample.Core.Handlers.Commands.Cadastros
{
    public class AlterarClienteCommand : Command<bool>
    {
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }

        public override bool Validar()
        {
            this.ValidationResult = new AlterarClienteCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AlterarClienteCommandValidator: AbstractValidator<AlterarClienteCommand>
    {
        public AlterarClienteCommandValidator()
        {
            RuleFor(c => c.IdCliente)
                .GreaterThanOrEqualTo(0)
                .WithMessage("ID do cliente não pode ser menor ou igual a ZERO");

            RuleFor(c => c.NomeCliente)
                .NotEmpty()
                .WithMessage("Nome do cliente é obrigatório");
        }
    }
}
