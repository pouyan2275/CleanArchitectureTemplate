using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Personal.Client.Pages.Person.Components;
using Personal.Client.Services.Implements;
using Personal.Shared.Dtos.Paginations;
using Personal.Shared.Dtos.Persons;

namespace Personal.Client.Pages.Person
{
    public partial class Person
    {
        List<PersonDtoSelect> personal;
        FormModal formModal;
        SearchComponent searchComponent;
        [Inject] IJSRuntime jSRuntime { get; set; }
        [Inject] PersonService personService { get; set; }
        PaginationDto filterParam = new PaginationDto();
        protected override async Task OnInitializedAsync()
        {
            await GetAllPersonal();
        }

        async Task GetAllPersonal()
        {
            personal = await personService.GetAll();
        }

        async Task OpenAddModal()
        {
            await formModal.OpenModal();
        }

        async Task OpenEditModal(PersonDtoSelect selectedRow)
        {
            var person = new PersonDto
            {
                Id = selectedRow.Id,
                DegreeId = selectedRow.DegreeId,
                Family = selectedRow.Family,
                Name = selectedRow.Name,
                NationalCode = selectedRow.NationalCode
            };
            await formModal.OpenModal(person);
        }

        async Task Delete(Guid id)
        {
            await personService.Delete(id);
            await GetAllPersonal();
            await ShowMessage("حذف", "حذف با موفقیت انجام شد");
        }

        async Task OnPersonCreated(PersonDto person)
        {
            await personService.Add(person);
            await GetAllPersonal();
            await ShowMessage("ذخیره", "ذخیره با موفقیت انجام شد");
        }

        async Task OnPersonUpdated(PersonDto person)
        {
            await personService.Update(person.Id, person);
            await GetAllPersonal();
            await ShowMessage("ویرایش", "ویرایش با موفقیت انجام شد");

        }

        async Task OnSearchResult(PaginationDtoSelect<PersonDtoSelect> pagination)
        {
            personal = pagination.Data;
        }

        async Task ShowMessage(string title, string message)
        {
            await jSRuntime.InvokeVoidAsync("ShowAlert", title, message);
        }
    }
}