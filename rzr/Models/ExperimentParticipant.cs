using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rzr.Models
{
    public class ExperimentParticipant
    {
        [Display(Name ="Experiment Name")]
        public int ExperimentId { get; set; }
        public Experiment Experiment { get; set; }

        [Display(Name = "Participant Info")]
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
    }
}
