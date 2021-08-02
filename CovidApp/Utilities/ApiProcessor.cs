using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Utilities
{
    public abstract class ApiProcessor<T>
    {
        public abstract string Url { get; }
        public abstract string endpoint { get; }
        public abstract Dictionary<string, string> qParams { get; set; }
        string strPrms { get { return string.Join("&", this.qParams.Select(kvp => $"{kvp.Key}={kvp.Value}")); } }
        HttpClient httpClient = new HttpClient();
        public virtual T GetData()
        {
            var strResult = httpClient.GetStringAsync($"{Url}{endpoint}?{strPrms}").Result;
            var result = JsonConvert.DeserializeObject<T>(strResult);
            
            return result;
        }
    }
}

