namespace VetS.Controllers.Resources
{
    public class ClienteQueryResource
    {
        public int? MascotaId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
