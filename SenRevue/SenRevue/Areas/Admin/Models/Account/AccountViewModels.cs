using SenRevue.Areas.Admin.Models.ViewModel;
using SenRevue.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SenRevue.Areas.Admin.Models.Account
{
    public class ExternalLoginConfirmationViewModel: AdminViewModelBase
    {
        [Required]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel : AdminViewModelBase
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel : AdminViewModelBase
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel : AdminViewModelBase
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Mémoriser ce navigateur ?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel : AdminViewModelBase
    {
        [Required]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }
    }

    public class LoginViewModel : AdminViewModelBase
    {
        [Required]
        [Display(Name = "Courrier électronique")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Display(Name = "Mémoriser le mot de passe ?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel : AdminViewModelBase, IValidatableObject
    {
        public RegisterViewModel()
        {
            Roles = GlobalHelper.EnumToSelectListItem<RoleEnum>();
        }

        /// <summary>
        /// Message de confirmation de la création de comptes
        /// </summary>
        public string ConfirmationMessage { get; set; }

        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe ")]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }

        public List<SelectListItem> Roles { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Email))
            {
                yield return new ValidationResult(LabelHelpers.GetLabel("email_required_error"), new[] { nameof(Email) });
            }
            else if(!GlobalHelper.IsEmailValid(Email))
            {
                yield return new ValidationResult(LabelHelpers.GetLabel("email_invalid_error"), new[] { nameof(Email) });
            }
            if (string.IsNullOrEmpty(Password))
            {
                yield return new ValidationResult(LabelHelpers.GetLabel("password_required_error"), new[] { nameof(Password) });
            }
            else if(Password.Length < 6)
            {
                yield return new ValidationResult(string.Format(LabelHelpers.GetLabel("password_minlength_error"),6), 
                    new[] { nameof(Password) });
            }
            if (string.IsNullOrEmpty(ConfirmPassword))
            {
                yield return new ValidationResult(LabelHelpers.GetLabel("confirm_password_required_error"), new[] { nameof(ConfirmPassword) });
            }
            if (string.IsNullOrEmpty(Role))
            {
                yield return new ValidationResult(LabelHelpers.GetLabel("role_required_error"), new[] { nameof(Role) });
            }
            if (!string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ConfirmPassword))
            {
                if (Password.CompareTo(ConfirmPassword) != 0)
                {
                    yield return new ValidationResult(LabelHelpers.GetLabel("no_correspondence_password_error"),
                        new[] { nameof(Password), nameof(ConfirmPassword) });
                }
            }
        }
    }
    
    public class ResetPasswordViewModel : AdminViewModelBase
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel : AdminViewModelBase, IValidatableObject
    {
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Email))
            {
                yield return new ValidationResult(LabelHelpers.GetLabel("email_required_error"), new[] { nameof(Email) });
            }
            else if (!GlobalHelper.IsEmailValid(Email))
            {
                yield return new ValidationResult(LabelHelpers.GetLabel("email_invalid_error"), new[] { nameof(Email) });
            }
        }
    }

    public class ConfirmEmailViewModel : AdminViewModelBase
    {
        public string ChangePasswordLink { get; set; }
    }
}
