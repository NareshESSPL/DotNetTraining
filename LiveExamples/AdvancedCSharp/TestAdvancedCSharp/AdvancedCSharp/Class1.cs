namespace AdvancedCSharp
{
    //public static class StudentManager
    //{
    //    //public string StudentName { get; set; }

    //    //public int StudentId { get; set; }

    //    //public StudentManager() { }

    //    //public bool IsPresent()
    //    //{
    //    //    return true;
    //    //}

    //    /*Sample Extension Method*/
    //    public static string GetFirstname(this string FullName)
    //    {
    //        return FullName.Substring(0, FullName.LastIndexOf(" "));
    //    }

    //}

    public class StudentManager
    {
        public string StudentName { get; set; }

        public int StudentId { get; set; }

        public StudentManager() { }

        public bool IsPresent()
        {
            return true;
        }
    }

    public static class Util
    {
        public  static string GetFName(this string Name)
        {
            return Name.Substring(0, Name.LastIndexOf(" "));
        }
    }

    public class TesExtension
    {

        public void Test()
        {
            var fullName = "Naresh Pardhan";

            var fname1 = Util.GetFName(fullName);


            var fname2 = fullName.GetFName();
            //var firstName = StudentManager.GetFirstname(fullName);

            //var fname = fullName.GetFirstname();
            int x = 9;

            //Console.WriteLine(firstName);

        }
    }


}
