

using Personal.Shared.Dtos.Paginations;
using Personal.Shared.Dtos.Persons;
using System.Net.Http.Json;

namespace Personal.Client.Services.Implements;

public class PersonService
{
    private readonly HttpClient _httpClient;
    private readonly string _address = "api/Person";

    public PersonService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<PersonDtoSelect>> GetAll()
    {
        return await _httpClient.GetFromJsonAsync<List<PersonDtoSelect>>(_address) ?? new();
    }
    public async Task<PersonDtoSelect?> GetById(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<PersonDtoSelect>($"{_address}/{id}");
    }
    public async Task Add(PersonDto person)
    {
        await _httpClient.PostAsJsonAsync<PersonDto>($"{_address}",person);
    }
    public async Task Update(Guid id,PersonDto person)
    {
        await _httpClient.PutAsJsonAsync($"{_address}/{id}",person);
    }
    public async Task Delete (Guid id)
    {
        await _httpClient.DeleteAsync($"{_address}/{id}");
    }

    public async Task<PaginationDtoSelect<PersonDtoSelect>> Pagination(PaginationDto filterParams)
    {
        var response = await _httpClient.PostAsJsonAsync(_address+"/pagination", filterParams);
        var result = await response.Content.ReadFromJsonAsync<PaginationDtoSelect<PersonDtoSelect>>();
        return result ?? new();
    }
}