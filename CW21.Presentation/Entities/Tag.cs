using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CW21.Presentation.Entities
{
    public class Tag : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
