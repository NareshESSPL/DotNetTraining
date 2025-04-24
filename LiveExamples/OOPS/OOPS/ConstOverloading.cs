using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class BaseClass
    {
        public BaseClass(string input)
        {
        }
    }

    public class ChilClass : BaseClass
    {
        string AppVersion;
        string appName;
        string Isprod;
        //public ChilClass() //: base()
        //{
        //    Console.WriteLine("ChilClass() called");
        //    AppVersion = ReadFromConfig();
        //}

        public ChilClass(string appName, bool Isprod) : base(appName)
        {
            Console.WriteLine("ChilClass(string appName, bool Isprod) called");
            AppVersion = ReadFromConfig();
        }

        private string? ReadFromConfig()
        {
            return "1.0.0";
        }
    }

    public class TestConst
    {
        public void Test()
        {
            var child = new ChilClass("", false);
            var child1 = new ChilClass("test", false);
        }

    }
}
