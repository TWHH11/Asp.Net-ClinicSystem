using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace ClinicInfo.Models
{
	public class Booking
	{
       
        public int BookingID { get; set; }
        public int PatientID { get; set; }

        public int DoctorID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dddd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Booking Date")]
        public DateTime Date { get; set; }


        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Booking Time")]
        public DateTime Time { get; set; }


        public Patient Patient{ get; set; }
        public Doctor Doctor{ get; set; }
    }
}

 