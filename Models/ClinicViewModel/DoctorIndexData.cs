using System;
namespace ClinicInfo.Models.ClinicViewModel
{
	public class DoctorIndexData
	{
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<DoctorVisit> DoctorVisits { get; set; }
        public IEnumerable<Patient> Patients { get; set; }
        public Patient SelectedPatient { get; set; }
    }
}

