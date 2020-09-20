using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetS.Extensions;

namespace VetS.Core.Models
{
    public class ClienteQuery : IQueryObject
    {
        public int? MascotaId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
