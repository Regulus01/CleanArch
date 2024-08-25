using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchMvc.WebUI.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductsController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetProducts();

        return View(products);
    }

    [HttpGet]
    public async Task<ActionResult> Create()
    {
        ViewBag.CategoryId = new SelectList(await _categoryService.GetCategoriesAsync(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductDto productDto)
    {
        if (ModelState.IsValid)
        {
            await _productService.CreateProduct(productDto);
            return RedirectToAction("Index");
        }
        
        ViewBag.CategoryId = new SelectList(await _categoryService.GetCategoriesAsync(), "Id", "Name");

        return View(productDto);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _productService.GetProductById(id);
        
        ViewBag.CategoryId = new SelectList(await _categoryService.GetCategoriesAsync(), "Id", "Name", product.CategoryId);

        
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductDto productDto)
    {
        if (ModelState.IsValid)
        {
            await _productService.UpdateProduct(productDto);
            return RedirectToAction("Index");
        }
        
        ViewBag.CategoryId = new SelectList(await _categoryService.GetCategoriesAsync(), "Id", "Name", productDto.CategoryId);

        return View(productDto);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productService.GetProductById(id);
        
        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _productService.DeleteProduct(id);
        
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var category = await _productService.GetProductById(id.Value);

        return View(category);
    }
}