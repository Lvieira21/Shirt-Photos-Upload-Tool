namespace TShirt.Photos.App.Application.Services;

using AutoMapper;
using Domain.Entities;
using Domain.Helpers;
using Interfaces;
using Microsoft.AspNetCore.Http;
using TShirt.Photos.App.Application.DTOs;
using TShirt.Photos.App.Application.DTOs.Validators;
using TShirt.Photos.App.Domain.Repositories;

public class ShirtImageService : IShirtImageService
{
    private readonly IShirtImageRepository _imageRepository;
    private readonly IShirtRepository _shirtRepository;
    private readonly IShirtImageHelper _imageHelper;
    private readonly IMapper _mapper;

    public ShirtImageService(
        IShirtImageRepository imageRepository,
        IShirtRepository shirtRepository,
        IShirtImageHelper imageHelper,
        IMapper mapper)
    {
        _imageRepository = imageRepository;
        _shirtRepository = shirtRepository;
        _imageHelper = imageHelper;
        _mapper = mapper;
    }

    public async Task<ResultService<List<ShirtImageDTO>>> GetAllByShirtIdAsync(int shirtId)
    {
        if (shirtId == 0)
        {
            return ResultService.Fail<List<ShirtImageDTO>>("Image not provided");
        }

        var shirt = await _shirtRepository.GetByIdAsync(shirtId);

        if (shirt is null)
        {
            return ResultService.Fail<List<ShirtImageDTO>>("Shirt not found!");
        }

        var images = await _imageRepository.GetAllByShirtIdAsync(shirtId);

        return images.Any()
            ? ResultService.Ok(_mapper.Map<List<ShirtImageDTO>>(images))
            : ResultService.Fail<List<ShirtImageDTO>>("Images not found!");
    }

    public async Task<ResultService<ShirtImage>> CreateImageAsync(ShirtImageDTO? shirtImageDto, IFormFile file)
    {
        if (shirtImageDto == null)
        {
            return ResultService.Fail<ShirtImage>("Image not provided");
        }

        var shirt = await _shirtRepository.GetByIdAsync(shirtImageDto.ShirtId);

        if (shirt is null)
        {
            return ResultService.Fail<ShirtImage>("Shirt not found!");
        }

        var validations = new ShirtImageDTOValidator().Validate(new ValidatorInput(shirtImageDto, shirt));

        if (!validations.IsValid)
        {
            return ResultService.RequestError<ShirtImage>("Validation Errors", validations);
        }

        var shirtImageUrl = _imageHelper.SaveFile(file);

        shirtImageDto.ImageUrl = shirtImageUrl;

        var shirtImage = _mapper.Map<ShirtImage>(shirtImageDto);
        var savedImg = await _imageRepository.CreateImageAsync(shirtImage);

        return ResultService.Ok(savedImg);
    }

    public async Task<ResultService> DeleteAsync(int id, int imageId)
    {
        var image = await _imageRepository.GetByShirtIdAndImageIdAsync(id, imageId);

        if (image is null)
        {
            return ResultService.Fail<ShirtImage>("Image not found!");
        }

        _imageHelper.DeleteFile(image.Url);

        await _imageRepository.DeleteAsync(image);
        return ResultService.Ok("");
    }
}
