namespace PropertyTest
{
    public class TestProperty
    {
        private string FullName;

        public string GetFullName()
        {
            return FullName;
        }

        public void SetFullName(string fullName)
        {
            if (fullName == "111")
                FullName = "";
            else
                FullName = fullName;
        }

        public string FirstName { get; set; }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value == "111")
                    _lastName = "";
                else
                    _lastName = value;

            }
        }

        public void test()
        {
            LastName = "";
            var x = LastName;
        }

    }
}
