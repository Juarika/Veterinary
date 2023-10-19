using API.Dtos;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

public class VeterinarianController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public VeterinarianController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userService = userService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<VeterinarianDto>>> Get()
    {
        var veterinarians = await _unitOfWork.Veterinarians.GetAllAsync();
        return _mapper.Map<List<VeterinarianDto>>(veterinarians);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VeterinarianDto>> Post(VeterinarianDto veterinarianDto)
    {
        var veterinarian = _mapper.Map<Veterinarian>(veterinarianDto);
        _unitOfWork.Veterinarians.Add(veterinarian);
        await _unitOfWork.SaveAsync();
        if (veterinarian == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = veterinarian.Id}, veterinarianDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VeterinarianDto>> Put(int id, [FromBody] VeterinarianDto veterinarianDto)
    {
        if (veterinarianDto == null) return NotFound();
        var veterinarian = _mapper.Map<Veterinarian>(veterinarianDto);
        _unitOfWork.Veterinarians.Update(veterinarian);
        await _unitOfWork.SaveAsync();
        return veterinarianDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var veterinarian = await _unitOfWork.Veterinarians.GetByIdAsync(id);
        if (veterinarian == null) return NotFound();
        _unitOfWork.Veterinarians.Remove(veterinarian);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}