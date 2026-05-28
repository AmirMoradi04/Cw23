using System.ComponentModel.DataAnnotations;

namespace CW21.Presentation.Entities;

public class Book : BaseEntity
{
    [Required(ErrorMessage = "Title is required")]
    [MaxLength(200)]
    public string Title { get; set; }

    //[Range(0M,decimal.MaxValue)]
    [Required]
    public decimal Price { get; set; }

    [Required]
    public int PublishYear { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Required]
    public int AuthorId { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public Author? Author { get; set; }


    public Category? Category { get; set; }


    [Range(0, int.MaxValue, ErrorMessage = "Kamtar az sefre ke")]
    [Required]
    public int Stock { get; set; }
    public int? PublisherId { get; set; }

    public Publisher Publisher { get; set; }


    public ICollection<Tag>? Tags { get; set; } = new List<Tag>();
}
