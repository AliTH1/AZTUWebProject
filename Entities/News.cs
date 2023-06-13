using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class News : BaseEntity
    {
        public string Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
