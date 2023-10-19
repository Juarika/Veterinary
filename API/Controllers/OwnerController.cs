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

public class OwnerController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OwnerController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<OwnerDto>>> Get()
    {
        var owner = await _unitOfWork.Owners.GetAllAsync();
        return _mapper.Map<List<OwnerDto>>(owner);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Owners.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<OwnerDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OwnerDto>> Post(OwnerDto OwnerDto)
    {
        var owner = _mapper.Map<Owner>(OwnerDto);
        _unitOfWork.Owners.Add(owner);
        await _unitOfWork.SaveAsync();
        if (owner == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = owner.Id}, OwnerDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OwnerDto>> Put(int id, [FromBody] OwnerDto OwnerDto)
    {
        if (OwnerDto == null) return NotFound();
        var owner = _mapper.Map<Owner>(OwnerDto);
        _unitOfWork.Owners.Update(owner);
        await _unitOfWork.SaveAsync();
        return OwnerDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var owner = await _unitOfWork.Owners.GetByIdAsync(id);
        if (owner == null) return NotFound();
        _unitOfWork.Owners.Remove(owner);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    /* Listar los propietarios y sus mascotas. */
    [HttpGet("Pets")]
    [MapToApiVersion("1.0")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> GetForSpecie([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Owners.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<OwnerWithPetsDto>>(paginated);
    }
}