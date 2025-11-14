namespace ABC_RETAIL_MVC.Models.DatabaseModels
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double Price { get; set; }
        public string? ImageUrl { get; set; }
        public int Quantity { get; set; }
    }
}
