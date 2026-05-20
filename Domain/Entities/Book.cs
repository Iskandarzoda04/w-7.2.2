using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Book
{
     public int Id { get; set; }
     [Required, MaxLength(200)]
    public string Title {get; set;} = null!;
    public int Year {get; set;}
    [Required,MaxLength(50)]
    public string ISBN {get; set;} = null!;
    public int Pages {get; set;}
    [MaxLength(1000)]
    public string Description {get; set;} = null!;
    public int AuthorId {get; set;}
    public int GenreId {get; set;}

     //  Navigation properties
    public Author Author { get; set; } = null!;
    public Genre Genre { get; set; } = null!;
}
