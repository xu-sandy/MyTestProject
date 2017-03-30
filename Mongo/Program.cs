using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo
{
    class Program
    {
        static void Main(string[] args)
        {
            var content = Console.ReadLine();
            Console.WriteLine(EcanConvertToCh.convertCh(content));
            Console.ReadLine();
        }
    }
}
