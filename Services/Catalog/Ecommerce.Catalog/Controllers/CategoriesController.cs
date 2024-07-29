﻿using Ecommerce.Catalog.Dtos.CategoryDtos;
using Ecommerce.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> categoryList()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return Ok(values); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getCategoryById(string id)
        {
            var values =await _categoryService.getByIdCategoryAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> createCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori Başarıyla Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> deleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Kategori Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> updateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori Başarıyla Güncellendi");
        }
    }
}
