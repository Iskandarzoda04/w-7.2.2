namespace Infrastructure.DTOs.Genre;

public class GenreDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public bool IsFiction { get; set; }
    public int Popularity { get; set; }
}