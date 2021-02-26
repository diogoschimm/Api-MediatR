using ApiSample.Core.Handlers.Commands.Bases;
using FluentValidation;

namespace ApiSample.Core.Handlers.Commands.Cadastros
{
    public class CriarClienteCommand : Command<bool>
    { 
        public string NomeCliente { get; set; }

        public override bool Validar()
        {
            ValidationResult = new CriarClienteCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CriarClienteCommandValidator: AbstractValidator<CriarClienteCommand>
    {
        public CriarClienteCommandValidator()
        {
            RuleFor(c => c.NomeCliente)
                .NotEmpty()
                .WithMessage("Nome do Cliente é obrigatório");
        }
    }
}
