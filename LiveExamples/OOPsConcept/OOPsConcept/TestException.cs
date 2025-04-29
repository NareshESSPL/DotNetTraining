using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsConcept
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

        internal void CloseConnection()
        {
            throw new NotImplementedException();
        }
    }
    public class TestExecc
    {
        public void TestDB()
        {
            try
            {
                //throw new Exception();
                //SqlDB sqlDB = new SqlDB();
                //sqlDB.Insert();
                //var i = 0;
                //var d = i / 0;
                int[] arr = new int[] { 1, 2, 3, };
                arr[4] = 4;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("divide by zero exception");
            }
            
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Stack over flow exception");
            }
            finally
            {
                //SqlDB sd = new SqlDB();
                //sd.CloseConnection();
                Console.WriteLine("finally called");
            }
        }
    }

    public class CustomException : Exception
    {
        
        public CustomException(string message)
            : base(message) 
        {
        }
    }

    public class UserValidation
    {
        
        public void Test(string firstName)
        {
            
            if (string.IsNullOrWhiteSpace(firstName))
            {
                
                throw new CustomException("First name is empty or contains only spaces.");
            }
            else
            {
                Console.WriteLine("First name is valid.");
            }
        }
    }


}
