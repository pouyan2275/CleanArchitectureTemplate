using Domain.Bases.Entities;

namespace Domain.Entities;

public class Degree : BaseEntity
{
    public string? Title { get; set; }
    public int? Index { get; set; }
    public ICollection<Person>? Person { get; } = [];
}
