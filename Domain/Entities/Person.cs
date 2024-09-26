using Domain.Bases.Interfaces.Entities;

namespace Domain.Entities;

public class Person : IBaseEntity
{   
    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? NationalCode { get; set; }
    public Guid? DegreeId { get; set; }
    public Degree? Degree { get; set; }
    public Guid Id { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
}
