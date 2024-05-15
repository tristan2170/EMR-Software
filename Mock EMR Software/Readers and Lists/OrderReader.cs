using Newtonsoft.Json.Linq;

namespace Mock_EMR_Software
{
    public class OrderReader
    {
        public static List<string> main()
        {
            List<string> order_list = new List<string>();

            string filePath = "Orders.json";
            string jsonContent = File.ReadAllText(filePath);

            JObject jsonObject = JObject.Parse(jsonContent);

            JArray drugsArray = (JArray)jsonObject["drugs"];

            List<string> drug_list = drugsArray.ToObject<List<string>>();

            
            return drug_list;
           
        }
    }
   
}

