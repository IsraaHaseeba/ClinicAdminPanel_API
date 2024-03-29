﻿using Microsoft.AspNetCore.Mvc;
using SpinelTest.DTOs;
using SpinelTest.Services;

namespace SpinelTest.Controllers
{
    [ApiController]
    [Route("/Category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null) { return NotFound(); }
            return Ok(category);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            var categories = await _categoryService.GetAll();
            if (categories == null) { return NotFound(); }
            return Ok(categories);
        }

        [HttpGet("CheckIfCodeExist/{code}/{id?}")]
        public async Task<ActionResult<bool>> CheckIfCodeExist(string code, int? id)
        {
            var isExisting = await _categoryService.CheckIfCodeExist(code, id);
            return Ok(isExisting);
        }

        [HttpPost("AddUpdate/{id?}")]
        public async Task<ActionResult<bool>> AddUpdate(int? id, CategoryDto doctor)
        {
            var isAdded = await _categoryService.AddUpdate(id, doctor);
            return Ok(isAdded);
        }

        [HttpDelete("Delete/{id}")]
        public async Task Delete(int id)
        {
            await _categoryService.Delete(id);
        }
    }
}