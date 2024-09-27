using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Personal.Client.Services.Implements;
using Personal.Shared.Dtos.Degrees;
using Personal.Shared.Dtos.Paginations;
using Personal.Shared.Dtos.Persons;

namespace Personal.Client.Pages.Person.Components;

public partial class FormModal
{
    private enum ModelJob
    {
        Add,
        Edit
    }
    ModelJob modelJob;
    PaginationDto filterParam;
    Guid defaultGuid = default(Guid);
    string modalId = Guid.NewGuid().ToString();
    PersonDto person = new();
    string nationalCodeValidation = "";
    string? personNationalCode;
    bool disableSave = true;
    List<DegreeDtoSelect> degrees = new();
    [Parameter] public EventCallback<PersonDto> OnPersonCreated { get; set; }
    [Parameter] public EventCallback<PersonDto> OnPersonUpdated { get; set; }
    [Inject] public IJSRuntime JSRuntime { get; set; }
    [Inject] public PersonService personService { get; set; }
    [Inject] DegreeService degreeService { get;set; }
    protected override async Task OnInitializedAsync()
    {
        degrees = await degreeService.GetAll();

    }

    public async Task OpenModal()
    {
        modelJob = ModelJob.Add;
        await JSRuntime.InvokeVoidAsync("OpenFormModal", modalId);
        personNationalCode = "";
    }


    public async Task OpenModal(PersonDto personDto)
    {
        modelJob = ModelJob.Edit;
        person = personDto;
        personNationalCode = personDto.NationalCode;
        await JSRuntime.InvokeVoidAsync("OpenFormModal", modalId);
        nationalCodeValidation = "";


    }

    public async Task CheckNationalCode()
    {
        if (person.NationalCode == null || personNationalCode == null || personNationalCode == person.NationalCode)
        {
            disableSave = false;
            nationalCodeValidation = "is-valid";
            return;
        }

        filterParam = new();
        filterParam.Filter = new()
    {
        new FilterPagination
        {
            Key = "NationalCode",
            Operator = FilterOperator.Equal,
            Value = person.NationalCode
        }
    };
        var result = await personService.Pagination(filterParam);
        if (result.Data.Count > 0)
        {
            nationalCodeValidation = "is-invalid";
            disableSave = true;
        }
        else
        {
            nationalCodeValidation = "is-valid";
            disableSave = false;

        }

    }

    async Task OnSave()
    {
        if (person.DegreeId == default(Guid))
            person.DegreeId = null;
        switch (modelJob)
        {
            case ModelJob.Add:
                await OnPersonCreated.InvokeAsync(person);
                break;
            case ModelJob.Edit:
                await OnPersonUpdated.InvokeAsync(person);
                break;
            default:
                break;

        }

        await JSRuntime.InvokeVoidAsync("CloseFormModal", modalId);
        person = new();
    }
}