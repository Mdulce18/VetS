﻿namespace VetS.Controllers.Resources
{
    public class MascotaQueryResource
    {
        public int? AnimalId { get; set; }
        public int? RazaId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
