using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class Specie : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Breed> Breeds { get; set; }
    public ICollection<Pet> Pets { get; set; }
}