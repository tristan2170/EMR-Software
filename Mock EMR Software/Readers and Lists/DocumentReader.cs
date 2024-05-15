using Newtonsoft.Json.Linq;
using System.Reflection.Metadata;

namespace Mock_EMR_Software
{
    public class DocumentReader
    {
        public static List<string> main()
        {
            List<string> document_list = new List<string>();

            string filePath = "Documents.json";
            string jsonContent = File.ReadAllText(filePath);

            JArray jsonArray = JArray.Parse(jsonContent);
            
            if (jsonArray is not null)
            {
                foreach (JObject obj in jsonArray)
                {
                    if (obj is not null && obj["name"] is not null)
                    {
                        string doc_name = obj["name"].ToString();
                        document_list.Add(doc_name);
                    }

                }
            }
            

            return document_list;
        }
    }
}