using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Koica
{
    public class GroupSubject
    {
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public Group Group { get; set; }
        public Subject Subject { get; set; }
    }
}
