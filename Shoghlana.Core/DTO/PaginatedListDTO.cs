namespace Shoghlana.Core.DTO
{
    public class PaginatedListDTO<T>
    {
        public IEnumerable<T> Items { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }
    }
}   