//install package FluentValidation
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace TestEFCore.DTO
{
    public class StudentWithTeacherDTO
    {
        public long StudentID { get; set; }
        public string StudentName { get; set; }

        [Display(Name = "Select Role")]
        public List<int>? SelectedTeacherIDs { get; set; } = new List<int>(); // Now supports multiple roles

        [Display(Name = "Select New Role")]
        public string? NewTeacherName { get; set; }  // New role if not selecting an existing one
    }


    public class StudentWithTeacherDTOValidator : AbstractValidator<StudentWithTeacherDTO>
    {
        public StudentWithTeacherDTOValidator()
        {
            RuleFor(x => x.StudentName)
                .NotEmpty().WithMessage("User name is required.")
                .MaximumLength(100).WithMessage("User name can't be longer than 100 characters.");

            //Either select a role in mutiselect list or enter a new role in textbox
            RuleFor(x => x)
                .Must(x => (x.SelectedTeacherIDs != null && x.SelectedTeacherIDs.Count > 0) ||
                            !string.IsNullOrWhiteSpace(x.NewTeacherName))
                .WithMessage("Please select at least one role or enter a new role name.");
        }
    }


}
