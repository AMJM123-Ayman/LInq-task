using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCareSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        // Navigation Property: المريض لديه قائمة مواعيد (Many-to-Many Bridge)
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
