using System.Text.Json.Serialization;

namespace Personal.Shared.Dtos.Paginations
{
    public class PaginationDto
    {
        public List<FilterPagination>? Filter { get; set; }
        public List<SortPagination>? Sort { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
