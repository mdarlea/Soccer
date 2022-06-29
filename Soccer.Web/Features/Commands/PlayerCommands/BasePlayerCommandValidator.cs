using FluentValidation;

namespace Soccer.Web.Features.Commands.PlayerCommands
{
    public abstract class BasePlayerCommandValidator<T>: AbstractValidator<T>
        where T : BasePlayerCommand
    {
        protected BasePlayerCommandValidator()
        {
            RuleFor(x => x.StreetAddress).NotEmpty();
            RuleFor(x => x.City).NotEmpty();

            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();

            RuleFor(x => x.TeamId).NotEmpty();
        }
    }
}
