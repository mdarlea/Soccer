using System.ComponentModel.DataAnnotations;

namespace Soccer.Web.ViewModels
{
    public class GameSummaryViewModel
    {
        public GameSummaryViewModel()
        {
            GameTeams = new List<GameTeamSummaryViewModel>();
        }

        public Guid Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime Time { get; set; }

        public List<GameTeamSummaryViewModel> GameTeams { get; set; }

        public bool IsGameOver { get; set; }
    }
}
