using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class BaseDB
    {
        public void ConnectDB()
        {

        }
    }
    public class SqlDB
    {
        public void Insert()
        {
            try
            {
                int[] arr = new int[] { 1, 2, 3 };

                for (int i = 0; i < 9; i++)
                {
                    Console.WriteLine(arr[i]);
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);

               // throw;

                throw ex;

                //throw new Exception("DB error");
            }
        }
    }
    public class TestExec
    {
        public void TestDB()
        {
            try
            {
                SqlDB sqlDB = new SqlDB();
                sqlDB.Insert();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
