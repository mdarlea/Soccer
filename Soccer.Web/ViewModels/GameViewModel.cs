using System.ComponentModel.DataAnnotations;

namespace Soccer.Web.ViewModels
{
    public class GameViewModel
    {
        public GameViewModel()
        {
            AllTeams = new List<SelectTeamViewModel>();
            Date = DateTime.Today;
            Time = DateTime.Now;
        }

        public Guid Id { get; set; }
        public List<SelectTeamViewModel> AllTeams { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime Time { get; set; }

        [Display(Name="Game is over")]
        public bool IsFinalScore { get; set; }
    }
}
