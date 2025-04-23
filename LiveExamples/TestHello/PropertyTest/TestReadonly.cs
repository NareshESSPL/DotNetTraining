using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyTest
{
    public class TestReadonly
    {
        //assigned to a variable during declaration and cannot be changed after that
        public const string AppName = "app";

        //assigned to a variable during declaration or inside a constructor
        //and cannot be changed after that
        public readonly string AppVersion;
        public readonly string AppMinorVersion = "1";

        //same as readonly
        public bool HasDeployed { get; } = false;

        public TestReadonly()
        {
            AppVersion = "1.0.0";
            HasDeployed  = true;
        }

        public void Change()
        {
            //AppName = "Appname";
            //AppVersion = "1.0.0";
            //AppMinorVersion = "0";
            //HasDeployed = true;
        }
    }
}
