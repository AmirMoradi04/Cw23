using System;
using System.Collections.Generic;
using System.Text;
using CW21.Presentation.Entities;

namespace CW21.Presentation.Data.Dto
{
    public class viewBookModelDto
    {
        public string Title { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public ICollection<string> TagName { get; set; }
       


       

    }
}
