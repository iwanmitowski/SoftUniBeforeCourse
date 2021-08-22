using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01.HospitalDatabase.Data.Models
{
    class Patient
    {
        public Patient()
        {
            this.Visitations = new HashSet<Visitation>();
            this.Diagnoses = new HashSet<Diagnose>();
            this.Prescriptions = new HashSet<PatientMedicament>();
        }
        public int PatientId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        [Column("VARCHAR(80)")]
        public string Email { get; set; }

        public bool HasInsurance { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }

        public virtual ICollection<Diagnose> Diagnoses { get; set; }

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
