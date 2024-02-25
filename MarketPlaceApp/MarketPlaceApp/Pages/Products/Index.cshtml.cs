using MarketPlace.Application.Dto;
using MarketPlace.Data.Persistent.Classes;
using MarketPlaceApplication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.Pages.Products;

[AllowAnonymous]
public class IndexModel : PageModel
{
    private readonly IProductService _productService;

    [BindProperty(SupportsGet = true)] public string SortOrder { get; set; }

    [BindProperty(SupportsGet = true)] public string categorySelect { get; set; }

    public IList<ProductDto> ProductsDto { get; set; }

    public List<Category> Categories { get; set; }

    public IndexModel(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> OnGetAsync(string? sortOrder, string? category)
    {
        SortOrder = sortOrder ?? "name";
        categorySelect = category;

        ViewData["NameSortParam"] = SortOrder == "name" ? "name_desc" : "name";
        ViewData["PriceSortParam"] = SortOrder == "price" ? "price_desc" : "price";
        ViewData["QuantitySortParam"] = SortOrder == "quantity" ? "quantity_desc" : "price";

        var products = await _productService.GetAllProductsAsync();
        products = SortOrder switch
        {
            "name_desc" => products.OrderByDescending(p => p.Name),
            "price" => products.OrderBy(p => p.Price),
            "price_desc" => products.OrderByDescending(p => p.Price),
            "quantity" => products.OrderBy(p => p.Quantity),
            "quantity_desc" => products.OrderByDescending(p => p.Quantity),
            _ => products.OrderBy(p => p.Name)
        };
        ProductsDto = products.ToList();

        Categories = await _productService.GetAllCategoriesAsync();

        if (!string.IsNullOrEmpty(category))
        {
            ProductsDto = ProductsDto.Where(p => p.CategoryName == category).ToList();
        }

        return Page();
    }
}