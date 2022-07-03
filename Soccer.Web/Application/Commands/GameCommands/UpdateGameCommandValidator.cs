using FluentValidation;

namespace Soccer.Web.Application.Commands.GameCommands
{
    /// <summary>
    /// Validates the UpdateGame command.
    /// </summary>
    /// <remarks>
    /// The following rules will be checked:
    /// <para>
    /// The game id must be specified
    /// </para>
    /// <para>
    /// For each team participating in the game the team id must be specified and the score must be greater or equal to 0
    /// </para>
    /// </remarks>
    public class UpdateGameCommandValidator : AbstractValidator<UpdateGameCommand>
    {
        public UpdateGameCommandValidator()
        {
            RuleFor(x => x.GameId).NotEmpty();

            RuleForEach(x => x.TeamScores)
                .NotEmpty()
                .SetValidator(new TeamScoreValidator());

        }
    }
}
