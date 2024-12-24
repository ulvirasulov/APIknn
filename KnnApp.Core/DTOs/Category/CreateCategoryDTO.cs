using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnApp.Core.DTOs.Category;
public record CreateCategoryDTO
{
    public string CategoryName { get; set; }

}
public class CreateCategoryValidator : AbstractValidator<CreateCategoryDTO>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.CategoryName)
            .NotNull().WithMessage("null ola bilmez")
            .NotEmpty().WithMessage("bos ola bilmez")
            .MinimumLength(3).WithMessage("min uzunluq 3 olmali")
            .MaximumLength(20).WithMessage("max uzunluq 20 olmali");
    }
}
