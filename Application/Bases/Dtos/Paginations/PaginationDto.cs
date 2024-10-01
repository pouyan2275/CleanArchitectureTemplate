using System.Text.Json.Serialization;

namespace Application.Bases.Dtos.Paginations
{
    public class PaginationDto
    {
        public List<FilterPagination>? Filter { get; set; }
        public List<SortPagination>? Sort { get; set; }
        public int PageSize { get; set; } = int.MaxValue;
        public int PageNumber { get; set; } = 1;
    }
}
