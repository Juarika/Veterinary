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

public class DetailMovementController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DetailMovementController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<DetailMovementDto>>> Get()
    {
        var detailMovement = await _unitOfWork.DetailMovements.GetAllAsync();
        return _mapper.Map<List<DetailMovementDto>>(detailMovement);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.DetailMovements.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<DetailMovementDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetailMovementDto>> Post(DetailMovementDto detailMovementDto)
    {
        var detailMovement = _mapper.Map<DetailMovement>(detailMovementDto);
        _unitOfWork.DetailMovements.Add(detailMovement);
        await _unitOfWork.SaveAsync();
        if (detailMovement == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = detailMovement.Id}, detailMovementDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetailMovementDto>> Put(int id, [FromBody] DetailMovementDto detailMovementDto)
    {
        if (detailMovementDto == null) return NotFound();
        var detailMovement = _mapper.Map<DetailMovement>(detailMovementDto);
        _unitOfWork.DetailMovements.Update(detailMovement);
        await _unitOfWork.SaveAsync();
        return detailMovementDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var detailMovement = await _unitOfWork.DetailMovements.GetByIdAsync(id);
        if (detailMovement == null) return NotFound();
        _unitOfWork.DetailMovements.Remove(detailMovement);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}