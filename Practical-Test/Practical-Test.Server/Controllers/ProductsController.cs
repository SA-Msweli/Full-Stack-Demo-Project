using Microsoft.AspNetCore.Mvc;
using Practical_Test.Server.Models;
using Practical_Test.Server.Services;

namespace Practical_Test.Server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly ILogger<ProductsController> _logger;
    private readonly IProductService _productService = new ProductService();

    public ProductsController(ILogger<ProductsController> logger) => _logger = logger;

    [HttpGet("pruduct{id}", Name = "GetProduct")]
    public ActionResult<Product> GetProduct(int id) => 
      _productService.GetProduct(id) == null ? NotFound() : Ok(_productService.GetProduct(id));

    [HttpGet("pruducts", Name = "GetProducts")]
    public ActionResult<IEnumerable<Product>> GetProducts() => Ok(_productService.GetProducts());

    [HttpPost("pruduct", Name = "PostProduct")]
    public ActionResult<Product> PostProduct(Product product)
    {
      Product? newProduct = _productService.AddProduct(product);
      return newProduct == null ? BadRequest() : CreatedAtAction(nameof(GetProduct), new { newProduct.Id}, product);
    }

    [HttpPut("pruduct", Name = "UpdateProduct")]
    public ActionResult<Product> PutProduct(Product product) => Accepted(_productService.UpdateProduct(product));

    [HttpDelete("product{id}", Name ="DeleteProduct")]
    public ActionResult DeleteProduct(int id) => _productService.DeleteProduct(id) ? Ok() : NotFound();
  }
}
