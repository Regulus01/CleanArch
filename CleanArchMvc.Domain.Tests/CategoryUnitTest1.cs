using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create Category with valid state")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        var action = () => new Category(1, "Category Name");

        action.Should().NotThrow<DomainExceptionValidation>();
    }
    
    [Fact(DisplayName = "Create Category with negative id throws exception")]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        var action = () => new Category(-1, "Category Name");

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Id must be greater than zero.");
    }
    
    [Fact]
    public void CreateCategory_EmptyName_DomainExceptionNameMustBeAtLeastThreeCharacters()
    {
        var action = () => new Category("Ca");

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Name must be at least 3 characters long.");
    }
    
    [Fact]
    public void CreateCategory_EmptyName_DomainExceptionNameEmpty()
    {
        var action = () => new Category(1, string.Empty);

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Name cannot be null or empty.");
    }

    [Fact]
    public void UpdateCategory_WithValidParameters_ResultObjectValidState()
    {
        var action = () =>
        {
            var category = new Category(1, "Category Name");
            
            category.Update(category);
        };
        
        action.Should().NotThrow<DomainExceptionValidation>();
    }
}
