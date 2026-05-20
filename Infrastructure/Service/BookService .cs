using Domain.Entities;
using Infrastructure.DTOs.Author;
using Infrastructure.DTOs.Book;
using Infrastructure.Interface;
using Infrastructure.Persistence.DataContext;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service;

public class BookService : IBookService
{
   private readonly AppDbContext _context;
    private readonly ILogger<BookService> _logger;

    public BookService(AppDbContext context, ILogger<BookService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<int> CreateAsync(CreateBookDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
        {
            _logger.LogWarning("Title is required");
            return 0;
        }

        if (dto.Title.Length < 2 || dto.Title.Length > 200)
        {
            _logger.LogWarning("Title must be 2-200 characters");
            return 0;
        }

        if (dto.Year < 1450 || dto.Year > DateTime.Now.Year)
        {
            _logger.LogWarning("Invalid year");
            return 0;
        }

        if (dto.Pages <= 0)
        {
            _logger.LogWarning("Pages must be greater than 0");
            return 0;
        }

        if (string.IsNullOrWhiteSpace(dto.ISBN))
        {
            _logger.LogWarning("ISBN is required");
            return 0;
        }

        if (dto.ISBN.Length < 10 || dto.ISBN.Length > 13)
        {
            _logger.LogWarning("ISBN must be 10-13 characters");
            return 0;
        }

        var book = new Book
        {
            Title = dto.Title,
            Year = dto.Year,
            ISBN = dto.ISBN,
            Pages = dto.Pages,
            Description = dto.Description,
            AuthorId = dto.AuthorId,
            GenreId = dto.GenreId
        };

        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Book created with Id: {Id}", book.Id);

        return book.Id;
    }

 public async Task<bool> DeleteAsync(int id)
{
    try
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            _logger.LogWarning("Book not found: {Id}", id);
            return false;
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Book deleted: {Id}", id);

        return true;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error while deleting book: {Id}", id);
        return false;
    }
}
public async Task<List<BookDto>> GetAllAsync()
{
    try
    {
        var books = await _context.Books.ToListAsync();

        return books.Select(b => new BookDto
        {
            Id = b.Id,
            Title = b.Title,
            Year = b.Year,
            ISBN = b.ISBN,
            Pages = b.Pages,
            Description = b.Description
        }).ToList();
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error while getting books");
        return new List<BookDto>();
    }
}

public async Task<BookDto?> GetByIdAsync(int id)
{
    var book = await _context.Books.FindAsync(id);

    if (book == null)
        return null;

    return new BookDto
    {
        Id = book.Id,
        Title = book.Title,
        Year = book.Year,
        ISBN = book.ISBN,
        Pages = book.Pages,
        Description = book.Description
    };
}
  public async Task<bool> UpdateAsync(int id, UpdateBookDto dto)
{
    try
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

        if (book == null)
        {
            _logger.LogWarning("Book not found: {Id}", id);
            return false;
        }

        if (string.IsNullOrWhiteSpace(dto.Title))
        {
            _logger.LogWarning("Title is required");
            return false;
        }

        if (dto.Title.Length < 2 || dto.Title.Length > 200)
        {
            _logger.LogWarning("Title must be 2-200 characters");
            return false;
        }

        if (dto.Year < 1450 || dto.Year > DateTime.Now.Year)
        {
            _logger.LogWarning("Invalid year");
            return false;
        }

        if (dto.Pages <= 0)
        {
            _logger.LogWarning("Pages must be greater than 0");
            return false;
        }

        book.Title = dto.Title;
        book.Year = dto.Year;
        book.ISBN = dto.ISBN;
        book.Pages = dto.Pages;
        book.Description = dto.Description;
        book.AuthorId = dto.AuthorId;
        book.GenreId = dto.GenreId;

        await _context.SaveChangesAsync();

        _logger.LogInformation("Book updated: {Id}", id);

        return true;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error while updating book");
        return false;
    }
}
}