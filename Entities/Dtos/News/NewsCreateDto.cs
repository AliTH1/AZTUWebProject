using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.News
{
    public class NewsCreateDto
    {
        public string Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsMain { get; set; }
        public string Url { get; set; }
    }
}
