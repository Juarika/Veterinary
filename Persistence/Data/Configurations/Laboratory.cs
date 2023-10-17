using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class Laboratory : BaseEntity
{
    public string Name { get; set; } 
    public string Direction { get; set; }
    public string Phone { get; set; } 
    public ICollection<Medicine> Medicines { get; set; }
}