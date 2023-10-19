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

public class AppointmentController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AppointmentController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> Get()
    {
        var appointment = await _unitOfWork.Appointments.GetAllAsync();
        return _mapper.Map<List<AppointmentDto>>(appointment);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Appointments.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<AppointmentDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AppointmentDto>> Post(AppointmentDto appointmentDto)
    {
        var appointment = _mapper.Map<Appointment>(appointmentDto);
        _unitOfWork.Appointments.Add(appointment);
        await _unitOfWork.SaveAsync();
        if (appointment == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = appointment.Id}, appointmentDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AppointmentDto>> Put(int id, [FromBody] AppointmentDto appointmentDto)
    {
        if (appointmentDto == null) return NotFound();
        var appointment = _mapper.Map<Appointment>(appointmentDto);
        _unitOfWork.Appointments.Update(appointment);
        await _unitOfWork.SaveAsync();
        return appointmentDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
        if (appointment == null) return NotFound();
        _unitOfWork.Appointments.Remove(appointment);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}