
using Domain.Entities;

namespace Application.Dtos.Categories;

public class PersonDtoSelect
{
    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? NationalCode { get; set; }
    public Guid Id { get; set; }
    public Guid? DegreeId { get; set; }
    public Degree? Degree { get; set; }
}
