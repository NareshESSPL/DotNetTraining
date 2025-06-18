namespace ValueTypes
{
    //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types
    //press ctrl + K + D for formatting the code
    public class DataTypes
    {
        public void SetDataType()
        {
            #region Non-numeric Types

            bool bType = false;
            bool BType = false;

            #endregion

            #region Integral Numeric Types

            //prefix s means signed i.e. positive numeric only
            //All integral numeric types are value types.

            //-128 to 127	Signed 8-bit integer    System.SByte
            sbyte sbyteType = -4;
            sbyte SByteType = 8;

            //0 to 255	Unsigned 8-bit integer	System.Byte
            byte byteType = 5;
            byte ByteType = 0;

            //-32,768 to 32,767	Signed 16-bit integer	System.Int16
            short shType = 9;
            short ShType = -10;

            //0 to 65,535	Unsigned 16-bit integer	System.UInt16
            ushort ushortType = 5;
            ushort UShortType = 100;

            //-2,147,483,648 to 2,147,483,647	Signed 32-bit integer	System.Int32
            int intType = 19;
            int IntType = 90;

            //0 to 4,294,967,295 Unsigned 32-bit integer	System.UInt32
            uint uintType = 19;
            uint UIntType = 90;

            //-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 Unsigned 32 -bit integer	System.UInt32
            long longType = 199999999;
            long LongType = 9999L;

            //Depends on platform (computed at runtime)	Signed 32-bit or 64-bit integer	System.Int
            nint nIntType = 19;
            nint NIntType = 10;

            //Depends on platform (computed at runtime)	Signed 32-bit or 64-bit integer	System.Int
            nuint unIntType = 19;
            nuint NuIntType = 10;

            #endregion

            #region Integer Literals
            /*Integer literals can be
              decimal: without any prefix
              hexadecimal: with the 0x or 0X prefix
              binary: with the 0b or 0B prefix
            */
            var decimalLiteral = 42;
            var hexLiteral = 0x2A;
            var binaryLiteral = 0b_0010_1010;

            #endregion

            #region Integral Types supported methods & properties

            var size = nint.Size;
            var minInt = int.MinValue;
            var maxInt = int.MaxValue;

            #endregion

            #region Floating-Point Types
            /*
             * The type of a real literal is determined by its suffix as follows:
             * The literal without suffix or with the d or D suffix is of type double
             * The literal with the f or F suffix is of type float
             * The literal with the m or M suffix is of type decimal
             * The default value of each floating-point type is zero, 0
             * The float and double types also provide constants that represent not-a-number and infinity values. 
             * For example, the double type provides the following constants: 
             * Double.NaN, Double.NegativeInfinity, and Double.PositiveInfinity.
             * 
             * The decimal type is appropriate when the required degree of precision 
             * is determined by the number of digits to the right of the decimal point.
            */

            //*Range* ±1.5 x 10−45 to ±3.4 x 1038  *Precision* ~6-9 digits *Size* 4 bytes .Net Type System.Single
            float fType = 3_000.5F;
            fType = 5.4f;

            double dType = 3D;
            dType = 4d;
            //The preceding example also shows the use of _ as a digit separator.
            //You can use the digit separator with all kinds of numeric literals.
            dType = 3.934_001;

            decimal decType = 1.5E6m;

            #endregion            

            #region Integral Types supported methods & properties

            var nan = Double.NaN;
            var negativeInfinity = Double.NegativeInfinity;
            var positiveInfinity = Double.PositiveInfinity;
            var minDouble = double.MinValue;
            var maxDouble = double.MaxValue;

            #endregion
        }


    }
}
