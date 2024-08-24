using CleanArchMvc.Application.DTO;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Interface;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
    Task<CategoryDto> GetCategoryByIdAsync(int id);
    Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto);
    Task<CategoryDto> UpdateCategoryAsync(CategoryDto categoryDto);
    Task DeleteCategoryAsync(int id);
}