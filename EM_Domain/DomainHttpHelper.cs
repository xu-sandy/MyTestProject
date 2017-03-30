using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM_Domain
{
    public class DomainHttpHelper : DomainBase
    {
        /// <summary>
        /// 概念
        /// </summary>
        /// <returns></returns>
        public string EmGetData()
        {
            Url = @"http://nufm.dfcfw.com/EM_Finance2014NumericApplication/JS.aspx?type=CT&cmd=C._BKGN&sty=DCFFPBFM&st=(BalFlowMain)&sr=-1&ps=10000&token=894050c76af8597a853f5b408b759f5d";
            return GetHtml(Url, null, Encoding.UTF8);
        }
        /// <summary>
        /// 行业
        /// </summary>
        /// <returns></returns>
        public string EmGetIndustryData()
        {
            Url = @"http://nufm.dfcfw.com/EM_Finance2014NumericApplication/JS.aspx?type=CT&cmd=C._BKHY&sty=DCFFPBFM&st=(BalFlowMain)&sr=-1&ps=999&token=894050c76af8597a853f5b408b759f5d";
            return GetHtml(Url, null, Encoding.UTF8);
        }
    }
}
