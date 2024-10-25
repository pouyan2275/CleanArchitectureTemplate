using Domain.Bases.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Test : BaseEntityDbFirst
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}
