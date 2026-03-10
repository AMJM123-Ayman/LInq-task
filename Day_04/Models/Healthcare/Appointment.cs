using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCareSystem.Models
{
    public class Appointment
    {
        public int PatientId { get; set; } // Foreign Key & Part of Composite Key
        public int DoctorId { get; set; }  // Foreign Key & Part of Composite Key
        public DateTime AppointmentDate { get; set; }

        // Navigation Properties
        public virtual Patient Patient { get; set; } = default!;
        public virtual Doctor Doctor { get; set; } = default!;
    }
}
