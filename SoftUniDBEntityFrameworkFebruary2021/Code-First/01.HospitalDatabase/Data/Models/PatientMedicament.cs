using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.HospitalDatabase.Data.Models
{
    class PatientMedicament
    {
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public int MedicamentId { get; set; }

        public Medicament Medicament { get; set; }
    }
}
