using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductAsync();
    Task<Product> GetByIdAsync(int? id);
    
    Task<Product> CreateAsync(Product category);
    Task<Product> UpdateAsync(Product category);
    Task<Product> DeleteAsync(Product category);
}