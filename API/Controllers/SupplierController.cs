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

public class SupplierController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SupplierController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<SupplierDto>>> Get()
    {
        var uupplier = await _unitOfWork.Suppliers.GetAllAsync();
        return _mapper.Map<List<SupplierDto>>(uupplier);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Suppliers.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<SupplierDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SupplierDto>> Post(SupplierDto supplierDto)
    {
        var uupplier = _mapper.Map<Supplier>(supplierDto);
        _unitOfWork.Suppliers.Add(uupplier);
        await _unitOfWork.SaveAsync();
        if (uupplier == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = uupplier.Id}, supplierDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SupplierDto>> Put(int id, [FromBody] SupplierDto supplierDto)
    {
        if (supplierDto == null) return NotFound();
        var uupplier = _mapper.Map<Supplier>(supplierDto);
        _unitOfWork.Suppliers.Update(uupplier);
        await _unitOfWork.SaveAsync();
        return supplierDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var uupplier = await _unitOfWork.Suppliers.GetByIdAsync(id);
        if (uupplier == null) return NotFound();
        _unitOfWork.Suppliers.Remove(uupplier);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    /* Listar los proveedores que me venden un determinado medicamento. */
    // [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet("GetForMedicine")]
    [ApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SupplierDto>>> GetForMedicine([FromQuery] Params _param)
    {
        var data = await _unitOfWork.Suppliers.GetForMedicine(_param.Search);
        var search = _mapper.Map<List<SupplierDto>>(data);
        return search;
    }
}