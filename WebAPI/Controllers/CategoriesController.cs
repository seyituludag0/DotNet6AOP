using Business.Abstracts;
using Business.Dtos;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public List<Category> GetAll()
        {
            return _categoryService.GetAll();
        }

        [HttpPost("add")]
        public void Add(Category category)
        {
            _categoryService.Add(category);
        }
    }
}
