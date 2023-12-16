using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mock_EMR_Software.Models;
using System.Runtime;

namespace Mock_EMR_Software.ViewModel
{
    public class DetailView
    {

        //Patient
        public int patientGUID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateAdmitted { get; set; }
        public DateTime dateDischarged { get; set; }
        public List<Patient> Patients { get; set; }


        //Orders
        public int orderGUID { get; set; }
        public string orderName { get; set; }

        public List<Orders> Orders { get; set; }
        


        //Documents
        public int documentGUID { get; set; }

        public string documentName { get; set; }
        public string Body { get; set; }

        public DateTime Date { get; set; }
        public List<Documents> Documents { get; set; }


        
    }
}