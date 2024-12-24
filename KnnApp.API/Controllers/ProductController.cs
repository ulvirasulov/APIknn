using AutoMapper;
using KnnApp.Core.DTOs.Product;
using KnnApp.Core.Entityes;
using KnnApp.DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnnApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    KnnAppDbContext _db;
    IMapper _mapper;
    public ProductController(KnnAppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }



    [HttpPost]
    public IActionResult CreateProduct(CreateProductDTO dto)
    {
        var product= _mapper.Map<Product>(dto);
        _db.Products.Add(product);
        _db.SaveChanges();
        return Ok(product);
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = _db.Products.FirstOrDefault(c => c.Id == id);
        return product == null ? NotFound() : Ok(product);
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        return Ok(_db.Products.ToList());
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(UpdateProductDTO dto)
    {
        var product = _db.Products.AsNoTracking().FirstOrDefault(c => c.Id == dto.Id);
        if (product == null) return NotFound(" yoxdur bele bir category ");
        product.OldPrice=product.Price;
        product=_mapper.Map<Product>(dto);
        _db.Products.Update(product);
        _db.SaveChanges();
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = _db.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();
        _db.Products.Remove(product);
        _db.SaveChanges();
        return StatusCode(StatusCodes.Status204NoContent);
    }


}