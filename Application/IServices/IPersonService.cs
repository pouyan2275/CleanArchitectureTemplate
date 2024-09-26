using Application.Bases.Dtos.Paginations;
using Application.Bases.Interfaces.IServices;
using Application.Dtos.Categories;
using Domain.Entities;

namespace Application.IServices
{
    public interface IPersonService : ICrudService<PersonDto, PersonDtoSelect, Person>
    {
    }
}
