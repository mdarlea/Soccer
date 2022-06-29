using FluentValidation;

namespace Soccer.Web.Features.Commands.GameCommands
{
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
