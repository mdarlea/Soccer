using FluentValidation;

namespace Soccer.Web.Application.Commands.PlayerCommands
{
    /// <summary>
    /// Validates the CreatePlayer command.
    /// </summary>
    /// <remarks>
    /// The following rules will be checked:
    /// <para>Player's CNP must be specified</para>
    /// </remarks>
    public class CreatePlayerCommandValidator : BasePlayerCommandValidator<CreatePlayerCommand>
    {
        public CreatePlayerCommandValidator()
        {
            RuleFor(x => x.CNP).NotEmpty();
        }
    }
}
