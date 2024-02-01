using Newtonsoft.Json.Linq;

namespace Mock_EMR_Software
{
    public class OrderList
    {
        public static void main()
        {
            List<string> document_list = new List<string>();

            string filePath = "Orders.json";
            string jsonContent = File.ReadAllText(filePath);

            JObject jsonObject = JObject.Parse(jsonContent);

            JArray drugsArray = (JArray)jsonObject["drugs"];

            List<string> drug_list = drugsArray.ToObject<List<string>>();

           
        }
    }
   
}

