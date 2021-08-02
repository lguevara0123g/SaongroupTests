using Microsoft.VisualStudio.TestTools.UnitTesting;
using CovidApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidApp.Utilities.Tests
{
    [TestClass()]
    public class CsvHelperTests
    {
        [TestMethod()]
        public void ConvertToCsvConvertsDataWell()
        {
            var obj = new List<Object>() { { new { Name = "Luis", LastName = "Guevara" } }, { new { Name = "Raquel", LastName = "Guevara" } } };            
            string csvExpectedResult = "Name,LastName\nLuis,Guevara\nRaquel,Guevara";
            //
            string csvResult = CsvHelper.ConvertToCsv(obj);
            bool valid = csvExpectedResult == csvResult;
            //
             Assert.IsTrue(valid);
        }
    }
}