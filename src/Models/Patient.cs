using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PatientPortalApplication.Models
{
    [Table("patient")]
    public class Patient
    {
        
            [Key]
            [Column("Patient Id")]
            public int patientId { get; set; }

            [Column("First Name")]
            public string first_name { get; set; }

            [Column("Last Name")]
            public string last_name { get; set; }
            
            [Column("Date Admitted", TypeName = "DateTime")]
            public DateTime date_admitted { get; set; }


            
            public virtual ICollection<Comments> Comments { get; set; } 
            public virtual ICollection<Prescrips> Prescrips { get; set; }
            public virtual ICollection<Patient> Patients { get; set; }
        
    }
}
