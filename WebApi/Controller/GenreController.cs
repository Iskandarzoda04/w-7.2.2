using Domain.Entities;
using Infrastructure.DTOs.Genre;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _service;

    public GenreController(IGenreService service)
    {
        _service = service;
    }


    [HttpGet]
    public async Task<List<GenreDto>> GetAll()
    {
        return await _service.GetAllAsync();
    }


    [HttpGet("{id}")]
    public async Task<GenreDto> GetById(int id)
    {
        return await _service.GetByIdAsync(id);
    }

  
    [HttpPost]
    public async Task<int> Create(CreateGenreDto dto)
    {
        return await _service.CreateAsync(dto);
    }

   
    [HttpPut("{id}")]
    public async Task<bool> Update(int id, UpdateGenreDto dto)
    {
        return await _service.UpdateAsync(id, dto);
    }

   
    [HttpDelete("{id}")]
    public async Task<bool> Delete(int id)
    {
        return await _service.DeleteAsync(id);
    }
}