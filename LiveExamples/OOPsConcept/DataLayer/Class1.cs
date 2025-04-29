namespace DataLayer
{
    public class CrudOperation
    {
        public void Ctreate()
        {

        }
        protected void Select()
        {

        }
        protected void Update()
        {

        }

        private void Delete()
        {

        }

    }

    public class SqlCrudOperation : CrudOperation
    {
        public void Test()
        {
            Ctreate();
            Select();
            Update();
            //Delete();

        }
    }
}
