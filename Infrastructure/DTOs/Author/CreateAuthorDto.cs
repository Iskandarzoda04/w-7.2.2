namespace Infrastructure.DTOs.Author;

public class CreateAuthorDto
{
     public string Name {get; set;} = null!;
    public int BirthYear {get; set;}
    public string? Country {get; set;}
    public string? Biography {get; set;}
}
