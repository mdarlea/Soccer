using System.ComponentModel.DataAnnotations;

namespace Soccer.Web.ViewModels
{
    public class PlayerViewModel:  BasePlayerViewModel
    {
        [Display(Name = "Team")]
        public Guid TeamId { get; set; }

        public string CNP { get; set; } = null!;

        [Display(Name = "Street")]
        public string StreetAddress { get; set; } = null!;
        public string City { get; set; } = null!;

        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
