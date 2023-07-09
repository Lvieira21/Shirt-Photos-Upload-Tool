namespace TShirt.Photos.App.Application.Services;

using AutoMapper;
using Domain.Repositories;
using DTOs;
using Interfaces;

public class ShirtService : IShirtService
{
    private readonly IShirtRepository _repository;
    private readonly IMapper _mapper;

    public ShirtService(IShirtRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResultService<List<ShirtsDTO>>> GetAllAsync()
    {
        var shirts = await _repository.GetAllAsync();

        return !shirts.Any() ? ResultService.Fail<List<ShirtsDTO>>("No T-Shirts were found.")
            : ResultService.Ok(_mapper.Map<List<ShirtsDTO>>(shirts));
    }

    public async Task<ResultService<ShirtDTO>> GetByIdAsync(int id)
    {
        var shirt = await _repository.GetByIdAsync(id);
        return ResultService.Ok(_mapper.Map<ShirtDTO>(shirt));
    }
}
