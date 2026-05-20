namespace Infrastructure.DTOs.Book;

public class UpdateBookDto
{
     public string Title {get; set;} = null!;
    public int Year {get; set;}
    public string ISBN {get; set;} = null!;
    public int Pages {get; set;}
    public string? Description {get; set;}
    public int GenreId { get; internal set; }
    
    public int AuthorId { get; set; }

}
