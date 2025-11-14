using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public double ProductPrice { get; set; }
    public int Stock { get; set; }
    public string? ProductDescription { get; set; }
    public string? ProductImageUrl { get; set; }
}
