using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalManagementSystem.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int PatientId { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientInsurance { get; set; }
        public string PatientAddress { get; set; }
        public string PatientPhone { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
