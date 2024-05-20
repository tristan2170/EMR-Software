using Newtonsoft.Json.Linq;
using Mock_EMR_Software.CustomExceptions;

namespace Mock_EMR_Software
{
    public class OrderReader
    {
        public static List<string> main()
        {
            

            string file_path = "Orders.json";

            if (!File.Exists(file_path))
            {
                throw new FileNotFoundException($"The file {file_path} does not exist.");
            }

            
            string json_content = File.ReadAllText(file_path);
            JObject json_obj = JObject.Parse(json_content);


            if (json_obj["drugs"] is JArray drugs_array)
            {
                List<string> drug_list = drugs_array.ToObject<List<string>>() ?? new List<string>();
                return drug_list;
            }


            throw new NullJsonObjectException("JSON Array is Empty and/or Invalid");
            

        }
    }
}
   


