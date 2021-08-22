using System;
using System.ComponentModel.DataAnnotations;

namespace _01.HospitalDatabase.Data.Models
{
    class Visitation
    {
        public int VisitationId { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [MaxLength(250)]
        public string Comments { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

    }
}
