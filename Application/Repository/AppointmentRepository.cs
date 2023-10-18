using Domain.Entities;
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
}