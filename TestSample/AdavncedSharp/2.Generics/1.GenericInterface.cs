namespace AdavncedCSharp
{
    public interface IGenericType<T>
    {
        public T Range { get; set; }

        public T Print(T input1, T input2);
    }

    public class GenericClass<T> : IGenericType<T>
    {
        public T Range { get; set; }

        public T Print(T input1, T input2)
        {
            Console.WriteLine(input1.ToString() + " " + input2.ToString());

            return input1;
        }
    }
}
