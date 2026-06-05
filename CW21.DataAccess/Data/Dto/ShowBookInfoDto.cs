using CW21.Presentation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW21.DataAccess.Data.Dto
{
    public class ShowBookInfoDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public string PublisherName { get; set; }

        public string AuthorName { get; set; }

        public List<string> Tags { get; set; } = new();
    }
}
