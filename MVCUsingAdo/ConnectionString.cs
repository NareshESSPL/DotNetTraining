namespace MVCUsingAdo
{
    public static class ConnectionString
    {
        private static string cs = "Server = ESSPLLAP169\\SQL2019; Database = MVC;Integrated Security = SSPI; TrustServerCertificate = True";

        //since it is private to show it we create another public string
        public static string dbcs { get { return cs; } }

       

    }
}
