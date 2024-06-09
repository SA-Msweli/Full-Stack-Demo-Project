
using Practical_Test.Server.Models;

namespace Practical_Test.Server.Services
{
  public class ProductService : IProductService
  {
    private static readonly Dictionary<int,Product> products = [];

    #region private methods
    private bool ExistingId(int id) => products.ContainsKey(id);
    private int NewId() => products.Keys.Count == 0 ? 0 : products.Keys.Order().Last() + 1;

    #endregion

    public Product AddProduct(Product product)
    {
      products.Add(NewId(), product);
      return product;
    }

    public Product UpdateProduct(Product product)
    {
      products[product.Id] = product;
      return product;
    }

    public Product? GetProduct(int id) => products.GetValueOrDefault(id);

    public ICollection<Product> GetProducts() => products.Values;
    public bool DeleteProduct(int id) => products.Remove(id);
  }
}
