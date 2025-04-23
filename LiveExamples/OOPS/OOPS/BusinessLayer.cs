namespace Businesslayer
{
    public class BaseClass
    {
        public const string AppName = "ERP";

        public readonly string AppVersion;

        public BaseClass()
        {
            AppVersion = "1.0.0";
        }

        public bool Validate()
        {
            return true;
        }

        private bool VersionCheck()
        {
            return true;
        }

        protected string PrintAppName()
        {
            return "The appname is : " + AppName;
        }

        internal void ConnectToDB()
        {

        }

        protected internal void ConnectToSql()
        {

        }

        void Test()
        {

        }
    }


    public class Auth : BaseClass
    {
        public bool SignIn()
        {
            Validate();

            //VersionCheck();

            ConnectToDB();

            return true;
        }

        public void WriteAppName()
        {
           Console.WriteLine(PrintAppName());
        }
    }

    public class TestAuth
    {
        public bool TestSignIn()
        {
            Auth auth = new Auth();
            auth.SignIn();

            var auth1 = new Auth();
            auth.SignIn();

            Auth auth2 = new();
            auth.SignIn();

            return true;
        }

        //public bool TestPrintName()
        //{
        //    BaseClass baseClass = new BaseClass();
        //    baseClass.PrintAppName();
        //}

        public bool TesConnectDB()
        {
            BaseClass obj= null;
            obj.ConnectToDB();


            obj = new BaseClass();
            obj.ConnectToDB();

            return true;
        }

        //public bool TesConnectSql()
        //{
        //    BaseClass baseClass = new BaseClass();
        //    baseClass.ConnectToSql();

        //    return true;
        //}

    }
}
