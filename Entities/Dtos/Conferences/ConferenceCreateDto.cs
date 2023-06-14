using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Conferences
{
    public class ConferenceCreateDto
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string ImagePath { get; set; }

    }
}
