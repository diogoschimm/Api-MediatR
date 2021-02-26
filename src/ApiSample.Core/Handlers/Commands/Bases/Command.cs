using FluentValidation.Results;
using MediatR;

namespace ApiSample.Core.Handlers.Commands.Bases
{
    public abstract  class Command<TResponse> : IRequest<TResponse>
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool Validar();
    }
}
