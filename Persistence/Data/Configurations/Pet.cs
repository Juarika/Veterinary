using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class Pet : BaseEntity
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public int OwnerId { get; set; }
    public Owner Owner { get; set; }
    public int BreedId { get; set; }
    public Breed Breed { get; set; }
    public int SpecieId { get; set; }
    public Specie Specie { get; set; }
}