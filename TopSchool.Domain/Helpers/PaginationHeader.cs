namespace TopSchool.Domain.Helpers
{
    public class PaginationHeader
    {
        public int CurPage { get; set; }
        public int TotalPages { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }

        public PaginationHeader(int curPage, int totalPages, int itemsPerPage, int totalItems)
        {
            CurPage = curPage;
            TotalPages = totalPages;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
        }
    }
}
