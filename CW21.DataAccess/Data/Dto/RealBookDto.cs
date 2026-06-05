using CW21.Presentation.Data;
using CW21.Presentation.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW21.DataAccess.Data.Dto
{
    public class RealBookDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public ICollection<Tag>? Tags { get; set; } = new List<Tag>();
    }
}
