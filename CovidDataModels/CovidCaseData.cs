using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidDataModels
{
    public class CovidCaseData
    {
        [Display(Name ="CASES")]
        public int confirmed { get; set; }
        [Display(Name = "DEATHS")]
        public int deaths { get; set; }
        public Region region { get; set; }        
    }
}
