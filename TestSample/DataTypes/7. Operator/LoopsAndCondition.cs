using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class LoopsAndCondition
    {
        /// <summary>
        /// 
        /// </summary>
        public void TestForLoop()
        {
            //assign check increment
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            //Break will break the loop
            for (int i = 0; i < 10; i++)
            {
                if (i == 6)
                    break;
            }

            //Continue will skip rest of the code and
            //will go to next iteration in loop[
            for (int i = 0; i < 10; i++)
            {
                if (i == 7)
                    continue;

                //This will be skipped if i == 7
                Console.WriteLine(i);
            }
        }

        public void TestWhileLoop()
        {
            int i = 0;
            while(i < 100)
            {
                Console.WriteLine(i);
                i = i+ 1;
            }

            //do while will execute atleast once even if the condition fails
            var j = 0;
            do
            {
                //The while condition will fail as j = 0 
                //still statements inside do will be excuted and loop will end
                Console.WriteLine(i); //will print 0
                j = j + 1;
            }
            while (j < 0);

        }

        public void TestForEachLoop()
        {
            List<int> list = new List<int>();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            foreach(var i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}
