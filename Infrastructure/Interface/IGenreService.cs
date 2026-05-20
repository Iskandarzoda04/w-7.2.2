using Domain.Entities;
using Infrastructure.DTOs.Genre;

namespace Infrastructure.Interface;

public interface IGenreService
{
       Task<List<GenreDto>> GetAllAsync();

    Task<GenreDto> GetByIdAsync(int id);

    Task<int> CreateAsync(CreateGenreDto dto);

    Task<bool> UpdateAsync(int id, UpdateGenreDto dto);

    Task<bool> DeleteAsync(int id);
}
