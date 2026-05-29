using System.ComponentModel.DataAnnotations;

namespace CW21.Presentation.Entities;

public class Author : BaseEntity
{
    [Required(ErrorMessage = "The field {0} is required")]
    [MaxLength(100, ErrorMessage = "dadash ta 80 tae ")]
    public string FullName { get; set; }

    public int? BirthYear { get; set; }

    public DateTime BirthDate { get; set; }
    
    [MaxLength(40,ErrorMessage =  "dadash ta 40 tae ")]
    public string Country { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}