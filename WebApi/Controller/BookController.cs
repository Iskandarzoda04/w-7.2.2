using Infrastructure.DTOs.Book;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _service;

    public BookController(IBookService service)
    {
        _service = service;
    }

   
    [HttpGet]
    public async Task<List<BookDto>> GetAll()
    {
        return await _service.GetAllAsync();
    }

   
    [HttpGet("{id}")]
    public async Task<BookDto> GetById(int id)
    {
        return await _service.GetByIdAsync(id);
    }

   
    [HttpPost]
    public async Task<int> Create(CreateBookDto dto)
    {
        return await _service.CreateAsync(dto);
    }

    
    [HttpPut("{id}")]
    public async Task<bool> Update(int id, UpdateBookDto dto)
    {
        return await _service.UpdateAsync(id, dto);
    }

    [HttpDelete("{id}")]
    public async Task<bool> Delete(int id)
    {
        return await _service.DeleteAsync(id);
    }
}