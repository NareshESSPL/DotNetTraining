using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp
{
    //Base class
    public class Animal { }

    //child(derived) class
    public class Dog : Animal { }

    public interface ICovariant<out T>
    {
        public T ReturnObjectOfT();
    }

    public class Covariant<T> : ICovariant<T> where T : new()
    {
        public T ReturnObjectOfT()
        {
            return new T();
        }
    }

    public class TestCovariant
    {
        public void Test()
        {
            ICovariant<Dog> dogCovariant = new Covariant<Dog>();

            ICovariant<Animal> animalCovariant = dogCovariant; // Allowed due to covariance

            var objectOfT = animalCovariant.ReturnObjectOfT();

            Console.WriteLine(objectOfT.GetType().ToString());

        }
    }

}
