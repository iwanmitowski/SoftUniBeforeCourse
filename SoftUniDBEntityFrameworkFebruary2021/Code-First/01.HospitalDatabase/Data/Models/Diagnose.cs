using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.HospitalDatabase.Data.Models
{
    class Diagnose
    {
        public int DiagnoseId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Comments { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
