namespace TShirt.Photos.App.Application.DTOs.Validators;

using FluentValidation;

public class ShirtImageDTOValidator : AbstractValidator<ShirtImageDTO>
{
    public ShirtImageDTOValidator()
    {
        this.RuleFor(x => x.ColourId)
            .NotEqual(0)
            .WithMessage("Image 'ColorId' have a valid ID.");

        this.RuleFor(x => x.ShirtId)
            .NotEqual(0)
            .WithMessage("Image 'ShirtId' have a valid ID.");

        this.RuleFor(x => x.FabricId)
            .NotEqual(0)
            .WithMessage("Image 'FabricId' have a valid ID.");
    }
}
