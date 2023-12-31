﻿using Entities.Koica;
using Entities.Koica.SubjectMaterials;

namespace WebApplication1.Areas.Koica.ViewModels
{
	public class HomeVM
	{
		public List<Notification> Notifications { get; set; }


        public List<Forum> Forums { get; set; }
        public CreateSubjectVM CreateSubjectVM { get; set; }


        public List<DidacticMaterial> DidacticMaterials { get; set; }
        public List<Evaluation> Evaluations { get; set; }
        public List<Progress> Progresses { get; set; }



        public Subject Subject { get; set; }
    }
}
