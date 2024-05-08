namespace Nike_clone_Backend.Models;

public class OrderProductModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Total { get; set; }
    public required OrderModel Order { get; set; }
    public required ProductModel Product { get; set; }
}