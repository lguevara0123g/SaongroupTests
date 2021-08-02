using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Utilities
{
    public class CsvHelper
    {
        public static string ConvertToCsv(Object obj)
        {
            return ConvertToCsv(JArray.FromObject(obj));
        }

        public static string ConvertToCsv(JArray obj)
        {
            string csvData = "";
            foreach (var item in obj)
            {
                if (csvData.Length == 0)                
                    csvData += string.Join(",", item.Children().Select(p => (p as JProperty).Name).ToArray()); 
                
                csvData += "\n";
                csvData += string.Join(",", item.Children().Select(p => (p as JProperty).Value.ToString()).ToArray());
            }
            return csvData;
        }
    }
}
