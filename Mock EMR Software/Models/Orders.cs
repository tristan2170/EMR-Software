using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Mock_EMR_Software.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mock_EMR_Software.Models
{
    [Table("Orders")]
    public class Orders
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        // GUID for instance of that order on patient's chart
        [Key]
        [Column("Order GUID")]
        public int orderGUID { get; set; }

        [Column("Order Name")]
        public string orderName { get; set; }

        [Column("Provider")]
        public string Provider { get; set; }

        [Column("Date Ordered")]
        public DateTime DateOrdered { get; set; }

        [Column("Date Discontinued")]
        public DateTime DateDiscontinued { get; set; }

        [Column("Frequency")]
        public string Frequency { get; set; }


        [ForeignKey("Patient")]
        public int patientGUID { get; set; }                
        public Patient Patient { get; set; }

    }



}