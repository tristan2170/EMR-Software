using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mock_EMR_Software.Models
{
    [Table("Addresses")]
    public class Addresses
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("AddressGUID")]
        public int AddressGUID { get; set; }

        [Column("Address")]
        public string Address { get; set; }

        [Column("City")]
        public string City { get; set; }

        [Column("State")]
        public string State { get; set; }

        [Column("Postal Code")]
        public string PostalCode { get; set; }


        [ForeignKey("Patient")]
        public int patientGUID { get; set; }
        public Patient Patient { get; set; }

    }
}
