using Microsoft.AspNetCore.Components;
using Personal.Client.Services.Implements;
using Personal.Shared.Dtos.Degrees;
using Personal.Shared.Dtos.Paginations;
using Personal.Shared.Dtos.Persons;

namespace Personal.Client.Pages.Person.Components
{
    public partial class SearchComponent
    {
        Guid defaultGuid = default(Guid);
        [Inject] PersonService personService { get; set; }
        [Inject] DegreeService degreeService { get; set; }
        List<DegreeDtoSelect> degrees = new();
        PersonDto person = new();
        [Parameter] public EventCallback<PaginationDtoSelect<PersonDtoSelect>> OnSearchResult { get; set; }
        protected override async Task OnInitializedAsync()
        {
            degrees = await degreeService.GetAll();
        }
        async Task SearchClicked()
        {
            var filterParams = new PaginationDto
            {
                Filter = new()
            };
            if (!string.IsNullOrEmpty(person.Name) && !string.IsNullOrWhiteSpace(person.Name))
            {
                var filter = new FilterPagination
                {
                    Key = "Name",
                    Operator = FilterOperator.Contains,
                    Value = person.Name
                };
                filterParams.Filter.Add(filter);
            }
            if (!string.IsNullOrEmpty(person.Family) && !string.IsNullOrWhiteSpace(person.Family))
            {
                var filter = new FilterPagination
                {
                    Key = "Family",
                    Operator = FilterOperator.Contains,
                    Value = person.Family
                };
                filterParams.Filter.Add(filter);
            }
            if (!string.IsNullOrEmpty(person.NationalCode) && !string.IsNullOrWhiteSpace(person.NationalCode))
            {
                var filter = new FilterPagination
                {
                    Key = "NationalCode",
                    Operator = FilterOperator.Contains,
                    Value = person.NationalCode
                };
                filterParams.Filter.Add(filter);
            }
            if (person.DegreeId != default(Guid))
            {
                var filter = new FilterPagination
                {
                    Key = "DegreeId",
                    Operator = FilterOperator.Contains,
                    Value = person.DegreeId.ToString()!
                };
                filterParams.Filter.Add(filter);
            }
            var result = await personService.Pagination(filterParams);
            await OnSearchResult.InvokeAsync(result);
        }
    }
}