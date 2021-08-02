using Microsoft.VisualStudio.TestTools.UnitTesting;
using CovidApp.DataProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.DataProcessors.Tests
{
    [TestClass()]
    public class CovidCasesProcessorTests
    {
        [TestMethod()]
        public void GetDataGetsData()
        {
            CovidCasesDataProcessor proc = new CovidCasesDataProcessor();
            ///
            var cases = proc.GetData();
            //
            bool hasData = cases?.Count > 0;
            Assert.IsTrue(hasData);
        }
    }
}