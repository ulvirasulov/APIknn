using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnApp.Core.DTOs.Category;
public record UpdateCategoryDTO
{
    public int Id { get; set; }
    public string CategoryName { get; set; }    

}
public class UpdateCategoryValidator:AbstractValidator<UpdateCategoryDTO>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("id null ola bilmez")
            .NotEmpty().WithMessage("id bos ola bilmez")
            .GreaterThan(0).WithMessage("0 dan boyuk olmali");
        RuleFor(x => x.CategoryName)
            .NotNull().WithMessage("name null ola bilmez")
            .NotEmpty().WithMessage("name bos ola bilmez")
            .MinimumLength(3).WithMessage("min uzunluq 3 olmali")
            .MaximumLength(20).WithMessage("max uzunluq 20 olmali");
    }
}
