using Application.Bases.Interfaces.IServices;
using Application.Dtos.Degrees;
using Domain.Entities;

namespace Application.IServices;

public interface IDegreeService : ICrudService<DegreeDto, DegreeDtoSelect, Degree>
{
}
