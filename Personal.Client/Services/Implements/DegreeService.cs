﻿using Personal.Shared.Dtos.Degrees;
using System.Net.Http.Json;

namespace Personal.Client.Services.Implements;

public class DegreeService
{
    private readonly HttpClient _httpClient;
    private readonly string _address = "api/Degree";

    public DegreeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<DegreeDtoSelect>> GetAll()
    {
        var result = await _httpClient.GetFromJsonAsync<List<DegreeDtoSelect>>(_address);
        return result ?? new();
    }
    public async Task<DegreeDtoSelect?> GetById(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<DegreeDtoSelect>($"{_address}/{id}");
    }
    public async Task<DegreeDtoSelect?> Add(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<DegreeDtoSelect>($"{_address}/{id}");
    }
    public async Task<DegreeDtoSelect?> Edit(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<DegreeDtoSelect>($"{_address}/{id}");
    }
    public async Task Delete (Guid id)
    {
        await _httpClient.DeleteAsync($"{_address}/{id}");
    }
}