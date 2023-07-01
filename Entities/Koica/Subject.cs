using Entities.Koica.SubjectMaterials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Koica
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TeacherInfoId { get; set; }



        public List<Group> Groups { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<Forum> Forums { get; set; }
        public List<DidacticMaterial> DidacticMaterials { get; set; }
        public List<Evaluation> Evaluations { get; set; }
        public List<Progress> Progresses { get; set; }
    }
}
