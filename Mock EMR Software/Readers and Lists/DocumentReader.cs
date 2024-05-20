using Mock_EMR_Software.CustomExceptions;
using Newtonsoft.Json.Linq;
using System.Reflection.Metadata;

namespace Mock_EMR_Software
{
    public class DocumentReader
    {
        public static List<string> main()
        {
            
            string file_path = "Documents.json";

            if (!File.Exists(file_path))
            {
                throw new FileNotFoundException($"The file {file_path} does not exist.");
            }

            string json_content = File.ReadAllText(file_path);
            JObject json_obj = JObject.Parse(json_content);

            if (json_obj["DocumentTypes"] is JArray docs_array)
            {
                List<string> docs_list = docs_array.ToObject<List<string>>() ?? new List<string>();
                return docs_list;
            }

            throw new NullJsonObjectException("JSON Array is Empty and/or Invalid");

        }
    }
}