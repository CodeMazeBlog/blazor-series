namespace Entities.RequestFeatures
{
    public class ProductParameters
    {
        private const int MaxPageSize = 50; 
        public int PageNumber { get; set; } = 1; 
        private int _pageSize = 4; 
        public int PageSize 
        { 
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        public string SearchTerm { get; set; }
    }
}
