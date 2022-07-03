using Soccer.Web.Application.Responses;

namespace Soccer.Web.Application.Commands.GameCommands
{
    /// <summary>
    /// Properties common to CreateGameCommand and UpdateGameCommand
    /// </summary>
    public abstract class BaseGameCommand
    {
        protected BaseGameCommand()
        {
            TeamScores = new List<GameTeam>();
        }

        /// <summary>
        /// For each team gets the score in the given game
        /// </summary>
        public List<GameTeam> TeamScores { get; set; }

        /// <summary>
        /// Specify if game is over
        /// </summary>
        public bool IsGameOver { get; set; }
    }
}
