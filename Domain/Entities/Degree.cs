using Domain.Bases.Interfaces.Entities;

namespace Domain.Entities;

public class Degree : IBaseEntity
{
    public string? Title { get; set; }
    public int? Index { get; set; }
    public ICollection<Person>? Person { get; } = [];
    public Guid Id { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
}
