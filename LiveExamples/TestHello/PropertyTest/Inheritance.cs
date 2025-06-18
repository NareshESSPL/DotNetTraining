using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyTest
{
    public class BaseClass
    {
        public string AppVersion;

        public BaseClass()
        {
            AppVersion = ReadAppVersionFromConfig();
        }

        //read the config in runtime
        private string ReadAppVersionFromConfig()
        {
            return "2.1.1";
        }

        public void Test()
        {
            AppVersion = "1111";
        }
    }
}
