using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Data.Dto
{
    public class BookDetailsDto
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public int PublishYear { get; set; }

        public string AuthorName { get; set; }

        public string CategoryName { get; set; }

        public string PublisherName { get; set; }

        public List<string> Tags { get; set; }

    }
}
