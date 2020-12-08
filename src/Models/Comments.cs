using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientPortalApplication.Models
{

    [Table("comments")]
    public class Comments
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]

        [Column("Comment Id")]
        public int commentId { get; set; }

        [Column("Comment")]
        public string comment { get; set; }

        [Column("Comment Date", TypeName ="DateTime")]
        public DateTime date { get; set; }


        [ForeignKey("Patient")]
        public int patientId { get; set; }
        public Patient Patient { get; set; }
    }


}
