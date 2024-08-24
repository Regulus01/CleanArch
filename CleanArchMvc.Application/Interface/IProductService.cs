using CleanArchMvc.Application.DTO;

namespace CleanArchMvc.Application.Interface;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProducts();
    Task<ProductDto> GetProductById(int id);
    Task<ProductDto> GetProductByCategoryId(int id);
    
    Task<ProductDto> CreateProduct(ProductDto product);
    Task<ProductDto> UpdateProduct(ProductDto product);
    Task DeleteProduct(int id);
}