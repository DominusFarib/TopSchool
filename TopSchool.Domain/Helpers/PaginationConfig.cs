namespace TopSchool.Domain.Helpers
{
    public class PaginationConfig
    {
        public const int MaxItemsPerPage = 50;
        public int CurrentPage { get; set; }
        // TODO: Add Variaveis de ambiente no settings.json
        private int _itemsPerPage = 5;
        public int ItemsPerPage
        {
            get { return _itemsPerPage; }
            set { _itemsPerPage = value > MaxItemsPerPage ? MaxItemsPerPage : value; }
        }
    }
}
