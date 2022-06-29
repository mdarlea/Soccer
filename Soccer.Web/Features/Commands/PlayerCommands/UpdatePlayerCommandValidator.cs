using FluentValidation;

namespace Soccer.Web.Features.Commands.PlayerCommands
{
    public class UpdatePlayerCommandValidator: BasePlayerCommandValidator<UpdatePlayerCommand>
    {
        public UpdatePlayerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
