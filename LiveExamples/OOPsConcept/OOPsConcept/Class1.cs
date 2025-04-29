namespace OOPsConcept
{
    //base class
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
            return "The App Name is : " + AppName;
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
    //child class
    public class Auth : BaseClass
    {
       public bool SignIn()
        {
            Validate();
           // VersionCheck(); 
            return true;
        }
        public void WriteAppName()
        {
            Console.
                WriteLine(PrintAppName());
        }
        public bool CheckConnectToDB()
        {
            ConnectToDB();
            return true;
        }
        public bool CheckConnectToSql()
        {
            ConnectToSql();
            return true;
        }
        //public bool CheckTest()
        //{
        //    Test();
        //    return true;
        //}

    }

    public class TestAuth
    {
        public bool TestSignIn()
        {
            Auth auth = new Auth();
            auth.SignIn();
            //Altrenative method for calling methods suitable for .net8 and csharp 13+ version
            //Auth auth1 = new();
            //auth1.SignIn();
            return true;
        }
        //public bool testPrintApp()
        //{
        //    BaseClass baseClass = new BaseClass();
        //    baseClass.PrintAppName(); // this is showing error due to protected access specifier
        //    return false;
        //}
        public bool TestConnectToDB()
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ConnectToDB();
            return true;
        }
        public bool TestConnectToSql()
        {
            BaseClass baseClass = new BaseClass();
            baseClass.ConnectToSql();  
            return true;
        }
    }
}
