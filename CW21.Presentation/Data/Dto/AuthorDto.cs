using CW21.Presentation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW21.Presentation.Data.Dto
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public int BookCount { get; set; }
    }
}
