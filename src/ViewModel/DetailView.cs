using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatientPortalApplication.Models;
using System.Runtime;

namespace PatientPortalApplication.ViewModel
{
    public class DetailView
    {

        //Patient
        public int patientId { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime date_admitted { get; set; }
        public List<Patient> Patients { get; set; }


        //Prescrips
        public int prescripId { get; set; }
        public string prescriptions { get; set; }

        public List<Prescrips> Prescrips { get; set; }
        


        //Comments
        public int commentId { get; set; }
        public string comment { get; set; }

        public DateTime date { get; set; }
        public List<Comments> Comments { get; set; }


        
    }
}