using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;

public sealed class Category : EntityBase
{
    public string Name { get; private set; }
    
    public ICollection<Product> Products { get; set; }
    
    public Category(int id, string name)
    {
        DomainExceptionValidation.When(id < 0, "Id must be greater than zero.");
        Id = id;
        Validate(name);
    }
    
    public Category(string name)
    {
        Validate(name);
    }

    public void Update(Category category)
    {
        Validate(category.Name);
    }
    
    private void Validate(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name cannot be null or empty.");
        DomainExceptionValidation.When(name.Length < 3, "Name must be at least 3 characters long.");
        
        Name = name;
    }
}