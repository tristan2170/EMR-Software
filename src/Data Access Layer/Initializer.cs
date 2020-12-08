using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatientPortalApplication.Models;



namespace PatientPortalApplication.DAL
{
    public class Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<Context>
    {

        protected override void Seed(Context context)
        {


           
            context.SaveChanges();
        }
    }


}