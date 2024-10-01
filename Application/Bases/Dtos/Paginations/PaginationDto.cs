using Infrastructure.Bases.Models.FilterParams;
using Infrastructure.Bases.Models.SortParams;
using System.ComponentModel;

namespace Application.Bases.Dtos.Paginations
{
    public class PaginationDto
    {
        public List<FilterParam>? Filter { get; set; }
        public List<SortParam>? Sort { get; set; }
        [DefaultValue(int.MaxValue)]
        public int PageSize { get; set; } = int.MaxValue;
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;
    }
}
