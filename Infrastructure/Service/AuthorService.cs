using Domain.Entities;
using Infrastructure.DTOs.Author;
using Infrastructure.Interface;
using Infrastructure.Persistence.DataContext;
using Microsoft.Extensions.Logging;
using Npgsql;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service;

public class AuthorService(AppDbContext context, ILogger<BookService> logger) : IAuthorService
{
       private readonly AppDbContext _context = context;
      private readonly ILogger<BookService> _logger = logger;


  public async Task<int> CreateAsync(CreateAuthorDto dto)
{
    if (string.IsNullOrWhiteSpace(dto.Name))
    {
        _logger.LogWarning("Name is required");
        return 0;
    }

    if (dto.Name.Length < 2 || dto.Name.Length > 30)
    {
        _logger.LogWarning("Name must be 2-30 characters");
        return 0;
    }

    if (dto.BirthYear < 1800 || dto.BirthYear > DateTime.Now.Year)
    {
        _logger.LogWarning("Invalid birth year");
        return 0;
    }

    if (!string.IsNullOrEmpty(dto.Country) && dto.Country.Any(char.IsDigit))
    {
        _logger.LogWarning("Country cannot contain digits");
        return 0;
    }

    var author = new Author
    {
        Name = dto.Name,
        BirthYear = dto.BirthYear,
        Country = dto.Country,
        Biography = dto.Biography
    };

    await _context.Authors.AddAsync(author);
    await _context.SaveChangesAsync();

    _logger.LogInformation("Author created with Id: {Id}", author.Id);

    return author.Id;
}

public async Task<bool> DeleteAsync(int id)
{
    try
    {
        var author = await _context.Authors.FindAsync(id);

        if (author == null)
        {
            _logger.LogWarning("Author not found: {Id}", id);
            return false;
        }

        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Author deleted: {Id}", id);

        return true;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error while deleting author: {Id}", id);
        return false;
    }
}
public async Task<List<Author>> GetAllAsync()
{
    try
    {
        return await _context.Authors.ToListAsync();
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error while getting authors");
        return new List<Author>();
    }
} 
    public async Task<Author?> GetByIdAsync(int id)
    {
     return await _context.Authors.FindAsync(id);
     }
    
    

public async Task<bool> UpdateAsync(int id, UpdateAuthorDto dto)
{
    try
    {
        var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);

        if (author == null)
        {
            _logger.LogWarning("Author not found: {Id}", id);
            return false;
        }

        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            _logger.LogWarning("Name is required");
            return false;
        }

        if (dto.Name.Length < 2 || dto.Name.Length > 30)
        {
            _logger.LogWarning("Name must be 2-30 characters");
            return false;
        }

        if (dto.BirthYear < 1800 || dto.BirthYear > DateTime.Now.Year)
        {
            _logger.LogWarning("Invalid birth year");
            return false;
        }

        if (!string.IsNullOrEmpty(dto.Country) && dto.Country.Any(char.IsDigit))
        {
            _logger.LogWarning("Country cannot contain digits");
            return false;
        }

        author.Name = dto.Name;
        author.BirthYear = dto.BirthYear;
        author.Country = dto.Country;
        author.Biography = dto.Biography;

        await _context.SaveChangesAsync();

        _logger.LogInformation("Author updated: {Id}", id);

        return true;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error while updating author");
        return false;
    }
}
    


}
