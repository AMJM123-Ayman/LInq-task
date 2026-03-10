using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCareSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;

        // Navigation Property: الدكتور لديه قائمة مواعيد مع مرضى مختلفين
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}