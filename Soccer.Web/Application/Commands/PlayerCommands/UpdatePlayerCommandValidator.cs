using FluentValidation;

namespace Soccer.Web.Application.Commands.PlayerCommands
{
    /// <summary>
    /// Validates the CreatePlayer command.
    /// </summary>
    /// <remarks>
    /// The following rule will be checked:
    /// <para>
    /// The player's id must be specified
    /// </para>
    /// </remarks>
    public class UpdatePlayerCommandValidator : BasePlayerCommandValidator<UpdatePlayerCommand>
    {
        public UpdatePlayerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
