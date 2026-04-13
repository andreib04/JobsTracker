using FluentValidation;
using JobsTracker.Application.DTOs.JobDTOs;

namespace JobsTracker.Application.Validators
{
    public class CreateJobValidator : AbstractValidator<CreateJobDto>
    {
        public CreateJobValidator()
        {
            RuleFor(job => job.Title)
                .NotEmpty().WithMessage("Company name is required.")
                .MaximumLength(100).WithMessage("Company name cannot exceed 100 characters.");

            RuleFor(job => job.CompanyId)
                .NotEmpty();
        }
    }
}
