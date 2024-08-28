using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ClinicInfo.Models
{
	public class Doctor
	{
        public int DoctorID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }


        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:##########}", ApplyFormatInEditMode = true)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        

        [Required]
        [StringLength(50)]
        [Display(Name = "Spacialization")]
        public string Spacialization { get; set; }


       
    }
}

