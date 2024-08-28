using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace ClinicInfo.Models
{
	public class DoctorVisit
	{

        public int DoctorVisitID { get; set; }
        public int DoctorID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dddd,yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Visit Date")]
        public DateTime Date { get; set; }


        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }


        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }


        public Doctor Doctor { get; set; }

        
	}
} 

