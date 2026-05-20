namespace Infrastructure.DTOs.Author;

public class AuthorDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int BirthYear { get; set; }
    public required string Country { get; set; }
    public required string Biography { get; set; }
}