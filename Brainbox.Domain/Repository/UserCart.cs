namespace Brainbox.Domain.Repository
{
    public class UserCart
    {
        public int id { get; internal set; }
        public int productId { get; internal set; }
        public int userId { get; internal set; }
        public string userEmail { get; internal set; }
        public decimal unitPrice { get; internal set; }
        public int quantity { get; internal set; }
        public string productName { get; internal set; }
    }

    public class UserCartTotal
    {
        public List<UserCart> cart { get; internal set; }
        public decimal total { get; internal set; }
    }
}