namespace TShirt.Photos.App.Application.DTOs.Validators;

using Domain.Entities;
using FluentValidation;

public class ShirtImageDTOValidator : AbstractValidator<ValidatorInput>
{
    public ShirtImageDTOValidator()
    {
        this.RuleFor(x => x.dto.ColourId)
            .NotEqual(0)
            .WithMessage("Image 'ColorId' have a valid ID.");

        this.RuleFor(x => x.dto.ShirtId)
            .NotEqual(0)
            .WithMessage("Image 'ShirtId' have a valid ID.");

        this.RuleFor(x => x.dto.FabricId)
            .NotEqual(0)
            .WithMessage("Image 'FabricId' have a valid ID.");

        this.RuleFor(x => x)
            .Must(x => x.shirt.Colours.Select(c => c.Id).Contains(x.dto.ColourId))
            .WithMessage("Shirt does not have the colour provided.");

        this.RuleFor(x => x)
            .Must(x => x.shirt.Fabrics.Select(c => c.Id).Contains(x.dto.FabricId))
            .WithMessage("Shirt does not have the fabric provided.");
    }
}

public record ValidatorInput(ShirtImageDTO dto, Shirt shirt);
