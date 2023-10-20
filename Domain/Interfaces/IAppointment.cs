using Domain.Entities;

namespace Domain.Interfaces;

public interface IAppointment : IGenericRepository<Appointment>
{ 
    IEnumerable<Pet> GetForMonthsAndMotive(int _monthInit, int _monthFinish, string _motive);
    Task<IEnumerable<Pet>> GetForVeterinarian(string _name);
}