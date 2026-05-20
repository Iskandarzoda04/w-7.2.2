using Domain.Entities;
using Infrastructure.DTOs.Genre;
using Infrastructure.Interface;
using Infrastructure.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Service;

public class GenreService : IGenreService
{
    private readonly AppDbContext _context;
    private readonly ILogger<GenreService> _logger;

    public GenreService(AppDbContext context, ILogger<GenreService> logger)
    {
        _context = context;
        _logger = logger;
    }

    
    public async Task<int> CreateAsync(CreateGenreDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            _logger.LogWarning("Name is required");
            return 0;
        }

        if (dto.Name.Length < 2 || dto.Name.Length > 100)
        {
            _logger.LogWarning("Name must be 2-100 characters");
            return 0;
        }

        if (dto.Popularity < 0 || dto.Popularity > 100)
        {
            _logger.LogWarning("Popularity must be 0-100");
            return 0;
        }

        var genre = new Genre
        {
            Name = dto.Name,
            Description = dto.Description,
            IsFiction = dto.IsFiction,
            Popularity = dto.Popularity
        };

        await _context.Genres.AddAsync(genre);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Genre created with Id: {Id}", genre.Id);

        return genre.Id;
    }

 
    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre == null)
            {
                _logger.LogWarning("Genre not found: {Id}", id);
                return false;
            }

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Genre deleted: {Id}", id);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while deleting genre: {Id}", id);
            return false;
        }
    }

    
public async Task<List<GenreDto>> GetAllAsync()
{
    try
    {
        var genres = await _context.Genres.ToListAsync();

        return genres.Select(g => new GenreDto
        {
            Id = g.Id,
            Name = g.Name,
            Description = g.Description,
            IsFiction = g.IsFiction,
            Popularity = g.Popularity
        }).ToList();
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error while getting genres");
        return new List<GenreDto>();
    }
}
public async Task<GenreDto?> GetByIdAsync(int id)
{
    var genre = await _context.Genres.FindAsync(id);

    if (genre == null)
        return null;

    return new GenreDto
    {
        Id = genre.Id,
        Name = genre.Name,
        Description = genre.Description,
        IsFiction = genre.IsFiction,
        Popularity = genre.Popularity
    };
}
   
    public async Task<bool> UpdateAsync(int id, UpdateGenreDto dto)
    {
        try
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);

            if (genre == null)
            {
                _logger.LogWarning("Genre not found: {Id}", id);
                return false;
            }

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                _logger.LogWarning("Name is required");
                return false;
            }

            if (dto.Name.Length < 2 || dto.Name.Length > 100)
            {
                _logger.LogWarning("Name must be 2-100 characters");
                return false;
            }

            if (dto.Popularity < 0 || dto.Popularity > 100)
            {
                _logger.LogWarning("Popularity must be 0-100");
                return false;
            }

            genre.Name = dto.Name;
            genre.Description = dto.Description;
            genre.IsFiction = dto.IsFiction;
            genre.Popularity = dto.Popularity;

            await _context.SaveChangesAsync();

            _logger.LogInformation("Genre updated: {Id}", id);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while updating genre");
            return false;
        }
    }
}