using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using PatientPortalApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientPortalApplication.Models
{
    [Table("prescrips")]
    public class Prescrips
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        [Column("Prescription Id")]
        public int prescripId { get; set; }

        [Column("Prescription")]
        public string prescriptions { get; set; }


        [ForeignKey("Patient")]
        public int patientId { get; set; }                
        public Patient Patient { get; set; }

    }



}