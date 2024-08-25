using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interface;
using CleanArchMvc.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

[Authorize]
public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetCategoriesAsync();

        return View(categories);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryDto category)
    {
        if (ModelState.IsValid)
        {
            await _categoryService.AddCategoryAsync(category);
            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }


    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var category = await _categoryService.GetCategoryByIdAsync(id.Value);

        if (category == null) return NotFound();

        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoryDto category)
    {
        if (ModelState.IsValid)
        {
            await _categoryService.UpdateCategoryAsync(category);
            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var category = await _categoryService.GetCategoryByIdAsync(id.Value);

        if (category == null) return NotFound();

        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _categoryService.DeleteCategoryAsync(id);

        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var category = await _categoryService.GetCategoryByIdAsync(id.Value);

        if (category == null) return NotFound();

        return View(category);
    }
}