using Newtonsoft.Json.Linq;
using System.Reflection.Metadata;

namespace Mock_EMR_Software
{
    public class DocumentList
    {
        public static void main()
        {
            List<string> document_list = new List<string>();

            string filePath = "Documents.json";
            string jsonContent = File.ReadAllText(filePath);

            JArray jsonArray = JArray.Parse(jsonContent);

            foreach (JObject obj in jsonArray)
            {
                string doc_name = obj["name"].ToString();
                document_list.Add(doc_name);

            }
        }
    }
}