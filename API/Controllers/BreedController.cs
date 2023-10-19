using API.Dtos;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using API.Helpers;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class BreedController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BreedController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userService = userService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<BreedDto>>> Get()
    {
        var breed = await _unitOfWork.Breeds.GetAllAsync();
        return _mapper.Map<List<BreedDto>>(breed);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Breeds.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<BreedDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BreedDto>> Post(BreedDto breedDto)
    {
        var breed = _mapper.Map<Breed>(breedDto);
        _unitOfWork.Breeds.Add(breed);
        await _unitOfWork.SaveAsync();
        if (breed == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = breed.Id}, breedDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BreedDto>> Put(int id, [FromBody] BreedDto breedDto)
    {
        if (breedDto == null) return NotFound();
        var breed = _mapper.Map<Breed>(breedDto);
        _unitOfWork.Breeds.Update(breed);
        await _unitOfWork.SaveAsync();
        return breedDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var breed = await _unitOfWork.Breeds.GetByIdAsync(id);
        if (breed == null) return NotFound();
        _unitOfWork.Breeds.Remove(breed);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}