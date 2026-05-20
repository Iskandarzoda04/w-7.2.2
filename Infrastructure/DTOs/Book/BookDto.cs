namespace Infrastructure.DTOs.Book;

public class BookDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int Year { get; set; }
    public required string ISBN { get; set; }
    public int Pages { get; set; }
    public required string Description { get; set; }
}