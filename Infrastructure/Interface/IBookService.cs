using Infrastructure.DTOs;
namespace Infrastructure.Interface;
using Domain.Entities;
using Infrastructure.DTOs.Book;


public interface IBookService
{
   Task<List<BookDto>> GetAllAsync();

    Task<BookDto> GetByIdAsync(int id);

    Task<int> CreateAsync(CreateBookDto dto);

    Task<bool> UpdateAsync(int id, UpdateBookDto dto);

    Task<bool> DeleteAsync(int id);
}

