using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidWeb.Models
{
    public class CovidData
    {
        int confirmed { get; set; }
        int deaths { get; set; }
        Region region { get; set; }
    }
}