using Practical_Test.Server.Models;

namespace Practical_Test.Server.Services
{
  public interface IProductService
  {
    Product? GetProduct(int id);
    ICollection<Product> GetProducts();
    bool DeleteProduct(int id);
    Product? AddProduct(Product product);
    Product? UpdateProduct(Product product);
  }
}