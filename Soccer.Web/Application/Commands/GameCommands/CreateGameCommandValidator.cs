using FluentValidation;

using Soccer.Web.Application.Responses;

namespace Soccer.Web.Application.Commands.GameCommands
{
    /// <summary>
    /// Validates the CreateGame command.
    /// </summary>
    /// <remarks>
    /// The following rules will be checked:
    /// <para>
    /// At least two teams must participate in the game
    /// </para>
    /// <para>
    /// For each team participating in the game the team id must be specified and the score must be greater or equal to 0
    /// </para>
    /// </remarks>
    public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
    {
        public CreateGameCommandValidator()
        {
            RuleFor(x => x.TeamScores.Count).GreaterThanOrEqualTo(2).WithMessage("Game must have at least two teams");
            RuleForEach(x => x.TeamScores)
                .NotEmpty()
                .SetValidator(new TeamScoreValidator());
        }
    }

    public class TeamScoreValidator : AbstractValidator<GameTeam>
    {
        public TeamScoreValidator()
        {
            RuleFor(x => x.TeamId).NotEmpty();
            RuleFor(x => x.Score).GreaterThanOrEqualTo(0);
        }
    }
}
