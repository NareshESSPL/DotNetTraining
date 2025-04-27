using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public class ErroMessageBuilder
    {
        /// <summary>
        /// Get All Inner Exception along with stack trace
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public string GetExceptionMessage(Exception ex)
        {
            if (ex == null) return string.Empty;

            StringBuilder exceptionDetails = new StringBuilder();
            exceptionDetails.AppendLine(string.Concat("  Exception: ", Environment.NewLine, GetAllExceptions(ex)));

            if (ex.InnerException != null)
            {
                exceptionDetails.AppendLine("Inner Exception(s):");
                exceptionDetails.AppendLine(GetExceptionMessage(ex.InnerException)); // Recursive call
            }

            return exceptionDetails.ToString();
        }


        /// <summary>
        /// Get all exception detail from exception object including inner exception 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="exception"></param>
        /// <returns>string</returns>
        public string GetAllExceptions(Exception exception)
        {
            var st = new StackTrace(exception, true);
            var frames = st.GetFrames();
            var traceString = new StringBuilder();

            foreach (var frame in frames)
            {
                if (frame.GetFileLineNumber() < 1)
                    continue;

                traceString.AppendLine(string.Concat("    Message: ", exception.Message));
                traceString.AppendLine(string.Concat("    File: ", frame.GetFileName()));
                traceString.AppendLine(string.Concat("    Method:", frame.GetMethod().Name));
                traceString.AppendLine(string.Concat("    LineNumber: ", frame.GetFileLineNumber()));
                traceString.AppendLine(string.Concat("/****************************************/"));
            }

            var mesaage = traceString.ToString();

            return mesaage;
        }

        /// <summary>
        /// Tester method to create error message
        /// </summary>
        /// <param name="input"></param>
        public void TestInnerException(int input)
        {
            try
            {
                try
                {
                    // Simulate an inner exception
                    int result = input / 0; // Causes DivideByZeroException
                }
                catch (DivideByZeroException innerEx)
                {
                    // Wrap inner exception in a new exception
                    throw new InvalidOperationException("A calculation error occurred.", innerEx);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = GetExceptionMessage(ex);

                Console.WriteLine(errorMessage);
            }
        }
    }
}
