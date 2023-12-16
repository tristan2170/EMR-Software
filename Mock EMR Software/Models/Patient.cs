using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace Mock_EMR_Software.Models
{
    [Table("Patient")]
    public class Patient
    {
        
            [Key]
            [Column("Patient GUID")]
            public int patientGUID { get; set; }

            [Column("First Name")]
            public string firstName { get; set; }

            [Column("Last Name")]
            public string lastName { get; set; }
            
            [Column("Date Admitted", TypeName = "DateTime")]
            public DateTime dateAdmitted { get; set; }

            [Column("Date Discharged", TypeName = "DateTime")]
            public DateTime dateDischarged { get; set; }


            
            public virtual ICollection<Documents> Documents { get; set; } 
            public virtual ICollection<Orders> Orders { get; set; }
            public virtual ICollection<Patient> Patients { get; set; }
            public virtual ICollection<Contacts> Contacts { get; set; }
            public virtual ICollection<Addresses> Addresss { get; set; }

        
    }
}
