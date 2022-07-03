using FluentValidation;

namespace Soccer.Web.Application.Commands.PlayerCommands
{
    /// <summary>
    /// Validates common properties to CreatePlayerCommand and UpdatePlayerCommand
    /// </summary>
    /// <remarks>
    /// The following rules will be checked:
    /// <para>
    /// Street address must be specified
    /// </para>
    /// <para>
    /// City must be specified
    /// </para>
    /// <para>
    /// First Name must be specified
    /// </para>
    /// <para>
    /// Last name must be specified
    /// </para>
    /// <para>
    /// Player's team id must be specified
    /// </para>
    /// </remarks>
    public abstract class BasePlayerCommandValidator<T> : AbstractValidator<T>
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
