namespace Shoghlana.Core.DTO
{
    public class PaginatedListDTO<T> // : List<T> where T : class  // so that I can iterate on PaginatedListDTO
    {
        public IEnumerable<T> Items { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }
    }
}   