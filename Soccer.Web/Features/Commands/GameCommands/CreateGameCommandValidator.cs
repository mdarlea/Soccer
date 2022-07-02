using FluentValidation;
using Soccer.Web.Models;

namespace Soccer.Web.Features.Commands.GameCommands
{
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

    public class TeamScoreValidator : AbstractValidator<GameTeamModel>
    {
        public TeamScoreValidator()
        {
            RuleFor(x => x.TeamId).NotEmpty();
            RuleFor(x => x.Score).GreaterThanOrEqualTo(0);
        }
    }
}
