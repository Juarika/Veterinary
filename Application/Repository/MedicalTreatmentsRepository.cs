using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class MedicalTreatmentsRepository : GenericRepository<MedicalTreatments>, IMedicalTreatments
{
    private readonly SkelettonContext _context;

    public MedicalTreatmentsRepository(SkelettonContext context) : base(context)
    {
       _context = context;
    }
}