namespace AdavncedCSharp
{
    //https://www.geeksforgeeks.org/c-sharp-generics-introduction/
    /*
     * By using generics, we can write code that is more flexible and less prone to errors.
     * 
     * {Reusability}
     * For example, instead of writing a separate method for each data type, 
     * we can write a single method that can work with different types of data.
     * 
     * {Type safety}
     * The main benefit of using generics is that it provides type safety. 
     * When we define a generic class, interface or method, 
     * we can specify the type parameter that it can work with. 
     * This ensures that the code will only accept 
     * and operate on data types that match the specified type parameter, 
     * preventing errors that can occur due to data type mismatches.
     * 
     * {Performance}
     * Generic types provide better performance as compared to normal system types 
     * because they reduce the need for boxing, unboxing, and typecasting of variables or objects.
     * 
     * {BuiltIn Generics}
     * as it is possible to write a generic class or method that can work with any data type, instead of writing multiple methods or classes for different data types.
     * C# provides a number of built-in generic types, such as List<T>, Dictionary<TKey, TValue>, and Nullable<T>. We can also create our own generic classes, interfaces, and methods by using the syntax <T>, where T is the type parameter that can be replaced with any valid data type.
    */
    public class BasicGeneric<T>
    {
        // private data members
        private T data;

        // using properties
        public T value
        {
            // using accessors
            get => data;
            set => data = value;
        }

    }

    public class BasicGenericTest
    {
        public void Test()
        {
            // instance of string type
            BasicGeneric<string> name = new BasicGeneric<string>();
            name.value = "GeeksforGeeks";

            // instance of float type
            BasicGeneric<float> version = new BasicGeneric<float>();
            version.value = 5.0F;

            Console.WriteLine(name.value);

            Console.WriteLine(version.value);
        }
    }

    public class GenericWithMethod
    {
        //Method can be static or non-static
        public static T ConvertValue<T, U>(U value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }

    public class GenericWithMethodTest
    {
        public void Test()
        {
            string convertedValue = GenericWithMethod.ConvertValue<string, int>(10);

            Console.WriteLine(convertedValue);
        }
    }

}
