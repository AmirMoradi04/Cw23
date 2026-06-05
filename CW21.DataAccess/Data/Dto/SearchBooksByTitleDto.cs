using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW21.DataAccess.Data.Dto
{
    public class SearchBooksByTitleDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public string PublisherName { get; set; }

        public string AuthorName { get; set; }

        public int CategoryId { get; set; }

        public int AuthorId { get; set; }

        public int PublisherId { get; set; }
    }
}
