using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_c_.Generic_with_delegates
{
    public delegate T Sorting<T>(T input);
    public class SortArr
    {
        Sorting<int[]>? sort;

        public SortArr(Sorting<int[]>? sort)
        {
            this.sort = sort;
        }
        public void SortMethod()
        {
            int[] num = new int[] { 5, 9, 8, 1, 3, 7 };
            num = sort(num);
            for (int i = 0; i < num.Length; i++)
            {
                Console.WriteLine(num[i]);
            }

        }
    }
    public class TestingSort
    {
        public void test()
        {
            Sorting<int[]> sort = new Sorting<int[]>(sortMethod);


            SortArr sortArr = new SortArr(sort);
            sortArr.SortMethod();


        }
        public int[] sortMethod(int[] num)
        {
            for (int i = 0; i < num.Length; i++)
            {
                for (int j = 0; j < num.Length - i - 1; j++)
                {
                    if (num[j] > num[j + 1])
                    {
                        int temp = num[j];
                        num[j] = num[j + 1];
                        num[j + 1] = temp;
                    }
                }
            }
            return num;
        }
    }
}
