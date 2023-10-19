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

public class MedicineMovementController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MedicineMovementController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<MedicineMovementDto>>> Get()
    {
        var medicineMovement = await _unitOfWork.MedicineMovements.GetAllAsync();
        return _mapper.Map<List<MedicineMovementDto>>(medicineMovement);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.MedicineMovements.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<MedicineMovementDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MedicineMovementDto>> Post(MedicineMovementDto breedDto)
    {
        var medicineMovement = _mapper.Map<MedicineMovement>(breedDto);
        _unitOfWork.MedicineMovements.Add(medicineMovement);
        await _unitOfWork.SaveAsync();
        if (medicineMovement == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = medicineMovement.Id}, breedDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MedicineMovementDto>> Put(int id, [FromBody] MedicineMovementDto breedDto)
    {
        if (breedDto == null) return NotFound();
        var medicineMovement = _mapper.Map<MedicineMovement>(breedDto);
        _unitOfWork.MedicineMovements.Update(medicineMovement);
        await _unitOfWork.SaveAsync();
        return breedDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var medicineMovement = await _unitOfWork.MedicineMovements.GetByIdAsync(id);
        if (medicineMovement == null) return NotFound();
        _unitOfWork.MedicineMovements.Remove(medicineMovement);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}