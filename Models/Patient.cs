using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicInfo.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
       
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:##########}", ApplyFormatInEditMode = true)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Address")]
        public string Address { get; set; }


 

        
    }
}