using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class Breed : BaseEntity
{
    public string Name { get; set; }
    public int SpecieId { get; set; }
    public Specie Specie { get; set; }
    public ICollection<Pet> Pets { get; set; }
}