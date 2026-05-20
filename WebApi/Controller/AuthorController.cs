using Domain.Entities;
using Infrastructure.DTOs.Author;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _service;

    public AuthorController(IAuthorService service)
    {
        _service = service;
    }


    [HttpGet]
    public async Task<List<Author>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    
    [HttpGet("{id}")]
    public async Task<Author?> GetById(int id)
    {
        return await _service.GetByIdAsync(id);
    }

  
    [HttpPost]
    public async Task<int> Create(CreateAuthorDto dto)
    {
        return await _service.CreateAsync(dto);
    }

    
    [HttpPut("{id}")]
    public async Task<bool> Update(int id, UpdateAuthorDto dto)
    {
        return await _service.UpdateAsync(id, dto);
    }

  
    [HttpDelete("{id}")]
    public async Task<bool> Delete(int id)
    {
        return await _service.DeleteAsync(id);
    }
}