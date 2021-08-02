using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidDataModels
{
    public class CovidDataResponse<T>
    {
        public List<T> data { get; set; }
    }
}
