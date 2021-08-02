using CovidApp.DataProcessors;
using CovidApp.Utilities;
using CovidWeb.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CovidWeb.Controllers
{
    public class CovidCasesDataController : Controller
    {
        CovidCasesDataProcessor _proc = new CovidCasesDataProcessor();
        IEnumerable<object> GetDataToDownload(string selectedRegion = null)
        {   

            IEnumerable<object> downloadData;
            if (String.IsNullOrEmpty(selectedRegion))
            {
                var rawData = _proc.GetData().Where(p => String.IsNullOrEmpty(p.region.province)).OrderByDescending(p => p.confirmed).Take(10).ToList();
                downloadData = rawData.Select(p => new { Region = p.region.name, CASES = p.confirmed, DEATHS = p.deaths });
            }
            else
            {
                _proc.RegionName = selectedRegion;
                var rawData = _proc.GetData().Where(p => !String.IsNullOrEmpty(p.region.province)).OrderByDescending(p => p.confirmed).Take(10).ToList();
                downloadData = rawData.Select(p => new { Province = p.region.province, CASES = p.confirmed, DEATHS = p.deaths });
            }

            return downloadData;

        }
        CovidDataSet GetData(string selecteRegion = null)
        {            
            var rawData = _proc.GetData();
            var top10Regions = rawData.Where(p => String.IsNullOrEmpty(p.region.province)).OrderByDescending(p => p.confirmed).Take(10).ToList();
            CovidDataSet ds = new CovidDataSet()
            {
                Regions = top10Regions.Select(p => p.region.name),
                SelectedRegion = Request.Form["SelectedRegion"],
                CovidCasesData = String.IsNullOrEmpty(selecteRegion) ? top10Regions :
                                                                     rawData.Where(p => p.region.name == selecteRegion && !String.IsNullOrEmpty(p.region.province)).OrderByDescending(p => p.confirmed).Take(10).ToList()
            };

            return ds;

        }
        // GET: CovidCasesData
        public ActionResult Index()
        {
            var ds = GetData(Request.Form["SelectedRegion"]);

            return View(ds);
        }
        public string GetSerializedStr(string format,IEnumerable<object> obj)
        {
            string data = "";
            switch (format.ToUpper())
            {
                case "JSON":
                    data = JArray.FromObject(obj).ToString();
                    break;
                case "XML":
                    data = JsonConvert.DeserializeXmlNode(JObject.FromObject(new { Data = obj }).ToString(),"XML").InnerXml;                    
                    break;
                case "CSV":
                    data = CsvHelper.ConvertToCsv(obj);
                    break;
                default:
                    break;
            }
            return data;
        }
        public ActionResult Download(string fileFormat, string selectedRegion)
        {
            var downloadData = GetDataToDownload(selectedRegion);
            string strData = GetSerializedStr(fileFormat, downloadData);

            return File(System.Text.Encoding.UTF8.GetBytes(strData), "text/plain", $"CovidData.{fileFormat.ToLower()}");
        }
        // GET: CovidCasesData/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CovidCasesData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CovidCasesData/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CovidCasesData/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CovidCasesData/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CovidCasesData/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CovidCasesData/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
    
}