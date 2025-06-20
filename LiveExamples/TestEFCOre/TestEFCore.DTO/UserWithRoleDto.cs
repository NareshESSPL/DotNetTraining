//install package FluentValidation
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace TestEFCore.DTO
{
    public class UserWithRoleDTO
    {
        public long UserID { get; set; }
        public string UserName { get; set; }

        public string EmailID { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        [Display(Name = "Select Role")]
        public List<int>? SelectedRoleIDs { get; set; } = new List<int>(); // Now supports multiple roles

        [Display(Name = "Select New Role")]
        public string? NewRoleName { get; set; }  // New role if not selecting an existing one
    }


    public class UserWithRoleDtoValidator : AbstractValidator<UserWithRoleDto>
    {
        public UserWithRoleDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("User name is required.")
                .MaximumLength(100).WithMessage("User name can't be longer than 100 characters.");

            RuleFor(x => x.EmailID)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MaximumLength(20).WithMessage("Password must be 20 characters or fewer.");

            //Either select a role in mutiselect list or enter a new role in textbox
            RuleFor(x => x)
                .Must(x => (x.SelectedRoleIDs != null && x.SelectedRoleIDs.Count > 0) ||
                            !string.IsNullOrWhiteSpace(x.NewRoleName))
                .WithMessage("Please select at least one role or enter a new role name.");
        }
    }


}
