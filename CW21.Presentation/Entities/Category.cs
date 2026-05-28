using System.ComponentModel.DataAnnotations;

namespace CW21.Presentation.Entities;

public class Category : BaseEntity
{
    [Required(ErrorMessage = "The field {0} is required")]
    [MaxLength(50,ErrorMessage = "dadash ta 50 tae ")]
    public string Name { get; set; }

    public string Description { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}