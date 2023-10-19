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

public class PetController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PetController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<PetDto>>> Get()
    {
        var pet = await _unitOfWork.Pets.GetAllAsync();
        return _mapper.Map<List<PetDto>>(pet);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Pets.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<PetDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PetDto>> Post(PetDto petDto)
    {
        var pet = _mapper.Map<Pet>(petDto);
        _unitOfWork.Pets.Add(pet);
        await _unitOfWork.SaveAsync();
        if (pet == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = pet.Id}, petDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PetDto>> Put(int id, [FromBody] PetDto petDto)
    {
        if (petDto == null) return NotFound();
        var pet = _mapper.Map<Pet>(petDto);
        _unitOfWork.Pets.Update(pet);
        await _unitOfWork.SaveAsync();
        return petDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var pet = await _unitOfWork.Pets.GetByIdAsync(id);
        if (pet == null) return NotFound();
        _unitOfWork.Pets.Remove(pet);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    /* Mostrar las mascotas que se encuentren registradas cuya especie sea felina. */
    [HttpGet("Species")]
    [MapToApiVersion("1.0")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public object GetForSpecie([FromQuery] Params queryParams)
    {
        var search = _unitOfWork.Pets.Find(e => e.Specie.Name == queryParams.Specie);
        return _mapper.Map<List<PetDto>>(search);
    }
}