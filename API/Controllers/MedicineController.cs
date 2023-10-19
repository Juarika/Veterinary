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

public class MedicineController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MedicineController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<MedicineDto>>> Get()
    {
        var medicine = await _unitOfWork.Medicines.GetAllAsync();
        return _mapper.Map<List<MedicineDto>>(medicine);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Medicines.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<MedicineDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MedicineDto>> Post(MedicineDto medicineDto)
    {
        var medicine = _mapper.Map<Medicine>(medicineDto);
        _unitOfWork.Medicines.Add(medicine);
        await _unitOfWork.SaveAsync();
        if (medicine == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = medicine.Id}, medicineDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MedicineDto>> Put(int id, [FromBody] MedicineDto medicineDto)
    {
        if (medicineDto == null) return NotFound();
        var medicine = _mapper.Map<Medicine>(medicineDto);
        _unitOfWork.Medicines.Update(medicine);
        await _unitOfWork.SaveAsync();
        return medicineDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var medicine = await _unitOfWork.Medicines.GetByIdAsync(id);
        if (medicine == null) return NotFound();
        _unitOfWork.Medicines.Remove(medicine);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}