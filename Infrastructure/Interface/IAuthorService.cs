using Domain.Entities;
using Infrastructure.DTOs.Author;

namespace Infrastructure.Interface;

public interface IAuthorService
{
     Task<List<Author>> GetAllAsync();

    Task<Author?> GetByIdAsync(int id);

    Task<int> CreateAsync(CreateAuthorDto dto);

    Task<bool> UpdateAsync(int id, UpdateAuthorDto dto);

    Task<bool> DeleteAsync(int id);
}
