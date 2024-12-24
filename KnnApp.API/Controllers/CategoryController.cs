

using AutoMapper;
using KnnApp.Core.DTOs.Category;
using KnnApp.Core.Entityes;
using KnnApp.DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnnApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    KnnAppDbContext _db;
    IMapper _mapper;
    public CategoryController(KnnAppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDTO categoryDTO)
    {
        var newCategory = _mapper.Map<Category>(categoryDTO);

        await _db.Categories.AddAsync(newCategory);
        await _db.SaveChangesAsync();

        return StatusCode(StatusCodes.Status201Created, newCategory);
    }

    [HttpGet("{id}")]
    public IActionResult GetCategory(int id) 
    {
        var category=_db.Categories.FirstOrDefault(c => c.Id == id);
        return category==null ? NotFound() : Ok(category); 
    }

    [HttpGet]
    public IActionResult GetAllCategories()
    {
        return Ok(_db.Categories.ToList());
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory(UpdateCategoryDTO dto)
    { 
        var category = _db.Categories.AsNoTracking().FirstOrDefault(c=>c.Id == dto.Id);
        if (category==null) return NotFound(" yoxdur bele bir category ");
        category=_mapper.Map<Category>(dto);
        _db.Categories.Update(category);
        _db.SaveChanges();
        return Ok(category);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var category = _db.Categories.FirstOrDefault(c =>c.Id == id);
        if (category==null) return NotFound();
        _db.Categories.Remove(category);
        _db.SaveChanges();
        return StatusCode(StatusCodes.Status204NoContent);
    }


}