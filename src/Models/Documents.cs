using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mock_EMR_Software.Models
{

    [Table("Documents")]
    public class Documents
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        [Column("Document GUID")]
        public int documentGUID { get; set; }

        [Column("Document Name")]
        public string documentName { get; set; }

        [Column("Body")]
        public string Body { get; set; }

        [Column("Document Date", TypeName ="DateTime")]
        public DateTime Date { get; set; }


        [ForeignKey("Patient")]
        public int patientGUID { get; set; }
        public Patient Patient { get; set; }
    }


}
