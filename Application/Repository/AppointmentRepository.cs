using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class AppointmentRepository : GenericRepository<Appointment>, IAppointment
{
    private readonly SkelettonContext _context;

    public AppointmentRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }

    public IEnumerable<Pet> GetForMonthsAndMotive(int _monthInit, int _monthFinish, string _motive)
    {
        DateTime dateInit = new DateTime(2023,_monthInit,01);
        DateTime dateFinish = new DateTime(2023,_monthFinish,31);
        var search = _context.Appointments
                                .Where(e => e.Date >= dateInit && e.Date <= dateFinish && e.Reason == _motive)
                                .Select(e => e.Pet);
        return search;
    }

    public async Task<IEnumerable<Pet>> GetForVeterinarian(string _name)
    {
        if( _name == null){
            return await _context.Set<Appointment>()
            .Include(e => e.Pet)
            .Select(e => e.Pet)
            .ToListAsync();
        }
        return await _context.Set<Appointment>()
            .Include(e => e.Pet)
            .ThenInclude(e => e.Breed)
            .ThenInclude(e => e.Specie)
            .Include(e => e.Veterinarian)
            .Where(e => e.Veterinarian.Name.ToLower() == _name.ToLower())
            .Select(e => e.Pet)
            .ToListAsync();
    }
}