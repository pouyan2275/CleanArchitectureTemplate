using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bases.Dtos.Paginations
{
    public class SortPagination
    {
        public required string Key { get; set; }
        public required bool Desc { get; set; } = true;

    }
}
