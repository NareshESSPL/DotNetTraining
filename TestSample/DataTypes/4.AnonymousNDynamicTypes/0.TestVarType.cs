using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    internal class VarType
    {
        public void TestVarType()
        {
            var people = new[]
            {
                new { Name = "Alice", Age = 25 },
                new { Name = "Bob", Age = 30 },
                new { Name = "Charlie", Age = 35 }
            };

            var y = 1;

            var m = "testing";

            // Select names only
            var names = people.Select(p => new { p.Name });

            foreach (var name in names)
            {
                Console.WriteLine(name.Name);
            }

        }
    }
}
