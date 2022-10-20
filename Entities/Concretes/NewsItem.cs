using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class NewsItem
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? PublishDate { get; set; }
        public string? SourceOfNews { get; set; }
        public string? LinkOfNews { get; set; }
        public string? CapturedWords { get; set; }
    }
}
