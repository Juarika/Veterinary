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

public class MovementTypeController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MovementTypeController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<MovementTypeDto>>> Get()
    {
        var movementType = await _unitOfWork.MovementTypes.GetAllAsync();
        return _mapper.Map<List<MovementTypeDto>>(movementType);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.MovementTypes.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<MovementTypeDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MovementTypeDto>> Post(MovementTypeDto movementTypeDto)
    {
        var movementType = _mapper.Map<MovementType>(movementTypeDto);
        _unitOfWork.MovementTypes.Add(movementType);
        await _unitOfWork.SaveAsync();
        if (movementType == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = movementType.Id}, movementTypeDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MovementTypeDto>> Put(int id, [FromBody] MovementTypeDto movementTypeDto)
    {
        if (movementTypeDto == null) return NotFound();
        var movementType = _mapper.Map<MovementType>(movementTypeDto);
        _unitOfWork.MovementTypes.Update(movementType);
        await _unitOfWork.SaveAsync();
        return movementTypeDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var movementType = await _unitOfWork.MovementTypes.GetByIdAsync(id);
        if (movementType == null) return NotFound();
        _unitOfWork.MovementTypes.Remove(movementType);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}