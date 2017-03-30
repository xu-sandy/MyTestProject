using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using EM_Domain;
using EM_Finance.Extender;

namespace EM_Finance.Controllers
{
    public class HomeController : Controller
    {

        private readonly DomainHttpHelper helper = new DomainHttpHelper();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //概念
            var data = helper.EmGetData();
            data = data.TrimStart('(').TrimEnd(')');
            List<string> array = new List<string>();
            array = JsonHelper.JSONStringToList<string>(data);

            var nameArr = new List<string>();
            var keyValueArr = new List<vModel>();
            foreach (var item in array)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (item.Contains(","))
                    {
                        var sitem = item.Split(',');
                        if (sitem.Length >= 4)
                        {
                            nameArr.Add(sitem[2]);
                            keyValueArr.Add(new vModel() { name = sitem[2], value = Convert.ToDecimal(sitem[3]) });
                        }
                    }
                }
            }
            ViewBag.nameArr = ToJson(nameArr);
            ViewBag.keyValueArr = ToJson(keyValueArr);

            //行业
            var data1 = helper.EmGetIndustryData();
            data = data1.TrimStart('(').TrimEnd(')');
            List<string> array1 = new List<string>();
            array = JsonHelper.JSONStringToList<string>(data);

            var nameArr1 = new List<string>();
            var keyValueArr1 = new List<vModel>();
            foreach (var item in array)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (item.Contains(","))
                    {
                        var sitem = item.Split(',');
                        if (sitem.Length >= 4)
                        {
                            nameArr1.Add(sitem[2]);
                            keyValueArr1.Add(new vModel() { name = sitem[2], value = Convert.ToDecimal(sitem[3]) });
                        }
                    }
                }
            }
            ViewBag.nameArr1 = ToJson(nameArr1);
            ViewBag.keyValueArr1 = ToJson(keyValueArr1);
            //return Content(data);
            return View();
        }

        public class vModel
        {
            public decimal value { get; set; }
            public string name { get; set; }
        }

        public static object ToJson(object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }
    }
}
