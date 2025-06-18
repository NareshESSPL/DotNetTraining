using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    internal interface ICrudOps
    {
        public string AppName { get; set; }

        public void Insert();
    }

    public class SqlCRUDOps : ICrudOps
    {
        public string AppName { get; set; }

        public void Insert()
        {
            throw new NotImplementedException();
        }
    }


    public class NoSqlCRUDOps : ICrudOps
    {
        public string AppName { get; set; }

        public void Insert()
        {
            throw new NotImplementedException();
        }
    }

    public class OracleCRUDOps : ICrudOps
    {
        public string AppName { get; set; }

        public void Insert()
        {
            throw new NotImplementedException();
        }
    }

    public class TestInterface
    {
        private ICrudOps GetCrudOps(string DBName)
        {
            ICrudOps crudOps;

            if (DBName == "sql")
            {
                crudOps = new SqlCRUDOps();
            }
            else if (DBName == "oracle")
            {
                crudOps = new OracleCRUDOps();
            }
            else
            {
                crudOps = new NoSqlCRUDOps();
            }

            return crudOps;
        }

        public void Test()
        {
            ICrudOps crudOps = GetCrudOps("sql");

            crudOps.Insert();

        }
    }
}
