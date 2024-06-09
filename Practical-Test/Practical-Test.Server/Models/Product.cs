namespace Practical_Test.Server.Models
{
  public class Product
  {
    public int Id;
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string? Category { get; set; }
    public required decimal Price { get; set; }
  }
}