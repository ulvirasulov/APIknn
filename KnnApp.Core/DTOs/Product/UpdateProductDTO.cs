using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnnApp.Core.DTOs.Product;
public record UpdateProductDTO
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }

}
public class UpdateProductValidator : AbstractValidator<UpdateProductDTO>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("id null ola bilmez")
            .NotEmpty().WithMessage("id bos ola bilmez")
            .GreaterThan(0).WithMessage("0 dan boyuk olmali");
        RuleFor(x => x.ProductName)
            .NotNull().WithMessage("null ola bilmez")
            .NotEmpty().WithMessage("bos ola bilmez")
            .MinimumLength(3).WithMessage("min uzunluq 3 olmali")
            .MaximumLength(50).WithMessage("max uzunluq 20 olmali");
        RuleFor(x => x.Description)
            .NotNull().WithMessage("null ola bilmez")
            .NotEmpty().WithMessage("bos ola bilmez")
            .MinimumLength(3).WithMessage("min uzunluq 3 olmali")
            .MaximumLength(500).WithMessage("max uzunluq 50 olmali");
        RuleFor(x => x.Price)
            .NotNull().WithMessage("null ola bilmez")
            .NotEmpty().WithMessage("bos ola bilmez")
            .GreaterThan(0).WithMessage("0 dan boyuk olmali");
        RuleFor(x => x.CategoryId)
            .NotNull().WithMessage("null ola bilmez")
            .NotEmpty().WithMessage("bos ola bilmez")
            .GreaterThan(0).WithMessage("0 dan boyuk olmali");
    }
}
