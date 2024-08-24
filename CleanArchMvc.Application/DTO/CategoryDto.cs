using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTO;

public class CategoryDto
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "The name is required")]
    [MinLength(3, ErrorMessage = "The name must be at least 3 characters long")]
    [MaxLength(100, ErrorMessage = "The name cannot be longer than 100 characters")]
    public string Name { get; set; }
}