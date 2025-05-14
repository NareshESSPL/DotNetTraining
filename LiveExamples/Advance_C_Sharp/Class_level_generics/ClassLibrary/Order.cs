namespace ClassLibrary
{
    //Model-class 1
    public abstract class Document {  }
    public class Order : Document
    {
        public int OrderId{ get; set; }
        public string ProductName { get; set; }
    }
    

}
