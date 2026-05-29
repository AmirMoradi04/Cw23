using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CW21.Presentation.Entities
{
    public class Publisher : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
