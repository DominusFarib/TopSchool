namespace TopSchool.Domain.Helpers
{
    public class PaginationList<T> : List<T>
    {
        public int CurPage { get; set; }
        public int TotalPages { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }

        public PaginationList() { }
        public PaginationList(List<T> items) { this.AddRange(items); }

        public PaginationList(int curPage, int itemsPerPage, int totalItems)
        {
            CurPage = curPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;

            TotalPages = itemsPerPage < TotalItems
                ? (int)Math.Ceiling(Convert.ToDecimal(totalItems / itemsPerPage))
                : 1;
        }

        public PaginationList(List<T> items, int curPage, int itemsPerPage, int totalItems)
        {
            CurPage = curPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;

            TotalPages = itemsPerPage < TotalItems
                ? (int)Math.Ceiling(Convert.ToDecimal(totalItems / itemsPerPage))
                : 1;

            this.AddRange(items);
        }
        public static async Task<PaginationList<T>> GetNextPageAsync(
            IEnumerable<T> sourceItems,
            int curPage,
            int itemsPerPage)
        {
            var totalItems = sourceItems.Count();
            var items = sourceItems
                .Skip((curPage - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();

            return new PaginationList<T>(items, curPage, itemsPerPage, totalItems);
        }

    }
}
