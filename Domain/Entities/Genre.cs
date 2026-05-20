using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Genre
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;
    [MaxLength(500)]
    public string Description { get; set; } = null!;
    public bool IsFiction { get; set; }
    public int Popularity { get; set; }
    //navigation 
    public List<Book> Books { get; set; } = new();
}
