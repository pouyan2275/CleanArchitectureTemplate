

using Personal.Shared.Dtos.Persons;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Personal.Client.Services.Implements;

public class PersonService
{
    private readonly HttpClient _httpClient;
    private readonly string _address = "api/Person";

    public PersonService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PersonDtoSelect[]?> GetAll()
    {
        return await _httpClient.GetFromJsonAsync<PersonDtoSelect[]>(_address);
    }
    public async Task<PersonDtoSelect?> GetById(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<PersonDtoSelect>($"{_address}/{id}");
    }
    public async Task Add(PersonDto person)
    {
        await _httpClient.PostAsJsonAsync<PersonDto>($"{_address}",person);
    }
    public async Task<PersonDtoSelect?> Edit(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<PersonDtoSelect>($"{_address}/{id}");
    }
    public async Task Delete (Guid id)
    {
        await _httpClient.DeleteAsync($"{_address}/{id}");
    }
}