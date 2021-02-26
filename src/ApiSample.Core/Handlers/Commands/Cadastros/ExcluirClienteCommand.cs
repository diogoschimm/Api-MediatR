using ApiSample.Core.Handlers.Commands.Bases;
using FluentValidation.Results;

namespace ApiSample.Core.Handlers.Commands.Cadastros
{
    public class ExcluirClienteCommand : Command<bool>
    {
        public int IdCliente { get; set; }

        public override bool Validar()
        {
            ValidationResult = new ValidationResult();
            if (IdCliente <= 0)
                ValidationResult.Errors.Add(new ValidationFailure("IdCliente", "ID Cliente é obrigatório"));

            return ValidationResult.IsValid;
        }
    }
}
