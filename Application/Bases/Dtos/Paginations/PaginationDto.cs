using System.ComponentModel;

namespace Application.Bases.Dtos.Paginations
{
    public class PaginationDto
    {
        public List<FilterPagination>? Filter { get; set; }
        public List<SortPagination>? Sort { get; set; }
        [DefaultValue(int.MaxValue)]
        public int PageSize { get; set; } = int.MaxValue;
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;
    }
}
