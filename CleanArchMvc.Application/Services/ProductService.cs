using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interface;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services;

public class ProductService : IProductService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    
    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        var products = await _mediator.Send(new GetProductsQuery());
        
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto> GetProductById(int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));
        
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> GetProductByCategoryId(int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));
        
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> CreateProduct(ProductDto product)
    {
        var command = _mapper.Map<ProductCreateCommand>(product);

        var productEntity = await _mediator.Send(command);
        
        return _mapper.Map<ProductDto>(productEntity);
    }

    public async Task<ProductDto> UpdateProduct(ProductDto product)
    {
        var command = _mapper.Map<ProductUpdateCommand>(product);

        var productEntity = await _mediator.Send(command);
        
        return _mapper.Map<ProductDto>(productEntity);
    }

    public async Task DeleteProduct(int id)
    {
        await _mediator.Send(new ProductRemoveCommand(id));
    }
}