using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace rzr.Models
{
    public class Participant
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string Surname { get; set; }

        [Required, Display(Name = "Phone Number"), StringLength(11, MinimumLength = 11)]
        [DataType(DataType.PhoneNumber), DisplayFormat(DataFormatString = "{0:# (###) ###-####}", ApplyFormatInEditMode = true)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Url), Display(Name = "Survey Link 1")]
        public string SurveyLinkNormal { get; set; }
        [DataType(DataType.Url), Display(Name ="Survey Link 2")]
        public string SurveyLinkDenseSampling { get; set; }

        public string NameNumber { get
            {
                return this.FirstName + " " + this.Surname + " (+" + this.PhoneNumber + ")";
            }
        }

        public ICollection<ExperimentParticipant> ExperimentParticipants { get; set; }
    }
}
