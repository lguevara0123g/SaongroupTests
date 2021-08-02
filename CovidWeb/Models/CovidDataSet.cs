using CovidDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidWeb.Models
{
    public class CovidDataSet
    {
        public List<CovidCaseData> CovidCasesData { get; set; }        
        public IEnumerable<string> Regions { get; set; }//{ get { return CovidCasesData?.Select(p => p.region.name).Distinct(); } }
        public string SelectedRegion { get; set; }
        public string RegionProvince { get { return String.IsNullOrEmpty(SelectedRegion) ? "REGION" : "PROVINCE"; } }
    }
}