using FluentValidation;

namespace Soccer.Web.Features.Commands.PlayerCommands
{
    public class CreatePlayerCommandValidator : BasePlayerCommandValidator<CreatePlayerCommand>
    {
        public CreatePlayerCommandValidator()
        {
            RuleFor(x => x.CNP).NotEmpty();
        }
    }
}
