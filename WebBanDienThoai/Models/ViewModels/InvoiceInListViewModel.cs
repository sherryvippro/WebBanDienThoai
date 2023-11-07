namespace WebBanDienThoai.Models.ViewModels
{
    public class InvoiceInListViewModel
    {
        public IEnumerable<THoaDonNhap> InvoiceIn { get; set; } = Enumerable.Empty<THoaDonNhap>();
        public PagingInfo PagingInfo { get; set; } = new PagingInfo();
    }
}
