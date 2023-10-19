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

public class MedicalTreatmentsController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MedicalTreatmentsController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<MedicalTreatmentsDto>>> Get()
    {
        var medicalTreatments = await _unitOfWork.MedicalTreatments.GetAllAsync();
        return _mapper.Map<List<MedicalTreatmentsDto>>(medicalTreatments);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.MedicalTreatments.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<MedicalTreatmentsDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MedicalTreatmentsDto>> Post(MedicalTreatmentsDto medicalTreatmentsDto)
    {
        var medicalTreatments = _mapper.Map<MedicalTreatments>(medicalTreatmentsDto);
        _unitOfWork.MedicalTreatments.Add(medicalTreatments);
        await _unitOfWork.SaveAsync();
        if (medicalTreatments == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = medicalTreatments.Id}, medicalTreatmentsDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MedicalTreatmentsDto>> Put(int id, [FromBody] MedicalTreatmentsDto medicalTreatmentsDto)
    {
        if (medicalTreatmentsDto == null) return NotFound();
        var medicalTreatments = _mapper.Map<MedicalTreatments>(medicalTreatmentsDto);
        _unitOfWork.MedicalTreatments.Update(medicalTreatments);
        await _unitOfWork.SaveAsync();
        return medicalTreatmentsDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var medicalTreatments = await _unitOfWork.MedicalTreatments.GetByIdAsync(id);
        if (medicalTreatments == null) return NotFound();
        _unitOfWork.MedicalTreatments.Remove(medicalTreatments);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}