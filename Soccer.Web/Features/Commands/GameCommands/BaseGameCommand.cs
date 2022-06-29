using Soccer.Web.Models;

namespace Soccer.Web.Features.Commands.GameCommands
{
    public abstract class BaseGameCommand
    {
        protected BaseGameCommand()
        {
            TeamScores = new List<TeamScoreModel>();
        }

        public List<TeamScoreModel> TeamScores { get; set; }
        public bool IsFinalScore { get; set; }
    }
}
