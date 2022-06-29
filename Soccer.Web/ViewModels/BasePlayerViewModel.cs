using System.ComponentModel.DataAnnotations;

namespace Soccer.Web.ViewModels
{
    public abstract class BasePlayerViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
        
        public string? Position { get; set; }
    }
}
