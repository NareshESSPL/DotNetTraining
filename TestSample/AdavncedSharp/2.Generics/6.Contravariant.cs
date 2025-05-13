using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdavncedCSharp
{
    //Base class
    public class Vehicle { }

    //child(derived) class
    public class Car : Vehicle { }

    public interface IContravariant<in T>
    {
        public void Display();
    }

    public class Contravariant<T> : IContravariant<T>
    {
        public void Display()
        {
            Console.WriteLine("Calling contravariant class");
        }
    }

    public class TestContravariant
    {
        public void Test()
        {
            ICovariant<Vehicle> dogCovariant = new Covariant<Car>();

            ICovariant<Vehicle> animalCovariant = dogCovariant; // Allowed due to covariance

            var objectOfT = animalCovariant.ReturnObjectOfT();

            Console.WriteLine(objectOfT.GetType().ToString());

        }
    }


    #region delegate example

    public delegate void Printer<in T>(T input); // `in` allows contravariance.
    internal class Covariant
    {

        void PrintObject(object obj)
        {
            Console.WriteLine(obj.ToString());
        }

        public void Test()
        {
            Printer<string> stringPrinter = PrintObject; // This works because of `in`.
            stringPrinter("Hello, Contravariance!");
        }

    }

    #endregion
}
