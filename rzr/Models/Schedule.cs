using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rzr.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        [Display(Name = "Start Date")]
        [Required, DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        /*[DisplayFormat(DataFormatString = "{0:dddd dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }*/

        [Required, Display(Name = "Start Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Display(Name = "Blackout Start Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        [DataType(DataType.Time)]
        public DateTime BlackoutTime { get; set; }

        [Display(Name = "Jitter (mins)"), DefaultValue(0), Range(0, ushort.MaxValue)]
        public ushort Jitter { get; set; }

        [Display(Name = "Period (mins)"), Range(0, ushort.MaxValue)]
        public ushort Period { get; set; }

        [Display(Name = "Repitions (Max SMSs per day)"), Range(0, byte.MaxValue)]
        public byte Repitions { get; set; }

    }
}
