using System.ComponentModel.DataAnnotations;
using ABC_RETAIL_MVC.Models.DatabaseModels;

public class Order
{
    [Key]
    public int OrderId { get; set; }

    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
}
