using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalManagementSystem.Models
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
