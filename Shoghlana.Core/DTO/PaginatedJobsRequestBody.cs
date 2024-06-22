namespace Shoghlana.Core.DTO
{
    public class PaginatedJobsRequestBody
    {
        public int[]? CategoriesIDs { get; set; } = null;

        public string[]? Includes { get; set; } = null;
    }
}