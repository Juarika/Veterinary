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

public class LaboratoryController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LaboratoryController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<LaboratoryDto>>> Get()
    {
        var laboratory = await _unitOfWork.Laboratories.GetAllAsync();
        return _mapper.Map<List<LaboratoryDto>>(laboratory);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Laboratories.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<LaboratoryDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LaboratoryDto>> Post(LaboratoryDto laboratoryDto)
    {
        var laboratory = _mapper.Map<Laboratory>(laboratoryDto);
        _unitOfWork.Laboratories.Add(laboratory);
        await _unitOfWork.SaveAsync();
        if (laboratory == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = laboratory.Id}, laboratoryDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LaboratoryDto>> Put(int id, [FromBody] LaboratoryDto laboratoryDto)
    {
        if (laboratoryDto == null) return NotFound();
        var laboratory = _mapper.Map<Laboratory>(laboratoryDto);
        _unitOfWork.Laboratories.Update(laboratory);
        await _unitOfWork.SaveAsync();
        return laboratoryDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var laboratory = await _unitOfWork.Laboratories.GetByIdAsync(id);
        if (laboratory == null) return NotFound();
        _unitOfWork.Laboratories.Remove(laboratory);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}