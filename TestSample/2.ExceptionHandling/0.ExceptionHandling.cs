namespace ExceptionHandling
{
    public class ExceptionHandling
    {
        /// <summary>
        /// Showing different ways to handle exception
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void TestException()
        {
            try
            {
                int[] ints = { 1, 2, 3 };

                for(int i =0; i<9; i++)
                    Console.WriteLine(ints[i]);
            }
            catch (Exception ex) 
            { 
            }


            try
            {

                int[] ints = { 1, 2, 3 };

                for (int i = 0; i < 9; i++)
                    Console.WriteLine(ints[i]);
            }
            catch
            {
            }


            try
            {
                throw new Exception("I want to raise an exception message");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            try
            {

                int[] ints = { 1, 2, 3 };

                for (int i = 0; i < 9; i++)
                    Console.WriteLine(ints[i]);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            /*throw will throw exception with stack trace*/
            try
            {

                int[] ints = { 1, 2, 3 };

                for (int i = 0; i < 9; i++)
                    Console.WriteLine(ints[i]);
            }
            catch (Exception ex)
            {
                throw;
            }


            /*Raising a custom exception after handling actual exception*/
            try
            {

                int[] ints = { 1, 2, 3 };

                for (int i = 0; i < 9; i++)
                    Console.WriteLine(ints[i]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception("Custom message");
            }
        }

    }
}
