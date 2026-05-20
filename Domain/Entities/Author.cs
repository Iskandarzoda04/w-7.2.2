using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Author
{
       public int Id {get; set;}

    [Required, MaxLength(100)]
    public string Name {get; set;} = null!;
    public int BirthYear {get; set;}
    [MaxLength(100)]
    public string Country {get; set;} = null!;
    [MaxLength(2000)]
    public string Biography {get; set;} = null!;
    public List<Book> Books {get; set;} =null!;
}
