namespace Infrastructure.DTOs.Genre;

public class CreateGenreDto
{
    public string Name {get; set;} = null!;
    public string? Description {get; set;}
    public bool IsFiction {get; set;}
    public int Popularity {get; set;}
}
