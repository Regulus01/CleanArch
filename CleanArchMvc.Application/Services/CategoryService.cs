using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interface;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
    {
        var categories = await _categoryRepository.GetCategoriesAsync();
        
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        
        var categoryInclude = await _categoryRepository.CreateAsync(category);
        
        return _mapper.Map<CategoryDto>(categoryInclude);
    }

    public async Task<CategoryDto> UpdateCategoryAsync(CategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        
        var categoryInclude = await _categoryRepository.UpdateAsync(category);
        
        return _mapper.Map<CategoryDto>(categoryInclude);
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        if (category == null)
            throw new Exception($"Category with id: {id} does not exist");
        
        await _categoryRepository.DeleteAsync(category);
    }
}