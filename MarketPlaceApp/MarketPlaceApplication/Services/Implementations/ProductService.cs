using AutoMapper;

using MarketPlace.Application.Dto;
using MarketPlace.Data.Persistent.Classes;
using MarketPlace.Data.Persistent.Repositories.Interfaces;
using MarketPlaceApplication.Services.Interfaces;

namespace MarketPlace.Application.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        var productsDto = products
            .Select(product => _mapper.Map<ProductDto>(product));

        return productsDto;
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task AddProductAsync(Product? product)
    {
        await _productRepository.AddAsync(product);
    }

    public async Task UpdateProductAsync(Product? product)
    {
        await _productRepository.UpdateAsync(product);
    }

    public async Task RemoveProductAsync(Product? product)
    {
        await _productRepository.RemoveAsync(product);
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _productRepository.GetAllCategoriesAsync();
    }
}