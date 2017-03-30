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
    public class IndustryController : Controller
    {
        private readonly DomainHttpHelper helper = new DomainHttpHelper();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var data = helper.EmGetIndustryData();
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
            ViewBag.nameArr = new JavaScriptSerializer().Serialize(nameArr);
            ViewBag.keyValueArr = new JavaScriptSerializer().Serialize(keyValueArr);
            //return Content(data);
            return View();
        }

        public class vModel
        {
            public decimal value { get; set; }
            public string name { get; set; }
        }

    }
}
