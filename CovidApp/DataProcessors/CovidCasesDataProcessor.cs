using CovidApp.Utilities;
using CovidDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CovidApp.DataProcessors
{
    public class CovidCasesDataProcessor : ApiProcessor<CovidDataResponse<CovidCaseData>>
    {
        public override string Url { get { return "https://covid-api.com"; } }
        public override string endpoint { get { return "/api/reports"; } }
        public override Dictionary<string, string> qParams { get; set; } = new Dictionary<string, string>();

        public new List<CovidCaseData> GetData() { return base.GetData().data; }
    }
}
