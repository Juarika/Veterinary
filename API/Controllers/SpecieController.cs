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

public class SpecieController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SpecieController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<SpecieDto>>> Get()
    {
        var specie = await _unitOfWork.Species.GetAllAsync();
        return _mapper.Map<List<SpecieDto>>(specie);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Species.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<SpecieDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SpecieDto>> Post(SpecieDto specieDto)
    {
        var specie = _mapper.Map<Specie>(specieDto);
        _unitOfWork.Species.Add(specie);
        await _unitOfWork.SaveAsync();
        if (specie == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = specie.Id}, specieDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SpecieDto>> Put(int id, [FromBody] SpecieDto specieDto)
    {
        if (specieDto == null) return NotFound();
        var specie = _mapper.Map<Specie>(specieDto);
        _unitOfWork.Species.Update(specie);
        await _unitOfWork.SaveAsync();
        return specieDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var specie = await _unitOfWork.Species.GetByIdAsync(id);
        if (specie == null) return NotFound();
        _unitOfWork.Species.Remove(specie);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    /* Listar todas las mascotas agrupadas por especie. */
    [HttpGet("Pets")]
    [MapToApiVersion("1.0")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> GetForSpecie([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Species.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<SpecieWithPetsDto>>(paginated);
    }
}