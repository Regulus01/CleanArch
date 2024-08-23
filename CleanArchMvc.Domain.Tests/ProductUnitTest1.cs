using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class ProductUnitTest1
{
    [Fact(DisplayName = "Create Product with valid state")]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        var action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "image");

        action.Should().NotThrow<DomainExceptionValidation>();
    }
    
    [Fact]
    public void CreateProduct_WithNullImage_NoDomainException()
    {
        var action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);

        action.Should().NotThrow<DomainExceptionValidation>();
    }
    
    [Fact]
    public void CreateProduct_WithNullImage_NoNullReferenceException()
    {
        var action = () => new Product("Product Name", "Product Description", 9.99m, 99, null);

        action.Should().NotThrow<NullReferenceException>();
    }

    
    [Fact]
    public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
    {
        var action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "image");

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
    }

}