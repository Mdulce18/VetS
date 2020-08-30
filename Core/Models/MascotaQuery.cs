using VetS.Extensions;

namespace VetS.Core.Models
{
    public class MascotaQuery : IQueryObject
    {
        public int? AnimalId { get; set; }
        public int? RazaId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
    }
}
