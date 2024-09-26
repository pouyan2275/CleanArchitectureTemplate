using Application.Bases.Interfaces.IServices;
using Application.Dtos.Persons;
using Domain.Entities;

namespace Application.IServices
{
    public interface IPersonService : ICrudService<PersonDto, PersonDtoSelect, Person>
    {
    }
}
