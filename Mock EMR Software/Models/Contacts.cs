using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mock_EMR_Software.Models
{
    [Table("Contact Info")]
    public class Contacts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("Contact GUID")]
        public int ContactGUID { get; set; }

        [Column("Phone Number")]
        public string PhoneNumber { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Emergency Contact First Name")]
        public string EmergFirstName { get; set; }

        [Column("Emergency Contact Last Name")]
        public string EmergLastName { get; set;}

        [Column("Emergency Contact Phone Number")]
        public string EmergNumber { get; set; }


        [ForeignKey("Patient")]
        public int patientGUID { get; set; }
        public Patient Patient { get; set; }



    }
}
