namespace TShirt.Photos.App.Application.Mappings;

using AutoMapper;
using Domain.Entities;
using DTOs;

public class ModelMapping : Profile
{
    public ModelMapping()
    {
        CreateMap<Shirt, ShirtsDTO>()
            .ConvertUsing((shirt, _) =>
                new(
                    shirt.Id,
                    shirt.Name,
                    shirt.Colours.Count,
                    shirt.Fabrics.Count,
                    shirt.Images.Count));

        CreateMap<Shirt, ShirtDTO>()
            .ConvertUsing((shirt, _, context) => new(shirt.Id, shirt.Name)
            {
                Colours = shirt.Colours.Select(c => context.Mapper.Map<ShirtColourDTO>(c)).ToList(),
                Fabrics = shirt.Fabrics.Select(f => context.Mapper.Map<ShirtFabricDTO>(f)).ToList(),
                Images = shirt.Images.Select(i => context.Mapper.Map<ShirtImageDTO>(i)).ToList(),
            });

        CreateMap<ShirtColour, ShirtColourDTO>()
            .ConvertUsing(c => new(c.Id, c.Name));

        CreateMap<ShirtFabric, ShirtFabricDTO>()
            .ConvertUsing(f => new(f.Id, f.Type));

        CreateMap<ShirtImage, ShirtImageDTO>()
            .ConvertUsing(i =>
                new(i.Id, i.ShirtId, i.ColourId, i.FabricId)
                {
                    ImageUrl = i.Url,
                });

        CreateMap<ShirtImageDTO, ShirtImage>()
            .ConvertUsing(dto =>
                new(dto.ImageUrl, dto.ShirtId, dto.ColourId, dto.FabricId));
    }
}
