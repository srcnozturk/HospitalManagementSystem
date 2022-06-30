using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalManagementSystem.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int DoctorId { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorAddress { get; set; }
        public string DoctorPhone { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
