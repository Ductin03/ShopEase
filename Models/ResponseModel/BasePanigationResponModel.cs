namespace ShopEase.Models.ResponseModel
{
    public class BasePanigationResponModel<T>
    {
        public BasePanigationResponModel(int pageIndex, int pageSize,int total, IEnumerable<T> items ) {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Total = total;
            Items=items;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total {  get; set; }
        public IEnumerable<T> Items { get; set; }=Enumerable.Empty<T>();
    }
}
