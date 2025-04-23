namespace DataMover
{
    public class DataMover
    {
        public void Test()
        {
            MoveData("Customer", "CustomerSummary");
        }

        public bool MoveData(string SourceTable, string destinationTable)
        {
            bool isSucess = true;

            if (SourceTable != "" && destinationTable != "")
                isSucess = true;
            else
                isSucess = false;

            return isSucess;
        }

    }
}
