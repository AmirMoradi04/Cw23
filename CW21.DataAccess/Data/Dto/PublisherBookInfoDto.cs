using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Data.Dto
{
    public class PublisherBookInfoDto
    {
        public string PublisherName { get; set; }
        public int BookCount { get; set; }
        public int SumBook { get; set; }
        public decimal AveragePriceBook { get; set; }
    }
}
