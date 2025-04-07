namespace Basket.API.Models
{
    public class ShoppingCart
    {
        public string UserName { get; set; } = null!;
        public List<ShoppingCartItem> Items { get; set; } = new();
        public decimal TotalPrice => Items.Sum(item => item.Price * item.Quantity);
    }
}
