//https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
namespace AdavncedCSharp
{
    //Struct Constraint
    //The type argument must be a non-nullable value type, which includes record struct types
    public class GenericConstraintType<T> where T : struct
    {
        private readonly T type;
        public void Show()
        {
            Console.WriteLine(type.ToString());
        }
    }

    public struct GenericConstraintStruct
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }

    public class TestGenericConstraintType
    {
        public void Test()
        {
            var genericConstraintType = new GenericConstraintType<GenericConstraintStruct>();

            genericConstraintType.Show();

        }
    }
}
