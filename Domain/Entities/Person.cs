using Domain.Bases.Entities;

namespace Domain.Entities;

public class Person : BaseEntity
{   
    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? NationalCode { get; set; }
    public Guid? DegreeId { get; set; }
    public Degree? Degree { get; set; }
}
