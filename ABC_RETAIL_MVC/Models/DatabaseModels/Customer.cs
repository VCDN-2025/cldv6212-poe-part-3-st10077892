using System.ComponentModel.DataAnnotations;

namespace ABC_RETAIL_MVC.Models.DatabaseModels
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerAddress { get; set; }
    }
}
