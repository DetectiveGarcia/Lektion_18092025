using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    //vg del, ProductResult AddProductToList();
    ProductResult AddProductToList(Product product);
    ProductResult<IEnumerable<Product>> GetAllProducts();

}
