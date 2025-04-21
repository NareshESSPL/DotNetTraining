using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypes
{
    //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
    //https://www.geeksforgeeks.org/difference-between-boxing-and-unboxing-in-c-sharp/?ref=asr1
    public class DataTypeConversion
    {
        public void TestConversion()
        {
            #region Typecasting
            /*
             * In C#, there are two types of casting:

             * Implicit Casting (automatically) - converting a smaller type to a larger type size
             * char -> int -> long -> float -> double

             * Explicit Casting (manually) - converting a larger type to a smaller size type
             * double -> float -> long -> int -> char
            */
            //implicit
            int imInt = 9;
            double imDouble = imInt;

            //explicit
            double exDouble = 9.78;
            int exInt = (int)exDouble;

            #endregion

            #region Convert

            int coInt = 10;
            double coDouble = 5.25;
            bool coBool = true;

            var outputStr = Convert.ToString(coInt);    // convert int to string
            var outputDouble = Convert.ToDouble(coDouble);    // convert int to double
            var outputInt = Convert.ToInt32(coDouble);  // convert double to int
            var outputBoolToInt = Convert.ToString(coBool);   // convert bool to string

            #endregion

            #region Boxing & Unboxing
            /*
             * The process of converting a Value Type variable(char, int etc.)
             * to a Reference Type variable(object) is called Boxing.
             * Boxing is an implicit conversion process in which object type (super type) is used.
             * Value Type variables are always stored in Stack memory,
             * while Reference Type variables are stored in Heap memory.

             * Boxing - It convert value type into an object type.
             * Boxing is an implicit conversion process.
             * Here, the value stored on the stack copied to the 
             * object stored on the heap memory.
            */
            int beforeBox = 23;
            object afterBox = beforeBox;

            //Unboxing
            //It convert an object type into value type.
            //Unboxing is the explicit conversion process.
            //Here, the object stored on the heap memory copied to the value stored on the stack .
            object beforeUnBox = 100;
            int afterUnBox = beforeBox;

            #endregion

        }


    }
}
