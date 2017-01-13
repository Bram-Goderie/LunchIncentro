using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LunchIncentro.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public Vestiging Vestiging { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Vestigingen { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }


    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Vestiging")]
        public Vestiging Vestiging { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Vestigingen { get; set; }
        
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Vestiging")]
        public Vestiging Vestiging { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Vestigingen { get; set; }

        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [Display(Name = "Vestiging")]
        public Vestiging Vestiging { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Vestigingen { get; set; }
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
